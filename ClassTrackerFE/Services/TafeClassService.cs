using ClassTrackerFE.Models;
using ClassTrackerFE.Models.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ClassTrackerFE.Services
{
    public class TafeClassService
    {
        public static HttpClient _client;

        public TafeClassService()
        {
            // If the Http client has not been created yet
            if (_client == null)
            {
                // Creates a new client
                _client = new HttpClient();
                _client.BaseAddress = new Uri("https://localhost:44356/api/");
                // Dictates to the API which specific data to return to the front end. If no json, API will send nothing.
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        // Get all TafeClasses
        public List<TafeClass> GetTafeClasses()
        {
            var response = _client.GetAsync("TafeClass").Result;
            // Use this for DEBUG ONLY. This EnsureStatusCode should NOT be left in for production!
            response.EnsureSuccessStatusCode();
            var tafeClasses = response.Content.ReadAsAsync<List<TafeClass>>().Result;
            return tafeClasses;
        }

        // Get a single TafeClasses
        public TafeClass GetSingleTafeClass(int id)
        {
            var response = _client.GetAsync("TafeClass/" + id).Result;
            response.EnsureSuccessStatusCode();
            var tafeClass = response.Content.ReadAsAsync<TafeClass>().Result;
            return tafeClass;
        }

        // Get all tafe classes for a given teacher
        public List<TafeClass> GetTafeClassesForTeacher(int id)
        {
            var response = _client.GetAsync($"TafeClass/GetForTeacherId/{id}").Result;
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<List<TafeClass>>().Result;
        }

        // Create new TafeClass
        public void CreateTafeClass(TafeClassCreate tafeClass)
        {
            var response = _client.PostAsJsonAsync("TafeClass", tafeClass).Result;
            // REMOVE. TESTING ONLY
            response.EnsureSuccessStatusCode();
        }

        // Update a TafeClass

        // Delete a TafeClass
    }
}
