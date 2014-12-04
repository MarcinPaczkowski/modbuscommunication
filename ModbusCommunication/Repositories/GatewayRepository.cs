using System;
using System.Collections.Generic;
using ModbusSensorOperation.Models;
using ModbusSensorOperation.Utils;
using Npgsql;

namespace ModbusSensorOperation.Repositories
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
                            ZoneName = dr["ZoneName"].ToString(),
                            ActiveStatus = Convert.ToInt32(dr["ActiveStatus"]),
                            Command = Convert.ToInt32(dr["Command"]),
                            ConnectionStatus = Convert.ToInt32(dr["ConnectionStatus"]),
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
                    SELECT 	 g.id as GatewayId
                            ,g.id_zone as ZoneId
                            ,g.com as SerialPort
                            ,z.name as ZoneName
                            ,grx.connectnow as ConnectionStatus
                            ,grx.activenow as ActiveStatus
                            ,grx.cmd as Command
                    FROM	gateway as g
                    JOIN    zones as z
                    ON      g.id_zone = z.id_zone
                    JOIN    gatewayrx as grx
                    ON      g.id = grx.id_gateway
                    WHERE   z.active = true
                    AND     g.active = true
                    AND     grx.activenow > 0";
            return query;
        }
    }
}
