using System;
using System.Threading;
using static System.Console;

/// <summary>
///    Thread_T1(), Thread_T2()를 생성해서 
///    Program 메소드에서 스레드 실행
/// </summary>
namespace ThreadController
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pro = new Program();
        }

        /// <summary>
        ///    Program 메소드에서 스레드 실행부분
        ///    <example>
        ///       <code>
        ///         new Thread(new ThreadStart(Thread_T1)).Start();
        ///         new Thread(new ThreadStart(Thread_T2)).Start();
        ///       </code>
        ///    </example>
        /// </summary>
        public Program()
        {
            new Thread(new ThreadStart(Thread_T1)).Start();
            new Thread(new ThreadStart(Thread_T2)).Start();
        }

        public void Thread_T1()
        {
            int i = 0;
            while (true)
            {
                WriteLine("Thread_T1 i = {0}", i++);
                Thread.Sleep(1000);
            }
        }

        public void Thread_T2()
        {
            int j = 0;
            while (true)
            {
                WriteLine("Thread_T2 j = {0}", j++);
                Thread.Sleep(2500);
            }
        }

    }
}
