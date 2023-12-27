using System.Data;

namespace Infrastructure.Databases.Dapper;
public interface IDapperConnection
{
    IDbConnection CreateConnection();
}
