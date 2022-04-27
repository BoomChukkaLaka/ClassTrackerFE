using ClassTrackerFE.Models;
using ClassTrackerFE.Models.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ClassTrackerFE.Services
{
    public class UnitService
    {
        public static HttpClient _client;

        public UnitService()
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
        // Get all Units
        public List<Unit> GetUnits()
        {
            var response = _client.GetAsync("Unit").Result;
            // Use this for DEBUG ONLY. This EnsureStatusCode should NOT be left in for production!
            response.EnsureSuccessStatusCode();
            var units = response.Content.ReadAsAsync<List<Unit>>().Result;
            return units;
        }

        // Get a single Unit
        public Unit GetSingleUnit(int id)
        {
            var response = _client.GetAsync("Unit/" + id).Result;
            response.EnsureSuccessStatusCode();
            var unit = response.Content.ReadAsAsync<Unit>().Result;
            return unit;
        }

        // Create new Unit
        public void CreateUnit(UnitCreate unit)
        {
            var response = _client.PostAsJsonAsync("Unit", unit).Result;
            // REMOVE. TESTING ONLY
            response.EnsureSuccessStatusCode();
        }

        // Update a Unit

        // Delete a Unit
    }
}
