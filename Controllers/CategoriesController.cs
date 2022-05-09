using Microsoft.AspNetCore.Mvc;

namespace Kursach.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CategoriesController : Controller
    {
        public object Categories()
        {
            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://www.themealdb.com/api/json/v1/1/categories.php")
            };
            using (var response = client.Send(request))
            {
                var body = response.Content.ReadAsStringAsync().Result;
                return body;
            }

        }
    }
}
