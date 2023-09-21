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
    public class MatriculaModel
    {
        public int RegistrarMatricula(MatriculaEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RegistrarMatricula";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                String Token = HttpContext.Current.Session["TokenUsuario"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

        public int PreMatricularCurso(PreMatriculaEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/PreMatriculaCurso";
                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }


        public List<PreMatriculaEnt> ConsultarPreMatricula()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarPreMatriculas";

                String Token = HttpContext.Current.Session["TokenUsuario"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<PreMatriculaEnt>>().Result;
                }

                return new List<PreMatriculaEnt>();
            }

        }


        public List<MatriculaEnt> ConsultarMatriculas()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarMatriculas";

                String Token = HttpContext.Current.Session["TokenUsuario"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<MatriculaEnt>>().Result;
                }

                return new List<MatriculaEnt>();
            }

        }

        public List<MatriculaEnt> ConsultarMatriculasHoy()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarMatriculasHoy";

                String Token = HttpContext.Current.Session["TokenUsuario"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<MatriculaEnt>>().Result;
                }

                return new List<MatriculaEnt>();
            }

        }


        public MatriculaEnt ConsultarMatricula(long i)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ConsultarMatricula?i=" + i;
                String Token = HttpContext.Current.Session["TokenUsuario"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<MatriculaEnt>().Result;
                }

                return null;
            }
        }


        public int EditarMatricula(MatriculaEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/EditarMatricula?q=" + entidad.IdMatricula;
                String Token = HttpContext.Current.Session["TokenUsuario"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

        public int ContactoPrematricula(PreMatriculaEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/ContactoPrematricula";
                String Token = HttpContext.Current.Session["TokenUsuario"].ToString();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

                JsonContent body = JsonContent.Create(entidad); //Serializar
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }

    }
}