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
            Beleg testBeleg = new Beleg();
            //testBeleg.BelegSize = 10;
            //testBeleg.Betrag = 11;
            testBeleg.Description = "servus";
            testBeleg.Status = Beleg.StatusEnum.ERFASST;
            //testBeleg.Belegnummer = 12;
            //testBeleg.Thumbnail = null;
            testBeleg.Type = "Hotel";
            testBeleg.Date = DateTime.UtcNow;
            int tmp4 = await test.CreateBeleg("hugo", testBeleg);
            List<Beleg> tmp3n = await test.GetBelegeByUserAsync("hugo");
            Beleg b = tmp3n.First();
            test.UpdateImage("hugo", b.Belegnummer.Value, new byte[] { 232, 23, 54, 87 });
            tmp3n = await test.GetBelegeByUserAsync("hugo");
            b = tmp3n.FirstOrDefault(h => h.Thumbnail != null);
        }
    }
}
