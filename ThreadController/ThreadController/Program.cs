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
        String Commander;
        Thread _thread;
        Thread _thread2;
        public Program()
        {
            _thread = new Thread(new ThreadStart(Thread_T1));
            _thread.Start();
            _thread2 = new Thread(new ThreadStart(Thread_T2));
            _thread2.Start();
            while (true)
            {
                //입력 커맨더를 기다린다.
                Commander = Console.ReadLine();
                if (Commander == "exit")
                {
                    //스레드를 종료한다.
                    _thread.Abort();
                    break;
                }
            }
            WriteLine("");
        }
        //쓰레드 실행 함수
        public void Thread_T1()
        {
            int i = 0;
            //무한 반복문
            while (true)
            {
                WriteLine("Thread_T1 j = {0}", i++);
                //1초 단위로 루프가 돈다.
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
