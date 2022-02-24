using Newtonsoft.Json;

namespace WebApplication1
{
    public class Price
    {
        [JsonProperty("15m")]
        public decimal minutes15 { get; set; }
        public decimal last { get; set; }
        public decimal buy { get; set; }
        public decimal sell { get; set; }
    }
}
