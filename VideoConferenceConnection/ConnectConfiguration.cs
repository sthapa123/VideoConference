﻿using System;
using VideoConferenceUtils;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Класс начальных настроек подключения
    /// </summary>
    public static class ConnectConfiguration
    {
        /// <summary>
        /// Имя машины
        /// </summary>
        public static string MachineName
        {
            get { return Environment.MachineName; }
        }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public static string UserName
        {
            get { return ConfigurationHelper.GetAppConfigurationString("username", String.Empty); }
        }

        /// <summary>
        /// Порт
        /// </summary>
        public static int Port
        {
            get { return ConfigurationHelper.GetAppConfigurationInt("port", 0); }
        }
    }
}
