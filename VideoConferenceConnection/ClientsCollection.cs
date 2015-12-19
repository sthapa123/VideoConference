using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VideoConferenceCommon;
using VideoConferenceConnection.Server;

namespace VideoConferenceConnection
{
    public static class ClientsCollection
    {
        /// <summary>
        /// Коллекция подключившихся клиентов
        /// </summary>
        private static List<IClient> _clients = new List<IClient>();

        /// <summary>
        /// Добавить клиента в коллекцию
        /// </summary>
        /// <param name="client"></param>
        public static void Add(IClient client)
        {
            _clients.Add(client);
        }

        /// <summary>
        /// Получить первого в списке
        /// </summary>
        /// <returns></returns>
        public static IClient GetFirstClient()
        {
            return _clients.First();
        }
    }
}
