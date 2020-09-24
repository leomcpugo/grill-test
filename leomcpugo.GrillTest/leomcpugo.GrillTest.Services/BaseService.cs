using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace leomcpugo.GrillTest.Services
{
    public class BaseService
    {
        protected static readonly HttpClient client = new HttpClient();


        protected async Task<T> Get<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(await client.GetStringAsync(url));
        }
    }
}
