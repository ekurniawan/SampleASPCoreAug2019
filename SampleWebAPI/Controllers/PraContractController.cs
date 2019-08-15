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
    public class PraContractController : ControllerBase
    {

        private IPraContract _pracontract;
        public PraContractController(IPraContract PraContract)
        {
            _pracontract = PraContract;
        }

        // GET: api/PraContract
        [HttpGet]
        public IEnumerable<PraContract> Get()
        {
            return _pracontract.GetAll();
        }

        // GET: api/PraContract/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/PraContract
        //hello
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
        //
        //// PUT: api/PraContract/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}
        //
        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
