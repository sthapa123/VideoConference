using System;
using System.IO;
using VideoConferenceCommon;
using VideoConferenceUtils.Interfaces;

namespace VideoConferenceUtils
{
    public class LogHelper : ILogHelper, IDisposable
    {
        private static string _logFileName;
        private string _class;
        private static long _counter;
        private static StreamWriter _writer;

        static LogHelper()
        {
            _logFileName = String.Concat(DateTime.Now.Date, Constants.LogFileSuffix);
            if (!FileExist)
                throw new Exception("Не удалось создать файл логирования. Приложение не может быть запущено!");
            
            _writer = new StreamWriter(_logFileName);
            WriteStartProgramString();
        }

        public LogHelper(string targetClass)
        {
            _class = targetClass;
        }
        
        /// <summary>
        /// Существует ли файл конфигурации, если нет - пытается создать
        /// </summary>
        private static bool FileExist
        {
            get
            {
                if (!File.Exists(_logFileName))
                    File.Create(_logFileName);

                return File.Exists(_logFileName);
            }
        }

        /// <summary>
        /// Текущее время
        /// </summary>
        private static string CurrentTime
        {
            get { return DateTime.Now.ToLongDateString(); }
        }
        
        /// <summary>
        /// Записать строку в лог файл
        /// </summary>
        /// <param name="logFormat"></param>
        /// <param name="message"></param>
        private void WriteString(string logFormat, string message)
        {
            if (FileExist)
                _writer.WriteLine(GetLogString(logFormat, message));
        }

        /// <summary>
        /// Возвращает строку в формате записи в лог файл
        /// </summary>
        private string GetLogString(string logFormat, string message)
        {
            return String.Join("\t", _counter++, CurrentTime, logFormat, message);
        }

        public void Info(string message)
        {
            WriteString(Constants.LogInfo, message);
        }

        public void InfoFormat(string message, params object[] parameters)
        {
            var textMessage = string.Format(message, parameters);
            WriteString(Constants.LogInfo, textMessage);
        }

        public void Warning(string message)
        {
            WriteString(Constants.LogInfo, message);
        }

        public void WarningFormat(string message, params object[] parameters)
        {
            var textMessage = string.Format(message, parameters);
            WriteString(Constants.LogWarning, textMessage);
        }

        public void Error(string message)
        {
            WriteString(Constants.LogInfo, message);
        }

        public void ErrorFormat(string message, params object[] parameters)
        {
            var textMessage = string.Format(message, parameters);
            WriteString(Constants.LogError, textMessage);
        }

        public void Dispose()
        {
            _writer.Dispose();
        }

        private static void WriteStartProgramString()
        {
            _writer.WriteLine(String.Join("/t", CurrentTime, "//////__________________Application Start_________________//////"));
        }
    }
}
