using MicroTask.Domain.Models;

namespace MicroTask.Infra.Data
{
    public interface IVendasRepository
    {
        Task<IEnumerable<Vendas>> GetAllAsync();
    }
}