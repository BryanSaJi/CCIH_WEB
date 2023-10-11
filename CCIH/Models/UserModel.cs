
using CCIH.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CCIH.Models
{
    public class UserModel
    {
        public UserEnt Login(UserEnt ent)
        {
            using (var custom = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/Login";
                JsonContent body = JsonContent.Create(ent); //Serializar

                HttpResponseMessage resp = custom.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<UserEnt>().Result;
                }

                return null;
            }
        }
        public int RegisterUser(CustomerUserEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/CreateUser";
                JsonContent body = JsonContent.Create(entidad); //Serializar
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
        public int ChangePassword(ChangePasswordEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ChangePassword";
                JsonContent body = JsonContent.Create(entidad); //Serializar
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
        public List<CustomerUserEnt> RequetUsers()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RequestUsers";

                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<CustomerUserEnt>>().Result;
                }

                return new List<CustomerUserEnt>();
            }
        }

        public int DeleteUser(long q)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/DeleteUser?q=" + q;
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
        public int Edituser(CustomerUserEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/EditUser";
                JsonContent body = JsonContent.Create(entidad); //Serializar
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
        public CustomerUserEnt RequetUser(long i)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RequestUser?i=" + i;
                String Token = HttpContext.Current.Session["TokenUser"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<CustomerUserEnt>().Result;
                }

                return null;
            }
        }

        public string Encrypt(string toEncrypt)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader = new AppSettingsReader();
            string key = ConfigurationManager.AppSettings["secretKey"].ToString();
            MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
            keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            hashmd5.Clear();

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();

            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
            tdes.Clear();
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
    }
}
