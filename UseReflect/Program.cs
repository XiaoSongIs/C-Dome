namespace UseReflect
{
    /// <summary>
    ///  反射的使用
    /// </summary>
    internal class Program
    {
        static void Main(string[] args)
        {
            //Assembly assembly = Assembly.GetExecutingAssembly();
            //foreach (Type item in assembly.GetTypes())
            //{
            //    //Console.WriteLine(item.Name);
            //    if (item.Name == "Person")
            //    {
            //        foreach (var member in item.GetMembers())
            //        {
            //            Console.WriteLine(member.Name);
            //        }
            //    }
            //}

            //Person per = new Person();
            //Type type = typeof(Person);
            //MethodInfo info = type.GetMethod("SayHollo2", BindingFlags.NonPublic | BindingFlags.Instance);
            //MethodInfo info = type.GetMethod("SayHollo5");
            //MakeGenericMethod
            //MethodInfo info1 = info.MakeGenericMethod(typeof(string));
            //object obj = info1.Invoke(per, new object[] { "这个女生你" });
            //Console.WriteLine(obj);
            //info.Invoke(null, new object[]{ "张三" });


            // 无参
            //object obj = Activator.CreateInstance(typeof(Person));
            //MethodInfo info = typeof(Person).GetMethod("SayHollo1");
            //info.Invoke(obj,new object[] { "张胜男"});
            // 有参
            //object obj = Activator.CreateInstance(typeof(Person), new object[] { "张胜男" });
            //MethodInfo info = typeof(Person).GetMethod("SayHello");
            //info.Invoke(obj, null);
            //泛型
            //Type type = typeof(Person<>);
            //Type gen = type.MakeGenericType(typeof(string));
            //object obj = Activator.CreateInstance(gen,new object[] { "zang"}); 
            //MethodInfo info = gen.GetMethod("SayHello");
            //info.Invoke(obj,null);
            //私有
            //Type type = typeof(Person<>);
            //Type gen = type.MakeGenericType(typeof(string));
            //ConstructorInfo ctor = gen.GetConstructor(
            //     BindingFlags.NonPublic | BindingFlags.Instance,
            //    null ,
            //    new Type[] { typeof(string) },
            //    null);

            //object obj = ctor.Invoke(new object[] { "1" });
            //MethodInfo info = gen.GetMethod("SayHello");
            //info.Invoke(obj, null);
        }

        class Person<T>
        {
            private string _name { get; set; }
            private Person(T t)
            {
                _name = t as string;
            }

            public void SayHello()
            {
                Console.WriteLine("Hello from Person!");
                Console.WriteLine(_name);
            }

            public void SayHollo1(string name)
            {
                Console.WriteLine("Hallo from " + name);
            }

            private void SayHollo2(string name)
            {
                Console.WriteLine("Hallo from " + name);
            }

            public static void SayHollo3(string name)
            {
                Console.WriteLine("Hallo from " + name);
            }

            public int SayHollo4(int a, int b)
            {
                return a + b;
            }

            public void SayHollo5<T>(T t)
            {
                Console.WriteLine(t.ToString());
            }
        }
    }
}
