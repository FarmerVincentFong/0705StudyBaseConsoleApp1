using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 测试linq简单基础用法
    /// </summary>
    public class SimpleLinqTest
    {
        public static void TestRun()
        {
            //查询集合中的数据
            OldQuery();
            LinqQuery();
            //查询XML文件
            OldXpathQueryXml();
            LinqToXmlQuery();
            Console.ReadKey();
        }

        private static List<string> CreateTestList()
        {
            List<string> a = new List<string>();
            for (int i = 0; i < 10; i++)
            {
                a.Add("A" + i);
            }
            return a;
        }

        //传统的查询集合
        public static void OldQuery()
        {
            var list = CreateTestList();
            int index = 0;
            List<string> tempList = new List<string>();
            foreach (string str in list)
            {
                //int i = int.Parse(str.Substring(1));
                if (index % 2 == 0)
                {
                    tempList.Add(str);
                }
                index++;
            }
            Console.WriteLine("传统的查询集合");
            //输出序号为偶数的项
            foreach (var ele in tempList)
            {
                Console.WriteLine(ele);
            }
        }
        //使用Linq查询集合
        public static void LinqQuery()
        {
            var list = CreateTestList();
            var list1 = from s in list
                        let index = int.Parse(s.Substring(1))
                        where index % 2 == 0
                        select s;
            var list2 = list.Where(s => int.Parse(s.Substring(1)) % 2 == 0);
            Console.WriteLine("使用Linq查询集合");
            foreach (var ele in list2)
            {
                Console.WriteLine(ele);
            }
        }

        private static string xmlStr = "<Persons>" +
            "<Person Id='1'>" +
            "<Name>张三</Name>" +
            "<Age>18</Age>" +
            "</Person>" +
            "<Person Id='2'>" +
            "<Name>李四</Name>" +
            "<Age>19</Age>" +
            "</Person>" +
             "<Person Id='3'>" +
            "<Name>王五</Name>" +
            "<Age>22</Age>" +
            "</Person>" +
            "</Persons>";

        //使用XPath方式来对XML文件进行查询
        private static void OldXpathQueryXml()
        {
            //找到Name为李四的节点
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlStr);
            // 创建查询XML文件的XPath
            string xPath = "/Persons/Person";
            XmlNodeList nodes = doc.SelectNodes(xPath);
            Console.WriteLine("使用XPath方式来对XML文件进行查询");
            foreach (XmlNode n in nodes)
            {
                foreach (XmlNode cn in n.ChildNodes)
                {
                    if (cn.InnerXml == "李四")
                    {
                        Console.WriteLine($"姓名为：{cn.InnerXml}   Id为:{n.Attributes["Id"].Value}");
                    }
                }
            }
        }
        //使用Linq 来对XML文件进行查询
        private static void LinqToXmlQuery()
        {
            Console.WriteLine("使用Linq 来对XML文件进行查询");
            //找到Name为李四的节点
            XElement root = XElement.Parse(xmlStr);
            var queryRes = from person in root.Elements("Person")
                           where person.Element("Name").Value == "王五"
                           select person;
            queryRes.ToList().ForEach(ele => Console.WriteLine($"姓名为：{ele.Element("Name").Value}   Id为:{ele.Attribute("Id").Value}"));
        }
    }
}
