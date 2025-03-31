using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace UseDelegate
{
    /// <summary>
    /// 委托作为参数
    /// </summary>
    
    public delegate void MyDelegate(string str);
    public delegate void MyDelegate1(int a, int b);

    public class Use1
    {
        //static void Main(string[] args)
        //{
        //    // 委托作为参数
        //    //My(MyMethod);

        //    // 委托作为返回值
        //    //MyDelegate1 myDelegate1 = My1();
        //    //myDelegate1(1, 2);

        //}

        static void MyMethod(string str)=> Console.WriteLine(str);

        static void My(MyDelegate myDelegate)
        {
           //myDelegate("Hello World");
           myDelegate.Invoke("Hello World");
        }

        static MyDelegate1 My1()
        {
            return (a,b)=> Console.WriteLine(a + b);
        }
    }
}
