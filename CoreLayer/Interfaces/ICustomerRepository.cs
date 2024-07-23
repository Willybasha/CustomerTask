using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer.Entites;
using CoreLayer.Paging;

namespace CoreLayer.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllAsync(CustomerPagingParameters PagingParamaeters);
        Task<Customer> GetByIdAsync(int id);
        Task AddAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(int id);
        Task<IEnumerable<Customer>> GetFilteredCustomerAsync(string name, string email,CustomerPagingParameters pagingParameters);

        Task SaveChangesAsync();
    }
}
