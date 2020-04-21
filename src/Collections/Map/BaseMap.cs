using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace JavaScript.Collections
{
    public abstract class BaseMap<TKey, TValue>
    {
        protected Dictionary<TKey, TValue> _entries = new Dictionary<TKey, TValue>();

        /// <summary>
        /// Returns the number of key/value pairs in the Map object.
        /// </summary>
        public int Size => _entries.Count;

        /// <summary>
        /// Returns a new iterable collection object of key, value pairs for every entry in the map.
        /// </summary>
        /// <returns></returns>
        public EntryCollection Entries() => new EntryCollection(this);

        /// <summary>
        /// Calls callbackFn once for each key-value pair present in the Map object, in insertion order.
        /// </summary>
        public virtual void ForEach(Action callbackfn)
        {
            for (int index = 0; index < this.Size; index++)
                callbackfn();
        }

        /// <summary>
        /// Calls callbackFn once for each key-value pair present in the Map object, in insertion order.
        /// </summary>
        public virtual void ForEach(Action<TValue> callbackfn)
        {
            foreach (TKey key in _entries.Keys)
                callbackfn(_entries[key]);
        }

        /// <summary>
        /// Calls callbackFn once for each key-value pair present in the Map object, in insertion order.
        /// </summary>
        public virtual void ForEach(Action<TValue, TKey> callbackfn)
        {
            foreach (TKey key in _entries.Keys)
                callbackfn(_entries[key], key);
        }

        /// <summary>
        /// Returns a boolean asserting whether a value has been associated to the key in the Map object or not.
        /// </summary>
        public virtual bool Has(TKey key) => _entries.ContainsKey(key);

        /// <summary>
        /// Returns a new iterable collection object that contains the keys for each element in the Map object in insertion order.
        /// </summary>
        public KeyCollection Keys() => new KeyCollection(this);

        /// <summary>
        /// Returns a new iterable collection object that contains the values for each element in the Map object in insertion order.
        /// </summary>
        public ValueCollection Values() => new ValueCollection(this);

        #region Entry Item
        [Serializable]
        public struct EntryItem
        {
            public TKey Key { get; }
            public TValue Value { get; }

            internal EntryItem(TKey key, TValue value)
            {
                Key = key;
                Value = value;
            }
        }
        #endregion

        #region Iterators

        [Serializable]
        public sealed class KeyCollection : IEnumerable<TKey>
        {
            private readonly BaseMap<TKey, TValue> raw;

            internal KeyCollection(BaseMap<TKey, TValue> map)
            {
                raw = map;
            }

            public int Size
            {
                get => raw.Size;
            }

            public IEnumerator<TKey> GetEnumerator() => new KeyIterator(raw);
            IEnumerator IEnumerable.GetEnumerator() => new KeyIterator(raw);

            [Serializable]
            public struct KeyIterator : IEnumerator<TKey>, IEnumerator
            {
                private IEnumerator<TKey> raw;
                private readonly BaseMap<TKey, TValue> raw_data;

                internal KeyIterator(BaseMap<TKey, TValue> map)
                {
                    raw = map._entries.Keys.GetEnumerator();
                    raw_data = map;
                }

                private void ResetRaw() => raw = raw_data._entries.Keys.GetEnumerator();

                public void Dispose() => raw.Dispose();

                public bool MoveNext() => raw.MoveNext();

                public TKey Current => raw.Current;

                object IEnumerator.Current
                {
                    get => raw.Current;
                }

                void IEnumerator.Reset()
                {
                    raw.Dispose();
                    ResetRaw();
                }
            }
        }

        [Serializable]
        public sealed class ValueCollection : IEnumerable<TValue>
        {
            private readonly BaseMap<TKey, TValue> raw;

            internal ValueCollection(BaseMap<TKey, TValue> map)
            {
                raw = map;
            }

            public int Size
            {
                get => raw.Size;
            }

            public IEnumerator<TValue> GetEnumerator() => new ValueIterator(raw);
            IEnumerator IEnumerable.GetEnumerator() => new ValueIterator(raw);

            [Serializable]
            public struct ValueIterator : IEnumerator<TValue>, IEnumerator
            {
                private IEnumerator<TValue> raw;
                private readonly BaseMap<TKey, TValue> raw_data;

                internal ValueIterator(BaseMap<TKey, TValue> map)
                {
                    raw = map._entries.Values.GetEnumerator();
                    raw_data = map;
                }

                private void ResetRaw() => raw = raw_data._entries.Values.GetEnumerator();

                public void Dispose() => raw.Dispose();

                public bool MoveNext() => raw.MoveNext();

                public TValue Current => raw.Current;

                object IEnumerator.Current
                {
                    get => raw.Current;
                }

                void IEnumerator.Reset()
                {
                    raw.Dispose();
                    ResetRaw();
                }
            }
        }

        [Serializable]
        public sealed class EntryCollection : IEnumerable<EntryItem>
        {
            private readonly BaseMap<TKey, TValue> raw;

            internal EntryCollection(BaseMap<TKey, TValue> map)
            {
                raw = map;
            }

            public int Size
            {
                get => raw.Size;
            }

            public IEnumerator<EntryItem> GetEnumerator() => new EntryIterator(raw);
            IEnumerator IEnumerable.GetEnumerator() => new EntryIterator(raw);

            [Serializable]
            public struct EntryIterator : IEnumerator<EntryItem>, IEnumerator
            {
                private BaseMap<TKey, TValue> map;
                private IEnumerator<TKey> keyEnumerator;
                private TKey currentKey;
                private TValue currentValue;

                internal EntryIterator(BaseMap<TKey, TValue> map)
                {
                    this.map = map;
                    currentKey = default;
                    currentValue = default;
                    keyEnumerator = map._entries.Keys.GetEnumerator();
                }

                public void Dispose()
                {
                    keyEnumerator.Dispose();
                }

                public bool MoveNext()
                {
                    bool result = keyEnumerator.MoveNext();
                    if (result == true)
                    {
                        currentKey = keyEnumerator.Current;
                        currentValue = map.Has(currentKey) ? map._entries[currentKey] : default;
                    }
                    else
                    {
                        currentKey = default;
                        currentValue = default;
                    }

                    return result;
                }

                public EntryItem Current
                {
                    get => new EntryItem(currentKey, currentValue);
                }

                object IEnumerator.Current
                {
                    get => Current;
                }

                void IEnumerator.Reset()
                {
                    keyEnumerator.Reset();

                    currentKey = default;
                    currentValue = default;
                }
            }
        }

        #endregion
    }
}