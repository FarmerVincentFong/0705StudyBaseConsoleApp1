//======================================================================
// Copyright (C) 2010-2019 广州市宏光软件科技有限公司 
// 版权所有 
// 
// 文件名: TupleAndValueTupleTest
// 创建人: 方文谦
// 创建时间: 2019/7/30 18:46:31
//======================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 使用Tuple和ValueTuple 方法返回多个值
    /// </summary>
    public class TupleAndValueTupleTest
    {
        public static void TestRun()
        {
            var r1 = ThreeResMed();
            Console.WriteLine($"{r1.Item1}:{r1.Item2}:{r1.Item3}");
            //var(a, b, c) = ThreeResMed();
            var r3 = ValueTuple.Create("asd", 10009);
            Console.WriteLine($"{r3.Item2}:{r3.Item2}");
            Console.ReadKey();
        }

        private static ValueTuple<string, int, double> ThreeResMed()
        {
            return new ValueTuple<string, int, double>("fwq", 19, 174.5);
        }

        //    private static (string x,int y,double z) ThreeResMedAlias()
        //    {
        //        return ("fwq", 19, 174.5);
        //        //return new ValueTuple<string, int, double>("fwq", 19, 174.5);
        //    }
        //}
    }
}