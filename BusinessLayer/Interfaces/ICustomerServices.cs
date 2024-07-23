using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTOS;
using CoreLayer.Entites;
using CoreLayer.Paging;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerResponseDTO>> GetAllCustomersAsync(CustomerPagingParameters pagingParameters);
        Task<CustomerResponseDTO> GetCustomerByIdAsync(int id);
        Task AddCustomerAsync(CustomerRequestDTO customer);
        Task UpdateCustomerAsync(int id,CustomerRequestDTO customer);
        Task DeleteCustomerAsync(int id);
        Task<IEnumerable<CustomerResponseDTO>> GetFilteredCustomersAsync(string name, string email, CustomerPagingParameters pagingParameters);
    }
}
