using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseDelegate
{
    internal class UseLinq
    {
        static void Main(String[] args)
        {
            List<T> list = new List<T>
            { 
            new T { Age = 10 },
            new T { Age = 20 },
            new T { Age = 40 },
            new T { Age = 50 },
            new T { Age = 60 }
            };


            // 查询年龄大于30的 

            //(1)
            var result = list.Where(t => t.Age > 30).ToList();
            //(2)
            var result1 = from t in list
                          where t.Age >= 30
                          select t;

            // 使用自定Linq
            var result2 = list.AntWhere(list => list.Age > 30).ToList();
            foreach (var t in result2)
            {
                Console.WriteLine(t.Age);
            }
            
        }
    }


    public class T
    {
        public int Age { get; set; }
    }



    /// <summary>
    ///  自己写Linq
    /// </summary>

    public static class ExtendMethod
    {
        public static List<T> AntWhere(this List<T> lists , Func<T, bool> func)
        {
            var list = new List<T>();
            foreach (var t in lists)
            {
                if (func.Invoke(t))
                {
                    list.Add(t);
                }
            }
            return list;
        }
    }
}
