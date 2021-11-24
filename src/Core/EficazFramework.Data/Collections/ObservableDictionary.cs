// Special Thanks to Shimmy Weitzhandler, for this nice implementation for active UI binding
// http://blogs.microsoft.co.il/blogs/shimmy/archive/2010/12/02/observabledictionary-lt-tkey-tvalue-gt.aspx

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Collections
{
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyPropertyChanged, INotifyCollectionChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public ObservableDictionary()
        {
            m_Dictionary = new Dictionary<TKey, TValue>();
        }

        public ObservableDictionary(IDictionary<TKey, TValue> dictionary)
        {
            m_Dictionary = new Dictionary<TKey, TValue>(dictionary);
        }

        public ObservableDictionary(IEqualityComparer<TKey> comparer)
        {
            m_Dictionary = new Dictionary<TKey, TValue>(comparer);
        }

        public ObservableDictionary(int capacity)
        {
            m_Dictionary = new Dictionary<TKey, TValue>(capacity);
        }

        public ObservableDictionary(IDictionary<TKey, TValue> dictionary, IEqualityComparer<TKey> comparer)
        {
            m_Dictionary = new Dictionary<TKey, TValue>(dictionary, comparer);
        }

        public ObservableDictionary(int capacity, IEqualityComparer<TKey> comparer)
        {
            m_Dictionary = new Dictionary<TKey, TValue>(capacity, comparer);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private const string CountString = "Count";
        private const string IndexerName = "Item[]";
        private const string KeysName = "Keys";
        private const string ValuesName = "Values";
        private IDictionary<TKey, TValue> m_Dictionary;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        protected IDictionary<TKey, TValue> Dictionary
        {
            get
            {
                return m_Dictionary;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void Clear()
        {
            if (Dictionary.Count > 0)
            {
                Dictionary.Clear();
                OnCollectionChanged();
            }
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Insert(item.Key, item.Value, true);
        }

        public void Add(TKey key, TValue value)
        {
            Insert(key, value, true);
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return Remove(item.Key);
        }

        public bool Remove(TKey key)
        {
            if (key is null)
                throw new ArgumentNullException("key");
            TValue item;
            Dictionary.TryGetValue(key, out item);
            bool removed = Dictionary.Remove(key);
            if (removed)
                OnCollectionChanged(); // FieldsNotifyCollectionChangedAction.Remove, New KeyValuePair(Of TKey, TValue)(key, item)
            return removed;
        }

        public TValue this[TKey key]
        {
            get
            {
                if (Dictionary.ContainsKey(key) == true)
                {
                    return Dictionary[key];
                }
                else
                {
                    return default;
                }
            }

            set
            {
                Insert(key, value, false);
            }
        }

        private void Insert(TKey key, TValue value, bool add)
        {
            if (key is null)
                throw new ArgumentNullException("key");
            TValue item;
            if (Dictionary.TryGetValue(key, out item))
            {
                if (add)
                    throw new ArgumentException("An item with the same key has already been added.");
                if (Equals(item, value))
                    return;
                Dictionary[key] = value;
                OnCollectionChanged(NotifyCollectionChangedAction.Replace, new KeyValuePair<TKey, TValue>(key, value), new KeyValuePair<TKey, TValue>(key, item));
            }
            else
            {
                Dictionary[key] = value;
                OnCollectionChanged(NotifyCollectionChangedAction.Add, new KeyValuePair<TKey, TValue>(key, value));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Dictionary.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get
            {
                return Dictionary.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return Dictionary.IsReadOnly;
            }
        }

        public ICollection<TKey> Keys
        {
            get
            {
                return Dictionary.Keys;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                return Dictionary.Values;
            }
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return Dictionary.Contains(item);
        }

        public bool ContainsKey(TKey key)
        {
            return Dictionary.ContainsKey(key);
        }

        public bool ContainsValue(TValue value)
        {
            return Dictionary.Values.Contains(value);
        }

        public bool TryGetValue(TKey key, [MaybeNullWhen(false)] out TValue value)
        {
            return Dictionary.TryGetValue(key, out value);
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return Dictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Dictionary).GetEnumerator();
        }

        private void OnPropertyChanged()
        {
            OnPropertyChanged(CountString);
            OnPropertyChanged(IndexerName);
            OnPropertyChanged(KeysName);
            OnPropertyChanged(ValuesName);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void OnCollectionChanged()
        {
            OnPropertyChanged();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> changedItem)
        {
            OnPropertyChanged();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItem, IndexOf(changedItem.Key)));
        }

        private void OnCollectionChanged(NotifyCollectionChangedAction action, KeyValuePair<TKey, TValue> newItem, KeyValuePair<TKey, TValue> oldItem)
        {
            OnPropertyChanged();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, newItem, oldItem, IndexOf(oldItem.Key)));
        }

        // Private Sub OnCollectionChanged(ByVal action As NotifyCollectionChangedAction, ByVal newItems As IList)
        // OnPropertyChanged()
        // RaiseEvent CollectionChanged(Me, New NotifyCollectionChangedEventArgs(action, newItems, ))
        // End Sub

        public int IndexOf(object key)
        {
            int i = 0;
            foreach (var pair in Dictionary)
            {
                if (Equals(pair.Key, key))
                {
                    break;
                }
                else
                {
                    i += 1;
                }
            }

            return i;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}