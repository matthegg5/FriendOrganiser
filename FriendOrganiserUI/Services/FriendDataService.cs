﻿using FriendOrganiser.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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

        public async Task Save(Friend friend)
        {
            try
            {
                var jsonFriend = JsonConvert.SerializeObject(friend);

                // build POST request to API
                var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:7020/api/friend/");
                request.Headers.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(jsonFriend, Encoding.UTF8);
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                // send request to API and gather response
                var response = await client.SendAsync(request);

                // throw an exception if request not successful.
                response.EnsureSuccessStatusCode();

            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Error fetching data: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error: " + ex.Message);
            }
        }
    }
}
