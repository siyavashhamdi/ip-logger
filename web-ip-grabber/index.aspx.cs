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
        protected void Page_Load(object sender, EventArgs e)
        {
            var ip = Utility.Common.GetIpAddress();
            var urlInfo = Request.Url.ToString();
            var currDate = Utility.Common.GetCurrentDateTime();

            Utility.Common.WriteToFile("log-ip.txt", currDate + ": " + urlInfo + " | " + ip);
            Utility.Common.RedirectToQueryUrl();
        }
    }
}
