using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HTTPRoutingDemo.Database;
using HTTPRoutingDemo.Database.Models;

namespace HTTPRoutingDemo.Repositories
{
    public class CustomerRepository
    {
        private readonly CRMContext _context;

        public CustomerRepository(CRMContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }

        public async Task<Customer?> FindCustomerAsync(int customerId)
        {
            return await _context.Customers.FindAsync(customerId);
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await FindCustomerAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            var dbCustomer = await FindCustomerAsync(customer.CustomerId);
            if (dbCustomer != null)
            {
                dbCustomer.FirstName = customer.FirstName;
                dbCustomer.LastName = customer.LastName;
                dbCustomer.Balance = customer.Balance;
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}

