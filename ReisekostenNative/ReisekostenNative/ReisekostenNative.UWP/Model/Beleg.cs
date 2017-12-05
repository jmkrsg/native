using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.UWP.Model
{
    public class Beleg
    {
        public string Id { get; set; }
        public DateTime Belegdatum { get; set; }
        public string Belegart { get; set; }
        public Decimal Betrag { get; set; }
        public string Bezeichnung { get; set; }
        public string Status { get; set; }
    }
}
