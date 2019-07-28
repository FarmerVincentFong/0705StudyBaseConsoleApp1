using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 测试迭代器的使用，分为C#1.0的和C#2.0的
    /// </summary>
    public class IEnumeratorAndIteratorTest
    {
        public static void TestRun()
        {
            ChildTest1();
        }
        private static void ChildTest1()
        {
            FriendColl friends = new FriendColl();
            friends[1] = new Friend("fwq");
            friends.Add(new Friend("zxc", 100));
            foreach (Friend f in friends)
            {
                Console.WriteLine(f.Name + "     " + f.Age);
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("使用yield return 返回一个枚举序列");
            foreach (int ii in WithIterator())
            {
                Console.WriteLine(ii);
            }
            var tempList = WhereListWithIterator(friends);
            foreach (var ss in tempList)
            {
                Console.WriteLine(ss);
            }
            Console.ReadKey();
        }

        private static IEnumerable<int> WithIterator()
        {
            for (var i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }

        //迭代器是延迟计算的，用foreach时，自动调用MoveNext时调用
        private static IEnumerable<string> WhereListWithIterator(FriendColl ff)
        {
            for (var i = 0; i < ff.Count; i++)
            {
                yield return ff[i].Name;
            }
        }

        //1.0实现迭代器
        public class Friend
        {
            private string name;
            public string Name { get { return name; } set { name = value; } }
            public int Age { get; set; }
            public Friend(string name)
            {
                this.Name = name;
            }
            public Friend(string name, int age)
            {
                this.Name = name;
                this.Age = age;
            }
        }
        /// <summary>
        /// 内部类
        /// 可使用foreach的自定义非泛型集合
        /// </summary>
        public class FriendColl : IEnumerable
        {
            private Friend[] friends;
            public FriendColl()
            {
                friends = new Friend[]
                { new Friend("张三",18),new Friend("李四",22),new Friend("王五",43) };
            }
            //索引器
            public Friend this[int index]
            {
                get
                {
                    return friends[index];
                }
                set
                {
                    friends[index] = value;
                }
            }

            public int Count { get { return friends.Length; } }

            public int Add(Friend newItem)
            {
                //对array进行扩容
                Array.Resize(ref friends, friends.Length + 1);  //类型参数自动推断
                friends[friends.Length - 1] = newItem;
                return friends.Length - 1;
            }

            ////C#1.0 实现IEnumerable的接口方法，返回该集合的迭代器
            //public IEnumerator GetEnumerator()
            //{
            //    return new FriendCollIterator(this);
            //}

            //C#2.0 使用yield return 简化迭代器的实现
            public IEnumerator GetEnumerator()
            {
                for (var i = 0; i < friends.Length; i++)
                {
                    yield return friends[i];
                }
            }
        }

        /// <summary>
        /// 内部类
        /// C#1.0 自定义迭代器类，对上面集合进行迭代
        /// </summary>
        public class FriendCollIterator : IEnumerator
        {
            private readonly FriendColl friends;    //迭代的集合
            private int index;  //当前索引指向
            private Friend current; //当前指向的元素
            internal FriendCollIterator(FriendColl fcol)
            {
                friends = fcol;
                index = 0;
            }
            #region 实现IEnumerator接口的成员
            public object Current { get { return this.current; } }
            public bool MoveNext()
            {
                if (index + 1 > friends.Count)
                {
                    return false;
                }
                else
                {
                    current = friends[index];
                    index++;
                    return true;
                }
            }
            public void Reset()
            {
                //重置迭代器的位置
                this.index = 0;
            }
            #endregion
        }
    }
}
