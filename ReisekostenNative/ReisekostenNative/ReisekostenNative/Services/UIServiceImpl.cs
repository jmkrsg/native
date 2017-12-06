using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.Services
{
    public static class UIServiceImpl
    {
        public static IUIService UIServiceImplementation (bool direct = false)
        {
            if (direct)
            {
                return DirectService.Instance;
            }
            else
            {
                return UIService.Instance;
            }
        }
    }
}
