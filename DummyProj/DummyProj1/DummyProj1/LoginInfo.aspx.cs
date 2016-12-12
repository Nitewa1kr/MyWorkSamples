using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
/*
 THINGS NEEDED TO BE DONE:
 * FIX THE CODE TO RE-ADD THE DATA TO THE GRID WITHOUT GIVING AN ERROR
 * SYNC THE ID SO IT WILL NOT DUPLICATE.
 * USE TRY CATCH AND FINALLY
 * FIX THE PROCEDURE FOR THE LABEL TO READ THE LAST ID AVALIABLE
 * ADD ANOTHER TABLE
 
 */

namespace DummyProj1
{

    public partial class LoginInfo : System.Web.UI.Page
    {

        static string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;


        int i = 0;
        private void GenerateID()
        {

            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();

            SqlCommand cmd = new SqlCommand("auto_gen", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            string value = cmd.ExecuteScalar().ToString();
            i++;
            int j = Int32.Parse(value) + 1;
            lblS_ID.Text = j.ToString();

            myConnection.Close();
        }



        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                GenerateID();
            }
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {



            SqlConnection myConnection = new SqlConnection(myConnectionString);
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }
            
            SqlCommand cmd = new SqlCommand("Insert into Student_Name(STUDENT_NUM,STUDENT_NAME) VALUES (@STUDENT_NUM,@STUDENT_NAME)", myConnection);
            //SqlCommand cmd = new SqlCommand("SELECT STUDENT_NUM FROM Student_Name", myConnection);
            cmd.Parameters.Add("@STUDENT_NUM", SqlDbType.VarChar).Value = lblS_ID.Text;
            cmd.Parameters.Add("@STUDENT_NAME", SqlDbType.VarChar).Value = txtstdName.Text;

            if( cmd.ExecuteNonQuery() > 0)
            {
                lblResult.Text = "Successfully Saved";
            }
            else
            {
                lblResult.Text = "Error";
            }
            cmd.Dispose();
            
            //Second Table

            cmd.CommandText = "Insert into Student_Pass(PASSWORD) VALUES (@PASSWORD) SELECT SCOPE_IDENTITY()";
            cmd.Parameters.Add("@PASSWORD", SqlDbType.VarChar).Value = txtStdPass.Text;

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            myConnection.Close();
            GenerateID();
            GridView1.DataBind();

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            lblS_ID.Text = GridView1.SelectedDataKey.Value.ToString();
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            SqlCommand cmd = new SqlCommand("UPDATE Student_Name SET STUDENT_NUM = '" + lblS_ID.Text + "', STUDENT_NAME = '" + txtstdName.Text + "'  WHERE S_ID ='" + GridView1.SelectedDataKey.Value + "'", myConnection);

            if (myConnection.State == ConnectionState.Closed)
            {

                myConnection.Open();

            }

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            
            cmd.CommandText = "UPDATE Student_Pass SET PASSWORD = '" + txtStdPass.Text + "' WHERE P_ID ='" + GridView1.SelectedDataKey.Value + "'";

            cmd.ExecuteNonQuery();
            cmd.Dispose();
            myConnection.Close();
            GenerateID();
            GridView1.DataBind();

            lblResult.Text = "Selection Updated";

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);


            SqlCommand cmd = new SqlCommand("DELETE FROM Student_Name WHERE S_ID = '" + GridView1.SelectedDataKey.Value + "'", myConnection);

            if (myConnection.State == ConnectionState.Closed)
            {

                myConnection.Open();

            }
            GenerateID();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            
            cmd.CommandText = "DELETE FROM Student_Pass WHERE P_ID = '" + GridView1.SelectedDataKey.Value + "'";
            
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            myConnection.Close();
            GenerateID();
            GridView1.DataBind();

            lblResult.Text = "Selection Deleted";

        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {



            Label name, password;

            name = (Label)GridView1.SelectedRow.FindControl("NAME");
            password = (Label)GridView1.SelectedRow.FindControl("PASS");

            txtstdName.Text = name.Text;
            txtStdPass.Text = password.Text;

        }



    }

}
