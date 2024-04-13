using System.Data;

namespace Infrastructure.Abstractions.Dapper;

public interface IDapperConnection
{
    IDbConnection CreateConnection();
}
