using System;
using System.Collections.Generic;
using ModbusCommon.Utils;
using ModbusCommunication.Models;
using Npgsql;

namespace ModbusCommunication.Repositories
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
                            Id = Convert.ToInt32(dr["Id"]),
                            HardwareGatewayId = Convert.ToInt32(dr["HardwareGatewayId"]),
                            ZoneId = Convert.ToInt32(dr["ZoneId"]),
                            SerialPort = dr["SerialPort"].ToString(),
                            ZoneName = dr["ZoneName"].ToString(),
                            SensorsInterval = Convert.ToInt32(dr["SensorsInterval"]),
                            SensorsIntervalCounter = Convert.ToInt32(dr["SensorsInterval"])
                        });
                    }
                }

                command.Connection.Close();
            }

            return gateways;
        }

        internal void InsertGatewayResponse(Gateway gateway, string response)
        {
            var insertQuery = GetInsertGatewayResponseQuery();
            using (var command = new NpgsqlCommand(insertQuery))
            {
                command.Parameters.AddWithValue("@HardwareGatewayId", gateway.HardwareGatewayId);
                command.Parameters.AddWithValue("@Response", response);

                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();
                command.ExecuteNonQuery();

                command.Connection.Close();
            }
        }

        private static string GetInsertGatewayResponseQuery()
        {
            const string query = @"
                INSERT INTO gatewayrx
                            (id_gateway
                            ,time
                            ,connectnow
                            ,active
                            ,activenow
                            ,cmd)
                    VALUES 
                            (@HardwareGatewayId
                            ,NOW()
                            ,1
                            ,1
                            ,1
                            ,@Response)";
            return query;
        }

        private static string GetSelectQuery()
        {
            const string query = @"
                    SELECT 	 g.id_gateway as Id
                            ,g.com_id_gateway as HardwareGatewayId
                            ,g.id_zone as ZoneId
                            ,g.com as SerialPort
                            ,z.name as ZoneName
                            ,g.sensors_interval as SensorsInterval
                    FROM	gateway as g
                    JOIN    zones as z
                    ON      g.id_zone = z.id_zone
                    WHERE   z.active = true
                    AND     g.active = true";
            return query;
        }
    }
}
