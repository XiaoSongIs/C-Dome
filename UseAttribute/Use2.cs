using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
#nullable disable


namespace UseAttribute
{
    /// <summary>
    /// 特性的使用例子2
    /// 在类、方法、属性、字段上使用特性
    /// </summary>
    class Use2
    {
        //static void Main(string[] args)
        //{
        //    // 使用原本的方法
        //    //ShowInvoke show1 = new ShowInvoke();
        //    //Text text = new Text();
        //    //show1.Invoke(text);

        //    // 使用拓展方法
        //    Text text = new Text();
        //    text.Invoke();
        //}
    }

    /// <summary>
    /// AttributeTargets
    /// AllowMultiple 
    /// Inherited
    /// </summary>
    [AttributeUsage(AttributeTargets.All,AllowMultiple = true,Inherited = false)]
    public class ShowAttribute : Attribute
    {
        public string ShowInfo { get; set; }
        public ShowAttribute(string info)
        {
            ShowInfo = info;
        }

        public void Show()
        {
            Console.WriteLine(ShowInfo);
        }
    }

    /// <summary>
    /// 使用
    /// </summary>
    [Show("这是在类上使用特性")]
    [Show("这是在类上使用特性1")]
    public class Text()
    {
        [Show("这是在属性上使用特性")]
        public string _Name1 { get; set; }

        [Show("这是在字段上使用特性")]
        public string _Name2 = "张三";

        [Show("这是在方法上使用特性")]
        public void Te(){}

    }

    /// <summary>
    /// 定义使用特性
    /// </summary>
    public static class ShowInvoke
    {
        public static void Invoke<T>(this T t)
        {
            Type type = typeof(T);
            if (type.IsDefined(typeof(ShowAttribute), true))
            {
                /// 获取类上的特性
                ShowAttribute[] showAttributeClass =
                    (ShowAttribute[])type.GetCustomAttributes<ShowAttribute>();

                object[] obj = type.GetCustomAttributes(typeof(ShowAttribute), true);

                foreach (var item in obj)
                {
                    (item as ShowAttribute).Show();
                    //item.Show();
                }
                // 获取属性、字段、方法上的特性
                foreach (MemberInfo info in type.GetMembers())
                {
                    if (info.IsDefined(typeof(ShowAttribute),true))
                    {
                        ShowAttribute showAttribute =
                            info.GetCustomAttribute<ShowAttribute>();

                        showAttribute.Show();
                    }
                }
            }

        }
    }
}
