using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            foo();

            Console.ReadLine();
        }

        private async static void foo ()
        {
            ReisekostenNative.RESTClient.RESTClient test = new ReisekostenNative.RESTClient.RESTClient();
            List<string> tmp = await test.GetTypesAsync();
            List<string> tmp2 = await test.GetStatiAsync();
            List<Beleg> tmp3n = await test.GetBelegeByUserAsync("hugo");
        }
    }
}
