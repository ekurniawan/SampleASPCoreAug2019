using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BO;
using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CIFController : ControllerBase
    {
        private ICIF _cif;
        public CIFController(ICIF cif)
        {
            _cif = cif;
        }

        // GET: api/CIF
        [HttpGet]
        public IEnumerable<CIF> Get()
        {
            return _cif.GetAll();
        }

        // GET: api/CIF/5
        /*[HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CIF
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/CIF/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
