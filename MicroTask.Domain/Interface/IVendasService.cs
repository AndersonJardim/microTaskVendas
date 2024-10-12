using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interface
{
    public interface IVendasService
    {
        Task<IEnumerable<Vendas>> GetAllAsync();
    }
}
