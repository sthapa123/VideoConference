using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NLog;
using VideoConferenceObjects.Interfaces;

namespace VideoConferenceCommon
{
    public class DataFragmentCollection : IDataFragmentCollection
    {
        #region Логгирование
        private static Logger log = LogManager.GetCurrentClassLogger();
        #endregion

        private Dictionary<DateTime, IDataFragment> _fragments;

        public DataFragmentCollection()
        {
            _fragments = new Dictionary<DateTime, IDataFragment>();
        }

        /// <summary>
        /// Возвращает элементы коллекции
        /// </summary>
        public Dictionary<DateTime, IDataFragment> Items
        {
            get { return _fragments; }
        }

        /// <summary>
        /// Колличество элементов в коллекции
        /// </summary>
        public int Count
        {
            get { return _fragments.Count; }
        }

        /// <summary>
        /// Добавляет фрагмент информации в коллекцию
        /// </summary>
        /// <param name="time">Время записи</param>
        /// <param name="fragmet">Фрагмент</param>
        public void Add(DateTime time, IDataFragment fragmet)
        {
            try
            {
                lock (_fragments)
                {
                    _fragments.Add(time, fragmet);
                    OnCollectionChanged();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex, "Фрагмент не был добавлен");
            }
        }

        /// <summary> 
        /// Удалить фрагмент из коллекции
        /// </summary>
        /// <param name="key">Ключ</param>
        public void Remove(DateTime key)
        {
            lock (_fragments)
            {
                _fragments.Remove(key);
            }
        }

        /// <summary>
        /// Возвращает первый элемент коллекции
        /// </summary>
        /// <returns></returns>
        public KeyValuePair<DateTime, IDataFragment> GetFirstFragment()
        {
            if (_fragments.Count == 0)
                return new KeyValuePair<DateTime, IDataFragment>();

            return _fragments.First();
        }

        /// <summary>
        /// Возвращает фрагмент и после удаляет его
        /// </summary>
        /// <returns>Фрагмент</returns>
        public KeyValuePair<DateTime, IDataFragment> GetAndRemoveFirstFragment()
        {
            lock (_fragments)
            {
                if (_fragments.Count == 0)
                    return new KeyValuePair<DateTime, IDataFragment>();

                var paid = _fragments.First();
                Remove(paid.Key);

                return paid;
            }
        }

        /// <summary>
        /// Очистить коллекцию
        /// </summary>
        public void Clear()
        {
            _fragments.Clear();
        }

        /// <summary>
        /// Событие изменения количества элементов
        /// </summary>
        private void OnCollectionChanged()
        {
            while (_fragments.Count > Constants.MaxFragmentCount)
                _fragments.Remove(_fragments.First().Key);
        }
    }
}
