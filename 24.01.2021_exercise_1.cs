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


        static void PrintToScreen(int number)
        {
            Console.WriteLine($"Curent number = {number}");
        }

        static void PrintToScreenNumberx2(int number)
        {
            Console.WriteLine($"Curent number*2 = {number*2}");
        }

        private static Action<int> invocationMethodsList;

        private static void RunFrom1to10(int number)
        {
            Console.WriteLine(number);
            Thread.Sleep(1000);

            if (invocationMethodsList != null)
            {
                invocationMethodsList.Invoke(number); 
            }

        }

        static void Main(string[] args)
        {

            invocationMethodsList += PrintToScreen;
            invocationMethodsList += PrintToScreenNumberx2;
            RunFrom1to10(6);

            invocationMethodsList -= PrintToScreenNumberx2;
            RunFrom1to10(8);

        }
    }
}

