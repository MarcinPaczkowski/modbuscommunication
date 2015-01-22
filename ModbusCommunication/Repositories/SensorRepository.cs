using System;
using System.Collections.Generic;
using System.Linq;
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
                command.Parameters.AddWithValue("@GatewayId", gatewayId);
                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();

                using (var dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        sensors.Add(new Sensor
                        {
                            Id = Convert.ToInt32(dr["SensorId"]),
                            GatewayId = gatewayId,
                            Status = Convert.ToInt32(dr["Status"])
                        });
                    }
                }

                command.Connection.Close();
            }

            return sensors;
        }

        internal void InsertSensorToArchive(Sensor sensor)
        {
            var insertQuery = GetInsertSensorArchiveQuery();
            using (var command = new NpgsqlCommand(insertQuery))
            {
                command.Parameters.AddWithValue("@GatewayId", sensor.GatewayId);
                command.Parameters.AddWithValue("@SensorId", sensor.Id);
                command.Parameters.AddWithValue("@Status", sensor.Status);

                command.Connection = new NpgsqlConnection(DbConnection.GetConnectionString());
                command.Connection.Open();
                command.ExecuteNonQuery();

                command.Connection.Close();
            }
        }

        internal void UpdateSensorStatus(Sensor sensor)
        {
            var updateQuery = GetUpdateSensorQuery();
            using (var command = new NpgsqlCommand(updateQuery))
            {
                command.Parameters.AddWithValue("@GatewayId", sensor.GatewayId);
                command.Parameters.AddWithValue("@SensorId", sensor.Id);
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
                UPDATE sensors
                   SET status = @Status
                 WHERE id_gateway = @GatewayId
                   AND id_sensor  = @SensorId";
            return query;
        }

        private static string GetSelectQuery()
        {
            const string query = @"
                select 	 s.id_sensor as SensorId
	                    ,s.status as Status
                from    sensors as s
                join    gateway as g
                on      s.id_gateway = g.id
                where   g.active = true
                and     s.id_gateway = @GatewayId";
            return query;
        }

        private static string GetInsertSensorArchiveQuery()
        {
            const string query = @"
            INSERT INTO sensors_archive
                        (id_gateway
                        ,id_sensor
                        ,status
                        ,time)
                 VALUES 
                        (@GatewayId
                        ,@SensorId
                        ,@Status
                        ,now());";
            return query;
        }
    }
}
