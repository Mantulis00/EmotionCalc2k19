using Microsoft.AspNetCore.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<TestModel> Get()
        {
            TestModel test = new TestModel()
            {
                Age = 5,
                Name = "Name",
            };

            return test;
        }
    }
}
