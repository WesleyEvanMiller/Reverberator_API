using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Reverberator_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReverberatorController : ControllerBase
    {
        private readonly ILogger<ReverberatorController> _logger;

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
        public async Task<string> QueryReverb()
        {
            var htmlString = "";
            var reverbURI = "https://reverb.com/item/40259382-ibanez-b200-banjo";

            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;

            HttpClient client = new HttpClient(handler);

            try
            {
                using (var requestMessage =
                new HttpRequestMessage(HttpMethod.Get, reverbURI))
                {
                    requestMessage.Headers.Authorization =
                    new AuthenticationHeaderValue("NoAuth");
                    var response = await client.SendAsync(requestMessage);
                    string responseBody = await response.Content.ReadAsStringAsync();
                    htmlString = responseBody;
                }
                //HttpResponseMessage response = await client.GetAsync(reverbURI);
                //response.EnsureSuccessStatusCode();
                //string responseBody = await response.Content.ReadAsStringAsync();
                //htmlString = requestMessage;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return htmlString;
        }
    }
}
