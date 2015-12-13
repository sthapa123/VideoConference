using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Text;
using VideoConferenceCommon;
using VideoConferenceConnection.Interfaces;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceConnection
{
    /// <summary>
    /// Класс, отвечающий за передачу бинарной информации
    /// </summary>
    public class BinaryDataManager : IBinaryDataManager
    {
        /// <summary>
        /// Чтение информации
        /// </summary>
        private readonly BinaryReader _reader;

        /// <summary>
        /// Запись информации
        /// </summary>
        private readonly BinaryWriter _writer;

        public BinaryDataManager(SslStream sslStream)
        {
            _reader = new BinaryReader(sslStream, Encoding.UTF8);
            _writer = new BinaryWriter(sslStream, Encoding.UTF8);
        }

        /// <summary>
        /// Проверяет подключение. От сервера к клиенту
        /// </summary>
        /// <returns>true - если подключение активно</returns>
        public bool CheckConnection()
        {
            SendHello();
            return ReceiveHello();
        }

        /// <summary>
        /// Отправить приветствие
        /// </summary>
        public void SendHello()
        {
            SendInt((int) Constants.PackageType.Hello);
        }

        /// <summary>
        /// Ожидает приветственные пакет
        /// </summary>
        /// <returns></returns>
        public bool ReceiveHello()
        {
            //Сделать таймаут ожидания
            var hello = _reader.ReadInt32();

            return hello == (int) Constants.PackageType.Hello;
        }

        /// <summary>
        /// Отправить пакет с информацией
        /// </summary>
        /// <param name="package">Пакет информации</param>
        public void SendPackage(IPackage package)
        {
            var packageType = package.VideoData == null
                ? Constants.PackageType.AudioData
                : Constants.PackageType.AudioAndVideoData;

            _writer.Write((int) packageType);
            _writer.Write(package.RecordTime);
            _writer.Write(package.AudioData.Length);
            _writer.Write(package.AudioData);
            if (packageType == Constants.PackageType.AudioAndVideoData && package.VideoData != null)
            {
                _writer.Write(package.VideoData.Length);
                _writer.Write(package.VideoData);
            }
            _writer.Flush();
        }

        /// <summary>
        /// Считать пакет из буфера
        /// </summary>
        /// <returns>Пакет</returns>
        public IPackage ReadPackage(Constants.PackageType packageType)
        {
            var package = new Package();
            package.RecordTime = ReadLong();
            var audioDataLenght = ReadInt();
            package.AudioData = ReadBytes(audioDataLenght);

            if (packageType == Constants.PackageType.AudioData)
                return package;

            var videoDataLenght = ReadInt();
            package.VideoData = ReadBytes(videoDataLenght);

            return package;
        }

        /// <summary>
        /// Ожидает получения пакета
        /// </summary>
        /// <returns>Возвращает тип полученного пакета</returns>
        public Constants.PackageType Receive()
        {
            return (Constants.PackageType) _reader.ReadInt32();
        }


        public void Close()
        {
            _writer.Close();
            _reader.Close();
        }


        #region Закрытые методы чтения/записи/передачи

        #region Чтение

        /// <summary>
        /// Считывает указанное количество байт
        /// </summary>
        /// <param name="lenght">Количество байт</param>
        public byte[] ReadBytes(int lenght)
        {
            return _reader.ReadBytes(lenght);
        }

        /// <summary>
        /// Прочитать целочисленное значение
        /// </summary>
        private int ReadInt()
        {
            return _reader.ReadInt32();
        }

        /// <summary>
        /// Считывает long из потока
        /// </summary>
        private long ReadLong()
        {
            return _reader.ReadInt64();
        }

        #endregion

        #region Запись

        #endregion

        #region Запись и передача

        /// <summary>
        /// Отправляет целочисленное значение
        /// </summary>
        /// <param name="value">Значение</param>
        private void SendInt(int value)
        {
            _writer.Write(value);
            _writer.Flush();
        }

        #endregion

        #endregion
    }
}
