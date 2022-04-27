using ClassTrackerFE.Models;
using ClassTrackerFE.Models.DTO;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ClassTrackerFE.Services
{
    public class TeacherService
    {
        public static HttpClient _client;

        public TeacherService()
        {
            // If the Http client has not been created yet
            if(_client == null)
            {
                // Creates a new client
                _client = new HttpClient();
                _client.BaseAddress = new Uri("https://localhost:44356/api/");
                // Dictates to the API which specific data to return to the front end. If no json, API will send nothing.
                _client.DefaultRequestHeaders.Clear();
                _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            }
        }
        // Get all Teachers
        public List<Teacher> GetTeachers()
        {
            var response = _client.GetAsync("Teacher").Result;
            // Use this for DEBUG ONLY. This EnsureStatusCode should NOT be left in for production!
            response.EnsureSuccessStatusCode();
            var teachers = response.Content.ReadAsAsync<List<Teacher>>().Result;
            return teachers;
        }

        // Get a single Teacher
        public Teacher GetSingleTeacher(int id)
        {
            var response = _client.GetAsync("Teacher/" + id).Result;
            response.EnsureSuccessStatusCode();
            var teacher = response.Content.ReadAsAsync<Teacher>().Result;
            return teacher;
        }

        // Create new Teacher
        public void CreateTeacher(TeacherCreate teacher)
        {
            var response = _client.PostAsJsonAsync("Teacher", teacher).Result;
            // REMOVE. TESTING ONLY
            response.EnsureSuccessStatusCode();
        }

        // Update a Teacher

        // Delete a Teacher
    }
}
