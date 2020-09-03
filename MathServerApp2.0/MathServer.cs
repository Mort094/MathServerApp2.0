using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MathServerApp2._0
{
    internal class MathServer
    {
        public void Start()
        {
            TcpListener server = new TcpListener(IPAddress.Loopback, 3002);
            server.Start();

            while (true)
            {
                TcpClient socket = server.AcceptTcpClient();
                Task.Run(() =>
                {
                    TcpClient tempSocket = socket;
                    DoClient(tempSocket);
                });
            }

        }

        private void DoClient(TcpClient socket)
        {
            NetworkStream ns = socket.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            while (true)
            {
                String str = sr.ReadLine();
                String[] vs = str.Split(' ');
                double x = Double.Parse(vs[1], new CultureInfo("da-DK"));
                double y = Double.Parse(vs[2], new CultureInfo("da-DK"));
                
                String strRetur = "Resultat = ";
                string test = vs[0];
                if (test == "add")
                {
                    double resultat = x + y;
                    sw.WriteLine(strRetur + resultat);
                    sw.Flush();
                } else if (test == "min")
                {
                    double resultat = x - y;
                    sw.WriteLine(strRetur + resultat);
                    sw.Flush();
                }

                
            }

        }
    }
}