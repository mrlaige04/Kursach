using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    [ApiController]
    [Route("[controller]/Index")]
    public class RestaurantsController : Controller
    {
        private static string api_key = "egz5E8E4Cvpep-CrfdP3pZzXcWxzzzK3vMITvopH";
        private static string sig = "528183a730595d9";
        private static HttpClient client = new HttpClient();
        private static HttpRequestMessage reqmessage;

        [HttpGet]
        public string Index()
        {
            string str = "";
            reqmessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://api.jowi.club/v010/restaurants?api_key={api_key}&sig={sig}"),
                //Headers =
                //{
                //    { "Content-Type" , "application/json" }
                //}
            };
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            using (var response = client.Send(reqmessage))
            {
                var result = response.Content.ReadAsStringAsync();
                return result.Result;
            }
            //return str;
        }
    }
}
