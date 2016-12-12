using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/*NAME: ADEEL KHILJI
  PROGRAM: SOFTWARE ENGINEER
  COURSE: C#
 */

namespace StudentInfo
{
    public partial class StudentInfo : System.Web.UI.Page
    {
        /*CREATE A CONNECTION STRING*/
        static string myConnectionString = ConfigurationManager.ConnectionStrings["StudentConnectionString"].ConnectionString;

        int i = 0;
        private void GenerateID()
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            /*USING THE STORAGE PROCEDURE CREATE AN INCREMENT PROCEDURE*/
            SqlCommand cmd = new SqlCommand("auto_gen", myConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            string value = cmd.ExecuteScalar().ToString();
            i++;
            int j = Int32.Parse(value) + 1;

            lblS_NUM.Text = j.ToString();
            lblC_ID.Text = j.ToString();
            lblM_ID.Text = j.ToString();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateID();
            }
        }

        protected void btnADD_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            myConnection.Open();
            /*FIRST TABLE*/
            SqlCommand cmd = new SqlCommand("INSERT INTO STUDENT(S_NUM,S_FNAME,S_LNAME,S_DOB,S_SDATE)" +
                                            "VALUES (@S_NUM,@S_FNAME,@S_LNAME,@S_DOB,@S_SDATE)",myConnection);
            //if (txtDOB.Text != null && txtSDATE.Text != null)
            cmd.Parameters.Add("@S_NUM", SqlDbType.Int).Value = lblS_NUM.Text;
            cmd.Parameters.Add("@S_FNAME", SqlDbType.VarChar).Value = txtfname.Text;
            cmd.Parameters.Add("@S_LNAME", SqlDbType.VarChar).Value = txtlname.Text;
            cmd.Parameters.Add("@S_DOB", SqlDbType.Date).Value = Convert.ToDateTime(txtDOB.Text);
            cmd.Parameters.Add("@S_SDATE", SqlDbType.Date).Value = Convert.ToDateTime(txtSDATE.Text);

            if(cmd.ExecuteNonQuery() > 0)
            {
                lblResult.Text = "Successfully Saved";
            }
            else
            {
                lblResult.Text = "Error: Failed to store the data";
            }

            cmd.Dispose();
            
            /*SECOND TABLE*/

            cmd.CommandText ="INSERT INTO COURSE(C_ID, COURSE_NAME)" +
                                            "VALUES (@C_ID,@COURSE_NAME)";

            cmd.Parameters.Add("@C_ID", SqlDbType.Int).Value = lblC_ID.Text;
            cmd.Parameters.Add("@COURSE_NAME", SqlDbType.VarChar).Value = txtCourseName.Text;


            if (cmd.ExecuteNonQuery() > 0)
            {
                lblResult.Text = "Successfully Saved";
            }
            else
            {
                lblResult.Text = "Error: Failed to store the data";
            }

            cmd.Dispose();

            /*THIRD TABLE*/

            cmd.CommandText = "INSERT INTO MARKS(M_ID,M_ASSIGNMENTS,M_TESTS,M_EXAMS,M_TOTAL)" +
                                            "VALUES (@M_ID,@M_ASSIGNMENTS,@M_TESTS,@M_EXAMS,@M_TOTAL)";

            cmd.Parameters.Add("@M_ID", SqlDbType.Int).Value = lblM_ID.Text;
            cmd.Parameters.Add("@M_ASSIGNMENTS", SqlDbType.Int).Value = txtAssign.Text;
            cmd.Parameters.Add("@M_TESTS", SqlDbType.Int).Value = txtTests.Text;
            cmd.Parameters.Add("@M_EXAMS", SqlDbType.Int).Value = txtExams.Text;

            int a, b, c, tot;
            a = Convert.ToInt32(txtAssign.Text);
            b = Convert.ToInt32(txtTests.Text);
            c = Convert.ToInt32(txtExams.Text);

            tot = Convert.ToInt32(a + b + c);
            txtTot.Text = tot.ToString();

            cmd.Parameters.Add("@M_TOTAL", SqlDbType.Int).Value = txtTot.Text;

            if (cmd.ExecuteNonQuery() > 0)
            {
                lblResult.Text = "Successfully Saved";
            }
            else
            {
                lblResult.Text = "Error: Failed to store the data";
            }

            cmd.Dispose();
            
            myConnection.Close();
            GenerateID();
            GridView1.DataBind();

        }

        protected void btnUPDATE_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            try
            {

                SqlCommand cmd = new SqlCommand("UPDATE STUDENT SET S_FNAME = '" + txtfname.Text+ 
                                                "', S_LNAME = '"+txtlname.Text+
                                                "',S_DOB ='"+txtDOB.Text+
                                                "',S_SDATE ='"+txtSDATE.Text+
                                                "'  WHERE S_NUM ='" + GridView1.SelectedDataKey.Value + "'", myConnection);

                if (myConnection.State == ConnectionState.Closed)
                {

                    myConnection.Open();

                }

                //lblS_NUM.Text = GridView1.SelectedDataKey.Value.ToString();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //SECOND TABLE
                cmd.CommandText = "UPDATE COURSE SET COURSE_NAME = '" +txtCourseName.Text+
                                                "'  WHERE C_ID = '" + GridView1.SelectedDataKey.Value + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                /**/
                int a, b, c, tot;
                a = Convert.ToInt32(txtAssign.Text);
                b = Convert.ToInt32(txtTests.Text);
                c = Convert.ToInt32(txtExams.Text);

                tot = Convert.ToInt32(a + b + c);
                txtTot.Text = tot.ToString();
                //THIRD TABLE
                cmd.CommandText = "UPDATE MARKS SET M_ASSIGNMENTS = '" + txtAssign.Text +
                                                    "',M_TESTS = '" + txtTests.Text +
                                                    "',M_EXAMS = '" + txtExams.Text +
                                                    "',M_TOTAL = '" + txtTot.Text +
                                                    "' WHERE M_ID ='" + GridView1.SelectedDataKey.Value + "'";

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            { lblResult.Text = ex.Message; }

            finally 
            { 
                myConnection.Close();
                GenerateID();
                GridView1.DataBind();
            }
            lblResult.Text = "Selection Updated";
        }

        protected void btnDEL_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);

            try
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM STUDENT WHERE S_NUM = '" + GridView1.SelectedDataKey.Value + "'", myConnection);

                if (myConnection.State == ConnectionState.Closed)
                {

                    myConnection.Open();

                }

                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //SECOND TABLE
                cmd.CommandText = "DELETE FROM COURSE WHERE C_ID = '" + GridView1.SelectedDataKey.Value + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                //THIRD TABLE
                cmd.CommandText = "DELETE FROM MARKS WHERE M_ID = '" + GridView1.SelectedDataKey.Value + "'";
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }

            catch (Exception ex)
            { lblResult.Text = ex.Message; }

            finally
            {
                myConnection.Close();
                GenerateID();
                GridView1.DataBind();
            }
            lblResult.Text = "Selection Deleted";
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label fname, lname, dob, sdate, cname, assign, tests, exams, tot;
            fname = (Label)GridView1.SelectedRow.FindControl("FNAME");
            lname = (Label)GridView1.SelectedRow.FindControl("LNAME");
            dob = (Label)GridView1.SelectedRow.FindControl("DOB");
            sdate = (Label)GridView1.SelectedRow.FindControl("SDATE");

            cname = (Label)GridView1.SelectedRow.FindControl("CNAME");
            
            assign = (Label)GridView1.SelectedRow.FindControl("ASSIGN");
            tests = (Label)GridView1.SelectedRow.FindControl("TESTS");
            exams = (Label)GridView1.SelectedRow.FindControl("EXAMS");
            tot = (Label)GridView1.SelectedRow.FindControl("TOTAL");

            txtfname.Text = fname.Text;
            txtlname.Text = lname.Text;
            txtDOB.Text = dob.Text;
            txtSDATE.Text = sdate.Text;

            txtCourseName.Text = cname.Text;

            txtAssign.Text = assign.Text;
            txtTests.Text = tests.Text;
            txtExams.Text = exams.Text;
        }
        
    }
}