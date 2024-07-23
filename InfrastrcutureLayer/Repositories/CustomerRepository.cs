using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CoreLayer.Entites;
using CoreLayer.Interfaces;
using CoreLayer.Paging;
using InfrastrcutureLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace InfrastrcutureLayer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public readonly AppDBContext _context;
        public CustomerRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CustomerPagingParameters pagingParameters)
        {
            return await _context.Customers
                .Skip((pagingParameters.PageNumber-1)*pagingParameters.PageSize).Take(pagingParameters.PageSize).ToListAsync();

        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                customer.IsDeleted = true;
                await UpdateAsync(customer);
            }
        }


        public async Task<IEnumerable<Customer>> GetFilteredCustomerAsync(string name, string email, CustomerPagingParameters pagingParameters)
        {
            var customers = _context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                customers = customers.Where(c => c.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(email))
            {
                customers = customers.Where(c => c.Email.Contains(email));
            }

            return await customers
                .Skip((pagingParameters.PageNumber - 1) * pagingParameters.PageSize)
                .Take(pagingParameters.PageSize).ToListAsync();
        }

        public async Task SaveChangesAsync() 
            => await _context.SaveChangesAsync();


    }
}
