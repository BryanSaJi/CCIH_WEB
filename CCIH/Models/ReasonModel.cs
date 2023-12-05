using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Web;

namespace CCIH.Models
{
    public class ReasonModel
    {
        UtilitiesModel apiEnviroment = new UtilitiesModel();

        public List<ReasonEnt> RequestReasonScrollDown()
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestReasonScrollDown";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<ReasonEnt>>().Result;
                }

                return new List<ReasonEnt>();
            }

        }

    }
}