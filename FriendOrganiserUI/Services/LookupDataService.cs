using System.Net.Http;
using System.Windows;
using FriendOrganiser.Model;
using Newtonsoft.Json;

namespace FriendOrganiserUI.Services
{
    public class LookupDataService : ILookupDataService
    {
        private static readonly HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            try
            {
                var response = await client.GetAsync("http://localhost:7020/api/lookup/friend-lookup");
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var lookupItems = JsonConvert.DeserializeObject<List<LookupItem>>(jsonString);

                return lookupItems;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
                return new List<LookupItem>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return new List<LookupItem>();
            }
        }
    }
}
