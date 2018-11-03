using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppDemo
{
    public partial class AjaxAction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //result.InnerHtml = "اطلاعات با موفقیت ثبت شد";

            var name = Request.QueryString["InputName"];
            var family = Request.QueryString["InputLastName"];
            var saloon = Request.QueryString["saloon"];
            var seat = Request.QueryString["seat"];
            // var seat = 12;



            using (StreamWriter sw = new StreamWriter(Server.MapPath("~/Reserve/Users.txt"), true))
            {
                sw.WriteLine($"{name},{family},{saloon},{seat}");
            }
            
            var responseText = $" اطلاعات با موفقیت ثبت شد";
            Response.Write(responseText);
           
        }
    }
}