## Attention! [The sweetCAPTCHA script is responsible for unwanted and potentially malicious popups](https://blog.sucuri.net/2015/06/sweetcaptcha-service-used-to-distribute-adware.html). It was OK when I created this integration, but since 2015 it's screwed up. Use it on your own risk!

# sweetCaptcha .NET SDK

### What's this?

sweetCaptcha is a free captcha service putting the users and your website at first priority.
This is a new and fresh graphical captcha focused on enhanced user experience, so instead of using difficult and boring text, SweetCaptcha offers a 

![SweetCaptcha](https://s3.amazonaws.com/sweetcaptcha/sweetcaptcha-preview.png)

See a live demo [here](http://sweetcaptcha.com/?ref=github-net)

### Installation

A compiled library is available via NuGet

To install via the nuget package console

```PS
Install-Package SweetCaptcha.Net
```

### Usage

1. Install library to your ASP.NET application via NuGet
2. Obtain your AppId and AppSecret by registering on [SweetCaptcha website](http://www.sweetcaptcha.com/accounts/signup)
3. Add following settings to your web.config file:
```xml
<add key="sweetcaptchaHost" value="http://sweetcaptcha.com/api" />
<add key="sweetcaptchaAppId" value="your_key" />
<add key="sweetcaptchaAppSecret" value="your_secret" />
```
4. Create instance of SweetCaptcha class in your code. See the Sample app for the example.

```C#
var sweetcaptcha = new SweetCaptcha.SweetCaptcha(
  ConfigurationManager.AppSettings["sweetcaptchaHost"],
  ConfigurationManager.AppSettings["sweetcaptchaAppId"],
  ConfigurationManager.AppSettings["sweetcaptchaAppSecret"]);
```

### Public methods

1. `public async Task<string> GetHtml(string language, bool isAutoSubmit = false);`
2. `public async Task<bool> Check(string sckey, string scvalue);`

