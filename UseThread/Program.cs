namespace UseThread
{
    internal class Program
    {
        public static int a = 1;
        // 使用线程
        static void Main(string[] args)
        {
            Thread thread = new Thread(() =>
            {
               for (int i = 0;  i < 1000; i++)
                {
                    a++;
                }
            });

            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 1000; i++)
                {
                    a++;
                }
            });

            thread.Start();
            thread1.Start();

        }


    }
}
