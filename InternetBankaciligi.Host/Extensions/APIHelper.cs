using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using InternetBankaciligi.Entities.API;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using System.Net;

namespace InternetBankaciligi.Host.Extensions
{
    [RoutePrefix("/api/InternetBankaciligi")]
    public class APIHelper : Controller
    {
        [HttpPost]
        [Route("/Home")]
        public static List<ExchangeRateInfo> HomeIndex()
        {
            var client = new RestClient("http://hasanadiguzel.com.tr/api/kurgetir");
            var request = new RestRequest(Method.GET);
            List<ExchangeRateInfo> exchangeRateInfos = new List<ExchangeRateInfo>();

            IRestResponse response = client.Execute(request);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.NullValueHandling = NullValueHandling.Ignore;

            JObject myJson = (JObject)JsonConvert.DeserializeObject(response.Content, settings);
            JArray jsonArray = JArray.Parse(myJson.Last.Last.ToString());

            List<string> childTokens = new List<string>();

            foreach (var childToken in jsonArray)
            {
                childTokens.Add(childToken.ToString());
            }


            foreach (var x in childTokens)
            {
                exchangeRateInfos.Add(JsonConvert.DeserializeObject<ExchangeRateInfo>(x));
            }

            return exchangeRateInfos;
        }
    }
}
