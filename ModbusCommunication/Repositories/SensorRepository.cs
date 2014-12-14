using System;
using System.Collections.Generic;
using ModbusCommunication.Models;
using ModbusCommunication.Utils;
using Npgsql;

namespace ModbusCommunication.Repositories
{
    internal class SensorRepository
    {
        internal List<Sensor> SelectSensors(int gatewayId)
        {
            var sensors = new List<Sensor>();

            var selectQuery = GetSelectQuery();

            using (var command = new NpgsqlCommand(selectQuery))
            {
                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sensors.Add(new Sensor
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            IsActive = Convert.ToInt32(dr["IsActive"]) == 1,
                            Status = GetSensorStatus(Convert.ToInt32(dr["Status"]))
                        });
                    }
                }

                command.Connection.Close();
            }

            return sensors;
        }

        private static string GetSensorStatus(int status)
        {
            switch (status)
            {
                case 0:
                    return "Nieaktywny";
                case 1:
                    return "Aktywny";
                default:
                    return "Nieaktywny od 24h";
            }
        }

        private static string GetSelectQuery()
        {
            const string query = @"
                        SELECT 	 s.id_sensor as Id
	                            ,g.connectnow as Status
	                            ,g.active as IsActive
                          FROM	gatewayrx as g
                          JOIN  sensors as s
                            ON  s.id_gateway = g.id_gateway
                         WHERE  g.index = s.id_sensor
                           AND   s.id_gateway = @GatewayId";
            return query;
        }
    }
}
