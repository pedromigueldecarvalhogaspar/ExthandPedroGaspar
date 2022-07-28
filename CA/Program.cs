using System;
using System.IO;
using System.Net;
using Timer = System.Timers.Timer;

namespace CA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, before anything want to thank you for the oportunity to be in your recruitment process. As I said in the e-mail I would be pleased beyond words if I could be a part of your team. :)  \n\nThe info is taken by the candles, where I could reach the Max and Min values of the day. I could not find any Get that returned a list of trades\n\n");

            Run.Cena();
            Timer x = new Timer(10000);
            x.AutoReset = true;
            x.Elapsed += new System.Timers.ElapsedEventHandler(Get);
            x.Start();
            
            Console.Read();
        }
        public static void Get(object sender, System.Timers.ElapsedEventArgs e)
        {
            Run.Cena();
        }
    }
}

