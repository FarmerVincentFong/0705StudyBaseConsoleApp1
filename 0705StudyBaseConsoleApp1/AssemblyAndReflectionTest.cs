//======================================================================
// Copyright (C) 2010-2019 广州市宏光软件科技有限公司 
// 版权所有 
// 
// 文件名: AssemblyAndReflectionTest
// 创建人: 方文谦
// 创建时间: 2019/7/19 16:57:20
//======================================================================
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 程序集与反射测试
    /// </summary>
    public class AssemblyAndReflectionTest
    {
        public static void TestRun()
        {
            Assembly ass;
            Type[] types;
            Type t1;
            object obj;
            try
            {
                //使用反射，获取动态加载的程序集的某些类型，并进行使用
                ass = Assembly.LoadFrom(@"F:\FangVincent\visual studio 2015\Projects\ConsoleApplicationTest1\ConsoleApplicationTest1\extlib\TestClassLibrary1.dll");
                types = ass.GetTypes();
                foreach (Type tt in types)
                {
                    //遍历程序集的类型
                    ConstructorInfo[] cia = tt.GetConstructors();
                    Console.WriteLine("构造函数");
                    ShowArrMsg<ConstructorInfo>(cia);

                    FieldInfo[] fia = tt.GetFields();
                    Console.WriteLine("字段");
                    ShowArrMsg(fia);

                    MethodInfo[] mia = tt.GetMethods();
                    Console.WriteLine("方法");
                    ShowArrMsg(mia);

                    PropertyInfo[] pia = tt.GetProperties();
                    Console.WriteLine("属性");
                    ShowArrMsg(pia);

                    EventInfo[] eia = tt.GetEvents();
                    Console.WriteLine("事件");
                    ShowArrMsg(eia);
                }

                //使用命名空间加类型名获取指定的类型
                t1 = ass.GetType("TestClassLibrary1.ReflectTestClass");
                //创建实例
                obj = ass.CreateInstance("TestClassLibrary1.ReflectTestClass");
                //获取实例方法
                MethodInfo m1 = t1.GetMethod("WriteString");
                Console.WriteLine("动态调用反射方法");
                Console.WriteLine(m1.Invoke(obj, new object[] { "Tom" }));
                MethodInfo m2 = t1.GetMethod("WriteName");
                Console.WriteLine(m2.Invoke(null, new object[] { "Tom" }));
                MethodInfo m3 = t1.GetMethod("WirteNopara");
                Console.WriteLine(m3.Invoke(obj, null));
            }
            catch (FileNotFoundException fnfe)
            {
                Console.WriteLine(fnfe.Message);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 遍历泛型枚举序列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        public static void ShowArrMsg<T>(IEnumerable<T> e)
        {
            foreach (T item in e)
            {
                Console.WriteLine(item.ToString());
            }
        }
    }
}
