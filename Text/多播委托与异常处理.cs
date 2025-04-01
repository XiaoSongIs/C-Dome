using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace Text
{
    class 多播委托与异常处理
    {
        /*
         * 在某些情况下，多个方法订阅了同一个委托，
         * 但如果其中一个方法抛出异常，不应该影响其他方法的执行。
         */
        public class P1
        {   
            //public delegate void ActionHandler();
            public Action ActionHandler;

            public List<Action> list = new List<Action>();

            public void Subscribe(Action action)
            {
                //list.Add(action);
                ActionHandler += action;
            }

            public void Invoke()
            {
                //foreach (var item in list)
                //{
                //    try
                //    {
                //        item.Invoke();
                //    }
                //    catch (Exception ex)
                //    {

                //    }
                //}

                if (ActionHandler == null)
                {
                    Console.WriteLine("⚠️ 没有订阅的方法");
                    return;
                }

                foreach (Delegate d in ActionHandler.GetInvocationList())
                {
                    try
                    {
                       
                        ((Action)d).Invoke();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"❌ 方法 {d.Method.Name} 发生异常: {ex.Message}");
                    }
                }

            }

            public void Text1()
            {
                Console.WriteLine("多播方法1");
            }
            public void Text2()
            {
                throw new Exception("异常");
            }
            public void Text3()
            {
                Console.WriteLine("多播方法3");
            }
        }
    }
}
