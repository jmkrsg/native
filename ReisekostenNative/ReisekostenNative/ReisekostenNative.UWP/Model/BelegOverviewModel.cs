using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.UWP.Model
{
    public class BelegOverviewModel
    {
        public List<IO.Swagger.Model.Beleg> BelegListe { get; set; }

        public string Username { get; set; }
    }
}
