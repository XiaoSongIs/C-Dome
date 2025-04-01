using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable
namespace UseDelegate
{
    /// <summary>
    /// 事件的使用,委托的安全版本
    /// 只能使用 += ，在定义类的外部不能调运
    /// Event
    /// </summary>   
    
    /*
     * 自定义 
     * 1.定义一个委托
     * 2.定义一个类去实现
     * 3.订阅事件
     */

    class Use4
    {

        static void Main(string[] args)
        {
            //But but = new But("Hello World");
            //but.Clicked += (str) => Console.WriteLine(str);
            //but.Click();

            P p = new P();

            PScribuer pScribuer = new PScribuer("pScribuer", p);

            p.DoClick();

        }

    }

    class But
    {
        public string _str { get; set;}

        public But(string str)
        {
            _str = str;
        }

        public event Action<string> Clicked;

        public void Click() => Clicked?.Invoke(_str); // 触发事件
    }

    /*
     * 事件发布者
     * 定义委托事件，触发事件也写在里面
     */
    class P
    {
        public event EventHandler<EventAtgsMessage> Clicked;
        
        /// <summary>
        /// 在类的外部调用
        /// </summary>
        public void DoClick()
        {
            /*
             * 
             */
            Invoke(new EventAtgsMessage("DoClick"));
        }

        /// <summary>
        /// 写在虚方法中方便子类重写
        /// </summary>
        /// <param name="e"></param>
        protected virtual void Invoke(EventAtgsMessage e)
        {
            Clicked?.Invoke(this,e);
        }
    }

    /*
     * 订阅者
     * 事件方法的编写和订阅
     */
    class PScribuer
    {
        /// <summary>
        /// 订阅的实现
        /// </summary>
        /// <param name="str"></param>
        /// <param name="p">发布者</param>
        public PScribuer(string str , P p)
        {
            p.Clicked += HanderP;
            //p.DoClick();
            this.str = str;
        }
        private readonly string str;

        // 根据委托写方法  具体做的事情
        private void HanderP(object sender, EventAtgsMessage e)
        {
            Console.WriteLine("发布者" + sender +"订阅者" + str +"参数是"+e._message);
        }
    }

    class EventAtgsMessage : EventArgs 
    {
        public string _message { get; set;}
        public EventAtgsMessage(string message)
        {
            _message = message;
        }
    }
}
