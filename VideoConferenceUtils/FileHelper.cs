using System;
using System.IO;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils
{
    static class FileHelper
    {
        static ILogHelper log = new LogHelper("FileHelper");
        
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
                if (File.Exists(fileFullName))
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Не удалось создать экземпляр класса: {0}", ex);
                return false;
            }
        }
    }
}
