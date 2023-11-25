using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace CCIH.Models
{
    public class TeacherModel
    {
        UtilitiesModel apiEnviroment = new UtilitiesModel();

        public List<TeacherEnt> RequestTeacher()
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestTeacher";

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

 
       public int InsertOFF( TeacherEnt ent)
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/InsertOFF";
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

    }

}