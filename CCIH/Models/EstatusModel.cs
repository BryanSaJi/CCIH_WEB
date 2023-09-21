using API_CentroCultural.Entities;
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
    public class EstatusModel
    {

        public List<EstatusEnt> ConsultarEstatusListarRolesScrollDown()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarEstatusScrollDown";
                String Token = HttpContext.Current.Session["TokenUsuario"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<EstatusEnt>>().Result;
                }

                return new List<EstatusEnt>();
            }

        }

    }
}