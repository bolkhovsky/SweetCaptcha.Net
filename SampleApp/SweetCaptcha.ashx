<%@ WebHandler Language="C#" Class="SweetCaptchaHandler" %>

using System.Configuration;
using System.Web;

public class SweetCaptchaHandler : HttpTaskAsyncHandler 
{
    public override async System.Threading.Tasks.Task ProcessRequestAsync(HttpContext context)
    {
        var sweetcaptch = new SweetCaptcha.SweetCaptcha(
                ConfigurationManager.AppSettings["sweetcaptchaHost"],
                ConfigurationManager.AppSettings["sweetcaptchaAppId"],
                ConfigurationManager.AppSettings["sweetcaptchaAppSecret"]);
        
        if (context.Request["method"] == "check")
        {
            var result = await sweetcaptch.Check(context.Request["sckey"], context.Request["scvalue"]);
            context.Response.Write(result);    
        }
        else
        {
            var html = await sweetcaptch.GetHtml();
            context.Response.Write(html);    
        }
    }
}