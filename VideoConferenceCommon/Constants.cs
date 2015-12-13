using System;

namespace VideoConferenceCommon
{
    public static class Constants
    {
        #region Константы подключения

        /// <summary>
        /// Типы пакетов передачи
        /// </summary>
        public enum PackageType
        {
            /// <summary>
            /// Приветствие
            /// </summary>
            Hello = 1,
            /// <summary>
            /// Только аудио
            /// </summary>
            AudioData = 2,
            /// <summary>
            /// Аудио и видео
            /// </summary>
            AudioAndVideoData = 3,

            Message = 4
        }

        #endregion


        /// <summary> 
        /// Метод обратного вызова. Возвращает только ошибку
        /// </summary>
        /// <param name="e">Ошибка во время выполнения основного метода</param>
        public delegate void VoidCallback(Exception e);

        /// <summary>
        /// Максимальное количество фрагментов в колекции
        /// </summary>
        public const int MaxFragmentCount = 10;

        /// <summary>
        /// Длина аудиофрагмента
        /// </summary>
        public const int FragmentLenght = 50;
    }
}
