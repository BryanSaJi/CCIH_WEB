
using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace CCIH.Models
{
    public class IdentificationsModel
    {


        public List<IdentificationsEnt> RequestIdentificationsScrollDown()
        {
            using (var custom = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RequestIdentificationsScrollDown";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<IdentificationsEnt>>().Result;
                }

                return new List<IdentificationsEnt>();
            }

        }

    }
}