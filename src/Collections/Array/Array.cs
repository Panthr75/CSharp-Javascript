using System;
using System.Collections;
using System.Collections.Generic;

namespace JavaScript.Collections
{
    public class Array : Array<object>
    {
        public Array() : base()
        {

        }

        public Array(int length) : base(length)
        {
            //
        }

        public Array(IEnumerable items)
        {
            Push(items);
        }

        /// <summary>
        /// Creates an array from an iterable object.
        /// </summary>
        /// <param name="iterable">An iterable object to convert to an array.</param>
        /// <returns></returns>
        public static Array From(IEnumerable iterable)
        {
            return new Array(iterable);
        }

        /// <summary>
        /// Creates an array from an iterable object.
        /// </summary>
        /// <param name="iterable">An iterable object to convert to an array.</param>
        /// <returns></returns>
        public static Array<T> From<T>(IEnumerable<T> iterable)
        {
            return new Array<T>(iterable);
        }

        /// <summary>
        /// Creates an array from an iterable object.
        /// </summary>
        /// <param name="iterable">An iterable object to convert to an array.</param>
        /// <returns></returns>
        public static Array<U> From<U>(IEnumerable iterable, Func<U> mapfn)
        {
            Array<U> result = new Array<U>();

            int index = 0;
            foreach (object item in iterable)
            {
                result.Push(mapfn());
                index++;
            }

            return result;
        }

        /// <summary>
        /// Creates an array from an iterable object.
        /// </summary>
        /// <param name="iterable">An iterable object to convert to an array.</param>
        /// <returns></returns>
        public static Array<U> From<U>(IEnumerable iterable, Func<object, U> mapfn)
        {
            Array<U> result = new Array<U>();

            int index = 0;
            foreach (object item in iterable)
            {
                result.Push(mapfn(item));
                index++;
            }

            return result;
        }

        /// <summary>
        /// Creates an array from an iterable object.
        /// </summary>
        /// <param name="iterable">An iterable object to convert to an array.</param>
        /// <returns></returns>
        public static Array<U> From<U>(IEnumerable iterable, Func<object, int, U> mapfn)
        {
            Array<U> result = new Array<U>();

            int index = 0;
            foreach (object item in iterable)
            {
                result.Push(mapfn(item, index));
                index++;
            }

            return result;
        }

        /// <summary>
        /// Creates an array from an iterable object.
        /// </summary>
        /// <param name="iterable">An iterable object to convert to an array.</param>
        /// <returns></returns>
        public static Array<U> From<T, U>(IEnumerable<T> iterable, Func<T, U> mapfn)
        {
            Array<U> result = new Array<U>();

            int index = 0;
            foreach (T item in iterable)
            {
                result.Push(mapfn(item));
                index++;
            }

            return result;
        }

        /// <summary>
        /// Creates an array from an iterable object.
        /// </summary>
        /// <param name="iterable">An iterable object to convert to an array.</param>
        /// <returns></returns>
        public static Array<U> From<T, U>(IEnumerable<T> iterable, Func<T, int, U> mapfn)
        {
            Array<U> result = new Array<U>();

            int index = 0;
            foreach (T item in iterable)
            {
                result.Push(mapfn(item, index));
                index++;
            }

            return result;
        }

        public bool IsArray(object arg)
        {
            Type argType = arg.GetType();

            if (argType.IsGenericType)
                return typeof(Array<>) == argType.GetGenericTypeDefinition();
            else
                return typeof(Array) == argType;
        }

        /// <summary>
        /// Converts an array of one type to another
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static Array<TTo> To<TTo, TFrom>(Array<TFrom> array)
        {
            Type TFromType = typeof(TFrom);

            Array<TTo> newArray = new Array<TTo>();

            for (int index = 0; index < array.Length; index++)
                newArray.Push((TTo)Convert.ChangeType(array[index], TFromType));

            return newArray;
        }
    }
}