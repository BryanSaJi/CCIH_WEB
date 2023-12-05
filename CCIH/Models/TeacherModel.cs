﻿using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.RegularExpressions;
using System.Web;

namespace CCIH.Models
{
    public class TeacherModel
    {
        UtilitiesModel apiEnviroment = new UtilitiesModel();

        public List<TeacherEnt> RequestTeachers()
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestTeachers";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<TeacherEnt>>().Result;
                }

                return new List<TeacherEnt>();
            }
        }

 
       public int InsertMark( TeacherEnt ent)
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/InsertMark";
                JsonContent body = JsonContent.Create(ent); 
                HttpResponseMessage resp = custom.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

      
        public int EntryMark(TeacherEnt ent)
        {
          using (var custom = new HttpClient())
          {
           string url = apiEnviroment.getApiUrl() + "api/EntryMark";
           JsonContent body = JsonContent.Create(ent);
           HttpResponseMessage resp = custom.PostAsync(url, body).Result;

           if (resp.IsSuccessStatusCode)
           {

                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

            return 0;
          }
        }

        public int ExitMark(TeacherEnt ent)
{
          using (var custom = new HttpClient())
          {
             string url = apiEnviroment.getApiUrl() + "api/ExitMark";
            JsonContent body = JsonContent.Create(ent);
            HttpResponseMessage resp = custom.PostAsync(url, body).Result;

            if (resp.IsSuccessStatusCode)
            {

                    return resp.Content.ReadFromJsonAsync<int>().Result;
            }

            return 0;
          }
        }


        public List<TeacherEnt> MarkHistory()
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/MarkHistory";

                //String Token = HttpContext.Current.Session["TokenUser"].ToString();
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<TeacherEnt>>().Result;
                }

                return new List<TeacherEnt>();
            }
        }

        public List<TeacherEnt> TotalWorkHours()
        {
            using (var client = new HttpClient())
            {
                 string url = apiEnviroment.getApiUrl() + "api/TotalWorkHours";
                 HttpResponseMessage resp = client.GetAsync(url).Result;
                 if (resp.IsSuccessStatusCode)
                {
                  return resp.Content.ReadFromJsonAsync<List<TeacherEnt>>().Result;
                }

                return new List<TeacherEnt>();
            }
        }

        public List<TeacherEnt> SeeOfficeLoByTeacher(long i)
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/SeeOfficeLoByTeacher?i=" + i;
                HttpResponseMessage resp = client.GetAsync(url).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<TeacherEnt>>().Result;
                }

                return new List<TeacherEnt>();
            }
        }



    }

}