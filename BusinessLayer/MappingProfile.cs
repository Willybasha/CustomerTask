using AutoMapper;
using BusinessLayer.DTOS;
using CoreLayer.Entites;

namespace BusinessLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerRequestDTO>().ReverseMap();
            CreateMap<CustomerResponseDTO, Customer > ().ReverseMap();
        }
    }
}
