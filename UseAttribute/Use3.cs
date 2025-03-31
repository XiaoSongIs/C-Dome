using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace UseAttribute
{
    /// <summary>
    /// 特性使用例子3
    /// 特性的验证
    /// 查找多个特性
    /// 使用抽象方法去实现
    /// </summary>
    class Use3
    {
        static void Main(string[] args)
        {
            Test text = new Test
            {
                _Phone = 12345678910,
                _Name = "Test"
            };
            //InvokeAttribute invoke = new InvokeAttribute();
            //if (invoke.Invokes(text))
            //{
            //    Console.WriteLine("验证成功");
            //}
            //else
            //{
            //    Console.WriteLine("验证失败");
            //}

            if (text.Invokes())
            {
                Console.WriteLine("验证成功");
            }
            else
            {
                Console.WriteLine("验证失败");
            }
        }
    }


    /// <summary>
    /// 总的特性
    /// </summary>
    public abstract class SomeAttribute : Attribute
    {
        public abstract bool Invoke(object obj);
    }

    /// <summary>
    /// 验证电话号码的长度
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class LongStringAttribute : SomeAttribute
    {
        private int _length;
        public LongStringAttribute(int length)
        {
            _length = length;
        }
        public override bool Invoke(object obj)
        {
            return obj != null && obj.ToString().Length == _length;
        }
    }

    /// <summary>
    /// 检查是否为nul
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class NoStringAttribute : SomeAttribute
    {
        public override bool Invoke(object obj)
        {
            return obj != null;
        }
    }

    /// <summary>
    /// 实现特性
    /// </summary>
    public static class InvokeAttribute
    {
        public static bool Invokes<T>(this T t)
        {
            Type type = typeof(T);
            foreach (PropertyInfo attr in type.GetProperties())
            {
                if (attr.IsDefined(typeof(SomeAttribute), true))
                {
                    SomeAttribute some = attr.GetCustomAttribute<SomeAttribute>();
                    if (!some.Invoke(attr.GetValue(t)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    public class Test
    {
        [LongString(11)]
        public long _Phone { get; set; }

        [NoString]
        public string _Name { get; set; }
    }
}
