using PCLStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.Services
{
    public class ConfigurationService
    {
        private static ConfigurationService instance;

        private const string DATADIRECTORY = "data";

        private Task<IFolder> datadirectoryCreationTask;

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

        public ConfigurationService()
        {
            InitialzeDataDirectory();
        }

        private void InitialzeDataDirectory()
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            datadirectoryCreationTask = rootFolder.CreateFolderAsync(DATADIRECTORY, CreationCollisionOption.OpenIfExists);
        }

        public String BelegserviceURL
        {
            get
            {
                return "http://52.169.65.115:8080";
            }
        }

        private string datadirectory;

        public string Datadirectory
        {
            get
            {
                if (datadirectory == null)
                {
                    datadirectory = datadirectoryCreationTask.Result.Path;
                }
                return datadirectory;
            }
        }
    }
}
