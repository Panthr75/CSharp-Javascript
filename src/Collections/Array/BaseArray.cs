using System;
using System.Collections;
using System.Collections.Generic;

namespace JavaScript.Collections
{
    public abstract class BaseArray<TArrayType, TArray> where TArray : BaseArray<TArrayType, TArray>
    {
        protected List<TArrayType> _entries = new List<TArrayType>();

        /// <summary>
        /// Returns a new iterable collection of key, value pairs for every entry in the array
        /// </summary>
        /// <returns></returns>
        public EntryCollection Entries() => new EntryCollection(this);

        /// <summary>
        /// Determines whether all the members of an array satisfy the specified test.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. The every method calls the callbackfn function for each element in the array until the callbackfn returns a value which is coercible to the Boolean value false, or until the end of the array.</param>
        /// <returns></returns>
        public abstract bool Every(Func<bool> callbackfn);

        /// <summary>
        /// Determines whether all the members of an array satisfy the specified test.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. The every method calls the callbackfn function for each element in the array until the callbackfn returns a value which is coercible to the Boolean value false, or until the end of the array.</param>
        /// <returns></returns>
        public abstract bool Every(Func<TArrayType, bool> callbackfn);

        /// <summary>
        /// Determines whether all the members of an array satisfy the specified test.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. The every method calls the callbackfn function for each element in the array until the callbackfn returns a value which is coercible to the Boolean value false, or until the end of the array.</param>
        /// <returns></returns>
        public abstract bool Every(Func<TArrayType, int, bool> callbackfn);

        /// <summary>
        /// Determines whether all the members of an array satisfy the specified test.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. The every method calls the callbackfn function for each element in the array until the callbackfn returns a value which is coercible to the Boolean value false, or until the end of the array.</param>
        /// <returns></returns>
        public abstract bool Every(Func<TArrayType, int, TArray, bool> callbackfn);

        /// <summary>
        /// Returns the elements of an array that meet the condition specified in a callback function.
        /// </summary>
        /// <param name="callbackfn">Returns the elements of an array that meet the condition specified in a callback function.</param>
        /// <returns></returns>
        public abstract TArray Filter(Func<bool> callbackfn);

        /// <summary>
        /// Returns the elements of an array that meet the condition specified in a callback function.
        /// </summary>
        /// <param name="callbackfn">Returns the elements of an array that meet the condition specified in a callback function.</param>
        /// <returns></returns>
        public abstract TArray Filter(Func<TArrayType, bool> callbackfn);

        /// <summary>
        /// Returns the elements of an array that meet the condition specified in a callback function.
        /// </summary>
        /// <param name="callbackfn">Returns the elements of an array that meet the condition specified in a callback function.</param>
        /// <returns></returns>
        public abstract TArray Filter(Func<TArrayType, int, bool> callbackfn);

        /// <summary>
        /// Returns the elements of an array that meet the condition specified in a callback function.
        /// </summary>
        /// <param name="callbackfn">Returns the elements of an array that meet the condition specified in a callback function.</param>
        /// <returns></returns>
        public abstract TArray Filter(Func<TArrayType, int, TArray, bool> callbackfn);

        /// <summary>
        /// Returns the value of the first element in the array where predicate is true, and undefined otherwise.
        /// </summary>
        /// <param name="callbackfn">find calls predicate once for each element of the array, in ascending order, until it finds one where predicate returns true. If such an element is found, find immediately returns that element value. Otherwise, find returns null.</param>
        /// <returns></returns>
        public abstract TArrayType Find(Func<bool> callbackfn);

        /// <summary>
        /// Returns the value of the first element in the array where predicate is true, and undefined otherwise.
        /// </summary>
        /// <param name="callbackfn">find calls predicate once for each element of the array, in ascending order, until it finds one where predicate returns true. If such an element is found, find immediately returns that element value. Otherwise, find returns null.</param>
        /// <returns></returns>
        public abstract TArrayType Find(Func<TArrayType, bool> callbackfn);

        /// <summary>
        /// Returns the value of the first element in the array where predicate is true, and undefined otherwise.
        /// </summary>
        /// <param name="callbackfn">find calls predicate once for each element of the array, in ascending order, until it finds one where predicate returns true. If such an element is found, find immediately returns that element value. Otherwise, find returns null.</param>
        /// <returns></returns>
        public abstract TArrayType Find(Func<TArrayType, int, bool> callbackfn);

        /// <summary>
        /// Returns the value of the first element in the array where predicate is true, and undefined otherwise.
        /// </summary>
        /// <param name="callbackfn">find calls predicate once for each element of the array, in ascending order, until it finds one where predicate returns true. If such an element is found, find immediately returns that element value. Otherwise, find returns null.</param>
        /// <returns></returns>
        public abstract TArrayType Find(Func<TArrayType, int, TArray, bool> callbackfn);

        /// <summary>
        /// Returns the index of the first element in the array where predicate is true, and -1 otherwise.
        /// </summary>
        /// <param name="callbackfn"></param>
        /// <returns>find calls predicate once for each element of the array, in ascending order, until it finds one where predicate returns true. If such an element is found, findIndex immediately returns that element index. Otherwise, findIndex returns -1.</returns>
        public abstract int FindIndex(Func<bool> callbackfn);

        /// <summary>
        /// Returns the index of the first element in the array where predicate is true, and -1 otherwise.
        /// </summary>
        /// <param name="callbackfn"></param>
        /// <returns>find calls predicate once for each element of the array, in ascending order, until it finds one where predicate returns true. If such an element is found, findIndex immediately returns that element index. Otherwise, findIndex returns -1.</returns>
        public abstract int FindIndex(Func<TArrayType, bool> callbackfn);

        /// <summary>
        /// Returns the index of the first element in the array where predicate is true, and -1 otherwise.
        /// </summary>
        /// <param name="callbackfn"></param>
        /// <returns>find calls predicate once for each element of the array, in ascending order, until it finds one where predicate returns true. If such an element is found, findIndex immediately returns that element index. Otherwise, findIndex returns -1.</returns>
        public abstract int FindIndex(Func<TArrayType, int, bool> callbackfn);

        /// <summary>
        /// Returns the index of the first element in the array where predicate is true, and -1 otherwise.
        /// </summary>
        /// <param name="callbackfn"></param>
        /// <returns>find calls predicate once for each element of the array, in ascending order, until it finds one where predicate returns true. If such an element is found, findIndex immediately returns that element index. Otherwise, findIndex returns -1.</returns>
        public abstract int FindIndex(Func<TArrayType, int, TArray, bool> callbackfn);

        /// <summary>
        /// Performs the specified action for each element in an array.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. forEach calls the callbackfn function one time for each element in the array.</param>
        public abstract void ForEach(Action callbackfn);

        /// <summary>
        /// Performs the specified action for each element in an array.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. forEach calls the callbackfn function one time for each element in the array.</param>
        public abstract void ForEach(Action<TArrayType> callbackfn);

        /// <summary>
        /// Performs the specified action for each element in an array.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. forEach calls the callbackfn function one time for each element in the array.</param>
        public abstract void ForEach(Action<TArrayType, int> callbackfn);

        /// <summary>
        /// Performs the specified action for each element in an array.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. forEach calls the callbackfn function one time for each element in the array.</param>
        public abstract void ForEach(Action<TArrayType, int, TArray> callbackfn);

        /// <summary>
        /// Determines whether an array includes a certain element, returning true or false as appropriate.
        /// </summary>
        /// <param name="searchElement">The element to search for.</param>
        /// <returns></returns>
        public abstract bool Includes(TArrayType searchElement);

        /// <summary>
        /// Determines whether an array includes a certain element, returning true or false as appropriate.
        /// </summary>
        /// <param name="searchElement">The element to search for.</param>
        /// <param name="fromIndex">The position in this array at which to begin searching for searchElement.</param>
        /// <returns></returns>
        public abstract bool Includes(TArrayType searchElement, int fromIndex);

        /// <summary>
        /// Returns the index of the first occurrence of a value in an array.
        /// </summary>
        /// <param name="searchElement">The value to locate in the array.</param>
        /// <returns></returns>
        public abstract int IndexOf(TArrayType searchElement);

        /// <summary>
        /// Returns the index of the first occurrence of a value in an array.
        /// </summary>
        /// <param name="searchElement">The value to locate in the array.</param>
        /// <param name="fromIndex">The array index at which to begin the search. If fromIndex is omitted, the search starts at index 0.</param>
        /// <returns></returns>
        public abstract int IndexOf(TArrayType searchElement, int fromIndex);

        /// <summary>
        /// Adds all the elements of an array separated by the specified separator string.
        /// </summary>
        /// <param name="seperator">A string used to separate one element of an array from the next in the resulting String. If omitted, the array elements are separated with a comma.</param>
        /// <returns></returns>
        public abstract string Join(string seperator = ",");

        /// <summary>
        /// Returns a new iterable collection of keys in the array
        /// </summary>
        /// <returns></returns>
        public KeyCollection Keys() => new KeyCollection(this);

        /// <summary>
        /// Returns the index of the last occurrence of a specified value in an array.
        /// </summary>
        /// <param name="searchElement">The value to locate in the array.</param>
        /// <returns></returns>
        public abstract int LastIndexOf(TArrayType searchElement);

        /// <summary>
        /// Returns the index of the last occurrence of a specified value in an array.
        /// </summary>
        /// <param name="searchElement">The value to locate in the array.</param>
        /// <param name="fromIndex">The array index at which to begin the search. If fromIndex is omitted, the search starts at the last index in the array.</param>
        /// <returns></returns>
        public abstract int LastIndexOf(TArrayType searchElement, int fromIndex);

        /// <summary>
        /// Returns a section of an array.
        /// </summary>
        /// <returns></returns>
        public abstract TArray Slice();

        /// <summary>
        /// Returns a section of an array.
        /// </summary>
        /// <param name="start">The beginning of the specified portion of the array.</param>
        /// <returns></returns>
        public abstract TArray Slice(int start);

        /// <summary>
        /// Returns a section of an array.
        /// </summary>
        /// <param name="start">The beginning of the specified portion of the array.</param>
        /// <param name="end">The end of the specified portion of the array. This is exclusive of the element at the index 'end'.</param>
        /// <returns></returns>
        public abstract TArray Slice(int start, int end);

        /// <summary>
        /// Determines whether the specified callback function returns true for any element of an array.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. The some method calls the callbackfn function for each element in the array until the callbackfn returns a value which is coercible to the Boolean value true, or until the end of the array.</param>
        /// <returns></returns>
        public abstract bool Some(Func<bool> callbackfn);

        /// <summary>
        /// Determines whether the specified callback function returns true for any element of an array.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. The some method calls the callbackfn function for each element in the array until the callbackfn returns a value which is coercible to the Boolean value true, or until the end of the array.</param>
        /// <returns></returns>
        public abstract bool Some(Func<TArrayType, bool> callbackfn);

        /// <summary>
        /// Determines whether the specified callback function returns true for any element of an array.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. The some method calls the callbackfn function for each element in the array until the callbackfn returns a value which is coercible to the Boolean value true, or until the end of the array.</param>
        /// <returns></returns>
        public abstract bool Some(Func<TArrayType, int, bool> callbackfn);

        /// <summary>
        /// Determines whether the specified callback function returns true for any element of an array.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to three arguments. The some method calls the callbackfn function for each element in the array until the callbackfn returns a value which is coercible to the Boolean value true, or until the end of the array.</param>
        /// <returns></returns>
        public abstract bool Some(Func<TArrayType, int, TArray, bool> callbackfn);

        public override string ToString() => Join();

        /// <summary>
        /// Returns a new iterable collection of values in the array
        /// </summary>
        /// <returns></returns>
        public ValueCollection Values() => new ValueCollection(this);

        /// <summary>
        /// Converts this array to a C# Array
        /// </summary>
        /// <returns></returns>
        public TArrayType[] ToArray() => _entries.ToArray();

        #region Iterators

        [Serializable]
        public sealed class KeyCollection : IEnumerable<int>
        {
            private readonly BaseArray<TArrayType, TArray> raw;

            internal KeyCollection(BaseArray<TArrayType, TArray> array)
            {
                raw = array;
            }

            public int Length
            {
                get => raw._entries.Count;
            }

            public IEnumerator<int> GetEnumerator() => new KeyIterator(raw);
            IEnumerator IEnumerable.GetEnumerator() => new KeyIterator(raw);

            [Serializable]
            public struct KeyIterator : IEnumerator<int>, IEnumerator
            {
                private IEnumerator<int> raw;
                private readonly BaseArray<TArrayType, TArray> raw_data;

                internal KeyIterator(BaseArray<TArrayType, TArray> array)
                {
                    List<int> indexList = new List<int>();

                    for (int index = 0; index < array._entries.Count; index++)
                        indexList.Add(index);

                    raw = indexList.GetEnumerator();
                    raw_data = array;
                }

                private void ResetRaw()
                {
                    List<int> indexList = new List<int>();

                    for (int index = 0; index < raw_data._entries.Count; index++)
                        indexList.Add(index);

                    raw = indexList.GetEnumerator();
                }

                public void Dispose() => raw.Dispose();

                public bool MoveNext() => raw.MoveNext();

                public int Current => raw.Current;

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

        public sealed class EntryCollection : IEnumerable<TArrayType>
        {
            private readonly BaseArray<TArrayType, TArray> raw;

            internal EntryCollection(BaseArray<TArrayType, TArray> array)
            {
                raw = array;
            }

            public int Length
            {
                get => raw._entries.Count;
            }

            public IEnumerator<TArrayType> GetEnumerator() => new EntryIterator(raw);
            IEnumerator IEnumerable.GetEnumerator() => new EntryIterator(raw);

            [Serializable]
            public struct EntryIterator : IEnumerator<TArrayType>, IEnumerator
            {
                private IEnumerator<TArrayType> raw;
                private readonly BaseArray<TArrayType, TArray> raw_data;

                internal EntryIterator(BaseArray<TArrayType, TArray> array)
                {
                    raw = array._entries.GetEnumerator();
                    raw_data = array;
                }

                private void ResetRaw() => raw = raw_data._entries.GetEnumerator();

                public void Dispose() => raw.Dispose();

                public bool MoveNext() => raw.MoveNext();

                public TArrayType Current => raw.Current;

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

        public sealed class ValueCollection : IEnumerable<TArrayType>
        {
            private readonly BaseArray<TArrayType, TArray> raw;

            internal ValueCollection(BaseArray<TArrayType, TArray> array)
            {
                raw = array;
            }

            public int Length
            {
                get => raw._entries.Count;
            }

            public IEnumerator<TArrayType> GetEnumerator() => new ValueIterator(raw);
            IEnumerator IEnumerable.GetEnumerator() => new ValueIterator(raw);

            [Serializable]
            public struct ValueIterator : IEnumerator<TArrayType>, IEnumerator
            {
                private IEnumerator<TArrayType> raw;
                private readonly BaseArray<TArrayType, TArray> raw_data;

                internal ValueIterator(BaseArray<TArrayType, TArray> array)
                {
                    raw = array._entries.GetEnumerator();
                    raw_data = array;
                }

                private void ResetRaw() => raw = raw_data._entries.GetEnumerator();

                public void Dispose() => raw.Dispose();

                public bool MoveNext() => raw.MoveNext();

                public TArrayType Current => raw.Current;

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

        #endregion
    }
}