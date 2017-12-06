using IO.Swagger.Model;
using ReisekostenNative.UWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.UWP.ViewParams
{

    class DetailViewParams
    {
        public string Username { get; set; }

        public Beleg Beleg { get; set; }

        public ViewMode Mode { get; set; }

    }
}
