using System;

namespace VideoConferenceCommon
{
    public static class Constants
    {
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
