namespace JavaScript.Collections
{
    public class Map<TKey, TValue> : BaseMap<TKey, TValue>
    {
        /// <summary>
        /// Removes all key-value pairs from the Map object.
        /// </summary>
        public virtual void Clear() => _entries.Clear();

        /// <summary>
        /// Returns true if an element in the Map object existed and has been removed, or false if the element does not exist. Map.prototype.Has(key) will return false afterwards.
        /// </summary>
        public virtual bool Delete(TKey key)
        {
            if (!this.Has(key))
                return false;

            return _entries.Remove(key);
        }

        /// <summary>
        /// Returns the value associated to the key, or the default value object if there is none.
        /// </summary>
        public virtual TValue Get(TKey key)
        {
            if (!this.Has(key))
                return default;

            return _entries[key];
        }

        /// <summary>
        /// Sets the value for the key in the Map object.
        /// </summary>
        public virtual void Set(TKey key, TValue value)
        {
            if (!this.Has(key))
                _entries.Add(key, value);
            else
                _entries[key] = value;
        }

        public TValue this[TKey key]
        {
            get => Get(key);
            set => Set(key, value);
        }
    }
}