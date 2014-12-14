using ModbusCommunication.Models;
using Npgsql;

namespace ModbusCommunication.Utils
{
    internal class DbConnection
    {
        static NpgsqlConnectionStringBuilder _connection;
        internal static void InitializeDb(DatabaseConfiguration configuration)
        {
            _connection = new NpgsqlConnectionStringBuilder
            {
                Host = configuration.Host,
                Database = configuration.Database,
                UserName = configuration.UserName,
                Password = configuration.Password,
                Port = configuration.Port
            };
        }

        internal static NpgsqlConnectionStringBuilder GetConnectionString()
        {
            return _connection;
        }
    }
}
