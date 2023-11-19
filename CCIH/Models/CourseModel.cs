
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

        UtilitiesModel apiEnviroment = new UtilitiesModel();

        public List<CourseEnt> RequestCourseScrollDown()
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestCourseScrollDown";
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<CourseEnt>>().Result;
                }

                return new List<CourseEnt>();
            }

        }



        public List<CourseEnt> SeeCoursesFiltered(string courseName)
        {
            using (var client = new HttpClient())
            {
                string url = apiEnviroment.getApiUrl() + "api/RequestCourseFiltered?courseName=" + courseName;
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