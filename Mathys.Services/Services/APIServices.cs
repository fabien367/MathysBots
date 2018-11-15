using Mathys.Services.IServices;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Mathys.Services.Services
{
    public class APIServices : IAPIService, IDisposable
    {
        protected HttpClient httpClient { get; set; }
        protected readonly string uriBase = "http://localhost:59397/";

        public APIServices()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mathys");
        }

        ~APIServices()
        {
            httpClient.Dispose();
        }

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
