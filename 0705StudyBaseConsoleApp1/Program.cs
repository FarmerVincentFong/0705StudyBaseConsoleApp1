using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0705StudyBaseConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //RefAndOutParams.testRun();  //测试值类型和引用类型,测试高级参数
            //RefAndOutParams.TestRun2();  //测试值类型和引用类型,测试高级参数
            //ArrayAndArrayList.TestRun();    //测试数组和简单容器（ArrayList、List）
            //DelegateTest.TestRun(); //测试委托
            //DelegateChainTest.TestRun(); //测试委托链
            //EventTest.TestRun(); //测试事件
            //GenericTest.TestRun(); //测试泛型
            //GenericTest2.TestRun(); //测试泛型中（类型推断、类型约束、反射调泛型方法）
            //NullableTest.TestRun(); //测试可空类型
            //DelegateFunctionTest.TestRun(); //测试匿名方法
            //IEnumeratorAndIteratorTest.TestRun();   //测试迭代器的使用
            //MultipleGrammarsTest.TestRun();   //测试自动实现的属性，隐式类型，对象集合初始化器，匿名类型
            //LambdaTest.TestRun();  // 测试Lambda表达式
            //ExtensionMethodTest.TestRun();  //测试扩展方法
            //SimpleLinqTest.TestRun();   //测试linq简单基础用法
            DynamicTest.TestRun();      //测试dynamic动态类型
        }
    }
}
