using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delegates1
{
    class Program
    {

        // 3 create a delegate for function that returns int and get no parameter
        public delegate int D1();
        // 4 create a delefate for function that returns double and gets two dobules
        public delegate double D2(double d1, double d2);

        static void Foo()
        {

        }
        static void Foo2()
        {
            Console.WriteLine("hello");
        }
        static void FooWithObject(object o)
        {
            Console.WriteLine($"Hello with object {o}");
        }
        // 4.1 create a real function that gets 2 doubles and return double (which is sum of both parameters)
        static double sumOfDouble(double d1, double d2) {
            return d1 + d2;
        }
        // 5 create a function that gets as parameter the function type (delegate) you created in 4
        //   in this function invoke the method you created in 4.1. and print the result
        static void PrintInvokeResult(D2 f, double d1, double d2) {
            Console.WriteLine(f(d1,d2));        
        }
        static void Main(string[] args)
        {

            // 1 create a functions in delegate of ParameterizedThreadStart
            // 2 create the thread , in ctor pass the function you just created name 
            Thread t1 = new Thread(Foo);
            t1.Start();
            Thread t2 = new Thread(FooWithObject);
            t2.Start();
            Thread t3 = new Thread(Foo2);
            t3.Start();
        }
    }
}
