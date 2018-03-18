using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestDotnetApp.Model;

namespace TestDotnetApp
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Page lastpage = (Page)Context.Handler;
            //    if (lastpage is Status)
            //    {
            //        TextBox1.Text = ((Status)lastpage).StatusName;
            //        TextBox2.Text = ((Status)lastpage).StatusMobile.ToString();
            //        TextBox3.Text = ((Status)lastpage).StatusEmail;
            //    }
            //}
            if (!IsPostBack)
            {
                TextBox1.Text = Request.QueryString["Name"] ?? "";
                TextBox2.Text = Request.QueryString["Mobile"] ?? "";
                TextBox3.Text = Request.QueryString["Email"] ?? "";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UpperCase uc = new UpperCase();
            string temp = uc.ChangeToUpperCase(TextBox1.Text, TextBox3.Text);
            string[] arr = temp.Split(',');
            string a = arr[0];
            string b = arr[1];
            Response.Redirect("~/Status.aspx?Name="+Server.UrlEncode(a)+"&Mobile="+ Server.UrlEncode(TextBox2.Text)+"&Email="+ Server.UrlEncode(b));
        }
        public string Name
        {
            get
            {
                return TextBox1.Text;
            }
        }
        public int Mobile
        {
            get
            {
                return Convert.ToInt32(TextBox2.Text);
            }
        }
        public string Email
        {
            get
            {
                return TextBox3.Text;
            }
        }
    }
}