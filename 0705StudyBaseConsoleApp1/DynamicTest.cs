using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Linq.Expressions;

namespace _0705StudyBaseConsoleApp1
{
    public class DynamicTest
    {
        public static void TestRun()
        {

            ChildMethod1();
            UsePython();
            DynamicLimit();
            ExpandDynamicTest();
            Console.ReadKey();
        }

        public static void ChildMethod1()
        {
            //测试dynamic与object在编译时的区别提示
            object obj = 10;
            Console.WriteLine(obj.GetType());
            obj = (int)obj + 10;
            dynamic dnum = 20;
            Console.WriteLine(dnum.GetType());
            dnum = dnum + 10;
            dnum = new ExpandoObject();
            dnum.fm = new Func<int, int>(n => n * n);
            Console.WriteLine(dnum.fm(10));
            dynamic dstr = "Hello fwq";
            Console.WriteLine(dstr.Substring(5));
        }

        //在C#里使用动态语言Python
        public static void UsePython()
        {
            ScriptEngine eng = Python.CreateEngine();
            Console.Write("调用Phtyon的print函数输出：");
            //调用Python语言的print函数来输出
            eng.Execute("print 'Hello Python In C#'");
        }

        //使用动态类型的限制
        public static void DynamicLimit()
        {
            //不能用动态类型作为参数调用扩展方法
            var numbers = Enumerable.Range(10, 10);
            dynamic num = 4;
            //var error = numbers.Take(num);
            var trueRes = numbers.Take((int)num);
            var trueRes2 = Enumerable.Take(numbers, num);
            //委托与动态类型不能隐式转换的限制
            //dynamic dt1 = x => x + 1; //错误
            dynamic dt2 = (Func<int, int>)(x => x + 1);
            dynamic dt3 = (Action<string>)Console.WriteLine;
            dt2(10);
            dt3("test dynamic delegate");
            //动态类型不能调用构造函数和静态方法的限制
            //dynamic s1 = new dynamic();
            //dynamic s2 = dynamic.Test();
            //类型声明和泛型类型参数
            //不能声明一个基类为dynamic的类型，也不能将dynamic用于类型参数的约束，或作为类型所实现的接口的一部分，

        }
        //dynamic动态添加属性和方法
        public static void ExpandDynamicTest()
        {
            Console.WriteLine("ExpandDynamicTest");
            //使用ExpandObject
            dynamic expandVal = new ExpandoObject();
            expandVal.Name = "fwq";
            expandVal.Age = 22;
            //动态添加方法
            expandVal.PrintInfo = (Func<string, bool>)(str =>
            {
                Console.WriteLine($"Name:{expandVal.Name}  Age:{expandVal.Age}  Remark:{str}\n");
                return true;
            });
            expandVal.PrintInfo("tttttttt");
            //使用DynamicObject
            dynamic dymobj = new DynamicType();
            dymobj.CallTestMethod("fwq", 12);
            dymobj.Name = "dym fwq";
            dymobj.Age = "122";
            //实现IDynamicMetaObjectProvider接口来实现动态行为
            Console.WriteLine("实现IDynamicMetaObjectProvider接口来实现动态行为");
            dynamic dymobj3 = new DynamicType2();
            dymobj3.CallTestMethod2("qqq", 11);
            dymobj3.Score = 100;
            Console.WriteLine(dymobj3.Score);
        }
        private class DynamicType : DynamicObject
        {
            // 重写方法，
            // TryXXX方法表示对对象的动态调用
            public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
            {
                Console.WriteLine(binder.Name + "方法被调用");
                result = null;
                return true;
            }
            public override bool TrySetMember(SetMemberBinder binder, object value)
            {
                Console.WriteLine(binder.Name + "属性被设置" + "  值位：" + value.ToString());
                return true;
            }
        }

        public class DynamicType2 : IDynamicMetaObjectProvider
        {
            public DynamicMetaObject GetMetaObject(Expression parameter)
            {
                Console.WriteLine("开始获得元数据......");
                return new Metadynamic(parameter, this);
            }
        }

        // 自定义Metadynamic类
        public class Metadynamic : DynamicMetaObject
        {
            internal Metadynamic(Expression expression, DynamicType2 value)
                : base(expression, BindingRestrictions.Empty, value)
            {
            }
            // 重写响应成员调用方法
            public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
            {
                // 获得真正的对象
                DynamicType2 target = (DynamicType2)base.Value;
                Expression self = Expression.Convert(base.Expression, typeof(DynamicType2));
                var restrictions = BindingRestrictions.GetInstanceRestriction(self, target);
                // 输出绑定方法名
                Console.WriteLine(binder.Name + " 方法被调用了");
                return new DynamicMetaObject(self, restrictions);
            }
            //重写获取属性方法
            public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
            {
                // 获得真正的对象
                DynamicType2 target = (DynamicType2)base.Value;
                Expression self = Expression.Convert(base.Expression, typeof(DynamicType2));
                var restrictions = BindingRestrictions.GetInstanceRestriction(self, target);
                // 输出绑定属性名
                Console.WriteLine(binder.Name + " 属性被获取调用了");
                return new DynamicMetaObject(self, restrictions);
            }
            //重写设置属性方法
            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
            {
                // 获得真正的对象
                DynamicType2 target = (DynamicType2)base.Value;
                Expression self = Expression.Convert(base.Expression, typeof(DynamicType2));
                var restrictions = BindingRestrictions.GetInstanceRestriction(self, target);
                // 输出绑定属性名
                Console.WriteLine(binder.Name + " 属性被设置调用了");
                return new DynamicMetaObject(self, restrictions);
            }
        }
    }
}
