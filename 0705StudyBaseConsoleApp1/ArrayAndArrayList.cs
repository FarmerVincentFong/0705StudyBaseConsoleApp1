using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 测试数组和简单容器（ArrayList、List）
    /// </summary>
    public class ArrayAndArrayList
    {
        public static void TestRun()
        {
            int[] ia1 = new int[10];
            int[] ia2 = new int[] { 1, 2, 3, 4 };
            int[] ia3 = { 4, 5, 6 };
            foreach (var i in ia3)
            {
                Console.WriteLine(i);
            }

            int[,] ba1 = new int[2, 3];
            int[,] ba2 = new int[,] { { 1, 2 }, { 4, 5 } };
            int[,] ba3 = { { 4, 5, 6 }, { 7, 8, 9 } };
            int[][] ba4 = new int[3][];
            ba4[0] = new int[] { 1 };
            ba4[1] = new int[] { 2, 3, };
            foreach (var j in ba3)
            {
                Console.WriteLine(j.ToString());
            }
            Console.WriteLine("接下来是ArrayList和List");
            //ArrayList可存储值类型和引用类型，但是值类型会装箱和拆箱，影响性能。用List这个泛型集合好
            ArrayList al1 = new ArrayList() { 1, 2, "qwe", "asd" };
            al1.Add("zxc");
            foreach (var item in al1)
            {
                Console.WriteLine(item);
            }
            List<string> sl1 = new List<string> { "ert", "dfg" };
            sl1.Add("cvb");
            sl1.ForEach((ele) =>
            {
                Console.WriteLine(ele);
            });
            Console.ReadKey();
        }
    }
}
