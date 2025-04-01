using static Text.事件委托练习;
using static Text.多播委托与异常处理;
using static Text.运行时权限检查;
namespace Text
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1 
            /*
              User user = new User { _id = 1, _name = "张三", _controls = "注册" };
              P p = new P();

              PEmailNotifier pEmailNotifier = new PEmailNotifier(p);
              PSMSNotifier pSMSNotifier = new PSMSNotifier(p);
              PPushNotifier pPushNotifier = new PPushNotifier(p);

              Console.WriteLine("1------------------------------");
              p.DoInvoke(user);
              p.Unsubscribe(pEmailNotifier.Invoke);
              Console.WriteLine("2------------------------------");
              p.DoInvoke(user);
             */

            //2
            //P1 p = new P1();
            //p.Subscribe(p.Text1);
            //p.Subscribe(p.Text2);
            //p.Subscribe(p.Text3);
            //p.Invoke();

            //3
            P2 p2 = new P2 { _jurisdiction = "Admin" };
            Console.WriteLine(Permission.Invoke(p2).ToString());

        }
    }
}
