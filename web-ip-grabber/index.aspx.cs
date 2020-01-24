using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_ip_grabber
{
    public partial class index : System.Web.UI.Page
    {
        protected string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        protected string GetCurrentDateTime()
        {
            return DateTime.Now.ToString("yyyy/MM/dd-HH:mm:ss");
        }

        protected void WriteToFile(string text)
        {
            var path = HostingEnvironment.MapPath(@"~/my-log.txt");

            System.IO.File.AppendAllText(path, text + "\n");
        }

        protected void RedirectToQueryUrl()
        {
            var redirectTo = Request.QueryString["url"];

            Response.Redirect(redirectTo, false);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var ip = GetIPAddress();
            var urlInfo = Request.Url.ToString();
            var currDate = GetCurrentDateTime();

            WriteToFile(currDate + ": " + urlInfo + " | " + ip);
            RedirectToQueryUrl();
        }
    }
}
