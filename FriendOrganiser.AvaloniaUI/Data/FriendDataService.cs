using FriendOrganiser.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace FriendOrganiserUI.Data
{
    public class FriendDataService : IFriendDataService
    {
        private static readonly HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(5) };

        public async Task<IEnumerable<Friend>> GetAll()
        {
            try
            {
                var response = await client.GetAsync("http://localhost:7020/api/friend/all");
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var friends = JsonConvert.DeserializeObject<List<Friend>>(jsonString);

                return friends;
            }
            catch (HttpRequestException ex)
            {
                //MessageBox.Show("Error fetching data: " + ex.Message); // replace using MessageBox.Avalonia
                return new List<Friend>(); 
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Unexpected error: " + ex.Message); // replace using MessageBox.Avalonia
                return new List<Friend>(); 
            }
        }
    }
}