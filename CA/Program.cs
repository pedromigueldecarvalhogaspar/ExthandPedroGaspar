using System;
using System.Timers;
using System.IO;
using System.Net;
using Timer = System.Timers.Timer;
using System.Threading.Tasks;

namespace CA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Run.MinMax();

            Timer timer = new Timer(10000);
            timer.AutoReset = true;
            timer.Elapsed += new ElapsedEventHandler(Get);
            timer.Start();           
            Console.Read();
        }
        public static void Get(object sender, ElapsedEventArgs e)
        {
            Run.MinMax();
        }

    }
}

