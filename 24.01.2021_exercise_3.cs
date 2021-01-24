using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDelegates
{
    class Program
    {
        //class
        public class DivEventArgs : EventArgs
        {
            public int number { get; set; }
        }

        //methods 
        static void PrintFizz(object sender, DivEventArgs e)
        {
            Console.WriteLine($"Fizz: {e.number} can be {sender} without reminder");
        }

        static void PrintBuzz(object sender, DivEventArgs e)
        {
            Console.WriteLine($"Buzz: {e.number} can be {sender} without reminder");
        }

        private static event EventHandler<DivEventArgs> invocationMethodsList;
        // events
        private static void dividedBy3(int number)
        {
            Thread.Sleep(1000);

            if (invocationMethodsList != null)
            {
                invocationMethodsList("divided by 3",
                    new DivEventArgs { number = number });
            }
        }
        private static void dividedBy5(int number)
        {
            Thread.Sleep(1000);

            if (invocationMethodsList != null)
            {
                invocationMethodsList("divided by 5",
                    new DivEventArgs { number = number });
            }
        }

        static void Main(string[] args)
        {
            for (int i = 1; i <= 20; i++) {
                invocationMethodsList = null;
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Console.WriteLine("Ups...");
                    //dividedBy3(i);
                    //dividedBy5(i);
                }
                else if(i % 3 == 0)
                {
                    invocationMethodsList += PrintFizz;
                    dividedBy3(i);
                }
                else if (i % 5 == 0)
                {
                    invocationMethodsList += PrintBuzz;
                    dividedBy5(i);
                }
                else {
                    Console.WriteLine(i);
                }  
            }
        }
    }
}
