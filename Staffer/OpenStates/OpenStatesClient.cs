using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Staffer.OpenStates.Exceptions;
using Staffer.OpenStates.Models;
using Newtonsoft.Json;
using Staffer.Utilities;

namespace Staffer.OpenStates
{
    public class OpenStatesClient
    {
        private string _apiKey;
        
        public OpenStatesClient(string apiKey)
        {
            if (String.IsNullOrEmpty(apiKey)) throw new MissingApiKeyException() { HelpLink = "http://sunlightfoundation.com/api/",  };
            _apiKey = apiKey;
        }

        public async Task<List<Legislator>> FindLegislatorsByGeographyAsync(double latitude, double longitude)
        {
            ValidateGeoCoordinates(latitude, longitude);

            var requestUrl = String.Format("http://openstates.org/api/v1/legislators/geo/?lat={0}&long={1}&apikey={2}", latitude, longitude, _apiKey);
            var request = new ApiRequest(requestUrl);
            return JsonConvert.DeserializeObject<List<Legislator>>(await request.FetchJsonAsync());
        }

        public async Task<Legislator> FindLegislatorById(string legislatorId)
        {
            string requestUrl = String.Format("http://openstates.org/api/v1/legislators/{0}/?apikey={1}", legislatorId, _apiKey);
            var request = new ApiRequest(requestUrl);
            return JsonConvert.DeserializeObject<Legislator>(await request.FetchJsonAsync());
        }

        private void ValidateGeoCoordinates(double latitude, double longitude)
        {
            if (longitude <= -180 || longitude > 180)
                throw new ArgumentOutOfRangeException("longitude", longitude, "Value must be between -180 and 180 (inclusive).");

            if (latitude < -90 || latitude > 90)
                throw new ArgumentOutOfRangeException("latitude", latitude, "Value must be between -90(inclusive) and 90(inclusive).");

            if (double.IsNaN(longitude))
                throw new ArgumentException("Longitude must be a valid number.", "longitude");

            if (double.IsNaN(latitude))
                throw new ArgumentException("Latitude must be a valid number.", "latitude");
        }

       
    }
}
