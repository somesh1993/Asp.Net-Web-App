using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TestDotnetApp.Model;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace TestDotnetApp
{
    public partial class Default : System.Web.UI.Page
    {
        string Baseurl = "http://localhost:52369/";
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
        //public string Name
        //{
        //    get
        //    {
        //        return TextBox1.Text;
        //    }
        //}
        //public int Mobile
        //{
        //    get
        //    {
        //        return Convert.ToInt32(TextBox2.Text);
        //    }
        //}
        //public string Email
        //{
        //    get
        //    {
        //        return TextBox3.Text;
        //    }
        //}

        protected void Button2_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = client.GetAsync("api/Values/GetSelectedEmployees/"+TextBox1.Text).Result;

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    emp = JsonConvert.DeserializeObject<Employee>(EmpResponse);
                    if (emp != null)
                    {
                        TextBox1.Text = emp.Name;
                        TextBox2.Text = emp.Mobile.ToString();
                        TextBox3.Text = emp.Email;
                    }
                    else
                    {
                        Label4.Text = "No MatchName";
                        Label5.Text = "No MatchMobile";
                        Label6.Text = "No MatchEmail";
                    }
                }
                
            }
        }
    }
}
