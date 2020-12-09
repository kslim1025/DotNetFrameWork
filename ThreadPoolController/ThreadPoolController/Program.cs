using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static System.Console;

///<summary>
///  쓰레드풀을 사용방법 검증
///  쓰레드는 따로 Abort를 통해서 종료를 해주지 않으면 지속적으로 실행중에 있지만 
///  쓰레드풀은 특정 공간에 여러개의 쓰레드를 실행해켰다가 Main이 끝남과 동시에 종결된다.
///  관리가 용이하고 좋음
///</summary>
namespace ThreadPoolController
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();

            WriteLine("Please press any key on ur keyboard");
            ReadKey();
        }

        /// <summary>
        ///     쓰레드풀 생성
        /// </summary>
        public Program()
        {
            WriteLine("Start ThreadPool");
            ThreadPool.QueueUserWorkItem(RunThreadPoolEx, null);
            WriteLine("End ThreadPool");
        }

        /// <summary>
        ///    i가 증가하면서 쓰레드의 움직임 파악가능
        /// </summary>
        /// <param name="state">현재 쓰레드의 실행 갯수를 i를 통해서 확인가능</param>
        private void RunThreadPoolEx(object state)
        {
            for (int i = 0; i < 10000; i++)
            {
                Thread.Sleep(100);
                WriteLine("RunThreadPoolEx - " + i);
            }
        }
    }
}
