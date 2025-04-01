using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace UseDelegate
{
    /// <summary>
    /// 内置委托的使用
    /// 委托回调函数的使用
    /// 自己定义第一个泛型委托
    /// </summary>
    internal class Use3
    {
        //static void Main(String[] args)
        //{
        //    //CallBack("url", action => Console.WriteLine(action));
        //    //CallBack1("url", user);
        //}

        // 回调函数
        static void CallBack(string url,Action<string> action)
        {
            Console.WriteLine("url="+url);
            action("ok");
        }

        public delegate void My();

        static void CallBack1(string url,My my)
        {
            Console.WriteLine(url);
            My my1 = my;
            my1.Invoke();
        }

      
        static void user()
        {
            Action<String> print = Console.WriteLine;
            print("Hello World");

            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine(add(1, 2));

            Predicate<int> isPositive = (a) => a > 0;
            Console.WriteLine(isPositive(1));
        }

        // 自定义泛型委托
        delegate void MyDelegate<T>(T t);
      
    }
}
