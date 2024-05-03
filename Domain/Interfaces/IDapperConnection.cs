using System.Data;

namespace Domain.Interfaces;

public interface IDapperConnection
{
    IDbConnection CreateConnection();
}
