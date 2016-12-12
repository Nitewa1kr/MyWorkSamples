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
 * FIX THE CODE TO RE-ADD THE DATA TO THE GRID WITHOUT GIVING AN ERROR[x]
 * SYNC THE ID SO IT WILL NOT DUPLICATE.[x]
 * USE TRY CATCH AND FINALLY[x]
 * FIX THE PROCEDURE FOR THE LABEL TO READ THE LAST ID AVALIABLE[x]
 * ADD ANOTHER TABLE[x]
 * DATE NEEDS TO BE HANDLED DIFFERENTLY
 * FIX YOUR DATA FLOW
 
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
            lblS_NUM.Text = j.ToString();

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
            cmd.Parameters.Add("@STUDENT_NUM", SqlDbType.VarChar).Value = lblS_NUM.Text;
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

            //Third Table
            cmd.CommandText = "Insert into Student_DOB(DOB) VALUES (@DOB) SELECT SCOPE_IDENTITY()";
            cmd.Parameters.Add("@DOB", SqlDbType.Date).Value = txtsDOB.Text;
            
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            
            myConnection.Close();
            GenerateID();
            GridView1.DataBind();

        }
        /*Since you need to select this to update and delete from the grid, use try catch and finally here.*/
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
             
            
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            try
            {

                SqlCommand cmd = new SqlCommand("UPDATE Student_Name SET STUDENT_NUM = '" + lblS_NUM.Text + "', STUDENT_NAME = '" + txtstdName.Text + "'  WHERE S_ID ='" + GridView1.SelectedDataKey.Value + "'", myConnection);

                if (myConnection.State == ConnectionState.Closed)
                {

                    myConnection.Open();

                }

                lblS_NUM.Text = GridView1.SelectedDataKey.Value.ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //SECOND TABLE
                cmd.CommandText = "UPDATE Student_Pass SET PASSWORD = '" + txtStdPass.Text + "' WHERE P_ID ='" + GridView1.SelectedDataKey.Value + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                //THIRD TABLE
                cmd.CommandText = "UPDATE Student_DOB SET DOB = '" + txtsDOB.Text + "' WHERE D_ID ='" + GridView1.SelectedDataKey.Value + "'";

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                lblResult.Text = "please select the data";
            }
            catch (Exception ex)
            { lblResult.Text = (ex.Message); }

            finally 
            { 
                myConnection.Close();
                GenerateID();
                GridView1.DataBind();
            }
            lblResult.Text = "Selection Updated";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);

            try
            {
            SqlCommand cmd = new SqlCommand("DELETE FROM Student_Name WHERE S_ID = '" + GridView1.SelectedDataKey.Value + "'", myConnection);

            if (myConnection.State == ConnectionState.Closed)
            {

                myConnection.Open();

            }
           
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //SECOND TABLE
                cmd.CommandText = "DELETE FROM Student_Pass WHERE P_ID = '" + GridView1.SelectedDataKey.Value + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //THIRD TABLE
                cmd.CommandText = "DELETE FROM Student_DOB WHERE D_ID = '" + GridView1.SelectedDataKey.Value + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            { lblResult.Text = (ex.Message); }

            finally { 
            myConnection.Close();
            GenerateID();
            GridView1.DataBind();
            }
            lblResult.Text = "Selection Deleted";
        }



        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {



            Label name, password,DOB;

            name = (Label)GridView1.SelectedRow.FindControl("NAME");
            password = (Label)GridView1.SelectedRow.FindControl("PASS");
            DOB = (Label)GridView1.SelectedRow.FindControl("DOB");

            txtstdName.Text = name.Text;
            txtStdPass.Text = password.Text;

        }



    }

}
