using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HTTPRoutingDemo.Database.Models;
using HTTPRoutingDemo.Repositories;

namespace HTTPRoutingDemo.Services
{
    public class CustomerService
    {
        private readonly CustomerRepository _repository;

        public CustomerService(CustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<Customer?> GetCustomerAsync(int customerId)
        {
            return await _repository.FindCustomerAsync(customerId);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return _repository.GetCustomers();
        }

        public async Task<bool> UpdateCustomerAsync(Customer customer)
        {
            return await _repository.UpdateCustomerAsync(customer);
        }

        public async Task CreateCustomerAsync(Customer customer)
        {
            await _repository.CreateCustomerAsync(customer);
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            await _repository.DeleteCustomerAsync(customerId);
        }
    }
}

