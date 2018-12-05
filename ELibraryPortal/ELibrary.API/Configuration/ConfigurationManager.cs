using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ELibrary.API.Configuration
{
    public class ConfigurationManager
    {
        #region Fields
        private IConfiguration configuration;
        private GlobalSettings _globalSettings;
        #endregion

        #region Properties
        public IConfiguration Configuration
        {
            get { return configuration; }
        }

        public GlobalSettings GlobalSettings
        {
            get { return GlobalSettings.Instance; }
        }
        #endregion 

        #region Singleton Section
        private static ConfigurationManager instance;

        private ConfigurationManager()
        {
            var appsettings= Path.Combine($"{ Directory.GetParent(Directory.GetCurrentDirectory()).FullName}ELibrary.API", "appsettings.json");
            configuration = new ConfigurationBuilder().AddJsonFile(appsettings, false).Build();
        }

        public static ConfigurationManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConfigurationManager();
                }
                return instance;
            }
        }
        #endregion

        #region Methods
        public string GetConnectionString(string key)
        {
            return Configuration.GetConnectionString(key).ToString();
        }
        #endregion
    }
}
