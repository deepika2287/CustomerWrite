using CustomerWrite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerWrite.Repository
{
    public class SQLRepository : ISQLRepository
    {
        private MicroServices_DeepikaContext _context;
        public SQLRepository(MicroServices_DeepikaContext context)
        {
            _context = context;
        }

        public async Task<Customers> AddCustomer(Customers customer)
        {
            _context.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        

        public async Task<Customers> DeleteCustomer(int customerId)
        {
            var cust = this.GetCustomerById(customerId);
            _context.Customers.Remove(cust);
            await _context.SaveChangesAsync();
            return cust;
        }

        public async Task<Customers> UpdateCustomer(Customers customer)
        {
            var custId = customer.CustomerId;
            _context.Entry(customer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            var cust = this.GetCustomerById(customer.CustomerId);
            return cust;
        }

       

        private Customers GetCustomerById(int customerId)
        {
            var customer = _context.Customers.Where(a => a.CustomerId == customerId).SingleOrDefault();
            return customer;
        }
    }
}
