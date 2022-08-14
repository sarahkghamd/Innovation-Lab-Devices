﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
namespace ILD
{
    public partial class NewAdmin : System.Web.UI.Page
    {
        SqlConnection con;
        public string getConstring()
        {
            string constr = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            return constr;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            if (pass.Value != pass2.Value)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "errorPassword();", true);
                //  Response.Write("<script>alert('كلمة المرور غير متطابقة');</script>");
            }
            else if (CheckUserExists())
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "error();", true);
                //  Response.Write("<script>alert('الرقم الوظيفي مسجل من قبل');</script>");
            }
            else
            {

                string str = getConstring();
                con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Account values (@userid,@fname,@lname,@emailAdd,@phoneNum,@password,@accountTyp, @dep)", con);
                cmd.Parameters.AddWithValue("@fname", firstname.Value.Trim().ToString());
                cmd.Parameters.AddWithValue("@lname", lastname.Value.Trim().ToString());
                cmd.Parameters.AddWithValue("@userid", usid.Value.Trim().ToString());
                cmd.Parameters.AddWithValue("@phoneNum", phone.Value.Trim().ToString());
                cmd.Parameters.AddWithValue("@emailAdd", email.Value.Trim().ToString());
                cmd.Parameters.AddWithValue("@password", pass.Value.Trim().ToString());
                cmd.Parameters.AddWithValue("@accountTyp", "admin");
                cmd.Parameters.AddWithValue("@dep", "null");
                cmd.ExecuteNonQuery();
                con.Close();
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "success();", true);
                //  Response.Write("<script>alert('تم التسجيل بنجاح');</script>");
                // Response.Redirect("Home.aspx");
            }
        }

        //user defined method
        bool CheckUserExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(getConstring());
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from Account where Id='" + usid.Value.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }


        }
    }
}
