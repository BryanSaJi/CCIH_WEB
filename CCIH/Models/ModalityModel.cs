﻿using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace CCIH.Models
{
    public class ModalityModel
    {
        UtilitiesModel apiEnviroment = new UtilitiesModel();

        public List<ModalityEnt> RequestModalityScrollDown()
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestModalityScrollDown";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<ModalityEnt>>().Result;
                }

                return new List<ModalityEnt>();
            }

        }
    }
}