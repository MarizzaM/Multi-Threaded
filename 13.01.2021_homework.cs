using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegetesLessson1
{
    class Program
    {
        // create a signature (delegate) D1 that retruns void and accepts 2 string parameters
        public delegate void Signature_D1(string s1, string s2);

        public delegate double Signature_D2(double f1, double f2);

        static void F1(string s1, string s2)
        {
            s1 = "hello";
            s2 = "world";
            Console.WriteLine($"{s1.ToUpper()}  {s2.ToUpper()}");
        }

        static void F2(Signature_D1 f, string s1, string s2)
        {
            f(s1,s2);
        }

        public static string ReversString(string str)
        {
            char[] arr = str.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        static double F3(double f1, double f2)
        {
            return f1 + f2;
        }

        static void F4(Signature_D2 f, double f1, double f2)
        {
            f(f1,f2);
        }

        static void Main(string[] args)
        {
            F2(F1, "Hello", "World");

            // from main call F2 and send it lambda expression which does the same as F1 but with lower case
            F2((s1, s2) => Console.WriteLine($"{s1.ToLower()}  {s2.ToLower()}"), "Hello", "World");

            // from main call F2 and send it lambda expression which print the two strings in reverse
            F2((s1, s2) => Console.WriteLine($"{ReversString(s2)} {ReversString(s1)}"), "Hello", "World");

            // create a signature (delegate) D2 that retruns float and accepts 2 floats parameters
            // create a function F3 that retruns float and accepts 2 floats parameters -- in this function
            //  RETURN the sum of both numbers
            // create a function F4 that gets a method with type D2 and two floats and invokes the function with the 2 floats
            // from main Console.Writeline the result of F4 and send it F3 as parameter, -4.555f, 19.4545
            F4(F3, -4.555f, 19.4545f);
            // from main Console.Writeline the result of F4 and send it lambda expression which perform minus 20.38 5.25
            F4((f1, f2) => f1 - f2, 20.38f, 5.25f);
            // from main Console.Writeline the result of F4 and send it lambda expression which perform multiply 14.4 60.27
            F4((f1, f2) => f1 * f2, 20.38f, 5.25f);
            // from main Console.Writeline the result of F4 and send it lambda expression which perform div, 
            //       but first check if not divide by zero 54.24 75.06 (+ also: 54.24, 0)
            F4((f1, f2) => f2 != 0 ? f1 / f2 : 0, 54.24f, 75.06f);
            // from main Console.Writeline the result of F4 and send it lambda expression which perform pow 43 91.26
            F4((f1, f2) => Math.Pow(f1,f2), 54.24, 75.06f);
            // from main Console.Writeline the result of F4 and send it lambda expression which returns the bigger 45.71 31.19
            F4((f1, f2) => f1 > f2 ? f1 : f2, 45.71f, 31.19f);
            // from main Console.Writeline the result of F4 and send it lambda expression which returns the smaller 54.24 75.06
            F4((f1, f2) => f1 < f2 ? f1 : f2, 54.2f, 75.06f);

        }
    }
}
