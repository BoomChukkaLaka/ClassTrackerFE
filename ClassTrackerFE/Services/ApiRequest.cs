using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ClassTrackerFE.Services
{
    public class ApiRequest<T> : IApiRequest<T>
    {
        // HttpClient
        private readonly HttpClient _client;
        // Store a reference to the HttpContext
        private readonly HttpContext _context;

        public ApiRequest(IHttpClientFactory httpClientFactory, IHttpContextAccessor accessor)
        {
            // Save the injected HttpContext
            _context = accessor.HttpContext;
            _client = httpClientFactory.CreateClient("ApiClient");

            // If we have a token
            if(_context.Session.GetString("Token") != null)
            {
                // Write the token to the authorisation header
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _context.Session.GetString("Token"));
            }
        }

        // Generic GetAll
        public List<T> GetAll(string controllerName)
        {
            var response = _client.GetAsync(controllerName).Result;
            // Use this for DEBUG ONLY. This EnsureStatusCode should NOT be left in for production!
            response.EnsureSuccessStatusCode();
            var entities = response.Content.ReadAsAsync<List<T>>().Result;
            return entities;
        }

        // Generic GetSingle
        public T GetSingle(string controllerName, int id)
        {
            var response = _client.GetAsync(controllerName + "/" + id).Result;
            response.EnsureSuccessStatusCode();
            var entity = response.Content.ReadAsAsync<T>().Result;
            return entity;
        }

        // Generic Create
        public T Create(string controllerName, T entity)
        {
            var response = _client.PostAsJsonAsync(controllerName, entity).Result;
            // REMOVE. TESTING ONLY
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<T>().Result;
        }

        // Generic Edit
        public T Edit(string controllerName, int id, T entity)
        {
            var response = _client.PutAsJsonAsync(controllerName + "/" + id, entity).Result;
            // REMOVE. TESTING ONLY
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsAsync<T>().Result;
        }

        // Generic Delete
        public void Delete(string controllerName, int id)
        {
            var response = _client.DeleteAsync(controllerName + "/" + id).Result;
            // REMOVE. TESTING ONLY
            response.EnsureSuccessStatusCode();
        }
    }
}
