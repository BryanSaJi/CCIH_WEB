using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using CCIH.Entities.Administracion;

namespace CCIH.Models
{
    public class ClienteModel
    {
        public int RegistrarCliente(ClienteEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RegistrarCliente";
                String Token = HttpContext.Current.Session["TokenUsuario"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

    }
}