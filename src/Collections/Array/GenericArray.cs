using System;
using System.Collections;
using System.Collections.Generic;

namespace JavaScript.Collections
{
    public class Array<T> : BaseArray<T, Array<T>>, IEnumerable<T>
    {
        private Array(Array<T> array)
        {
            _entries = new List<T>(array._entries);
        }

        public Array(int length)
        {
            Length = length;
        }

        public Array(IEnumerable<T> items)
        {
            foreach (T item in items)
                Push(item);
        }

        public Array(params T[] items)
        {
            _entries.AddRange(items);
        }

        /// <summary>
        /// Combines two or more arrays.
        /// </summary>
        /// <param name="items">Additional items to add to the end of array1.</param>
        /// <returns></returns>
        public Array<T> Concat(params T[] items)
        {
            Array<T> newArray = new Array<T>(this);
            newArray.Push(items);

            return newArray;
        }

        /// <summary>
        /// Combines two or more arrays.
        /// </summary>
        /// <param name="items">Additional items to add to the end of array1.</param>
        /// <returns></returns>
        public Array<T> Concat<TItem>(params TItem[] items)
        {
            Array<T> newArray = new Array<T>(this);

            for (int index = 0; index < items.Length; index++)
                newArray.Push((T)Convert.ChangeType(items[index], typeof(TItem)));

            return newArray;
        }

        /// <summary>
        /// Copies a section of the array identified by start and end to the same array starting at position target
        /// </summary>
        /// <param name="target">If target is negative, it is treated as length+target where length is the length of the array.</param>
        /// <param name="start">If start is negative, it is treated as length+start. If end is negative, it is treated as length+end.</param>
        /// <returns>This</returns>
        public virtual Array<T> CopyWithin(int target, int start) => CopyWithin(target, start, Length);

        /// <summary>
        /// Copies a section of the array identified by start and end to the same array starting at position target
        /// </summary>
        /// <param name="target">If target is negative, it is treated as length+target where length is the length of the array.</param>
        /// <param name="start">If start is negative, it is treated as length+start. If end is negative, it is treated as length+end.</param>
        /// <param name="end">If not specified, length of the this object is used as its default value.</param>
        /// <returns>This</returns>
        public virtual Array<T> CopyWithin(int target, int start, int end)
        {
            if (target < 0)
                target = Length + target;

            if (start < 0)
                start = Length + start;

            if (end < 0)
                start = Length + end;

            _entries.InsertRange(target, Slice(start, end));

            return this;
        }

        public override bool Every(Func<bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn() == false)
                    return false;
            }
            return true;
        }

        public override bool Every(Func<T, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(_entries[index]) == false)
                    return false;
            }
            return true;
        }

        public override bool Every(Func<T, int, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(_entries[index], index) == false)
                    return false;
            }
            return true;
        }

        public override bool Every(Func<T, int, Array<T>, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(_entries[index], index, this) == false)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Fills the section identified by start and end with value
        /// </summary>
        /// <param name="value">value to fill array section with</param>
        /// <returns>This</returns>
        public virtual Array<T> Fill(T value) => Fill(value, 0, Length - 1);

        /// <summary>
        /// Fills the section identified by start and end with value
        /// </summary>
        /// <param name="value">value to fill array section with</param>
        /// <param name="start">index to start filling the array at. If start is negative, it is treated as length+start where length is the length of the array.</param>
        /// <returns>This</returns>
        public virtual Array<T> Fill(T value, int start) => Fill(value, start, Length - 1);

        /// <summary>
        /// Fills the section identified by start and end with value
        /// </summary>
        /// <param name="value">value to fill array section with</param>
        /// <param name="start">index to start filling the array at. If start is negative, it is treated as length+start where length is the length of the array.</param>
        /// <param name="end">index to stop filling the array at. If end is negative, it is treated as length+end.</param>
        /// <returns>This</returns>
        public virtual Array<T> Fill(T value, int start, int end)
        {
            if (start < 0)
                start = Length + start;

            if (end < 0)
                end = Length + end;

            for (int index = start; index < end; index++)
                this[index] = value;

            return this;
        }

        public override Array<T> Filter(Func<bool> callbackfn)
        {
            Array<T> result = new Array<T>();

            for (int index = 0; index < Length; index++)
            {
                if (callbackfn() == true)
                    result.Push(this[index]);
            }

            return result;
        }

        public override Array<T> Filter(Func<T, bool> callbackfn)
        {
            Array<T> result = new Array<T>();

            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index]) == true)
                    result.Push(this[index]);
            }

            return result;
        }

        public override Array<T> Filter(Func<T, int, bool> callbackfn)
        {
            Array<T> result = new Array<T>();

            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index], index) == true)
                    result.Push(this[index]);
            }

            return result;
        }

        public override Array<T> Filter(Func<T, int, Array<T>, bool> callbackfn)
        {
            Array<T> result = new Array<T>();

            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index], index, this) == true)
                    result.Push(this[index]);
            }

            return result;
        }

        public override T Find(Func<bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn() == true)
                    return this[index];
            }

            return default;
        }

        public override T Find(Func<T, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index]) == true)
                    return this[index];
            }

            return default;
        }

        public override T Find(Func<T, int, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index], index) == true)
                    return this[index];
            }

            return default;
        }

        public override T Find(Func<T, int, Array<T>, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index], index, this) == true)
                    return this[index];
            }

            return default;
        }

        public override int FindIndex(Func<bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn() == true)
                    return index;
            }

            return -1;
        }

        public override int FindIndex(Func<T, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index]) == true)
                    return index;
            }

            return -1;
        }

        public override int FindIndex(Func<T, int, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index], index) == true)
                    return index;
            }

            return -1;
        }

        public override int FindIndex(Func<T, int, Array<T>, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index], index, this) == true)
                    return index;
            }

            return -1;
        }

        public override void ForEach(Action callbackfn)
        {
            for (int index = 0; index < Length; index++)
                callbackfn();
        }

        public override void ForEach(Action<T> callbackfn)
        {
            for (int index = 0; index < Length; index++)
                callbackfn(this[index]);
        }

        public override void ForEach(Action<T, int> callbackfn)
        {
            for (int index = 0; index < Length; index++)
                callbackfn(this[index], index);
        }

        public override void ForEach(Action<T, int, Array<T>> callbackfn)
        {
            for (int index = 0; index < Length; index++)
                callbackfn(this[index], index, this);
        }



        public IEnumerator<T> GetEnumerator() => Values().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Values().GetEnumerator();

        public override bool Includes(T searchElement) => Includes(searchElement, 0);
        public override bool Includes(T searchElement, int fromIndex)
        {
            for (int index = fromIndex; index < Length; index++)
            {
                if (Comparer<T>.Default.Compare(this[index], searchElement) == 0)
                    return true;
            }
            return false;
        }

        public override int IndexOf(T searchElement) => IndexOf(searchElement, 0);
        public override int IndexOf(T searchElement, int fromIndex)
        {
            for (int index = fromIndex; index < Length; index++)
            {
                if (Comparer<T>.Default.Compare(this[index], searchElement) == 0)
                    return index;
            }
            return -1;
        }

        public override string Join(string seperator = ",")
        {
            string result = "";
            for (int index = 0; index < Length; index++)
            {
                if (index > 0)
                    result += seperator;

                result += this[index].ToString();
            }

            return result;
        }

        public override int LastIndexOf(T searchElement) => LastIndexOf(searchElement, Length - 1);
        public override int LastIndexOf(T searchElement, int fromIndex)
        {
            for (int index = fromIndex; index >= 0; index--)
            {
                if (Comparer<T>.Default.Compare(this[index], searchElement) == 0)
                    return index;
            }

            return -1;
        }

        /// <summary>
        /// Calls a defined callback function on each element of an array, and returns an array that contains the results.
        /// </summary>
        /// <typeparam name="U">The new type</typeparam>
        /// <param name="callbackfn">A function that accepts up to three arguments. The map method calls the callbackfn function one time for each element in the array.</param>
        /// <returns></returns>
        public virtual Array<U> Map<U>(Func<U> callbackfn)
        {
            Array<U> result = new Array<U>();

            for (int index = 0; index < Length; index++)
                result.Push(callbackfn());

            return result;
        }

        /// <summary>
        /// Calls a defined callback function on each element of an array, and returns an array that contains the results.
        /// </summary>
        /// <typeparam name="U">The new type</typeparam>
        /// <param name="callbackfn">A function that accepts up to three arguments. The map method calls the callbackfn function one time for each element in the array.</param>
        /// <returns></returns>
        public virtual Array<U> Map<U>(Func<T, U> callbackfn)
        {
            Array<U> result = new Array<U>();

            for (int index = 0; index < Length; index++)
                result.Push(callbackfn(this[index]));

            return result;
        }

        /// <summary>
        /// Calls a defined callback function on each element of an array, and returns an array that contains the results.
        /// </summary>
        /// <typeparam name="U">The new type</typeparam>
        /// <param name="callbackfn">A function that accepts up to three arguments. The map method calls the callbackfn function one time for each element in the array.</param>
        /// <returns></returns>
        public virtual Array<U> Map<U>(Func<T, int, U> callbackfn)
        {
            Array<U> result = new Array<U>();

            for (int index = 0; index < Length; index++)
                result.Push(callbackfn(this[index], index));

            return result;
        }

        /// <summary>
        /// Calls a defined callback function on each element of an array, and returns an array that contains the results.
        /// </summary>
        /// <typeparam name="U">The new type</typeparam>
        /// <param name="callbackfn">A function that accepts up to three arguments. The map method calls the callbackfn function one time for each element in the array.</param>
        /// <returns></returns>
        public virtual Array<U> Map<U>(Func<T, int, Array<T>, U> callbackfn)
        {
            Array<U> result = new Array<U>();

            for (int index = 0; index < Length; index++)
                result.Push(callbackfn(this[index], index, this));

            return result;
        }

        /// <summary>
        /// Removes the last element from an array and returns it.
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            T lastItem = this[Length - 1];
            _entries.RemoveAt(Length - 1);

            return lastItem;
        }

        /// <summary>
        /// Appends new elements to an array.
        /// </summary>
        /// <param name="items">New elements of the Array.</param>
        /// <returns>the new length of the array.</returns>
        public virtual int Push(params T[] items)
        {
            _entries.AddRange(items);
            return Length;
        }

        /// <summary>
        /// Appends new elements to an array.
        /// </summary>
        /// <param name="items">New elements of the Array.</param>
        /// <returns>the new length of the array.</returns>
        public virtual int Push(IEnumerable<T> items)
        {
            _entries.AddRange(items);
            return Length;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object Reduce(Func<object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn();

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object Reduce(Func<object, object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn(result);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object Reduce(Func<object, T, object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn(result, this[index]);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object Reduce(Func<object, T, int, object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn(result, this[index], index);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object Reduce(Func<object, T, int, Array<T>, object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn(result, this[index], index, this);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U Reduce<U>(Func<U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn();

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U Reduce<U>(Func<U, U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn(result);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U Reduce<U>(Func<U, T, U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn(result, this[index]);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U Reduce<U>(Func<U, T, int, U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn(result, this[index], index);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduce method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U Reduce<U>(Func<U, T, int, Array<T>, U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = 0; index < Length; index++)
                result = callbackfn(result, this[index], index, this);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object ReduceRight(Func<object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn();

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object ReduceRight(Func<object, object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn(result);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object ReduceRight(Func<object, T, object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn(result, this[index]);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object ReduceRight(Func<object, T, int, object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn(result, this[index], index);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual object ReduceRight(Func<object, T, int, Array<T>, object> callbackfn, object initialValue = null)
        {
            object result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn(result, this[index], index, this);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U ReduceRight<U>(Func<U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn();

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U ReduceRight<U>(Func<U, U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn(result);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U ReduceRight<U>(Func<U, T, U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn(result, this[index]);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U ReduceRight<U>(Func<U, T, int, U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn(result, this[index], index);

            return result;
        }

        /// <summary>
        /// Calls the specified callback function for all the elements in an array, in descending order. The return value of the callback function is the accumulated result, and is provided as an argument in the next call to the callback function.
        /// </summary>
        /// <param name="callbackfn">A function that accepts up to four arguments. The reduceRight method calls the callbackfn function one time for each element in the array.</param>
        /// <param name="initialValue"></param>
        /// <returns></returns>
        public virtual U ReduceRight<U>(Func<U, T, int, Array<T>, U> callbackfn, U initialValue = default)
        {
            U result = initialValue;
            for (int index = Length - 1; index >= 0; index--)
                result = callbackfn(result, this[index], index, this);

            return result;
        }

        /// <summary>
        /// Reverses the elements in an Array.
        /// </summary>
        /// <returns></returns>
        public virtual Array<T> Reverse()
        {
            _entries.Reverse();

            return this;
        }

        /// <summary>
        /// Removes the first element from an array and returns it.
        /// </summary>
        /// <returns></returns>
        public virtual T Shift() 
        {
            T firstItem = _entries[0];
            _entries.RemoveAt(0);

            return firstItem;
        }

        public override Array<T> Slice() => Slice(0, Length - 1);
        public override Array<T> Slice(int start) => Slice(start, Length - 1);
        public override Array<T> Slice(int start, int end) => new Array<T>(_entries.GetRange(start, end - start));

        public override bool Some(Func<bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn() == true)
                    return true;
            }

            return false;
        }

        public override bool Some(Func<T, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index]) == true)
                    return true;
            }

            return false;
        }

        public override bool Some(Func<T, int, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index], index) == true)
                    return true;
            }

            return false;
        }

        public override bool Some(Func<T, int, Array<T>, bool> callbackfn)
        {
            for (int index = 0; index < Length; index++)
            {
                if (callbackfn(this[index], index, this) == true)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Sorts an array.
        /// </summary>
        /// <returns></returns>
        public virtual Array<T> Sort()
        {
            _entries.Sort();

            return this;
        }

        /// <summary>
        /// Sorts an array.
        /// </summary>
        /// <param name="compareFn">Function used to determine the order of the elements. It is expected to return a negative value if first argument is less than second argument, zero if they're equal and a positive value otherwise. If omitted, the elements are sorted in ascending, ASCII character order.</param>
        /// <returns></returns>
        public virtual Array<T> Sort(Func<T, T, int> compareFn)
        {
            _entries.Sort(delegate (T a, T b)
            {
                return compareFn(a, b);
            });

            return this;
        }

        /// <summary>
        /// Removes elements from an array and, if necessary, inserts new elements in their place, returning the deleted elements.
        /// </summary>
        /// <param name="start">The zero-based location in the array from which to start removing elements.</param>
        /// <param name="deleteCount">The number of elements to remove.</param>
        /// <returns></returns>
        public virtual Array<T> Splice(int start, int deleteCount)
        {
            Array<T> deletedItems = new Array<T>(_entries.GetRange(start, deleteCount));
            _entries.RemoveRange(start, deleteCount);

            return deletedItems;
        }

        /// <summary>
        /// Removes elements from an array and, if necessary, inserts new elements in their place, returning the deleted elements.
        /// </summary>
        /// <param name="start">The zero-based location in the array from which to start removing elements.</param>
        /// <param name="deleteCount">The number of elements to remove.</param>
        /// <param name="items">Elements to insert into the array in place of the deleted elements.</param>
        /// <returns></returns>
        public virtual Array<T> Splice(int start, int deleteCount, params T[] items)
        {
            Array<T> deletedItems = Splice(start, deleteCount);
            _entries.InsertRange(start, items);

            return deletedItems;
        }

        /// <summary>
        /// Removes elements from an array and, if necessary, inserts new elements in their place, returning the deleted elements.
        /// </summary>
        /// <param name="start">The zero-based location in the array from which to start removing elements.</param>
        /// <param name="deleteCount">The number of elements to remove.</param>
        /// <param name="items">Elements to insert into the array in place of the deleted elements.</param>
        /// <returns></returns>
        public virtual Array<T> Splice(int start, int deleteCount, IEnumerable<T> items)
        {
            Array<T> deletedItems = Splice(start, deleteCount);
            _entries.InsertRange(start, items);

            return deletedItems;
        }

        /// <summary>
        /// Inserts new elements at the start of an array.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual int Unshift(params T[] items)
        {
            _entries.InsertRange(0, items);

            return Length;
        }

        /// <summary>
        /// Inserts new elements at the start of an array.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public virtual int Unshift(IEnumerable<T> items)
        {
            _entries.InsertRange(0, items);

            return Length;
        }

        /// <summary>
        /// Gets or sets the length of the array. This is a number one higher than the highest element defined in an array.
        /// </summary>
        public virtual int Length
        {
            get => _entries.Count;
            set
            {
                int net = value - _entries.Count;
                if (net > 0)
                {
                    for (int i = 0; i < net; i++)
                        _entries.Add(default);
                }
                else if (net < 0)
                    _entries.RemoveRange(_entries.Count + net, -net);
            }
        }

        public T this[int index]
        {
            get
            {
                if (index >= _entries.Count || index < 0)
                    return default;

                return _entries[index];
            }
            set => _entries[index] = value;
        }
    }
}