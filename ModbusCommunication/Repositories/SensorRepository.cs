using System;
using System.Collections.Generic;
using ModbusCommunication.Models;
using ModbusCommunication.Utils;
using Npgsql;

namespace ModbusCommunication.Repositories
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

        internal int SelectPreviousSensorStatus(Sensor sensor, int zoneId)
        {
            var previousStatus = 0;
            var selectQuery = GetSelectPreviousStatusQuery();

            using (var command = new NpgsqlCommand(selectQuery))
            {
                command.Parameters.AddWithValue("@ZoneId", zoneId);
                command.Parameters.AddWithValue("@GatewayId", sensor.GatewayId);
                command.Parameters.AddWithValue("@SensorId", sensor.Id);

                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                        previousStatus = Convert.ToInt32(dr["PreviousStatus"]);
                }

                command.Connection.Close();
            }

            return previousStatus;
        }

        internal void UpdateSensorStatus(Sensor sensor, int zoneId)
        {
            var updateQuery = GetUpdateSensorQuery();
            using (var command = new NpgsqlCommand(updateQuery))
            {
                command.Parameters.AddWithValue("@GatewayId", sensor.GatewayId);
                command.Parameters.AddWithValue("@SensorId", sensor.Id);
                command.Parameters.AddWithValue("@ZoneId", zoneId);
                command.Parameters.AddWithValue("@Status", sensor.Status);

                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();
                command.ExecuteNonQuery();

                command.Connection.Close();
            }
        }

        private static string GetUpdateSensorQuery()
        {
            const string query = @"
                UPDATE   sensors_events_cur
                   SET   cur_state = @Status
                        ,dtime = NOW()
                 WHERE   id_gateway = @GatewayId
                   AND   id_sensor  = @SensorId
                   AND   id_zone  = @ZoneId";
            return query;
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

        private static string GetSelectPreviousStatusQuery()
        {
            const string query = @"
               SELECT cur_state as PreviousStatus
                 FROM sensors_events_cur
                WHERE id_sensor = @SensorId
                  AND id_gateway = @GatewayId
                  AND id_zone = @ZoneId";
            return query;
        }
    }
}
