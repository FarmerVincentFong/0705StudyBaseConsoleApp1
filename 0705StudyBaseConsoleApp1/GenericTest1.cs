//======================================================================
// Copyright (C) 2010-2019 广州市宏光软件科技有限公司 
// 版权所有 
// 
// 文件名: GenericTest1
// 创建人: 方文谦
// 创建时间: 2019/7/15 9:36:19
//======================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplicationTest1
{
    /// <summary>
    /// 泛型测试
    /// </summary>
    public class GenericTest1
    {
        public static void TestRun()
        {
            object o = null;
            // Dictionary<,>是一个开放类型，它有2个类型参数
            Type t1 = typeof(Dictionary<,>);
            // 创建开放类型的实例（创建失败，出现异常）
            o = CreateInstance(t1);
            Console.WriteLine();

            // DictionaryStringKey<>也是一个开放类型，但它有1个类型参数
            Type t2 = typeof(DictionaryStringKey<>);
            // 创建该类型的实例（同样会失败，出现异常）
            o = CreateInstance(t2);
            Console.WriteLine();

            // DictionaryStringKey<int>是一个封闭类型
            Type t3 = typeof(DictionaryStringKey<int>);
            // 创建封闭类型的一个实例（成功）
            o = CreateInstance(t3);
            Console.WriteLine($"对象类型={o.GetType()}");
            //测试泛型类
            DictionaryStringKey<int> dic = new DictionaryStringKey<int>("werwer");
            dic.Add("a", 111);
            dic.Add("b", 222);

            Type t4 = typeof(TestClass1);
            // 创建抽象类的实例（创建失败，出现异常）
            o = CreateInstance(t4);

            Console.ReadKey();
        }

        //声明开放泛型类型
        public sealed class DictionaryStringKey<T> : Dictionary<string, T>
        {
            private string nametest;
            public DictionaryStringKey()
            {
            }
            public DictionaryStringKey(string name111)
            {
                nametest = name111;
            }
        }

        //根据元类型创建实例
        private static object CreateInstance(Type t)
        {
            object obj = null;
            try
            {
                // 使用指定类型t的默认构造函数来创建该类型的实例
                obj = Activator.CreateInstance(t);
                Console.WriteLine($"已创建{t.ToString()}的实例");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return obj;
        }

        //使用抽象类测试实例化
        public abstract class TestClass1
        {
            public string name;
            protected abstract void SetInit(string title);
        }
    }
}
