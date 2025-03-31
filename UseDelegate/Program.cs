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
        //    MyDelegate my = My;
        //    my("World");
        //    my.Invoke("1111");

        //}

        public static void My(string name)
        {
            Console.WriteLine("Hello, " + name);
        }
    }
}
