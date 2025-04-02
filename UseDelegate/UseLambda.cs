using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace UseDelegate
{
    internal class UseLambda
    {
        //static void Main(String [] args)
        //{
        //    {
        //        // 普通写法
        //        Func<int, int, int> func = new Func<int, int, int>(Add);
        //        Console.WriteLine(func(1, 2));
        //    }

        //    {
        //        // deletage
        //        Func<int, int, int> func = new Func<int, int, int>(
        //            delegate
        //            (int a, int b){
        //                return a + b;
        //            }
        //        );
        //        Console.WriteLine(func(1, 2));
        //    }

        //    {
        //        // Lambda  =>
        //        Func<int, int, int> func = (a, b) => a + b;
        //        Console.WriteLine(func(1, 2));


        //        Action action = () => Console.WriteLine("1");
        //        action += () => Console.WriteLine("2");
                
        //    }
           
        //}


        public static int Add(int a, int b)
        {
            return a + b;
        }
    }  
}
