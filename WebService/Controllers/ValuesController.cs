﻿using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<TestModel> Get()
        {
            TestModel test = new TestModel()
            {
                Age = 7,
                Name = "Name",
            };

            return test;
        }
    }
}
