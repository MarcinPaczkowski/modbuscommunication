using ModbusCommon.Utils;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModbusCommon.Repositories
{
    public class TestConnectionRepository
    {
        public bool TestConnectionToDatabase()
        {
            var testQuery = GetTestQuery();

            using (var command = new NpgsqlCommand(testQuery))
            {
                try
                {
                    command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                    command.Connection.Open();
                    command.ExecuteScalar();
                }
                catch (Exception)
                {
                    return false;
                }
                finally
                {
                    command.Connection.Close();
                }

            }
            return true;
        }

        private static string GetTestQuery()
        {
            const string query = @"
                SELECT id_state
                FROM states";
            return query;
        }
    }
}
