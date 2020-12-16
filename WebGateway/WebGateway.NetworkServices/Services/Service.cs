namespace WebGateway.NetworkServices.Services
{
    using System.Text;
    using Newtonsoft.Json;
    using System.Net.Http;

    public class Service
    {
        private readonly HttpClient httpClient;

        public Service(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        protected HttpClient HttpClient
        {
            get { return this.httpClient; }
        }

        protected StringContent SerializeObjectToStringContent(dynamic bm)
        {
            var dataJSON = JsonConvert.SerializeObject(bm);
            var stringContent = new StringContent(dataJSON, Encoding.UTF8, "application/json");

            return stringContent;
        }
    }
}
