﻿using System;
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
        private IPraContract _praContract;
        public PraContractController(IPraContract praContract)
        {
            _praContract = praContract;
        }

        // GET: api/PraContract
        [HttpGet]
        public IEnumerable<PraContract> Get()
        {
            return _praContract.GetAll();
        }

        [HttpGet("GetByName/{name}")]
        public IEnumerable<PraContract> GetByName(string name)
        {
            return _praContract.GetByName(name);
        }

        // GET: api/PraContract/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/PraContract
        [HttpPost]
        public IActionResult Post([FromBody] PraContract praContract)
        {
            try
            {
                _praContract.Insert(praContract);
                return Ok("Berhasil Tambah Data PraContract");
            }
            catch (Exception ex)
            {
                return BadRequest($"Kesalahan: {ex.Message}");
            }
        }

        // PUT: api/PraContract/5
        [HttpPut]
        public IActionResult Put([FromBody] PraContract praContract)
        {
            try
            {
                _praContract.Update(praContract);
                return Ok("Berhasil Update PraContract");
            }
            catch (Exception ex)
            {
                return BadRequest($"Kesalahan: {ex.Message}");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
