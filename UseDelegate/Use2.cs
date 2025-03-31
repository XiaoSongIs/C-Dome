using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace UseDelegate
{
    /// <summary>
    /// 多播委托的使用
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
        //    myDelegate -= my1;
        //    myDelegate += my2;
        //    myDelegate.Invoke("My2");

        //} 
    }
}
