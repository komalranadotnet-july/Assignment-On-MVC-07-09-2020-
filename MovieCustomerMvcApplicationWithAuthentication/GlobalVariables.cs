using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MovieCustomerMvcApplicationWithAuthentication
{
    public static class GlobalVariables
    {
        public static HttpClient webApiClient = new HttpClient();
        static GlobalVariables()
        {
            webApiClient.BaseAddress = new Uri("https://localhost:44379/api/");
            webApiClient.DefaultRequestHeaders.Accept.Clear
                ();
            webApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
}