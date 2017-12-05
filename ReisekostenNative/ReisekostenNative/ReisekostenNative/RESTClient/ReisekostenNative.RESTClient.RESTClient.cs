using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ReisekostenNative.RESTClient
{
    public class RESTClient
    {
        Uri baseUri;

		public RESTClient()
        {
			// get from config
			this.baseUri = new Uri("http://52.169.65.115:8080");
        }

		public async Task<List<string>> GetTypesAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = this.baseUri;
            try
            {
                var response = await client.GetAsync("belegerfassung-ui/rest/belege/types");
                var content = await response.Content.ReadAsStringAsync();
                List<string> types = JsonConvert.DeserializeObject<List<string>>(content);
                return types;
            }
            catch (Exception ex)
            {
                int i = 0;
                return null;
            }
        }
    }
}
