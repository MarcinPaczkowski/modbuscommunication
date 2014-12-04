using System;
using System.Collections.Generic;
using System.Xml.Linq;
using ModbusSensorOperation.Models;

namespace ModbusSensorOperation.Utils
{
    internal class Configuration
    {
        readonly Dictionary<string, string> _configParams;
        static readonly Configuration _instance = new Configuration();

        static Configuration()
        {
        }

        private Configuration()
        {
            _configParams = new Dictionary<string, string>();
        }

        internal static Configuration Instance
        {
            get
            {
                return _instance;
            }
        }

        internal void CreateConfiguration(string configFileName)
        {
            var vBody = new XElement("configuration");

            foreach (var item in _configParams)
            {
                vBody.Add(new XElement("param", new XAttribute("name", item.Key), item.Value));
            }

            vBody.Save(configFileName);
        }

        internal void LoadConfiguration(string configFileName)
        {
            var conf = XDocument.Load(configFileName);
            foreach (var elem in conf.Descendants("configuration").Elements("param"))
            {
                _configParams.Add(elem.Attribute("name").Value, elem.Value);
            }

            DbConnection.InitializeDb(GetEmptyDatabaseConfiguration());
        }

        internal void SetValue(string key, string value)
        {
            if (_configParams.ContainsKey(key))
                _configParams[key] = value;
            else
                _configParams.Add(key, value);
        }

        internal string GetValue(string paramName)
        {
            if (_configParams.ContainsKey(paramName))
                return _configParams[paramName];
            throw new Exception(String.Format("{0} {1} {2}",
                "Brak parametru", paramName, "w pliku konfiguracyjnym"));
        }

        internal DatabaseConfiguration GetEmptyDatabaseConfiguration()
        {
            return new DatabaseConfiguration
            {
                UserName = GetValue("User"),
                Password = GetValue("Password"),
                Host = GetValue("Server"),
                Database = GetValue("Database"),
                Port = Convert.ToInt32( GetValue("Port")),
            };
        }
    }
}
