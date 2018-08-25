using Countries.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Services
{
    public class CountriesApi
    {
        readonly string _api_base_url = "https://restcountries.eu/rest/v2";

        public async Task<List<string>> GetCountriesAsync()
        {
            using (var client = new HttpClient())
            {
                //grab json from server
                var json = await client.GetStringAsync($"{_api_base_url}/all");

                //Deserialize json
                var items = JsonConvert.DeserializeObject<List<string>>(json);

                //return the items
                return items;
            }
        }

        public async Task<Country> GetByNameAsync(string name)
        {
            //grab json from server
            var json = await GetJsonData($"{_api_base_url}/name/{name}");

            //Deserialize json
            var joke = JsonConvert.DeserializeObject<Country>(json);

            //return the items
            return joke;
        }

        async Task<string> GetJsonData(string url)
        {
            using (var client = new HttpClient())
            {
                var json = await client.GetStringAsync(url);
                return json;
            }
        }

    }
}
