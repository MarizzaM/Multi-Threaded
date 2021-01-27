using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcEvent
{
    class Program
    {
        //        Winform or Console
        //Calculator:

        //Add
        //Subtract
        //Div
        //Multiply
        //HandleDivideByZero ==> print "cannot divide by zero"
        //ResultLargerThan 1,000,000


        //Event FirePlus
        //Event FireMinus
        //Event FireDiv
        //Event FireMul
        //Event DivideByZero
        //Event DisplayOverload == cannpt print result or print "E"

        //FirePlus += Add
        //...

        //get 2 numbers from user
        //get operation
        public class CalcEventArgs : EventArgs
        {
            public double number1 { get; set; }
            public double number2 { get; set; }
        }

        //methods 
        static void Add(object sender, CalcEventArgs e)
        {
            Console.WriteLine($" {e.number1} {sender} {e.number2} = {e.number1+ e.number2} ");
        }
        static void Subtract(object sender, CalcEventArgs e)
        {
            Console.WriteLine($" {e.number1} {sender} {e.number2} = {e.number1 - e.number2} ");
        }
        static void Div(object sender, CalcEventArgs e)
        {
            Console.WriteLine($" {e.number1} {sender} {e.number2} = {e.number1 / e.number2} ");
        }
        static void Multiply(object sender, CalcEventArgs e)
        {
            Console.WriteLine($" {e.number1} {sender} {e.number2} = {e.number1 * e.number2} ");
        }
        static void HandleDivideByZero(object sender, CalcEventArgs e)
        {
            Console.WriteLine($" {e.number1} {sender} {e.number2} : Cannot divide by zero! ");
        }
        static void ResultLargerThan1M(object sender, CalcEventArgs e)
        {
            Console.WriteLine($" {sender} : cannpt print result ");
        }

        private static event EventHandler<CalcEventArgs> invocationMethodsList;

        private static void FirePlus(double number1, double number2)
        {
            if (invocationMethodsList != null)
            {
                invocationMethodsList("+",  new CalcEventArgs { number1 = number1, number2 =number2 });
            }
        }
        private static void FireMinus(double number1, double number2)
        {
            if (invocationMethodsList != null)
            {
                invocationMethodsList("-", new CalcEventArgs { number1 = number1, number2 = number2 });
            }
        }
        private static void FireDiv(double number1, double number2)
        {
            if (invocationMethodsList != null)
            {
                invocationMethodsList("/", new CalcEventArgs { number1 = number1, number2 = number2 });
            }
        }
        private static void FireMul(double number1, double number2)
        {
            if (invocationMethodsList != null)
            {
                invocationMethodsList("*", new CalcEventArgs { number1 = number1, number2 = number2 });
            }
        }
        private static void DivideByZero(double number1, double number2)
        {
            if (invocationMethodsList != null)
            {
                invocationMethodsList("/", new CalcEventArgs { number1 = number1, number2 = number2 });
            }
        }

        private static void DisplayOverload(double number1, double number2)
        {
            if (invocationMethodsList != null)
            {
                invocationMethodsList("E", new CalcEventArgs { number1 = number1, number2 = number2 });
            }
        }

        static void Main(string[] args)
        {
            Console.Write("Please enter number1: ");
            double num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please enter number2: ");
            double num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter ' + ' or ' - ' or ' * ' or ' / ' ");

            string s = Console.ReadLine();
            switch (s)
            {
                case "+":
                    if (num1 + num2 > 1000000)
                    {
                        invocationMethodsList += ResultLargerThan1M;
                        DisplayOverload(num1, num2);
                        break;
                    }
                    else
                    {
                        invocationMethodsList += Add;
                        FirePlus(num1, num2);
                        break;
                    }

                case "-":
                    if (num1 - num2 > 1000000)
                    {
                        invocationMethodsList += ResultLargerThan1M;
                        DisplayOverload(num1, num2);
                        break;
                    }
                    else
                    {
                        invocationMethodsList += Subtract;
                        FireMinus(num1, num2);
                        break;
                    }
                case "*":
                    if (num1 * num2 > 1000000)
                    {
                        invocationMethodsList += ResultLargerThan1M;
                        DisplayOverload(num1, num2);
                        break;
                    }
                    else
                    {
                        invocationMethodsList += Multiply;
                        FireMul(num1, num2);
                        break;
                    }
                case "/":
                    if (num2 != 0)
                    {
                        invocationMethodsList += Div;
                        FireDiv(num1, num2);
                        break;
                    }
                    else {
                        if (num1 / num2 > 1000000)
                        {
                            invocationMethodsList += ResultLargerThan1M;
                            DisplayOverload(num1, num2);
                            break;
                        }
                        else
                        {
                            invocationMethodsList += HandleDivideByZero;
                            DivideByZero(num1, num2);
                            break;
                        }
                    }
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
    }
}
