using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 匿名方法的测试
    /// </summary>
    public class DelegateFunctionTest
    {
        delegate void VoteDelegate(string name);

        public static void TestRun()
        {
            CTest1();
            //CTest2();
            CTest3();
            Console.ReadKey();
        }

        private static void CTest1()
        {
            //创建委托对象
            VoteDelegate vd1 = new VoteDelegate(delegate (string n)
            {
                Console.WriteLine($"{n} 投票给fwq");
            });
            VoteDelegate vd2 = delegate (string nn)
            {
                Console.WriteLine($"{nn} 投票给fff");
            };
            vd1("qqqq");
            vd2("aaa");
            Console.WriteLine("-----------------");
        }

        private static void CTest2()
        {
            System.Timers.Timer tm = new System.Timers.Timer();
            tm.Interval = 2000;
            tm.Elapsed += new ElapsedEventHandler(ecallb);
            tm.Elapsed += delegate { Console.WriteLine("匿名方法：" + DateTime.Now); };
            tm.Elapsed += (a,b) => { Console.WriteLine("Lambda表达式：" + DateTime.Now); };
            tm.Start();
            Console.ReadLine();
        }
        private static void ecallb(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine("普通方法：" + DateTime.Now);
        }
        private static void CTest3()
        {
            Thread t1 = new Thread(delegate () { Console.WriteLine("线程t1"); });
            Thread t2 = new Thread(delegate (object a) { Console.WriteLine("线程t2"); });
            t1.Start();
            t2.Start("aaa");
            Console.ReadLine();
        }
    } 
}
