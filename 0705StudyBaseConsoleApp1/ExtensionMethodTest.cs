using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;

namespace _0705StudyBaseConsoleApp1
{
    using FwqExtensionTest;
    /// <summary>
    /// 测试扩展方法
    /// </summary>
    public class ExtensionMethodTest
    {
        public static void TestRun()
        {
            //发送请求
            WebRequest req = WebRequest.Create("http://www.cnblogs.com");
            using(WebResponse resp = req.GetResponse())
            {
                using(Stream respStr = resp.GetResponseStream())
                {
                    using(FileStream fs = File.Create("textRes.html"))
                    {
                        //调用扩展方法，将相应写到文件中
                        respStr.CopyToNewStream(fs);
                    }
                }
            }
            Console.WriteLine("读写成功！");
            //调用其他命名空间的扩展方法
            "fwq".IsNull();
            string str1 = null;
            str1.IsNull();
            Console.ReadKey();
        }

    }

    /// <summary>
    /// 扩展方法必须放在顶级非嵌套非泛型的静态类中
    /// </summary>
    public static class StreamExt
    {
        /// <summary>
        /// 此扩展方法，扩展Stream类，实现从一个流中内容复制到另一个流
        /// </summary>
        /// <param name="inputS">源流</param>
        /// <param name="outStream">输出流</param>
        public static void CopyToNewStream(this Stream inputS, Stream outStream, int bufferSize = 8192)
        {
            //缓存
            byte[] buffer = new byte[bufferSize];
            int read;
            //循环去读写
            while ((read = inputS.Read(buffer, 0, buffer.Length)) > 0)
            {
                outStream.Write(buffer, 0, read);
            }
        }
    }
}

namespace FwqExtensionTest
{
    public static class NullExten
    {
        public static bool IsNull(this string str)
        {
            return str == null;
        }
    }
}


