using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using RestSharp;
using PuppeteerSharp;

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
            string fullUrl = "https://reverb.com/marketplace?query=Fender%20%2765%20Deluxe%20Reverb%20Reissue&sort=published_at%7Cdesc";

            try
            {
                var options = new LaunchOptions()
                {
                    Headless = true,
                    ExecutablePath = "C:\\Program Files (x86)\\Google\\Chrome\\Application\\chrome.exe"
                };

                using (var browser = await Puppeteer.LaunchAsync(options))
                using (var page = await browser.NewPageAsync())
                {
                    await page.GoToAsync(fullUrl);
                    await page.WaitForSelectorAsync("body > main > section > div:nth-child(2) > div > div > div.faceted-grid > div.faceted-grid__inner > div.faceted-grid__main > ul > li:nth-child(1) > div > a");

                    var jsSelectAllAnchors = @"Array.from(document.querySelectorAll('body > main > section > div:nth-child(2) > div > div > div.faceted-grid > div.faceted-grid__inner > div.faceted-grid__main > ul > li > div > a')).map(a => a.href);";
                    var urls = await page.EvaluateExpressionAsync<string[]>(jsSelectAllAnchors);

                    foreach (string url in urls)
                    {
                        Console.WriteLine($"Url: {url}");
                    }

                    return "hi";
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return "hi";
        }
    }
}
