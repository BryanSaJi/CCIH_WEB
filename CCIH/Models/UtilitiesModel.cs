using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CCIH.Models
{
    public class UtilitiesModel
    {

        public string getApiUrl()
        {
            string resp = "";

            if (ConfigurationManager.AppSettings["Environment"].ToString() == "LOCAL")
            {
                resp = ConfigurationManager.AppSettings["urlApiLocal"].ToString();
            }
            else
            {
                resp = ConfigurationManager.AppSettings["urlApiAzure"].ToString();
            }

            return resp;
        }

    }
}