using JavaScript.Web;
using JavaScript.Web.Fetch;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace JavaScript
{
    public static class Global
    {
        public static Number ParseFloat(object number)
        {
            return Number.ParseFloat(new Number(number).ToString());
        }

        public static Number ParseInt(object number)
        {
            return Number.ParseInt(new Number(number).ToString());
        }

        public static IPromise<Response> Fetch(string url) => Fetch(url, new FetchOptions());

        public static IPromise<Response> Fetch(string url, FetchOptions options)
        {
            return new Promise<Response>(async (resolve, reject) =>
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
                req.Method = FetchOptions.GetMethodName(options.Method);

                //TODO: Implement Credentials

                if (!(options.Method == WebRequestType.GET || options.Method == WebRequestType.HEAD) && options.Encoding != null && options.Body != null)
                {
                    req.ContentType = options.Headers.Get("Content-Type") ?? "text/plain;charset=UTF-8";
                    byte[] requestBody = Encoding.GetEncoding(options.Encoding).GetBytes(options.Body);

                    // set the content length
                    req.ContentLength = requestBody.Length;

                    // get the stream and write the request body to it.
                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(requestBody, 0, requestBody.Length);
                }

                try
                {
                    HttpWebResponse response = (HttpWebResponse)await req.GetResponseAsync();
                    resolve(new Response(response));
                }
                catch(WebException webex)
                {
                    // still got a response, but was most likely a non-200-like response
                    if (webex.Response is HttpWebResponse res)
                        resolve(new Response(res));

                    // got no response (usually client-side problem)
                    else
                        reject(webex);
                }
                catch(Exception ex)
                {
                    reject(ex);
                }
            });
        }
    }
}