using AutoMapper;
using MicroTask.Domain.Models;

namespace MicroTask.WebApi
{
    public class VendasMapperConfiguration : Profile
    {
        public VendasMapperConfiguration()
        {
            CreateMap<Vendas, VendasDto>();
        }
    }
}
