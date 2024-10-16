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
        public async Task<Vendas?> GetByIdAsync(int id) =>
            await _vendasRepository.GetByIdAsync(id);
        public async Task<Vendas> AddAsync(Vendas venda) =>
            await _vendasRepository.AddAsync(venda);
        public async Task UpdateAsync(Vendas venda) =>
            await _vendasRepository.UpdateAsync(venda);
        public async Task<int> DeleteAsync(int id) =>
            await _vendasRepository.DeleteAsync(id);

    }
}
