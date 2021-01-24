using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threads1
{
    class Program
    {
        static void foo()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine($"----{i}----");
                Thread.Sleep(100);
            }
        }
        static void Main(string[] args)
        {
            var ct = Thread.CurrentThread;

            for (int i = 3; i >= 0; i--)
            {
                Console.WriteLine($"Main Thread {i}");

                Thread t1 = new Thread(foo);
              t1.Start();
               Console.WriteLine();
            
                Thread.Sleep(1000);
            }
            Console.WriteLine("Boom");
        }
    }
}
