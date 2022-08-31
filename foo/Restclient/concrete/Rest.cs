using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using Stackoverflow.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stackoverflow.Restclient.concrete
{
    public class Rest: IRest
    {
        public List<T> GetList<T>(string url)
        {
            var client = new RestClient("https://localhost:44383/");
            var request = new RestRequest("api/admin/questions", Method.GET);
            var queryResult = client.Execute<List<T>>(request).Data;
            return queryResult;
        }

        public T Get<T>(string url)
        {
            var client = new RestClient("https://localhost:44383/");
            var request = new RestRequest(url, Method.GET);
            var result = client.Execute<T>(request);
            var queryResult = JsonConvert.DeserializeObject<T>(result.Content);
            return queryResult;
        }

        public IRestResponse Post<T>(string url, T model)
        {
            var client = new RestClient("https://localhost:44383/");
            var request = new RestRequest(url, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(model);
            var result = client.Execute(request);
            return result;
        }

        public void Delete(string url)
        {
            var client = new RestClient("https://localhost:44383/");
            var request = new RestRequest(url, Method.DELETE);
            client.Execute(request);
           

        }
    }
}
