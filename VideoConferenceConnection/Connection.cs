using System;
using VideoConferenceUtils;

namespace VideoConferenceConnection
{
    public class Connection
    {
        private string _userName;
        private int _port;

        //public Connection()
        //{
        //    
        //}

        public Connection()
        {
            var userName = ConfigurationHelper.GetAppConfigurationString("username", String.Empty);
            var port = ConfigurationHelper.GetAppConfigurationInt("port", 0);
            var machineName = Environment.MachineName;

            if (String.IsNullOrEmpty(userName) || port == 0)
            {
                Console.WriteLine("Нет логина/порта");
                return;
            }
        }
    }
}
