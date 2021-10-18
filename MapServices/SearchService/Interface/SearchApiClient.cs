using Newtonsoft.Json;
using SearchService.ViewModels;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;

namespace SearchService.Interface
{
    public class SearchApiClient : ISearchApiClient
    {
        private readonly IMemoryCache _cache;
        private readonly IConfiguration _configuration;
        private readonly string tokenCacheKey;
        private readonly HttpClient httpClient;

      

        public SearchApiClient(IConfiguration configuration, IMemoryCache memoryCache)
        {
            _configuration = configuration;
            _cache = memoryCache;
            tokenCacheKey = "GISToken";
            httpClient = new HttpClient();
        }

        public async Task<List<SearchView>> GetSearchAsync(string address)
        {
            using (var response = await httpClient.GetAsync($"{_configuration.GetValue<string>("GISLocationSearchAPI")}?" +
                $"address={address.Replace(",", " ")}&f=json&token={await GetToken()}&outFields=PlaceName,Place_addr"))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = JsonConvert.DeserializeObject<GISSearchResultModel>(await response.Content.ReadAsStringAsync());
                    return result.candidates.Select(location => new SearchView
                    {
                        Place = location.attributes.PlaceName,
                        PlaceAddress = location.attributes.Place_addr,
                        LocationInfo = new SearchView.Location
                        {
                            Longitude = location.location.x,
                            Latitude = location.location.y
                        }
                    }).ToList();
                }
                else
                    throw new UnauthorizedAccessException($"GIS token access error - {await response.Content.ReadAsStringAsync()}");
            }

        }


        private async Task<string> GetToken()
        {
            if (!_cache.TryGetValue(tokenCacheKey, out GISAuthTokenModel gisToken))
            {
                // Key not in cache, so get data.
                gisToken = await GenerateGISToken();

                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromSeconds(gisToken.expires_in));

                // Save data in cache.
                _cache.Set(tokenCacheKey, gisToken, cacheEntryOptions);
            }
            return gisToken.access_token;
        }

        private async Task<GISAuthTokenModel> GenerateGISToken()
        {
            List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
            postData.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
            postData.Add(new KeyValuePair<string, string>("client_id", _configuration.GetValue<string>("GISCredentials:ClientId")));
            postData.Add(new KeyValuePair<string, string>("client_secret", _configuration.GetValue<string>("GISCredentials:ClientSecret")));

            using (var response = await httpClient.PostAsync(_configuration.GetValue<string>("GISCredentials:AuthURL"),
                new FormUrlEncodedContent(postData)))
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<GISAuthTokenModel>(await response.Content.ReadAsStringAsync());
                }
                else
                    throw new UnauthorizedAccessException($"GIS token access error - {await response.Content.ReadAsStringAsync()}");
            }
        }

       
    }
}
