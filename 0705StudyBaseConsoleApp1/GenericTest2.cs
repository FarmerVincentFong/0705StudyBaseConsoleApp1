using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Common;
using System.Reflection;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 泛型中（类型推断、类型约束、反射调泛型方法）
    /// </summary>
    public class GenericTest2
    {
        public static void TestRun()
        {
            int n1 = 4, n2 = 8;
            ArrayList a1 = new ArrayList { 1 };
            ArrayList a2 = new ArrayList { 2 };
            GenericSwitchVal(ref a1, ref a2);
            Console.WriteLine($"n1:{n1}    n2:{n2}");
            //TestMethods<>.Test("");

            //使用反射调用泛型方法
            TestC2 c = new TestC2();
            Type t1 = c.GetType();
            // 首先，获得方法的定义
            // 如果不传入BindFlags实参，GetMethod方法只返回公共成员
            // 这里我指定了NonPublic，也就是返回私有成员
            // (这里要注意的是，如果指定了Public或NonPublic的话，
            // 必须要同时指定Instance|Static,否则不返回成员，具体大家可以用代码来测试的)
            var m1 = t1.GetMethod("PrintType", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            m1.MakeGenericMethod(typeof(FileInfo)).Invoke(null, null);

            //测试泛型的可变性（协变，逆变）
            List<object> st1 = new List<object>();
            List<string> st2 = new List<string>();
            st1.AddRange(st2);  //协变

            IComparer<object> tc1 = new TestComparer();
            IComparer<string> tc2 = new TestComparer();
            st2.Sort(tc1);  //逆变
            Func<int> ff1 = new Func<int>(() => 1);
            Func<object> ff2 = new Func<object>(() => "");
            Func<string> ff3 = () => "ee";
            ff2=ff3;
            Action<int> ff4 = new Action<int>((i) => { });
            Action<object> ff5 = new Action<object>((i) => { });
            Action<string> ff6 = (s) => { };
            ff6 = ff5;
            Console.ReadKey();
        }

        /// <summary>
        /// 泛型方法，交换两个数的值 
        /// </summary>
        private static void GenericSwitchVal<T>(ref T n1, ref T n2)
        {
            T temp = n1;
            n1 = n2;
            n2 = temp;
        }
        public class TestMethods<T, U> where T : StringReader, IDisposable, new() where U : struct
        {
            public static void Test(T stream, U f)
            {
                Console.WriteLine(typeof(T));
                Console.WriteLine(typeof(U));
            }
        }

        public class TestC2
        {
            private static void PrintType<T>()
            {
                Console.WriteLine(typeof(T));
            }
        }

        public class TestComparer : IComparer<object>
        {
            public int Compare(object x, object y)
            {
                return x.ToString().CompareTo(y.ToString());
            }

        }
    }
}
