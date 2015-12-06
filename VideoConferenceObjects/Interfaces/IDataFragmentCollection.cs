using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VideoConferenceObjects.Interfaces
{
    //todo Сделать наследование от ICollection<IDataFragment>

    public interface IDataFragmentCollection //: ICollection<IDataFragment>
    {
        /// <summary>
        /// Возвращает элементы коллекции
        /// </summary>
        Dictionary<DateTime, IDataFragment> Items { get; }

        /// <summary>
        /// Количество элементов в коллекции
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Добавляет фрагмент информации в коллекцию
        /// </summary>
        /// <param name="time">Время записи</param>
        /// <param name="fragmet">Фрагмент</param>
        void Add(DateTime time, IDataFragment fragmet);

        /// <summary> 
        /// Удалить фрагмент из коллекции
        /// </summary>
        /// <param name="key">Ключ</param>
        void Remove(DateTime key);

        /// <summary>
        /// Возвращает первый элемент коллекции
        /// </summary>
        /// <returns></returns>
        KeyValuePair<DateTime, IDataFragment> GetFirstFragment();

        /// <summary>
        /// Возвращает первый элемент коллекции, после удаляет его
        /// </summary>
        /// <returns></returns>
        KeyValuePair<DateTime, IDataFragment> GetAndRemoveFirstFragment();

        /// <summary>
        /// Очистить коллекцию
        /// </summary>
        void Clear();
    }
}
