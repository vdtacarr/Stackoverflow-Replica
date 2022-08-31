using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stackoverflow.Restclient
{
    public interface IRest
    {
        public List<T> GetList<T>(string url);

        public T Get<T>(string url);

        public IRestResponse Post<T>(string url, T model);

        public void Delete(string url);


    }
}
