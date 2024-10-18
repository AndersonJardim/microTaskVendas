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
        public async Task<Vendas?> GetByIdAsync(int id)
        {
            var query = "SELECT TOP 1 * FROM Vendas WHERE Id = @Id";
            var param = new { Id = id };
            return await dbConnection.QueryFirstOrDefaultAsync<Vendas>(query, param);
        }
        public async Task<Vendas> AddAsync(Vendas venda)
        {
            var query = "INSERT INTO Vendas (IdCliente, IdProduto) VALUES (@IdCliente, @IdProduto); ";
            await dbConnection.ExecuteAsync(query, new { venda.IdCliente, venda.IdProduto });
            return venda;

        }
        public async Task UpdateAsync(Vendas venda)
        {
            var query = "UPDATE Vendas SET IdCliente = @IdCliente, IdProduto = @IdProduto WHERE Id = @Id";
            await dbConnection.ExecuteAsync(query, new { venda.IdCliente, venda.IdProduto, venda.Id });
        }
        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Vendas WHERE Id = @Id";
            return await dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
