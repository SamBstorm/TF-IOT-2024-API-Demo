using ASP_WebAPI.Models;
using BLL_Employee.Entities;
using Common_Employee.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository<Employee> _employeeRepository;

        public EmployeeController(IEmployeeRepository<Employee> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        [ProducesResponseType(typeof(IApiResult<IEnumerable<Employee>>), 200)]
        [Produces("text/json", "text/xml")]
        public IActionResult Get()
        {
            IEnumerable<Employee> result = _employeeRepository.Get();
            //return Ok(new { result, length=result.Count(), statusCode = 200 });
            return Ok(new ApiResult<IEnumerable<Employee>>() { 
                result = result, 
                length=result.Count(), 
                statusCode = 200 
            });
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IApiResult<Employee>),200)]
        [ProducesResponseType(typeof(ApiErrorResult<int>),404)]
        [Produces("text/json", "text/xml")]
        public IActionResult Get(int id)
        {
            try
            {
                Employee result = _employeeRepository.Get(id);
                return Ok(new ApiResult<Employee>{ result = result, length = 1, statusCode = 200 } );
            }
            catch
            {
                return NotFound(new ApiErrorResult<int>{ Message = $"L'identifiant n'est pas correct.", Error = id , ParameterName = nameof(id), statusCode = 404 });
            }
        }

        // POST api/<EmployeeController>
        [HttpPost]
        [ProducesResponseType(typeof(int), 201)]
        [Produces("text/json", "text/xml")]
        public IActionResult Post(Employee value)
        {
            int id = _employeeRepository.Insert(value);
            return CreatedAtAction(nameof(Get),id);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        [Produces("text/json", "text/xml")]
        public IActionResult Put(int id, Employee value)
        {
            _employeeRepository.Update(id, value);
            return NoContent();
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        [Produces("text/json", "text/xml")]
        public IActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return NoContent();
        }
    }
}
