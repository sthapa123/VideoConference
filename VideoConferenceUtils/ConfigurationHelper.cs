using System;
using System.Configuration;

namespace VideoConferenceUtils
{
    /// <summary>
    /// Класс для работы с файлом конфигурации
    /// </summary>
    public static class ConfigurationHelper
    {
        /// <summary>
        /// Возвращает целочисленное значение из конфигурационного файла
        /// </summary>
        /// <param name="configurationName">Имя параметра</param>
        /// <param name="defaultValue">Значение по умолчанию</param>
        /// <returns>Значение из конфигурационного файла</returns>
        public static int GetAppConfigurationInt(string configurationName, int defaultValue)
        {
            var value = ConfigurationSettings.AppSettings.Get(configurationName);

            if (String.IsNullOrEmpty(value))
                return defaultValue;

            return int.Parse(value);
        }

        /// <summary>
        /// Возвращает строковое значение из конфигурационного файла
        /// </summary>
        /// <param name="configurationName">Имя параметра</param>
        /// <param name="defaultValue">Значение по умолчанию</param>
        /// <returns>Значение из конфигурационного файла</returns>
        public static string GetAppConfigurationString(string configurationName, string defaultValue)
        {
            var value = ConfigurationSettings.AppSettings.Get(configurationName);

            if (String.IsNullOrEmpty(value))
                return defaultValue;

            return value;
        }
    }
}
