using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using SimpleCqrs.Contracts;

namespace SimpleCqrs.DataAccess
{
    public class ProductQueryService
    {
        private readonly Func<IDbConnection> dbConnectionFactory;

        public ProductQueryService(Func<IDbConnection> dbConnectionFactory)
        {
            this.dbConnectionFactory = dbConnectionFactory;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            using (var dbConnection = dbConnectionFactory())
            {
                const string sql = "select Id, Title, Price, CategoryName from dbo.GetProducts";
                return await dbConnection.QueryAsync<ProductDto>(sql);
            }
        }

        public async Task<IEnumerable<ProductDto>> GetProductById(GetProductById query)
        {
            using (var dbConnection = dbConnectionFactory())
            {
                const string sql = "select Id, Title, Price, CategoryName from dbo.GetProducts where Id=@Id";
                return await dbConnection.QueryAsync<ProductDto>(sql, query);
            }
        }
    }
}
