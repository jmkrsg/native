using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.UWP.Model
{
    public enum ViewMode
    {
        Create,
        Edit,
        View
    }

    public class BelegDetailModel
    {
        public Beleg SelectedBeleg { get; set; }

        public ViewMode Mode { get; set; }
    }
}
