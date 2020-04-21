using JavaScript.Collections;
using System;

namespace JavaScript.Web
{
    public class Headers : BaseMap<string, string>
    {
        /// <summary>
        /// Appends an new value onto an existing header. However, if no such header exists, a new one is created.
        /// </summary>
        /// <param name="name">The name of the HTTP header</param>
        /// <param name="value">The value of the HTTP header</param>
        public void Append(string name, string value)
        {
            if (Get(name) == null)
                Set(name, value);
            else
                Set(name, _entries[name] + "," + value);
        }

        /// <summary>
        /// Deletes a header via the given header name.
        /// </summary>
        /// <param name="name">The name of the HTTP header</param>
        public void Delete(string name)
        {
            if (!Has(name))
                return;
            //throw new TypeException("The name of the header given does not exist.");
            else
                _entries.Remove(name);
        }

        /// <summary>
        /// Executes the provided action/function once for each header item.
        /// </summary>
        /// <param name="callbackfn">A zero argument callback function</param>
        public override void ForEach(Action callbackfn)
        {
            for (int index = 0; index < _entries.Count; index++)
                callbackfn();
        }

        /// <summary>
        /// Executes the provided action/function once for each header item.
        /// </summary>
        /// <param name="callbackfn">A one argument callback function where the first argument is the value of a header</param>
        public override void ForEach(Action<string> callbackfn)
        {
            foreach (string headerName in _entries.Keys)
                callbackfn(_entries[headerName]);
        }

        /// <summary>
        /// Executes the provided action/function once for each header item.
        /// </summary>
        /// <param name="callbackfn">A two argument callback function where the first argument is the value of a header, and the second argument is the name of the header</param>
        public override void ForEach(Action<string, string> callbackfn)
        {
            foreach (string headerName in _entries.Keys)
                callbackfn(_entries[headerName], headerName);
        }

        /// <summary>
        /// Executes the provided action/function once for each header item.
        /// </summary>
        /// <param name="callbackfn">A three argument callback function where the first argument is the value of a header, the second argument is the name of the header, and the third argument being the original headers object</param>
        public void ForEach(Action<string, string, Headers> callbackfn)
        {
            foreach (string headerName in _entries.Keys)
                callbackfn(_entries[headerName], headerName, this);
        }

        /// <summary>
        /// Returns a string containing all of the values of a header with the given name. If the requested header doesn't exist, returns null.
        /// </summary>
        /// <param name="name">The name of the HTTP header</param>
        /// <returns></returns>
        public string Get(string name)
        {
            if (Has(name))
                return _entries[name];
            else
                return null;
        }

        /// <summary>
        /// Returns a boolean of whether this headers object contains the specific header from the provided names.
        /// </summary>
        /// <param name="name">The name of the HTTP header</param>
        /// <returns></returns>
        public override bool Has(string name) => _entries.ContainsKey(name);

        /// <summary>
        /// Sets a new value for an existing header, or adds the header if it does not exist.
        /// </summary>
        /// <param name="name">The name of the HTTP header</param>
        /// <param name="value">The new value</param>
        public void Set(string name, string value)
        {
            _entries[name] = value;
        }

        public string this[string key]
        {
            get => Get(key);
            set => Set(key, value);
        }
    }
}