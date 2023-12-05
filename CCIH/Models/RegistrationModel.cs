using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Models
{
    [Authorize]
    public class RegistrationModel
    {
        UtilitiesModel apiEnviroment = new UtilitiesModel();

        public int CreateRegistration(RegistrationEnt ent)
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/CreateRegstration";//revisar
                JsonContent body = JsonContent.Create(ent); //Serializar
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = custom.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

        public int CreatePreRegistration(PreRegistrationEnt ent)
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/CreatePreRegistration";
                JsonContent body = JsonContent.Create(ent); //Serializar
                HttpResponseMessage resp = custom.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }


        public List<PreRegistrationEnt> RequetsPreRegistrations()
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestPreRegistrations";

                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<PreRegistrationEnt>>().Result;
                }

                return new List<PreRegistrationEnt>();
            }

        }


        public List<RegistrationEnt> RequestRegistrations()
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestRegistrations";

                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<RegistrationEnt>>().Result;
                }

                return new List<RegistrationEnt>();
            }

        }

        public List<RegistrationEnt> RequestRegistrationsToday()
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestRegistrationsToday";

                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<RegistrationEnt>>().Result;
                }

                return new List<RegistrationEnt>();
            }

        }


        public RegistrationEnt RequestRegistration(long i)
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestRegistration?i=" + i;
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<RegistrationEnt>().Result;
                }

                return null;
            }
        }


        public int EditRegister(RegistrationEnt ent)
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/EditRegister?i=" + ent.RegistrationId;//revisar
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                JsonContent body = JsonContent.Create(ent); //Serializar
                HttpResponseMessage resp = custom.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

        public int ContactPreregister(PreRegistrationEnt ent)
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/ContactPreregister";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                JsonContent body = JsonContent.Create(ent); //Serializar
                HttpResponseMessage resp = custom.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

    


    }
}