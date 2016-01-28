<%@ WebHandler Language="C#" Class="SweetCaptchaHandler" %>

using System.Web;

public class SweetCaptchaHandler : HttpTaskAsyncHandler 
{
    public override async System.Threading.Tasks.Task ProcessRequestAsync(HttpContext context)
    {
        var sweetcaptch = new SweetCaptcha.SweetCaptcha();
        
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