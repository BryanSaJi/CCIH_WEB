﻿using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CCIH.Models
{
    public class PaymentsModel
    {
        UtilitiesModel apiEnviroment = new UtilitiesModel();
        [AllowAnonymous]
        public List<PaymentsEnt> RequestPayment()
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestPayment";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<PaymentsEnt>>().Result;
                }

                return new List<PaymentsEnt>();
            }

        }

        public int CreatePayment(PaymentsEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/CreatePayment";
                JsonContent body = JsonContent.Create(entidad); 
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }


        public int EditPayment(PaymentsEnt i)
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/EditPayment";
                JsonContent body = JsonContent.Create(i); 
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.PutAsync(url, body).Result;
                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }


        public PaymentsEnt RequestPayment(long i)
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestPayment?i=" + i;
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<PaymentsEnt>().Result;
                }

                return null;
            }
        }


        public int DeletePayment(long i)
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/DeletePayment?i=" + i;
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.DeleteAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }


        public List<PaymentsEnt> RequestPaymentsScrollDown()
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestPaymentsScrollDown";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<PaymentsEnt>>().Result;
                }

                return new List<PaymentsEnt>();
            }

        }


        public PaymentsEnt RequestPaymentById(string PaymentsId)
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestPaymentById?PaymentsId=" + PaymentsId;
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<PaymentsEnt>().Result;
                }

                return null;
            }
        }


        public List<PaymentsEnt> RequestPaymentTypeScrollDown()
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestPaymentTypeScrollDown";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<PaymentsEnt>>().Result;
                }

                return new List<PaymentsEnt>();
            }

        }


        //public List<PaymentsEnt> RequestReasonScrollDown()
        //{
        //    using (var custom = new HttpClient())
        //    {
        //        string url = apiEnviroment.getApiUrl() + "api/RequestReasonScrollDown";
        //        String Token = HttpContext.Current.Session["TokenUser"].ToString();
        //        custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
        //        HttpResponseMessage resp = custom.GetAsync(url).Result;

        //        if (resp.IsSuccessStatusCode)
        //        {
        //            return resp.Content.ReadFromJsonAsync<List<PaymentsEnt>>().Result;
        //        }

        //        return new List<PaymentsEnt>();
        //    }

        //}
         

        public List<PaymentsEnt> RequestIncomeOutcomeScrollDown()
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestIncomeOutcomeScrollDown";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<PaymentsEnt>>().Result;
                }

                return new List<PaymentsEnt>();
            }

        }

         
        public List<PaymentsEnt> RequestPaymentMotiveScrollDown()
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestPaymentMotiveScrollDown";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<PaymentsEnt>>().Result;
                }

                return new List<PaymentsEnt>();
            }

        }
         
        public List<PaymentsEnt> ListOfPays()
        {
            using (var custom = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestPayment";
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                custom.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = custom.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<PaymentsEnt>>().Result;
                }

                return new List<PaymentsEnt>();
            }

        }





    }
}