using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{



    /// <summary>
    /// All Ingredients
    /// </summary>
    [ApiController]
    [Route("/[controller]")]
    public class IngredientsController : Controller
    {
        public object Index()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://www.themealdb.com/api/json/v1/1/list.php?i=list")
            };
            using (var response = client.Send(message))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                return body;
            }
            
        }
    }
}
