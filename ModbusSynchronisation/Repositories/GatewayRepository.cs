using System;
using System.Collections.Generic;
using ModbusSynchronisation.Models;
using Npgsql;
using ModbusCommon.Utils;

namespace ModbusSynchronisation.Repositories
{
    internal class GatewayRepository
    {
        internal List<Gateway> SelectGateways()
        {
            var gateways = new List<Gateway>();

            var selectQuery = GetSelectQuery();

            using (var command = new NpgsqlCommand(selectQuery))
            {
                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        gateways.Add(new Gateway
                        {
                            GatewayId = Convert.ToInt32(dr["GatewayId"]),
                            ZoneId = Convert.ToInt32(dr["ZoneId"]),
                            SerialPort = dr["SerialPort"].ToString(),
                            ZoneName = dr["ZoneName"].ToString()
                        });
                    }
                }

                command.Connection.Close();
            }

            return gateways;
        }

        private static string GetSelectQuery()
        {
            const string query = @"
                    SELECT 	 g.id_gateway as GatewayId
                            ,g.id_zone as ZoneId
                            ,g.com as SerialPort
                            ,z.name as ZoneName
                    FROM	gateway as g
                    JOIN    zones as z
                    ON      g.id_zone = z.id_zone
                    WHERE   z.active = true
                    AND     g.active = true";
            return query;
        }
    }
}
