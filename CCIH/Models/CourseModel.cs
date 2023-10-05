
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
    public class CourseModel
    {
        public List<CourseEnt> ConsultCourseListRolesScrollDown()
        {
            using (var client = new HttpClient())
            {
                string url = ConfigurationManager.AppSettings["urlApi"].ToString() + "api/RequestCourseScrollDown";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<CourseEnt>>().Result;
                }

                return new List<CourseEnt>();
            }

        }
    }
}