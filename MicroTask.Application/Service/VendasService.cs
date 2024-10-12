using MicroTask.Domain.Interface;
using MicroTask.Domain.Models;
using MicroTask.Infra.Data;

namespace MicroTask.Application.Service
{
    public class VendasService : IVendasService
    {
        private readonly IVendasRepository _vendasRepository;

        public VendasService(IVendasRepository vendasRepository)
        {
            _vendasRepository = vendasRepository;
        }

        public async Task<IEnumerable<Vendas>> GetAllAsync() =>
            await _vendasRepository.GetAllAsync();
    }
}
