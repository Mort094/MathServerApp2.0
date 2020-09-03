using System;

namespace MathServerApp2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            MathServer worker = new MathServer();
            worker.Start();

            Console.ReadLine();
        }
    }
}
