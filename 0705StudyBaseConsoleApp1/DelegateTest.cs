using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 委托
    /// </summary>
    public class DelegateTest
    {
        private delegate void MyAction1(int parm);
        public static void TestRun()
        {
            MyAction1 ma1;
            ma1 = m1;
            ma1 += m2;
            MyTest(10, new MyAction1(ma1));
            Console.ReadKey();
        }

        //委托做参数
        private static void MyTest(int n, MyAction1 act1)
        {
            //act1(n);
            act1.Invoke(n);
        }

        private static void m1(int num)
        {
            Console.WriteLine(num + num);
        }
        private static void m2(int num)
        {
            Console.WriteLine(num * num);
        }
    }
}
