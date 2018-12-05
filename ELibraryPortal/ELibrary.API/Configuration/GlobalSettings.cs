using System;
using System.Collections.Generic;
using System.Text;

namespace ELibrary.API.Configuration
{
    public class GlobalSettings
    {
        #region Singleton Section
        private static GlobalSettings instance;

        private GlobalSettings()
        {
        }

        public static GlobalSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GlobalSettings();
                }
                return instance;
            }
        }
        #endregion
    }
}
