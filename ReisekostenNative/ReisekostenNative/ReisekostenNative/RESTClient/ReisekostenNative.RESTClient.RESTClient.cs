using IO.Swagger.Model;
using Newtonsoft.Json;
using ReisekostenNative.Services;
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
            ConfigurationService configService = new ConfigurationService();
			// get from config
			this.baseUri = new Uri(configService.BelegserviceURL);
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

        public async Task<List<string>> GetStatiAsync()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = this.baseUri;
            try
            {
                var response = await client.GetAsync("belegerfassung-ui/rest/belege/status");
                var content = await response.Content.ReadAsStringAsync();
                List<string> stati = JsonConvert.DeserializeObject<List<string>>(content);
                return stati;
            }
            catch (Exception ex)
            {
                int i = 0;
                return null;
            }
        }

        public async Task<List<Beleg>> GetBelegeByUserAsync(string user)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = this.baseUri;
            try
            {
                var response = await client.GetAsync($"belegerfassung-ui/rest/belege/{user}");
                var content = await response.Content.ReadAsStringAsync();
                List<Beleg> belege = JsonConvert.DeserializeObject<List<Beleg>>(content);
                return belege;
            }
            catch (Exception ex)
            {
                int i = 0;
                return null;
            }
        }

        public async Task<Beleg> GetBelegeByUserAndNumberAsync(string user, int belegNummer)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = this.baseUri;
            try
            {
                var response = await client.GetAsync($"belegerfassung-ui/rest/belege/{user}/{belegNummer}");
                var content = await response.Content.ReadAsStringAsync();
                Beleg beleg = JsonConvert.DeserializeObject<Beleg>(content);
                return beleg;
            }
            catch (Exception ex)
            {
                int i = 0;
                return null;
            }
        }

        public async Task<int> CreateBeleg(string user, Beleg beleg)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = this.baseUri;
            try
            {
                var json = JsonConvert.SerializeObject(beleg);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"belegerfassung-ui/rest/belege/{user}", content);
                var responseContent = await response.Content.ReadAsStringAsync();
                return Convert.ToInt32(responseContent);
            }
            catch (Exception ex)
            {
                int i = 0;
                return 0;
            }
        }

        public async void UpdateBeleg(string user, int belegNummer, Beleg beleg)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = this.baseUri;
            try
            {
                var json = JsonConvert.SerializeObject(beleg);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PutAsync($"belegerfassung-ui/rest/belege/{user}/{belegNummer}", content);
            }
            catch (Exception ex)
            {
                int i = 0;
            }
        }

        public async Task<byte[]> GetBelegImage(string user, int belegNummer)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = this.baseUri;
            try
            {
                var response = await client.GetAsync($"belegerfassung-ui/rest/belege/{user}/{belegNummer}/beleg");
                var content = await response.Content.ReadAsByteArrayAsync();
                return content;
            }
            catch (Exception ex)
            {
                int i = 0;
                return null;
            }
        }

        public async Task<byte[]> UpdateImage(string user, int belegNummer, byte[] image)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = this.baseUri;
            try
            {
                var content = new ByteArrayContent(image);

                var response = await client.PutAsync($"belegerfassung-ui/rest/belege/{user}/{belegNummer}/beleg", content);
                var thumbnail = await response.Content.ReadAsByteArrayAsync();
                return thumbnail;
            }
            catch (Exception ex)
            {
                int i = 0;
                return null;
            }
        }

        public async void DeleteImage(string user, int belegNummer)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = this.baseUri;
            try
            {
                var response = await client.DeleteAsync($"belegerfassung-ui/rest/belege/{user}/{belegNummer}");
            }
            catch (Exception ex)
            {
                int i = 0;
            }
        }
    }
}
