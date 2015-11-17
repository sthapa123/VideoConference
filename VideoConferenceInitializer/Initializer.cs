using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;

namespace VideoConferenceInitializer
{
    /// <summary>
    /// Класс, инициализирующий приложение
    /// </summary>
    public class Initializer
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        public Initializer()
        {
            
        }

        /// <summary>
        /// Инициализация приложения.
        /// </summary>
        /// <returns>true - если инициализация прошла успешно</returns>
        public bool Initialize()
        {

            return true;
        }
    }
}
