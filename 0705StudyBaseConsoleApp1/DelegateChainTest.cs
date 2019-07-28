using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    //测试委托链
    public class DelegateChainTest
    {
        //委托类型
        public delegate string TestDg(int i);
        public static void TestRun()
        {
            TestDg dg1 = new TestDg(Method1);
            TestDg dg2 = new TestDg(new DelegateChainTest().Method2);
            TestDg dg3 = new TestDg(new DelegateChainTest().Method3);
            //定义委托链
            TestDg dgChain = null;
            dgChain += dg1;
            dgChain += dg2;
            dgChain += dg3;
            dgChain += dg2;
            dgChain -= dg2;
            CallDgChain(dgChain);
            //Console.WriteLine(dgChain(11));
            Console.ReadKey();
        }
        //静态方法1
        private static string Method1(int num)
        {
            string msg = $"静态方法1 {num}";
            return msg;
        }
        //实例方法2
        private string Method2(int num)
        {
            throw new Exception("方法2报错");
            string msg = $"实例方法2 {num}";
            return msg;
        }
        private string Method3(int num)
        {
            string msg = $"实例方法3 {num}";
            return msg;
        }
        private static void CallDgChain(TestDg dgChain)
        {
            if (dgChain != null)
            {
                //遍历委托对象的调用列表，调用关联的所有委托对象
                Delegate[] dgArray = dgChain.GetInvocationList();
                foreach(TestDg item in dgArray)
                {
                    try
                    {
                        Console.WriteLine(item(11)+Environment.NewLine);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"{item.Method.Name} {ex.Message} " + Environment.NewLine);
                    }
                }
            }
        }
    }

}
