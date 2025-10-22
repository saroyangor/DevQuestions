using System.Data;
using DevQuestions.Application.Database;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DevQuestions.Infrastructure.Postgres;

public class SqlConnectionFactory(IConfiguration configuration) : ISqlConnectionFactory
{
    public IDbConnection Create()
    {
        var connection = new NpgsqlConnection(configuration.GetConnectionString("Database"));

        return connection;
    }
}
