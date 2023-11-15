using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

//allows you to use interface to be used anywhere, to prevent redundant code 
namespace Powerlifting.Service
{
    //Implementation class
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration config;
        public string ConnectionStringName { get; set; } = "dev"; public SqlDataAccess(IConfiguration config)
        {
            this.config = config;
        }
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = config.GetConnectionString(ConnectionStringName); //Establishing connection
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                var data = await connection.QueryAsync<T>(sql, parameters); return data.ToList();    //Running query commands and returning data
            }
        }


        //WILL USE THIS FOR LATER 
        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = config.GetConnectionString(ConnectionStringName); //Establishing connection
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(sql, parameters);            //Executing saving data
            }
        }
        public async Task ExecuteQuery(string sql)
        {
            string connectionString = config.GetConnectionString(ConnectionStringName);  //Establishing connection
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //await
                await connection.ExecuteAsync(sql);             //Executing query
            }
        }
    }
}

