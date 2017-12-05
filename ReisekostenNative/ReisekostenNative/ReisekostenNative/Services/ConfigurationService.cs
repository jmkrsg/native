using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.Services
{
    class ConfigurationService
    {
        private static ConfigurationService instance;

        public static ConfigurationService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationService();
                }
                return instance;
            }
        }

        public String BelegserviceURL
        {
            get
            {
                return "52.169.65.115:8080";
            }
        }

        private string datadirectory;

        public String Datadirectory
        {
            get
            {
                if (datadirectory == null)
                {
                    IFolder rootFolder = FileSystem.Current.LocalStorage;


                }
                return datadirectory;
            }
        }
    }
}
