using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 测试可空类型
    /// </summary>
    public class NullableTest
    {
        public static void TestRun()
        {
            Nullable<int> ni1 = 10;
            int? ni2 = 20;
            int? ni3 = new Nullable<int>(); //值类型都有公共无参构造方法
            float? fi1 = null;
            float? fi2 = 3.14f;
            float f3 = fi1 ?? 8f;
            float f4 = fi2 ?? 9f;   //等价于fi2.HasValue?fi2.Value: 9f
            string stringnotnull = "123";
            string stringisnull = null;
            string result = stringnotnull ?? "456";
            string result2 = stringisnull ?? "12";
            Console.ReadKey();
        }
    }
}
