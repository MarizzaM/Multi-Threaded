using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreaded_HW
{
    class Program
    {
        static int[] numbers = new int[1000];
        static int[] numbers1 = new int[1000000];
        static void Main(string[] args)
        {

            /* ===task1===
            To use a modern processor's computing power effectively, it is very important to be able to compose program in a way
            that it can use more than one computing core, which leads to organizing it as several thread communicating 
            and synchronizing with each other.
            */

            /* ===task2===
            A thread - execution path of a program. Each thread defines a unique flow of control

            A Process is an execution of a program. It is considered as an active entity 
            and realizes the actions specified in a program
            */

            /* ===task3===
            Process ends after the completion of the task
            */

            /* ===task4===
            A context switch is the computing process of saving and restoring the state(context) of a CPU
            such that multiple processes can share a single CPU resource.

            A context switch occurs when  transfers control of the CPU from an executing process to another
            that is ready to run.
            */

            /* ===task5===
            Foreground threads keep an application alive as long as they are running, while background threads do not.
            when you close applications, all background threads are automatically terminated

            Background threads are useful for any operation that should continue as long as an application is running
            but should not prevent the application from terminating

                  var th = new Thread(ExecuteInForeground);
                  th.IsBackground = true;
            */

            /* ===task6===
            The Unstarted State − It is the situation when the instance of the thread is created
            but the Start method is not called.

            The Ready State − It is the situation when the thread is ready to run and waiting CPU cycle.

            The Not Runnable State − A thread is not executable, when

            Sleep method has been called
            Wait method has been called
            Blocked by I/O operations
            The Dead State − It is the situation when the thread completes execution or is aborted.
            */

            /* ===task7===
            Start is initializes a new instance of the Thread class.
            Abort is begin the process of terminating the thread. 
            Join is blocks the calling thread until a thread terminates
            Yield is causes the calling thread to yield execution to another thread that is ready
            to run on the current processor. 
             */

            /* ===task8===
            16
             */

            /* ===task9===
            ManagedThreadId  gets a unique identifier for the current managed thread.
            */

            /* ===task10===
            To display the Threads window in break mode or run mode
            While Visual Studio is in debug mode, select the Debug menu, point to Windows, and then select Threads.

            In the left gutter, right-click a thread marker icon Thread Marker, point to Switch to, and then click the name 
            of that thread to which you want to switch. 
            The shortcut menu shows only the threads at that specific location.

            In the Threads window, right-click any thread and then select Freeze. ...
            Select Columns in the Threads window toolbar, and then select Suspended Count to display 
            the Suspended Count column. ...
            Right-click the frozen thread and select Thaw.
             */

            /* ===task11===
            ThreadStart enables you to start a thread and pass no arguments to the target method.
            For parameterless target methods, this type is ideal.

            ParameterizedThreadStart gives you the ability to pass an argument of any type to a specific method on a thread.
            We can process many different data values on different threads.

            ParameterizedThreadStart(for void methods with one Object type parameter)
            */
            //===============================================//
            Random randomGenerator = new Random();
            int n1 = 1, n2 = 1, mul = 0;

            while (mul != n1 * n2) {
                n1 = randomGenerator.Next(1, 9);
                n2 = randomGenerator.Next(1, 9);
                Console.WriteLine($"How much is  {n1} * {n2} = ?");
                Thread t1 = new Thread(timer);
                t1.Start();
                mul = Convert.ToInt32(Console.ReadLine());
                t1.Abort();
            };
            Console.WriteLine("You are Great!");
    
            //===============================================//
           
            ParameterizedThreadStart index = new ParameterizedThreadStart(Set100ItemsInArray);
            List<Thread> threadsTo1000 = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                var t = new Thread(index);
                threadsTo1000.Add(t);
            }

            long timeThredStart = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            for (int i = 0; i < threadsTo1000.Count; i++)
            {
                threadsTo1000[i].Start(i*100);
            }
            long timeThredEnd = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Console.WriteLine($"Time of thred: {timeThredEnd - timeThredStart} milliseconds ");
            long timeFuncStart = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Set1000ItemsInArray();
            long timeFuncEnd = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Console.WriteLine($"Time of function: {timeFuncEnd - timeFuncStart} milliseconds ");

            Console.WriteLine($"\nmillion-size array");

            ParameterizedThreadStart index1 = new ParameterizedThreadStart(Set100ItemsInArray1);
            List<Thread> threadsTo1000000 = new List<Thread>();
            for (int i = 0; i < 100; i++)
            {
                var t = new Thread(index1);
                threadsTo1000000.Add(t);
            }

           timeThredStart = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            for (int i = 0; i < threadsTo1000000.Count; i++)
            {
                threadsTo1000000[i].Start(i * 100);
            }
            timeThredEnd = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Console.WriteLine($"Time of thred: {timeThredEnd - timeThredStart} milliseconds ");

             timeFuncStart = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Set1000000ItemsInArray();
             timeFuncEnd = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            Console.WriteLine($"Time of function: {timeFuncEnd - timeFuncStart} milliseconds ");
            
        }

        static void timer()
        {
            for (int i = 5; i > 0; i--)
            {
                Console.WriteLine($"----{i}----");
                Thread.Sleep(1000);
            }
        }

        static void Set100ItemsInArray(object i) {
            for (int index = (int)i; index < ((int)i + 100); index++) {
                numbers[index] = 1;
            }
        }

        static void Set100ItemsInArray1(object i)
        {
            for (int index = (int)i; index < ((int)i + 100); index++)
            {
                numbers1[index] = 1;
            }
        }
        static void Set1000ItemsInArray()
        {
      
            for (int index = 0; index < 1000; index++)
            {
                numbers[index] = 1;
            }
        }

        static void Set1000000ItemsInArray()
        {

            for (int index = 0; index < 1000000; index++)
            {
                numbers1[index] = 1;
            }
        }
    }
}
