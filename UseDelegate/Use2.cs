using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace UseDelegate
{
    /// <summary>
    ///  多播委托的使用
    ///  MulticastDelegate 委托的基类
    ///  带返回值的委托只返回最后一个委托的返回值
    ///  匿名方法会生成不同的名称，传递方法会生成相同的名称
    /// </summary>
    public class Use2
    {
        public delegate void MyDelegate(string str);
        static void my1(string str)=> Console.WriteLine("my1: " + str);
        static void my2(string str)=> Console.WriteLine("my2: " + str);
        //static void Main(string[] args)
        //{
        //    MyDelegate myDelegate = my1;
        //    myDelegate("My1");
        //    myDelegate = MulticastDelegate.Combine(myDelegate, my2) as MyDelegate;
        //    myDelegate -= my1;
        //    myDelegate += my2;
        //    myDelegate.Invoke("My2");
        //}
    }
}
