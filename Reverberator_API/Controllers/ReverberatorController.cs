using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;

namespace Reverberator_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReverberatorController : ControllerBase
    {
        private readonly ILogger<ReverberatorController> _logger;

        static readonly HttpClient client = new HttpClient();

        public ReverberatorController(ILogger<ReverberatorController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// A method that displays for health checks
        /// </summary>
        /// <returns>Hello World</returns>
        [HttpGet("helloworld")]
        public string Get()
        {
            return "Hello World";
        }

        /// <summary>
        /// A method that will make a rest request to reverb.com
        /// </summary>
        /// <returns></returns>
        [HttpGet("reverbtest")]
        public string QueryReverb()
        {
            string htmlString;
            try
            {
                HttpResponseMessage response = await client.GetAsync("http://www.contoso.com/");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }
            return responseBody;
        }
    }
}
