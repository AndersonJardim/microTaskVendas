using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interface
{
    public interface IVendasService
    {
        Task<IEnumerable<Vendas>> GetAllAsync();
        Task<Vendas?> GetByIdAsync(int id);
        Task<Vendas> AddAsync(Vendas venda);
        Task UpdateAsync(Vendas venda);
        Task<int> DeleteAsync(int id);
    }
}
