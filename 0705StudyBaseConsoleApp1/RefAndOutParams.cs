using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 测试值类型和引用类型
    /// 测试高级参数
    /// </summary>
    public class RefAndOutParams
    {
        /// <summary>
        /// 测试ref和out等高级参数 
        /// </summary>
        public static void TestRun2()
        {
            int a1 = 30;
            fun1(out a1);
            Console.WriteLine(a1);
            int[] arr1 = { 1, 2 };
            fun2(ref arr1);
            foreach (var i in arr1) Console.WriteLine(i);
            int b1=40;
            fun3(ref b1);
            Console.WriteLine(b1);
            Console.ReadKey();
        }

        private static void fun1(out int i)
        {
            i = 20;
        }
        private static void fun2(ref int[] arr2)
        {
            //arr2 = null;
        }
        private static void fun3(ref int a)
        {
            a = 20;
        }
        /// <summary>
        /// 测试的运行方法
        /// </summary>
        public static void testRun()
        {
            Console.WriteLine("test start");
            int totalCount = 100000000;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < totalCount; i++)
            {
                TestRef temp = new TestRef() { Id = i, Name = "test" };
            }
            sw.Stop();
            Console.WriteLine($"引用类型实例化测试消耗：{sw.ElapsedMilliseconds}");
            sw.Reset();
            sw.Start();

            for (int i = 0; i < totalCount; i++)
            {
                TestVal temp = new TestVal() { Id = i, Name = "test" };
            }
            sw.Stop();
            Console.WriteLine($"值类型实例化测试消耗：{sw.ElapsedMilliseconds}");
            Console.Read();
        }
        class TestRef
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Name2 { get; set; }
            public string Name3 { get; set; }
            public string Name4 { get; set; }
            public string Name5 { get; set; }
            public string Name6 { get; set; }
        }
        struct TestVal
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Name2 { get; set; }
            public string Name3 { get; set; }
            public string Name4 { get; set; }
            public string Name5 { get; set; }
            public string Name6 { get; set; }
        }
    }
}
