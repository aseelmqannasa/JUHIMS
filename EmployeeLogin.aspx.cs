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

namespace JUHIMSemployee
{
    public partial class EmployeeLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void eloginbtn_Click(object sender, EventArgs e)
        {
            if (eusername.Text == null || epassword.Text == null)
            {
                eWrongPassword.Text = ("Required fields missing");
            }
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HIMSConnectionString"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from dbo.Employee where Username =@username and Password=@password", con);
            cmd.Parameters.AddWithValue("@username", eusername.Text);
            cmd.Parameters.AddWithValue("@password", epassword.Text);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                FormsAuthentication.RedirectFromLoginPage(eusername.Text, false);
                SqlCommand getID = new SqlCommand("select Id from dbo.Employee where Username='" + eusername.Text + "'", con);
                SqlDataReader sdr = getID.ExecuteReader();
                while (sdr.Read())
                {
                    Session["EmployeeID"] = sdr["Id"].ToString();
                }
                sdr.Close();
                con.Close();
            }
            else
                eWrongPassword.Text = ("Incorrect Username/Password");

        }
    }
}