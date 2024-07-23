using AutoMapper;
using BusinessLayer.DTOS;
using BusinessLayer.Interfaces;
using CoreLayer.Entites;
using CoreLayer.Interfaces;
using CoreLayer.Paging;

namespace BusinessLayer.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerServices(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CustomerResponseDTO>> GetAllCustomersAsync(CustomerPagingParameters pagingParameters)
        {
          var customers = await _repository.GetAllAsync(pagingParameters);
          return _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
        }
     
        public async Task<CustomerResponseDTO> GetCustomerByIdAsync(int id)
        {
             var customer = await _repository.GetByIdAsync(id);
             return _mapper.Map<CustomerResponseDTO>(customer);
        }

        public async Task AddCustomerAsync(CustomerRequestDTO customerDto)
        {
            var customer = _mapper.Map<Customer>(customerDto);
            await _repository.AddAsync(customer);
        }

        public async Task UpdateCustomerAsync( int id ,CustomerRequestDTO customerDto)
        {
            var customerToUpdate=await _repository.GetByIdAsync(id);
            if (customerToUpdate is null)
                throw new Exception("not found");

            _mapper.Map(customerDto, customerToUpdate);

            await _repository.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }


        public async Task<IEnumerable<CustomerResponseDTO>> GetFilteredCustomersAsync(string name, string email, CustomerPagingParameters pagingParameters)
        {
            var customers = await _repository.GetFilteredCustomerAsync(name, email, pagingParameters);
            return _mapper.Map<IEnumerable<CustomerResponseDTO>>(customers);
        }
    }
}



