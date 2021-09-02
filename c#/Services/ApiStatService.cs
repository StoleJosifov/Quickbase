using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Backend.Services
{
    public class ApiStatService : IApiStatService
    {
        private static readonly HttpClient Client = new HttpClient();

        public async Task<List<Tuple<string, int>>> GetCountryPopulationsAsync()
        {
            List<Tuple<string, int>> product = null;
            HttpResponseMessage response = await Client.GetAsync("https://cney361r8b.execute-api.eu-central-1.amazonaws.com/default/StatService");

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<List<Tuple<string, int>>>(responseString);
            }

            return product;
        }
	}
}
