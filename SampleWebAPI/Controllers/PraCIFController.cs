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
    public class PraCIFController : ControllerBase
    {
        private IPraCIF _praCIF;
        public PraCIFController(IPraCIF praCIF)
        {
            _praCIF = praCIF;
        }

        // GET: api/PraCIF
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PraCIF/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PraCIF
        [HttpPost]
        public IActionResult Post([FromBody] PraCIF praCif)
        {
            try
            {
                _praCIF.Insert(praCif);
                return Ok("Berhasil Tambah Data PraCIF");
            }
            catch (Exception ex)
            {
                return BadRequest($"Kesalahan: {ex.Message}");
            }
        }

        // PUT: api/PraCIF/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
