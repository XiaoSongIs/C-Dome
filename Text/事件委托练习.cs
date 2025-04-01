using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace Text
{
    class 事件委托练习
    {
        /*
         * 当用户完成某些操作（如注册、下单），
         * 系统应该触发通知（如邮件、短信、推送）。
         * 不同类型的通知方式可能会动态添加或移除。
         */

        /// <summary>
        /// 用户操作
        /// </summary>
        public class User
        {
            public int _id { get; set; }
            public string _name { get; set; }
            public string _controls { get; set; }
        }

        
        public delegate void UserAction(User user);

        /// <summary>
        /// 发布者
        /// </summary>
        public class P
        {
            public event UserAction UserActionEvent;


            public void Subscribe(UserAction userA)
            {
                UserActionEvent += userA;
            }

            public void Unsubscribe(UserAction userA)
            {
                UserActionEvent -= userA;
            }

            public void DoInvoke(User user)
            {
                OnInvoke(user);
            }

            protected virtual void OnInvoke(User user)
            {
                UserActionEvent?.Invoke(user);
            }
        }

        /// <summary>
        /// 订阅者
        /// </summary>
        public class PEmailNotifier
        {
            public PEmailNotifier(P p)
            {
                //p.UserActionEvent += Invoke;
                p.Subscribe(Invoke);
            }

            public void Invoke(User user)
            {
                Console.WriteLine("发送邮件");
            }
        }

        public class PSMSNotifier
        {
            public PSMSNotifier(P p)
            {
                p.Subscribe(Invoke);
            }

            public void Invoke(User user)
            {
                Console.WriteLine("发送短信");
            }
        }

        public class PPushNotifier
        {
            public PPushNotifier(P p)
            {
                p.Subscribe(Invoke);
            }

            public void Invoke(User user)
            {
                Console.WriteLine("发送推送");
            }
        }


    }
}
