using System.Collections.Generic;
using System.Linq;
using WebApi.Crud.Models.Contexts;
using WebApi.Models.Entities;

namespace WebApi.Crud.Models.Services
{
    public class CustomerRepository
    {
        private readonly DataBaseContext _context;
        public CustomerRepository(DataBaseContext context)
        {
            this._context = context;
        }

        public List<Customer> GetAll()
        {
            return _context.Customer.ToList();
        }
        public Customer Get(int id)
        {
            var customer = _context.Customer.SingleOrDefault(p => p.id == id);
            return customer;
        }
        public Customer Add(Customer customer)
        {
            _context.Customer.Add(customer);
            _context.SaveChanges();
            return customer;
        }
        public void Delete(int Id)
        {
            _context.Customer.Remove(new Customer { id = Id });
            _context.SaveChanges();
        }
        public bool EditAll(Customer customer)
        {
            _context.Customer.Update(customer);
            _context.SaveChanges();
            return true;
        }
        public bool Edit(Customer newCustomer)
        {
            var customer = Get(newCustomer.id);
            if (newCustomer.name != null) { customer.name = newCustomer.name; }
            if (newCustomer.surname != null) { customer.surname = newCustomer.surname; }
            if (newCustomer.code != 0) { customer.code = newCustomer.code; }
            _context.Customer.Update(customer);
            _context.SaveChanges();
            return true;
        }
         
    }
}
