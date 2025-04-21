using System.IO.Ports;

namespace UseSerialport
{
    internal class Program
    {
        /// <summary>
        /// 使用串口
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            SerialPort serialPort = new SerialPort();
            serialPort.PortName = "COM3";          // 设置串口名称 
            serialPort.BaudRate = 9600;           // 波特率
            serialPort.Parity = Parity.None;      // 校验位
            serialPort.DataBits = 8;              // 数据位
            serialPort.StopBits = StopBits.One;   // 停止位
            serialPort.Handshake = Handshake.None;
            serialPort.Open();


            
            serialPort.WriteLine("\r\n");
            serialPort.DataReceived += (sender, e) =>
            {
                try
                {
                    string data = serialPort.ReadExisting();
                    Console.WriteLine("收到ESP8266消息：" + data);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("读取串口数据出错：" + ex.Message);
                }
            };


            while (true)
            {
                Console.WriteLine("输入");
                string input = Console.ReadLine();
                serialPort.WriteLine(input);
            }

            Console.ReadLine();

            //// 获取当前可用的串口
            //string[] str = SerialPort.GetPortNames();

        }
    }
}
