using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Crud.Models.Services;
using WebApi.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerRepository customerRepository;
        public CustomerController(CustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var customerList = customerRepository.GetAll();
            return Ok(customerList);

        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var customer = customerRepository.Get(id);

            return Ok(customer);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer item)
        {
            var result = customerRepository.Add(item);

            string url = Url.Action(nameof(Get), "Customer", new { Id = result.id }, Request.Scheme);

            return Created(url, true);
        }
        [HttpPut()]
        public IActionResult Put([FromBody] Customer customer)
        {
            var result = customerRepository.Edit(customer);
            return Ok(result);
        }
        [HttpPatch()]
        public IActionResult Patch([FromBody] Customer customer)
        {
            var result = customerRepository.EditAll(customer);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            customerRepository.Delete(id);
            return Ok();
        }
       

    }
}
