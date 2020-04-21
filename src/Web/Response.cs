using System;
using System.IO;
using System.Net;

namespace JavaScript.Web
{
    public class Response : IBody
    {
        /// <summary>
        /// The headers associated with the response
        /// </summary>
        public Headers Headers { get; }

        /// <summary>
        /// A boolean indicating whether the response was successful (status in the range 200-299) or not
        /// </summary>
        public bool OK { get; }

        /// <summary>
        /// Whether or not this response is the result of a redirect (that is, its URL list has more than one entry)
        /// </summary>
        [Obsolete("Not yet implemented")]
        public bool Redirected { get; }

        /// <summary>
        /// The status code of the response. (This will be 200 for a success).
        /// </summary>
        public int Status { get; }

        /// <summary>
        /// The status message corresponding to the status code. (e.g., OK for 200).
        /// </summary>
        public string StatusText { get; }

        /// <summary>
        /// The URL of the response.
        /// </summary>
        public string URL { get; }

        #region Body Implementation
        public Stream Body { get; }

        public IPromise<string> Text()
        {
            return new Promise<string>(async (resolve, reject) =>
            {
                try
                {
                    StreamReader reader = new StreamReader(Body);

                    string result = await reader.ReadToEndAsync();

                    reader.Close();

                    resolve(result);
                }
                catch(Exception ex)
                {
                    reject(ex);
                }
            });
        }
        #endregion

        internal Response(HttpWebResponse res)
        {
            Headers = new Headers();
            string[] headerNames = res.Headers.AllKeys;

            for (int index = 0; index < headerNames.Length; index++)
            {
                string headerName = headerNames[index];
                Headers.Set(headerName, res.GetResponseHeader(headerName));
            }

            OK = res.StatusCode == HttpStatusCode.OK;
            Status = (int)res.StatusCode;
            StatusText = res.StatusDescription;
            URL = res.ResponseUri.AbsoluteUri;

            Body = res.GetResponseStream();

            res.Close();
        }
    }
}