﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eTABU.Server;

namespace eTABUApp
{
    public class eTABUDataSource
    {

        public static readonly HttpClient client = new HttpClient();

        public eTABUDataSource()
        {
            client.BaseAddress = new Uri("http://localhost:5113/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<eTABU>> GetTABUs()
        {

            HttpResponseMessage response = await client.GetAsync(
                "api/TabuModels");
            response.EnsureSuccessStatusCode();

            List<eTABU> SongResponse = new List<eTABU>();
            if (response.IsSuccessStatusCode)
            {
                SongResponse = DataSerializer.Deserialize<List<eTABU>>(await response.Content.ReadAsStringAsync())!;
            }
            return SongResponse;
        }


    }
}

