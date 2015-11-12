using System;
using System.IO;
using NLog;

namespace VideoConferenceUtils
{
    public static class FileHelper
    {
        #region Логгирование
        private static Logger _log = LogManager.GetCurrentClassLogger();
        #endregion

        /// <summary>
        /// Удаляет указанный файл
        /// </summary>
        /// <returns>true - если файла нет</returns>
        public static bool RemoveFile(string fileFullName)
        {
            if (!File.Exists(fileFullName))
                return true;

            try
            {
                File.Delete(fileFullName);
                return File.Exists(fileFullName);
            }
            catch(Exception ex)
            {
                _log.Error(ex, "RemoveFile. Не удалось удалить файл {0}", fileFullName);
                return false;
            }
        }
    }
}
