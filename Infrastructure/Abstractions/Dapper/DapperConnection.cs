using System.Data;
using Microsoft.Data.SqlClient;

namespace Infrastructure.Abstractions.Dapper;

internal sealed class DapperConnection : IDapperConnection
{
    private readonly string _connectionString;

    public DapperConnection(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        var connection = new SqlConnection(_connectionString);
        connection.Open();

        return connection;
    }
}
