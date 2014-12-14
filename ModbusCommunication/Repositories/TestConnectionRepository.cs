using System;
using ModbusCommunication.Utils;
using Npgsql;

namespace ModbusCommunication.Repositories
{
    internal class TestConnectionRepository
    {
        internal bool TestConnectionToDatabase()
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
