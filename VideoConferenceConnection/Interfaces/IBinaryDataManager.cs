using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.SqlServer.Server;
using VideoConferenceCommon;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceConnection.Interfaces
{
    /// <summary>
    /// Класс, отвечающий за передачу бинарной информации
    /// </summary>
    public interface IBinaryDataManager
    {
        /// <summary>
        /// Проверяет подключение. Отправляет приветственный пакет и ожидает ответа
        /// </summary>
        /// <returns>true - если подключение активно</returns>
        bool CheckConnection();

        /// <summary>
        /// Отправить приветствие
        /// </summary>
        void SendHello();

        /// <summary>
        /// Ожидает приветственные пакет
        /// </summary>
        /// <returns></returns>
        bool ReceiveHello();

        /// <summary>
        /// Закрывает базовый поток
        /// </summary>
        void Close();

        /// <summary>
        /// Отправить пакет с информацией
        /// </summary>
        /// <param name="package">Пакет информации</param>
        void SendPackage(IPackage package);

        /// <summary>
        /// Считать пакет из буфера
        /// </summary>
        /// <returns>Пакет</returns>
        IPackage ReadPackage(Constants.PackageType packageType);

        /// <summary>
        /// Ожидает получения пакета
        /// </summary>
        /// <returns>Возвращает тип полученного пакета</returns>
        Constants.PackageType Receive();

    }
}
