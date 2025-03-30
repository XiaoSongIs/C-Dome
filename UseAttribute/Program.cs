using System.Reflection;
#nullable disable
namespace UseAttribute
{
    /// <summary>
    /// 使用特性
    /// </summary>
    [MyAttribute("这是一个特性")]
    class Program
    {
        static void Main(string[] args)
        {
            //// 获取特性
            //Type type = typeof(Program);
            //object[] obj = type.GetCustomAttributes(true);
            //foreach (object o in obj)
            //{
            //    MyAttribute my = o as MyAttribute;
            //    if (my != null)
            //    {
            //        Console.WriteLine(my._name);
            //    }
            //}

            AttributeInboke inboke = new AttributeInboke();
            Console.WriteLine(inboke.GetRemark(MyEnum.Normal));
        }
    }


    class MyAttribute : Attribute
    {
        public string _name;
        public MyAttribute(string name)
        {
            _name = name;
            Console.WriteLine(_name);
        }
    }


    /// <summary>
    /// 1.根据状态给出提示
    /// 自定义特性
    /// 创建获取特性的类去调运特性
    /// </summary>
    public enum MyEnum
    {
        /// <summary>
        /// 正常
        /// </summary>
        [Remark("正常")]
        Normal = 1,
        /// <summary>
        /// 冻结
        /// </summary>
        [Remark("冻结")]
        Frozen = 2,
        /// <summary>
        /// 删除
        /// </summary>
        [Remark("删除")]
        Deleted = 3
    }

    /// <summary>
    /// AttributeUsage用来约束段的使用范围
    /// </summary>
    [AttributeUsage(AttributeTargets.All)]
    public class RemarkAttribute : Attribute
    {
        public string Remark { get; private set; }
        public RemarkAttribute(string remark)
        {
            Remark = remark;
        }
    }

    /// <summary>
    /// 特性的调运
    /// </summary>
    public class AttributeInboke
    {
        public string GetRemark(MyEnum myEnum)
        {
            // 1.获取到枚举的类型
            // 2.获取到枚举的字段
            // 3.判断是否有特性
            // 4.获取特性
            Type type = typeof(MyEnum);
            var filed = type.GetField(myEnum.ToString());
            if (filed.IsDefined(typeof(RemarkAttribute), true))
            {
                //RemarkAttribute remark = filed.GetCustomAttribute<RemarkAttribute>();
                RemarkAttribute remark = filed.GetCustomAttribute(typeof(RemarkAttribute),true) as RemarkAttribute;
                return remark.Remark;
            }
            else
            {
                return myEnum.ToString();
            }
        }
    }

}
