using ReisekostenNative.UWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.UWP.Help
{
    class BelegGenerator
    {
        public List<Beleg> GenerateData(int count)
        {
            List<Beleg> result = new List<Beleg>();
            for (int i = 0; i < count; i++)
            {
                Beleg b = new Beleg();
                b.Belegart = "Testbelegart " + ((i%3)+1);
                b.Id = (i+1000).ToString();
                b.Betrag = (100/(i%5+1)) + i + ((i%9)/10);
                b.Bezeichnung = "Testbeleg " + (i+1);
                b.Status = "OK";
                result.Add(b);
            }
            return result;
        }
    }
}
