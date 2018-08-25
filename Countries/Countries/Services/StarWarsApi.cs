using Countries.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Services
{
    public class StarWarsApi
    {
        readonly string _api_base_url = "https://swapi.co/api/";

        public async Task<List<string>> GetPeopleAsync()
        {
            using (var client = new HttpClient())
            {
                //grab json from server
                var json = await client.GetStringAsync($"{ _api_base_url}people/");

                //Deserialize json
                var items = JsonConvert.DeserializeObject<List<string>>(json);

                //return the items
                return items;
            }
        }

        public async Task<string> GetByNameAsync(int person_id)
        {
            //grab json from server
            var json = await GetJsonData($"{_api_base_url}people/{person_id}");

            //Deserialize json
            var person = JsonConvert.DeserializeObject<string>(json);

            //return the items
            return person;
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
