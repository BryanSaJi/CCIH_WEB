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
    public class ScheduleModel
    {
        UtilitiesModel apiEnviroment = new UtilitiesModel();

        public List<ScheduleEnt> RequestScheduleScrollDown()
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestScheduleScrollDown";//revisar
                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<ScheduleEnt>>().Result;
                }

                return new List<ScheduleEnt>();
            }

        }
    }
}