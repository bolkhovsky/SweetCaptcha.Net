using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading.Tasks;

namespace SweetCaptcha
{
    public class SweetCaptcha
    {
        private Dictionary<string, string> DefaultParameters;
        private readonly string _appId;
        private readonly string _appKey;
        private readonly string _host;

        public SweetCaptcha()
            : this(
            ConfigurationManager.AppSettings["sweetcaptchaHost"],
            ConfigurationManager.AppSettings["sweetcaptchaAppId"],
            ConfigurationManager.AppSettings["sweetcaptchaAppSecret"])
        { }

        public SweetCaptcha(string sweetcaptchaHost, string sweetcaptchaAppId, string sweetcaptchaAppSecret)
        {
            if (string.IsNullOrEmpty(sweetcaptchaHost))
                throw new ArgumentNullException("sweetcaptchaHost");
            if (string.IsNullOrEmpty(sweetcaptchaAppId))
                throw new ArgumentNullException("sweetcaptchaAppId");
            if (string.IsNullOrEmpty(sweetcaptchaAppSecret))
                throw new ArgumentNullException("sweetcaptchaAppSecret");

            _host = sweetcaptchaHost;
            _appId = sweetcaptchaAppId;
            _appKey = sweetcaptchaAppSecret;

            DefaultParameters = new Dictionary<string, string>
                {
                    { "app_id", _appId },
                    { "app_key", _appKey },
                    { "method", "get_html" },
                    { "platform", "sweetcaptcha-dotnet" },
                };
        }

        public async Task<string> GetHtml()
        {
            return await GetHtml(DefaultParameters);
        }

        public async Task<string> GetHtml(string language, bool isAutoSubmit = false)
        {
            var parameters = DefaultParameters;
            parameters.Add("language", language);

            if (isAutoSubmit)
            {
                parameters.Add("is_auto_submit", "1");
            }

            return await GetHtml(parameters);
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

        private async Task<string> GetHtml(Dictionary<string, string> parameterDictionary)
        {
            var client = new HttpClient();
            var request = await client.PostAsync(_host, new FormUrlEncodedContent(parameterDictionary));
            return await request.Content.ReadAsStringAsync();
        }
    }
}
