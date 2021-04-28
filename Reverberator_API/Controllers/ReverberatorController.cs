using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        [HttpGet]
        public string Get()
        {
            return "Hello World";
        }
    }
}
