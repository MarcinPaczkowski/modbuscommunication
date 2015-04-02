using System;
using System.Collections.Generic;
using ModbusCommon.Utils;
using ModbusCommunication.Models;
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
                command.Parameters.AddWithValue("@Id", gateway.Id);
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
                            GatewayId = gateway.HardwareGatewayId,
                        });
                    }
                }

                command.Connection.Close();
            }

            return sensors;
        }

        internal Sensor SelectPreviousSensorStatus(Sensor sensor, int zoneId, int gatewayId)
        {
            var previousSensor = new Sensor();
            var selectQuery = GetSelectPreviousStatusQuery();

            using (var command = new NpgsqlCommand(selectQuery))
            {
                command.Parameters.AddWithValue("@ZoneId", zoneId);
                command.Parameters.AddWithValue("@GatewayId", gatewayId);
                command.Parameters.AddWithValue("@SensorId", sensor.Id);

                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        previousSensor.Status = Convert.ToInt32(dr["PreviousStatus"]);
                        previousSensor.IsOffline = Convert.ToBoolean(dr["IsOffline"]);
                    }
                }

                command.Connection.Close();
            }

            return previousSensor;
        }

        internal void UpdateSensorStatus(Sensor sensor, int zoneId, int gatewayId)
        {
            var updateQuery = GetUpdateSensorQuery();
            using (var command = new NpgsqlCommand(updateQuery))
            {
                command.Parameters.AddWithValue("@GatewayId", gatewayId);
                command.Parameters.AddWithValue("@SensorId", sensor.Id);
                command.Parameters.AddWithValue("@ZoneId", zoneId);
                command.Parameters.AddWithValue("@Status", sensor.Status);
                command.Parameters.AddWithValue("@IsOffline", sensor.IsOffline);

                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();
                command.ExecuteNonQuery();

                command.Connection.Close();
            }
        }

        private static string GetSelectQuery()
        {
            const string query = @"
                select 	s.id_sensor as SensorId
                from    sensors as s
                join    gateway as g
                on      s.id_gateway = g.id_gateway
                where   g.active = true
                and     s.id_gateway = @Id
                and     g.id_zone = @ZoneId";
            return query;
        }

        private static string GetSelectPreviousStatusQuery()
        {
            const string query = @"
               SELECT  cur_state as PreviousStatus
                      ,is_offline as IsOffline
                 FROM sensors_events_cur
                WHERE id_sensor = @SensorId
                  AND id_gateway = @GatewayId
                  AND id_zone = @ZoneId";
            return query;
        }

        private static string GetUpdateSensorQuery()
        {
            const string query = @"
                UPDATE   sensors_events_cur
                   SET   cur_state = @Status
                        ,is_offline = @IsOffline
                        ,dtime = NOW()
                 WHERE   id_gateway = @GatewayId
                   AND   id_sensor  = @SensorId
                   AND   id_zone  = @ZoneId";
            return query;
        }
    }
}
