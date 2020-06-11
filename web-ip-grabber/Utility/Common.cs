using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web_ip_grabber.Utility
{
    public class Common
    {
        public static string GetIpAddress()
        {
            var context = HttpContext.Current;
            var ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAddress))
                return context.Request.ServerVariables["REMOTE_ADDR"];

            var addresses = ipAddress.Split(',');

            if (addresses.Length != 0)
                return addresses[0];

            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        public static string GetCurrentDateTime()
        {
            return DateTime.Now.ToString("yyyy/MM/dd-HH:mm:ss");
        }

        public static void WriteToFile(string logFileName, string text)
        {
            var path = HostingEnvironment.MapPath(@"~/Logs/" + logFileName);

            System.IO.File.AppendAllText(path, text + "\n");
        }

        public static void RedirectToQueryUrl()
        {
            var request = HttpContext.Current.Request;
            var response = HttpContext.Current.Response;

            var redirectTo = request.QueryString["url"];

            response.Redirect(redirectTo, false);
        }
    }
}
