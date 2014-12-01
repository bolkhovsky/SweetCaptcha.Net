using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SweetCaptcha
{
    public class SweetCaptcha
    {
        private readonly string _appId;
        private readonly string _appKey;
        private readonly string _host;

        public SweetCaptcha(string host, string appId, string appKey)
        {
            if (string.IsNullOrEmpty(host))
                throw new ArgumentNullException("host");
            if (string.IsNullOrEmpty(appId))
                throw new ArgumentNullException("appId");
            if (string.IsNullOrEmpty(appKey))
                throw new ArgumentNullException("appKey");

            _host = host;
            _appId = appId;
            _appKey = appKey;
        }

        public async Task<string> GetHtml()
        {
            var client = new HttpClient();
            var parameters = new Dictionary<string, string>
            {
                { "app_id", _appId },
                { "app_key", _appKey },
                { "method", "get_html" },
                { "platform", "sweetcaptcha-dotnet" },
            };
            var request = await client.PostAsync(_host, new FormUrlEncodedContent(parameters));
            return await request.Content.ReadAsStringAsync();
        }

        public async Task<bool> Check(string sckey, string scvalue)
        {
            var client = new HttpClient();
            var parameters = new Dictionary<string, string>
            {
                {"app_id", _appId},
                {"app_key", _appKey},
                {"method", "check"},
                {"platform", "sweetcaptcha-dotnet"},
                {"sckey", sckey},
                {"scvalue", scvalue}
            };
            var request = await client.PostAsync(_host, new FormUrlEncodedContent(parameters));
            var result = await request.Content.ReadAsStringAsync();
            return result.ToLower() == "true";
        }
    }
}
