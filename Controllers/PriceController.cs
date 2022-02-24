using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        // GET: api/<PriceController>
        [HttpGet]
        public MinMax Get()
        {
            string url = "https://raw.githubusercontent.com/sinloong/yl/main/ticker0.json";
            var data = Download_Data_From_URL(url);
            var listOf15m = data.ToDictionary(a => a.Value.minutes15).ToList();
            
            var minValue = listOf15m.Min(a => a.Key);
            var maxValue = listOf15m.Max(a => a.Key);

            return new MinMax()
            {
                Min = minValue,
                Max = maxValue
            };
                 
            //return new string[] { "value1", "value2" };
        }

        private Dictionary<string, Price> Download_Data_From_URL(string url)
        {
            using(WebClient webClient = new WebClient())
            {
                var data = webClient.DownloadString(url);
                var result = JsonConvert.DeserializeObject<Dictionary<string, Price>>(data);
                return result;
            }
        }


    }
}
