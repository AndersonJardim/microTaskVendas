using MicroTask.Domain.Models;

namespace MicroTask.Infra.Data
{
    public interface IVendasRepository
    {
        Task<IEnumerable<Vendas>> GetAllAsync();
        Task<Vendas?> GetByIdAsync(int id);
        Task<int> AddAsync(Vendas venda);
        Task UpdateAsync(Vendas venda);
        Task<int> DeleteAsync(int id);
    }
}