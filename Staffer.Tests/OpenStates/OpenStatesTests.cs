using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Staffer.OpenStates;
using Staffer.OpenStates.Exceptions;

namespace Staffer.Tests.OpenStates
{
    [TestFixture]
    class OpenStatesTests
    {
        private const string ApiKey = "eee5c15bce4f4ad4adf360f15c84e3ab";
        private OpenStatesClient _client;

        public OpenStatesTests()
        {
            _client = new OpenStatesClient(ApiKey);

        }

        [TestCase]
        public async void Get_Legislators_For_43016()
        {
            //Dublin, OH 43016 | 40.1249, -83.0956
            var results = await _client.FindLegislatorsByGeographyAsync(40.1249, -83.0956);
            Assert.True(results.Any());
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async void Failure_On_Upper_Latitude_Bounds()
        {
            await _client.FindLegislatorsByGeographyAsync(91, 50);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async void Failure_On_Lower_Latitude_Bounds()
        {
            await _client.FindLegislatorsByGeographyAsync(-91, 50);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async void Failure_On_Upper_Longitude_Bounds()
        {
            await _client.FindLegislatorsByGeographyAsync(50, 181);
        }

        [TestCase]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public async void Failure_On_Lower_Longitude_Bounds()
        {
            await _client.FindLegislatorsByGeographyAsync(50, -181);
        }

        [TestCase]
        public void Failure_On_Null_Api_Key()
        {
            var ex = Assert.Throws<MissingApiKeyException>(() => new OpenStatesClient(String.Empty));
            Console.WriteLine(ex);
        }

        [TestCase]
        public void Failure_On_Empty_Api_Key()
        {
            var ex = Assert.Throws<MissingApiKeyException>(() => new OpenStatesClient(String.Empty));
            Console.WriteLine(ex);
        }
    }
}
