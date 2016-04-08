using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemInfo
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("System Information ---------------------");
            System.Console.WriteLine("Machine name: " + Environment.MachineName);
            System.Console.WriteLine("OS Version: " + Environment.OSVersion);
            System.Console.WriteLine("Current User: " + Environment.UserName);
            System.Console.WriteLine("Number of Processors: " + Environment.ProcessorCount);
            System.Console.WriteLine("Network Domain: " + Environment.UserDomainName);

            System.Console.ReadLine();
        }
    }
}
