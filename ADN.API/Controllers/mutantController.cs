using ADN.BM;
using ADN.DT;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ADN.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mutantController : ControllerBase
    {
        private IBMMutant _obj;
        private IHostingEnvironment hostingEnv;
        public mutantController(IBMMutant IData, IHostingEnvironment env)
        {
            _obj = IData;
            hostingEnv = env;
        }

        [HttpPost]
        [Route("Mutant")]
        [EnableCors("AllowOrigin")]
        public ActionResult<HttpStatusCode> Mutant(DTAdn dna)
        {
            return _obj.DetectarMutant(dna);
        }

        [HttpGet]
        [Route("stats")]
        [EnableCors("AllowOrigin")]
        public ActionResult<DTStats> stats()
        {
            DTStats response = new DTStats();
            try
            {
                response = _obj.stat();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
            return Ok(response);

        }
    }
}
