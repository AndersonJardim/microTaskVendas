using MicroTask.Domain.Models;
using System.Data;
using Dapper;

namespace MicroTask.Infra.Data
{
    public class VendasRepository : IVendasRepository
    {
        private readonly IDbConnection dbConnection;

        public VendasRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;            
        }
        public async Task<IEnumerable<Vendas>> GetAllAsync()
        {
            return await dbConnection.QueryAsync<Vendas>("SELECT * FROM Vendas");
        }
    }
}
