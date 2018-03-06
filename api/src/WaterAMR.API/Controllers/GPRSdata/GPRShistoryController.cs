﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WaterAMR.Business.Interfaces;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WaterAMR.API.Controllers.GPRSdata
{
    [Route("api/[controller]")]
    public class GPRShistoryController : Controller
    {
        private IGPRSdataService BusinessService;
        public GPRShistoryController(IGPRSdataService service)
        {
            this.BusinessService = service;
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IEnumerable<BusinessModels.GPRSdata.GprsDetail> Post([FromBody]string value)
        {
            return this.BusinessService.GetGprsHistory(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}