using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO.Swagger.Model;

namespace ReisekostenNative.Services
{
    public class DirectService : IUIService
    {
        private static DirectService instance;

        private RESTClient.RESTClient client;

        public static DirectService Instance
        {
            get
            {
                return instance ?? (instance = new DirectService());
            }
        }

        private DirectService() {
            client = new RESTClient.RESTClient();
        }

        public void CreateBeleg(Beleg beleg, Action<Task<int>> callback)
        {
            throw new NotImplementedException();
        }

        public void Export(string user, Action<Task<List<Beleg>>> callback)
        {
            throw new NotImplementedException();
        }

        public void GetBelegarten(Action<Task<List<string>>> callback)
        {
            client.GetTypesAsync().ContinueWith((o) => callback(o));
        }

        public void GetBelege(string user, Action<Task<List<Beleg>>> callback)
        {
            throw new NotImplementedException();
        }

        public void GetBelegStati(Action<Task<List<string>>> callback)
        {
            this.client.GetStatiAsync().ContinueWith((o) => callback(o));
        }

        public void GetExported(string user, Action<Task<List<Beleg>>> callback)
        {
            throw new NotImplementedException();
        }

        public void UpdateBeleg(Beleg beleg)
        {
            throw new NotImplementedException();
        }
    }
}
