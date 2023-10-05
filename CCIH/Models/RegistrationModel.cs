using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using CCIH.Entities.Administration;

namespace CCIH.Models
{
    public class RegistrationModel
    {
        public int CreateRegistration(RegistrationEnt ent)
        {
            using (var custom = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/CreateRegstration";//revisar
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
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/CreatePreRegistration";
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
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RequestPreRegistrations";

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
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RequetRegistrations";

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
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RequetRegistrationsToday";

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


        public RegistrationEnt RequetRegistrations(long i)
        {
            using (var custom = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RequetRegistration" + i;
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
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/EditRegister" + ent.IdRegistration;//revisar
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
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ContactPreregister";
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