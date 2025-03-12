﻿using Microsoft.AspNetCore.Mvc;
using NetCoreAI.Project01_ApiDemo.Context;
using NetCoreAI.Project01_ApiDemo.Enitities;

namespace NetCoreAI.Project01_ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    { 
        private readonly ApiContext _context;
        public CustomersController(ApiContext context) 
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult CustomerList()
        {
            var value = _context.Customers.ToList(); 
            return Ok(value);
        }


        [HttpPost]
        public IActionResult CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return Ok("Customer added successfully");
        }


        [HttpDelete]
        public IActionResult DeleteCustomer(int id)
        {
            var value = _context.Customers.Find(id); 
            _context.Customers.Remove(value);
            _context.SaveChanges();
            return Ok("Customer deleted successfully");
        }

        [HttpGet("GetCustomer")]
        public IActionResult GetCustomer(int id)
        {
            var value = _context.Customers.Find(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
            return Ok("Customer updated successfully");
        }
    }
}
