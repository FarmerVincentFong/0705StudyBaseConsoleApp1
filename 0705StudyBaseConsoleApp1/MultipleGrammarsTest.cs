using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 测试自动实现的属性，隐式类型，对象集合初始化器，匿名类型
    /// </summary>
    public class MultipleGrammarsTest
    {
        public static void TestRun()
        {
            //Person p1 = new Person("ee",10);
            //p1.Name = "efe";
            //p1.Age = 20;
            //使用隐式类型
            var a = 12345;
            var b = new { Name = "fwq", Age = 123 };
            var dic = new Dictionary<string, int>();
            foreach (var item in dic)
            {
            }
            var intarr = new[] { 1, 2, 3 };
            var stringarr = new[] { "a", "b" };
            //var errorarr = new[] { "fwq", 12 };   //报错
            //使用初始化器
            Person p2 = new Person { Name = "qqq", Age = 12 };
            p2 = new Person() { Name = "qqq", Age = 12 };
            p2 = new Person("aaa",1) { Name = "qqq", Age = 12 };
            var strList = new List<string> { "qqq", "www", "eee" };
            var pList2 = new List<Person>() { new Person { Name = "zzz", Age = 10 }, new Person { Name = "xxx", Age = 20 } };
            //测试匿名类型
            var at1 = new { Cash = (decimal)10001.0, Account = "621226" };
            var at1arr = new[] { new { Cash = 20000, Account = "101" }, new { Cash = 10001, Account = "621226" } };
            foreach(var ele in at1arr)
            {

            }
        }

        public class Person
        {
            //C#3.0之前的属性
            private string _name;
            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
            //自动实现属性
            //public int Age { get; private set; }
            public int Age { get; set; }
            public Person()
            {
            }

            public Person(string name, int age)
            {
                this._name = name;
                this.Age = age;
            }
        }
        public struct PersonVal
        {
            //在结构体使用自动属性
            public string ClassName { get; set; }
            //使用自动属性出问题时，可以考虑调用默认的无参构造方法
            public PersonVal(string cn) : this()
            {
                ClassName = cn;
            }
        }
    }
}
