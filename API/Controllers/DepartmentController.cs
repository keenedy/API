using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok("Get All Student");
        }

        [HttpGet("{code}")]
        public IActionResult GetA(String code)
        {
            return Ok("get this " + code + "department data");
        }

        [HttpPost]
        public IActionResult Insert()
        {
            return Ok("Department created");
        }

        [HttpPut("{code}")]
        public IActionResult Update(String code)
        {
            return Ok("Update this " + code + "department data");
        }

        [HttpDelete("{code}")]
        public IActionResult Delete(String code)
        {
            return Ok("Delete this " + code + "department data");
        }
    }
}
