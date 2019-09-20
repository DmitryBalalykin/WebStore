using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebStore.Clients.Base;
using WebStore.Interface.Api;
using System.Net.Http.Headers;

namespace WebStore.Clients.Value
{
    public class ValuesClient : BaseClient, IValueService
    {

        public ValuesClient(IConfiguration configuration) : base(configuration, "api/values") { }

        public async Task<IEnumerable<string>> GetAsync()
        {
            var response = await _Client.GetAsync(_ServiceAddress);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<List<string>>();

            return new string[0];
        }

        public IEnumerable<string> Get() => GetAsync().Result;

        public string Get(int id) => GetAsync(id).Result;
        public async Task<string> GetAsync(int id)
        {
            var response = await _Client.GetAsync($"{_ServiceAddress}/get/{id}");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<string>();

            return string.Empty;
        }

        public Uri Post(string value) => Post(value);
        public async Task<Uri> PostAsync(string value)
        {
            var response =await _Client.PostAsJsonAsync($"{_ServiceAddress}/post", value);

            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public HttpStatusCode Put(int id, string value) => Put(id, value);
        public async Task<HttpStatusCode> PutAsync(int id, string value)
        {
            var response = await _Client.PutAsJsonAsync($"{_ServiceAddress}/put/{id}", value);

            return response.EnsureSuccessStatusCode().StatusCode;
        }

        public HttpStatusCode Delete(int id) => DeleteAsync(id).Result;

        public async Task<HttpStatusCode> DeleteAsync(int id)
        {
            var response = await _Client.DeleteAsync($"{_ServiceAddress}/delete/{id}");
            return response.StatusCode;
        }
    }
}
