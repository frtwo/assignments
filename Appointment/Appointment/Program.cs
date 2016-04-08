using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment
{
    class Program
    {
        static void Main(string[] args)
        {
            Doctor d1 = new Doctor() { Name = "Bert" };
            Doctor d2 = new Doctor() { Name = "Ernie" };
            Doctor d3 = new Doctor() { Name = "Cookie Monster" };
            Doctor d4 = new Doctor() { Name = "The Count" };
            Doctor d5 = new Doctor() { Name = "Big Bird" };

            Patient p1 = new Patient() { Name = "Mary", Address = "123 Sesame Street, New York, NY 12345" };
            Patient p2 = new Patient() { Name = "Jane", Address = "123 Sesame Street, New York, MN 12345" };
            Patient p3 = new Patient() { Name = "Jerry", Address = "321 Rockedge Street, San Francisco, FL 54321" };
            Patient p4 = new Patient() { Name = "Jacob", Address = "322 Rockedge Street, San Francisco, OR 54321" };
            Patient p5 = new Patient() { Name = "Alisha", Address = "123 Sesame Street, New York, AL 12345" };
            Patient p6 = new Patient() { Name = "Walker", Address = "329 Rockedge Street, San Francisco, DC 54321" };
            Patient p7 = new Patient() { Name = "Akira", Address = "123 Sesame Street, New York, MT 12345" };
            Patient p8 = new Patient() { Name = "Ray", Address = "345 Rockedge Street, San Francisco, WI 54321" };
            Patient p9 = new Patient() { Name = "Han", Address = "123 Sesame Street, New York, ME 12345" };
            Patient p0 = new Patient() { Name = "Ali", Address = "6234 Rockedge Street, San Francisco, OR 54321" };

            AppointmentService ap = new AppointmentService();

            ap.CreateAppointment(DateTime.Now, p1, d1);
            ap.CreateAppointment(new DateTime(2016, 03, 02), p2, d1);
            ap.CreateAppointment(new DateTime(2016, 11, 02), p3, d2);
            ap.CreateAppointment(new DateTime(2016, 03, 03), p4, d2);
            ap.CreateAppointment(new DateTime(2016, 08, 02), p5, d3);
            ap.CreateAppointment(new DateTime(2016, 03, 04), p6, d3);
            ap.CreateAppointment(new DateTime(2016, 12, 02), p7, d4);
            ap.CreateAppointment(new DateTime(2016, 03, 05), p8, d4);
            ap.CreateAppointment(new DateTime(2016, 07, 02), p9, d5);
            ap.CreateAppointment(new DateTime(2016, 03, 08), p0, d5);

            // check for doctor and patient names (first of each is successful, second should rerutn empty.)
            IEnumerable<Appointment> a1 = ap.SearchDoctorName("Ernie");
            IEnumerable<Appointment> a2 = ap.SearchDoctorName("Charlie");
            IEnumerable<Appointment> b1 = ap.SearchPatientName("Mary");
            IEnumerable<Appointment> b2 = ap.SearchPatientName("Clara");

            // check for appointments (first is true; second should return false)
            bool c1 = ap.CheckAppointments(d1, p2);
            bool c2 = ap.CheckAppointments(d3, p0);

            // print the appointments
            foreach (var item in ap.ShowAppointments())
            {
                Console.WriteLine("Appointment on " + item.Schedule.ToLongDateString() + " at " + item.Schedule.ToLocalTime() + ":");
                Console.WriteLine("Patient Name: " + item.Patient.Name);
                Console.WriteLine("Patient lives at: " + item.Patient.Address);
                Console.WriteLine("Doctor Name: " + item.Doctor.Name);
                Console.WriteLine(" --- ");
            }

            Console.ReadLine();
        }
    }

    public class Patient
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }

    public class Doctor
    {
        public string Name { get; set; }
    }

    public class Appointment
    {
        public DateTime Schedule { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }

    public class AppointmentService
    {
        private List<Appointment> Appointments { get; set; }

        public AppointmentService()
        {
            Appointments = new List<Appointment>();
        }

        public IEnumerable<Appointment> SearchDoctorName(string name = "")
        {
            if (name != "")
            {
                return (Appointments.Where(a => a.Doctor.Name == name));
            }
            return null;
        }

        public IEnumerable<Appointment> SearchPatientName(string name = "")
        {
            if (name != "")
            {
                return (Appointments.Where(a => a.Patient.Name == name));
            }

            return null;
        }

        public bool CreateAppointment(DateTime time, Patient patient = null, Doctor doctor = null)
        {
            if ((patient != null) && (doctor != null))
            {
                Appointments.Add(new Appointment() {
                    Doctor = doctor,
                    Patient = patient,
                    Schedule = time
                });
                return true;
            }

            return false;
        }

        public bool CheckAppointments(Doctor d = null, Patient p = null)
        {
            if (d == null || p == null) return false;

            IEnumerable<Appointment> a = Appointments.Where(n => (n.Doctor == d && n.Patient == p));
            if (a.Count() < 1) return false;

            return true;
        }

        public List<Appointment> ShowAppointments()
        {
            return Appointments;
        }
    }
}
