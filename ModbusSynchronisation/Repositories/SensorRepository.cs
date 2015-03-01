using System;
using System.Collections.Generic;
using ModbusCommon.Utils;
using ModbusSynchronisation.Models;
using Npgsql;

namespace ModbusSynchronisation.Repositories
{
    internal class SensorRepository
    {
        internal List<Sensor> SelectSensors(Gateway gateway)
        {
            var sensors = new List<Sensor>();
            var selectQuery = GetSelectQuery();

            using (var command = new NpgsqlCommand(selectQuery))
            {
                command.Parameters.AddWithValue("@GatewayId", gateway.GatewayId);
                command.Parameters.AddWithValue("@ZoneId", gateway.ZoneId);
                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sensors.Add(new Sensor
                        {
                            Id = Convert.ToInt32(dr["SensorId"]),
                            GatewayId = gateway.GatewayId,
                        });
                    }
                }

                command.Connection.Close();
            }

            return sensors;
        }

        private static string GetSelectQuery()
        {
            const string query = @"
                select 	s.id_sensor as SensorId
                from    sensors as s
                join    gateway as g
                on      s.id_gateway = g.id_gateway
                where   g.active = true
                and     s.id_gateway = @GatewayId
                and     g.id_zone = @ZoneId";
            return query;
        }
    }
}
