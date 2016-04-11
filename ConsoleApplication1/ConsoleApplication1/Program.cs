using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream,
                   ProtocolType.Unspecified);

            do
            {
                Console.WriteLine("podaj adres ip serva");
                String adres = Convert.ToString(Console.ReadLine());
                Console.WriteLine("podaj numer portu");
                int port = Convert.ToInt32(Console.ReadLine());

                try
                {
                    s.Connect(new IPEndPoint(IPAddress.Parse(adres), port));
                }
                catch (SocketException e)
                {
                    Console.WriteLine("bledny adres IP");
                }
                catch(FormatException e)
                {
                    Console.WriteLine("bledny adres IP");
                }

            } while (!s.IsBound);



                byte[] buffer = new byte[1024];
            while (true)
            {
                int result = s.Receive(buffer);
                String time = Encoding.ASCII.GetString(buffer, 0, result);

                Console.WriteLine(time);
                String napis = Convert.ToString(Console.ReadLine());
                byte[] toBytes = Encoding.ASCII.GetBytes(napis);
                s.Send(toBytes);
            }
        }
    }
}
