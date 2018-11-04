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
          

          var name = Request.QueryString["InputName"];
            var family = Request.QueryString["InputLastName"];
            var saloon = Request.QueryString["saloon"];
            var seat = Request.QueryString["seat"];
            // var reallsaloon = saloon + 1;
           

          using (StreamWriter sw = new StreamWriter(Server.MapPath("~/Reserve/Users.txt"), true))
            {
                sw.WriteLine($"name:{name},family: {family},saloon :{saloon},Seat :{seat}");

                /*   sw.Write($"name:{name},family: {family},saloon :{saloon}");
                 for(int i=0;i<seat.Length;i++)
                  {
                      sw.Write($"Seat :{seat[i]}");
                  }
                  sw.WriteLine();*/
            }
            
           
           
        }
    }
}