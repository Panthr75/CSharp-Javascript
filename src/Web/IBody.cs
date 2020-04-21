using System.IO;

namespace JavaScript.Web
{
    public interface IBody
    {
        Stream Body { get; }

        IPromise<string> Text();
    }
}