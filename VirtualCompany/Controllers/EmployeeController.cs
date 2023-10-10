using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Runtime.InteropServices;
using VirtualCompany.Buisness_Layer.Repositories;
using VirtualCompany.Models.Employee;

namespace VirtualCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRep employeeRep;
        private readonly ApplicationDbContext db;
        private long photoSize = 1048576;
        public EmployeeController(EmployeeRep employeeRep,ApplicationDbContext db)
        {
            this.employeeRep = employeeRep;
            this.db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {

            var data = await employeeRep.Get();
            return Ok(data);
        }

        #region Alot of methods to define a lot of on Get Action such as MVC but style of Api hhhh

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByEmployeeId(int id)
        {
            var data = await employeeRep.getByEmployeeId(id);

            return Ok(data);
        }

        [HttpGet("GetByEmployeeId")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await employeeRep.getByEmployeeId(id);

            return Ok(data);
        }
        [HttpGet("getAllDepender")]
        public async Task<IActionResult> getAllDependers(int id)
        {
            var data = await employeeRep.GetAnyEqualId(id);

            return Ok(data);
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] EmployeeFileVM employee)
        {



            if (employee.PhotoUrl.Length > photoSize)
            {
                return BadRequest($"Size of your photo more from 1 Mega");
            }

            await employeeRep.AddEmployee(employee);
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] EmployeeFileVM employee)
        {
            var ch = await employeeRep.CheckIdAsync(id);

            if (ch == null)
                return NotFound();

            ch = await employeeRep.EditAsync(employee);

            return Ok(ch);

        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await employeeRep.Delete(id);
            return Ok();
        }

    }
}
