using JavaScript.Web.Credentials;
using System;

namespace JavaScript.Web.Fetch
{
    public class FetchOptions
    {
        /// <summary>
        /// The request method, e.g., GET, POST. Note that the Origin header is not set on Fetch requests with a method of HEAD or GET.
        /// </summary>
        public WebRequestType Method { get; set; } = WebRequestType.GET;

        /// <summary>
        /// Headers for the request. 
        /// </summary>
        public Headers Headers { get; set; } = new Headers();

        /// <summary>
        /// The body of the request. <b>Requests using the GET or HEAD methods cannot have a body</b>
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// The request of the encoding. Makes me not have to implement complex stuff :D
        /// </summary>
        public string Encoding { get; set; } = "UTF-8";

        /// <summary>
        /// The type of credentials for the request
        /// </summary>
        [Obsolete("Not yet implemented")]
        public CredentialType CredentialType { get; set; } = CredentialType.Omit;

        /// <summary>
        /// credentials for the request
        /// </summary>
        [Obsolete("Not yet implemented")]
        public Credential Credentials { get; set; }


        public static string GetMethodName(WebRequestType method) => Enum.GetName(typeof(WebRequestType), method);
        public static string GetMethodName(int methodIndex) => GetMethodName((WebRequestType)methodIndex);
    }
}