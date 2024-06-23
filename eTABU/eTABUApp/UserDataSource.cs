using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using Todo.Server.Utils;

namespace eTABUApp
{
    internal class UserDataSource
    {


        public static readonly HttpClient client = new HttpClient();



        public UserDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5118/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
    

        static async Task<int> Register(User user)  
        {


            HttpResponseMessage response = await client.PostAsJsonAsync(
                "register", user);
            response.EnsureSuccessStatusCode();

            int userResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                userResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return userResponse;
        }

        static async Task<int> Login(User user)
        {

            HttpResponseMessage response = await client.PostAsJsonAsync(
                "login", user);
            response.EnsureSuccessStatusCode();

            int userResponse = 0;
            if (response.IsSuccessStatusCode)
            {
                userResponse = DataSerializer.Deserialize<int>(await response.Content.ReadAsStringAsync())!;
            }
            return userResponse;
        }
    }
}
