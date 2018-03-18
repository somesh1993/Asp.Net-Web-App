using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace TestDotnetApp
{
    public partial class Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Page lastpage = (Page)Context.Handler;
            //    if (lastpage is Default)
            //    {
            //        Label2.Text = ((Default)lastpage).Name;
            //        Label4.Text = ((Default)lastpage).Mobile.ToString();
            //        Label6.Text = ((Default)lastpage).Email;
            //    }
            //    else
            //    {
            //        Label2.Text = T1;
            //        Label4.Text = T2.ToString();
            //        Label6.Text = T3;
            //    }
            //}
            Label2.Text = Request.QueryString["Name"];
            Label4.Text = Request.QueryString["Mobile"];
            Label6.Text = Request.QueryString["Email"];
        }

        protected void Button1_Click(object sender, EventArgs e)

        {
            Response.Redirect("~/Default.aspx?Name=" + Server.UrlEncode(Label2.Text) + "&Mobile=" + Server.UrlEncode(Label4.Text) + "&Email=" + Server.UrlEncode(Label6.Text));
        }

        public string StatusName
        {
            get
            {
                return Label2.Text;
            }
        }
        public int StatusMobile
        {
            get
            {
                return Label4.Text!=null? Convert.ToInt32(Label4.Text):0;
            }
        }
        public string StatusEmail
        {
            get
            {
                return Label6.Text;
            }
        }
        public string T1
        {
            get
            {
                return StatusName;
            }
        }
        public int T2
        {
            get
            {
                return StatusMobile;
            }
        }
        public string T3
        {
            get
            {
                return StatusEmail;
            }
        }

    }
}