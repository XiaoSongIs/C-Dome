
#nullable disable
namespace UseDelegate
{
    /// <summary>
    /// 委托的基本使用
    /// </summary>
    internal class Program
    {
        public delegate void MyDelegate(string name);
        //static void Main(string[] args)
        //{
        //    //MyDelegate my = My;
        //    //my("World");
        //    //my.Invoke("1111");

        //    // -------- 未使用委托 ------------------
        //    List<Person> list = new List<Person>();
        //    list.Add(new Person{  _id = 1, _name = "张三1" , _persion = 10});
        //    list.Add(new Person{  _id = 2, _name = "张三2" , _persion = 30});
        //    list.Add(new Person{  _id = 3, _name = "张三3" , _persion = 60});
        //    list.Add(new Person{  _id = 4, _name = "张三4" , _persion = 110});
        //    //Person person = new Person();
        //    //person.GetPersonVip(list);

        //    // -------- 使用委托 ------------------
        //    Person person = new Person();
        //    IsVip isvpi = IsVip1;
        //    person.GetPersonVip(list, isvpi);
        //}

        public static void My(string name)
        {
            Console.WriteLine("Hello, " + name);
        }

        /*
         * 使用案例
         * 1.根据不同的条件判断不同的事件
         * 2.排序根据倒叙和顺序去排序
         */
        public class Person 
        { 
            public int _id { get; set; }
            public string _name { get; set; }
            public int _persion { get; set; }


            public void GetPersonVip(List<Person> list, IsVip isVip)
            {
                foreach (Person p in list)
                {
                    //if (p._persion > 100)
                    //{
                    //    Console.WriteLine(p._name+"是vip客户");
                    //}

                    if (isVip.Invoke(p))
                    {
                        Console.WriteLine(p._name + "是vip客户");
                    }
                }
            }
        }


        public delegate bool IsVip(Person p);

        public static bool IsVip1(Person p)
        {
            return p._persion > 10;
        }
    }
}
