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
        readonly string _api_base_url = "https://restcountries.eu/rest/v2/all";

        public async Task<List<Country>> GetCountriesAsync()
        {
            using (var client = new HttpClient())
            {
                //grab json from server
                var json = await client.GetStringAsync("https://restcountries.eu/rest/v2/all");

                //Deserialize json
                var itens = JsonConvert.DeserializeObject<List<Country>>(json);

                //return the items
                return itens;
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
