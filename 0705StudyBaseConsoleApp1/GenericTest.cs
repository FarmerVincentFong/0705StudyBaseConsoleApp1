using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    //测试泛型
    public class GenericTest
    {
        public static void TestRun()
        {
            Console.WriteLine(GCompare<int>.CompareGeneric(3, 5));
            Console.WriteLine(GCompare<string>.CompareGeneric("bbb", "aaa"));
            //计算泛型集合的性能
            Stopwatch sw = new Stopwatch();
            //非泛型集合（数组）
            ArrayList al = new ArrayList();
            //泛型集合（数组）
            List<double> gl = new List<double>();
            //开始计时
            sw.Start();
            for (var i = 0; i < 10000000; i++)
            {
                //al.Add(i * 0.9);  //非泛型
                gl.Add(i * 0.9);  //泛型
            }
            // 结束计时
            sw.Stop();
            // 输出所用的时间
            TimeSpan ts = sw.Elapsed;
            string elapsedTime = string.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("运行的时间： " + elapsedTime);
            Console.ReadKey();
        }

        public class GCompare<T> where T : IComparable
        {
            //返回大的
            public static T CompareGeneric(T t1, T t2)
            {
                if (t1.CompareTo(t2) > 0)
                {
                    return t1;
                }
                else
                {
                    return t2;
                }
            }
        }
    }
}
