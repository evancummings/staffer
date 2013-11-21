using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Staffer.Utilities
{
    public class ApiRequest
    {
        private string _endpoint;
        private HttpClient _httpClient;

        public ApiRequest(string endpoint)
        {
            _endpoint = endpoint;
            _httpClient = new HttpClient();
        }

        public async Task<string> FetchJsonAsync()
        {   
            var response = await _httpClient.GetAsync(_endpoint);
            response.EnsureSuccessStatusCode();

            return JsonSanitizer.Santize(await response.Content.ReadAsStringAsync());
        }
    }
}
