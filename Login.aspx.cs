using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace JUHIMS
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void loginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (username.Text == null | password.Text == null)
                {
                    WrongPassword.Text = ("Required fields missing");
                }
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["LoginConnection"].ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from dbo.Users where Username =@username and Password=@password", con);
                cmd.Parameters.AddWithValue("@username", username.Text);
                cmd.Parameters.AddWithValue("@password", password.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    FormsAuthentication.RedirectFromLoginPage(username.Text, false);
                    SqlCommand getID = new SqlCommand("select EID from dbo.Users where Username='" + username.Text + "'", con);
                    SqlDataReader sdr = getID.ExecuteReader();
                    while (sdr.Read())
                        Session["ID"] = sdr["EID"].ToString();
                    sdr.Close();
                    con.Close();
                }
                else
                    WrongPassword.Text = ("Incorrect Username/Password");
            }
            catch (Exception ee)
            {
                Feedback.Text = "An Error Occurred (" + ee.Message.ToString() + "), Please Retry Again Later.";
            }



        }
    }
}