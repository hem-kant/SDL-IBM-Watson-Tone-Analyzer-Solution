using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDL.IBM.Tone.Microservice.Controllers
{
    [Route("api/v1/[controller]")]
    public class ToneController: Controller
    {
        // GET api/v1/tone
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}
