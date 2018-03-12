using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServiceReference1.AccountServiceClient();
            Console.WriteLine(client.Register(null));
        }
    }
}
