using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 测试事件与事件模式
    /// </summary>
    public class EventTest
    {
        public static void TestRun()
        {
            // 实例化一个事件源对象
            Me eventSource = new Me("fwq");
            // 实例化关注事件的对象
            Friend f1 = new Friend();
            Friend f2 = new Friend();
            // 使用委托把对象及其方法注册到事件中
            eventSource.BirthDayEvent += new BirthDayEventHandle(f1.BuyCake);
            eventSource.BirthDayEvent += f2.SendGift;

            eventSource.InputKeysEvent += f1.BuyCake;
            eventSource.InputKeysEvent += f2.SendGift;

            //触发生日事件
            eventSource.TimeUp();
            while (!eventSource.CheckKeys(Console.ReadLine()))
            {
                Console.WriteLine("密钥有误！");
            }
            Console.WriteLine("监听结束！");
            Console.ReadKey();
        }

        // 第一步： 定义一个类型用来保存所有需要发送给事件接收者的附加信息
        public class BirthdayEventArgs : EventArgs
        {
            //过生日人的姓名
            private readonly string name;
            public string Name { get { return name; } }
            public BirthdayEventArgs(string name)
            {
                this.name = name;
            }
        }

        // 第二步：定义一个生日事件，首先需要定义一个委托类型，用于指定事件触发时被调用的方法类型
        public delegate void BirthDayEventHandle(object sender, BirthdayEventArgs e);
        //定义事件成员
        public class Subject
        {
            // 定义生日事件
            public event BirthDayEventHandle BirthDayEvent;
            public event EventHandler<BirthdayEventArgs> InputKeysEvent;

            // 第三步：定义一个负责触发事件的方法，它通知已关注的对象（通知我的好友）
            protected virtual void Notify(BirthdayEventArgs e)
            {
                // 出于线程安全的考虑，现在将对委托字段的引用复制到一个临时字段中
                BirthDayEventHandle temp = Interlocked.CompareExchange(ref BirthDayEvent, null, null);
                if (temp != null)
                {
                    // 触发事件，与方法的使用方式相同
                    // 事件通知委托对象，委托对象调用封装的方法
                    temp(this, e);
                }
            }
            protected virtual void NotifyKeys(BirthdayEventArgs e)
            {
                // 出于线程安全的考虑，现在将对委托字段的引用复制到一个临时字段中
                Interlocked.CompareExchange(ref InputKeysEvent, null, null)?.Invoke(this,e);
            }
        }

        // 定义触发事件的对象，事件源
        public class Me : Subject
        {
            private string name;
            public Me(string name)
            {
                this.name = name;
            }
            public void TimeUp()
            {
                //生日到了，触发事件 
                BirthdayEventArgs eventArgs = new BirthdayEventArgs("fwq");
                this.Notify(eventArgs);
            }
            public bool CheckKeys(string keys)
            {
                if (keys == "fwq123")
                {
                    BirthdayEventArgs eventArgs = new BirthdayEventArgs("隐藏密钥输入成功！");
                    this.NotifyKeys(eventArgs);
                    return true;
                }
                return false;
            }
        }
        //好友对象
        public class Friend
        {
            //生日事件处理方法
            public void SendGift(object sender,BirthdayEventArgs e)
            {
                Console.WriteLine(e.Name + " 生日到了，我要送礼物");
            }
            public void BuyCake(object sender,BirthdayEventArgs e)
            {
                Console.WriteLine(e.Name + " 生日到了,我要准备买蛋糕");
            }
        }
    }
}
