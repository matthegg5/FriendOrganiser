using FriendOrganiser.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace FriendOrganiserUI.Services
{
    public class FriendDataService : IFriendDataService
    {
        private static readonly HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };

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
                MessageBox.Show("Error fetching data: " + ex.Message);
                return new List<Friend>(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return new List<Friend>(); 
            }
        }

        public async Task<Friend> GetFriendById(int friendId)
        {
            try
            {
                var response = await client.GetAsync($"http://localhost:7020/api/friend/{friendId}");
                response.EnsureSuccessStatusCode();

                var jsonString = await response.Content.ReadAsStringAsync();
                var friends = JsonConvert.DeserializeObject<Friend>(jsonString);

                return friends;
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
                return new Friend(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
                return new Friend();
            }
        }
    }
}
