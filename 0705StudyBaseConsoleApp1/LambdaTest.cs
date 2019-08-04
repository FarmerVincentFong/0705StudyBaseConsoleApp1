using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;

namespace _0705StudyBaseConsoleApp1
{
    /// <summary>
    /// 测试Lambda表达式
    /// </summary>
    public class LambdaTest
    {
        public static void TestRun()
        {
            //下面是C# 1中创建委托实例的代码
            Func<string, int> dt1 = new Func<string, int>(CallBackMethod1);
            dt1("fwq");
            //下面是C# 2中用匿名方法来创建委托实例，此时就不需要额外定义回调方法Callbackmethod
            Func<string, int> dt2 = delegate (string str) { return str.Length; };
            //下面是 C# 3中使用Lambda表达式来创建委托实例
            Func<string, int> dt3 = (string text) => { return text.Length; };
            Func<string, int> dt4 = (str) => { return str.Length; };
            Func<string, int> dt5 = str => str.Length;
            //上面三种Lambda表达式等价，所以可简写
            Console.WriteLine(dt5("fwq"));
            TestRunChild2();
            Console.ReadKey();
            TestRunChild1();
        }

        private static int CallBackMethod1(string text)
        {
            return text.Length;
        }

        //控制台调用WinForm控件来测试Lambda表达式与事件绑定
        public static void TestRunChild1()
        {
            Button btn1 = new Button() { Text = "点击我" };
            //C#2 使用匿名方法绑定事件
            btn1.Click += delegate (object s, EventArgs e) { ReportEventInfo("匿名方法的Click事件", s, e); };
            btn1.KeyPress += delegate (object s, KeyPressEventArgs e) { ReportEventInfo("匿名方法的KeyPress事件", s, e); };

            //C#3 使用Lambda表达式绑定事件
            btn1.Click += (sender, e) => ReportEventInfo("Lambda表达式的Click事件", sender, e);
            btn1.KeyPress += (sender, e) => ReportEventInfo("Lambda表达式的KeyPress事件", sender, e);
            //使用对象初始化器，初始化Form 
            Form f1 = new Form() { Name = "控制台创建窗体，测试Lambda", AutoSize = true, Controls = { btn1 } };
            //运行窗体
            Application.Run(f1);
        }

        //事件的回调方法（处理方法）
        private static void ReportEventInfo(string title, object sender, EventArgs e)
        {
            Console.WriteLine($"发生的事件为：{title}\n触发事件的对象为：{sender.ToString()}\n事件的参数：{e.GetType()}\n");
        }
        //测试Lambda表达式与表达式树Expression
        public static void TestRunChild2()
        {
            Expression<Func<int, int, string>> exp1 = (a, b) => (a + b).ToString();
            Expression<Func<int, string>> exp2 = (x) => x.ToString();

            //Expression<Func<int, int, int>> exp1 = (a, b) => a + b;
            Console.WriteLine(exp1.Compile()(4, 5));    //编译表达式树
            
        }
    }
}
