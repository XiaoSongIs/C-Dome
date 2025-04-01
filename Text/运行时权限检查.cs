using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace Text
{
    public class 运行时权限检查
    {
        /*
         * 某些方法需要特定权限才能访问，例如 Admin 角色才能调用 DeleteUser()方法
         */
        public class P2
        {
            [RequirePermission("Admin")]
            public string _jurisdiction { get; set; }
        }

        [AttributeUsage(AttributeTargets.Property)]
        public class RequirePermissionAttribute : Attribute
        {
            public string _str { get; set; }
            public RequirePermissionAttribute(string str)
            {
                this._str = str;
            }

            public bool IsAdmin()
            {
                return _str!=null && _str.Equals("Admin");
            }
        }

        public static class Permission
        {
            public static bool Invoke<T>(T t)
            {
                Type type = t.GetType();

                foreach (PropertyInfo item in type.GetProperties())
                {
                    if (item.IsDefined(typeof(RequirePermissionAttribute), true))
                    {
                        RequirePermissionAttribute require1 =
                     item.GetCustomAttribute<RequirePermissionAttribute>();

                        var res = item.GetValue(t, null);
                        if (require1.IsAdmin() && res.Equals("Admin"))
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
        }

    }
}
