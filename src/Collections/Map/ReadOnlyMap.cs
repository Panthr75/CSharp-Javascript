namespace JavaScript.Collections
{
    public class ReadOnlyMap<TKey, TValue> : BaseMap<TKey, TValue>
    {
        /// <summary>
        /// Returns the value associated to the key, or the default value object if there is none.
        /// </summary>
        public virtual TValue Get(TKey key)
        {
            if (!this.Has(key))
                return default;

            return _entries[key];
        }

        public TValue this[TKey key]
        {
            get => Get(key);
        }
    }
}