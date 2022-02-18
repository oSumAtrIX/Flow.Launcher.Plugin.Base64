using System.Collections.Generic;
using System.Windows;

namespace Flow.Launcher.Plugin.Base64
{
    public class Base64 : IPlugin
    {
        public List<Result> Query(Query query)
        {
            List<Result> results = new();

            if (string.IsNullOrEmpty(query.Search)) 
                return results;

            string encoded = query.Search.ToBase64String();
            results.Add(new Result
            {
                Title = encoded,
                SubTitle = "Copy to clipboard",
                Action = _ =>
                {
                    Clipboard.SetText(encoded);
                    return true;
                },
                IcoPath = "Images\\encode.png"
            });
            
            if (query.Search.Length <= 1) 
                return results;
           
            string decoded = query.Search.FromBase64String();
            results.Add(new Result()
            {
                Title = decoded,
                SubTitle = "Copy to clipboard",
                Action = _ =>
                {
                    Clipboard.SetText(decoded);
                    return true;
                },
                IcoPath = "Images\\decode.png"
            });
            return results;
        }

        public void Init(PluginInitContext context) { }
    }
}