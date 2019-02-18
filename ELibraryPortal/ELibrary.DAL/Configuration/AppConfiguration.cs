using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ELibrary.DAL.Configuration
{
    public class AppConfiguration 
    {
        private readonly string _sqlConnection;
        private static AppConfiguration _instance;
        public static AppConfiguration Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AppConfiguration();
                }
                return _instance;
            }
        }
        public AppConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder();
            //var appsettings = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()) + "/ELibrary.API", "appsettings.json");
            //deploy olurken aktif
            var appsettings = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(appsettings, false);

            var root = configurationBuilder.Build();
            _sqlConnection = @"server=diyarkitap.com\\MSSQLSERVER2012;user id=baltazzar;password=Angel4you!;initial catalog=DiyarKitapDB";// root.GetConnectionString("SqlConnection"); 
        }

        public string SqlDataConnection
        {
            get => _sqlConnection;
        }
    }
}
