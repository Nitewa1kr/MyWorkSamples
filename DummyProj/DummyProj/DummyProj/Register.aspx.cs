using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DummyProj
{
    public partial class Register : System.Web.UI.Page
    {
        /*Create a global connection string*/
        string myConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();

        /*Assign it to the sql connection string and create sql connection string*/
        
        //SqlConnection myConnection = new SqlConnection();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerateID();
            }

        }

        /*create a function that allows you to add one to the last avaliable data in the db table*/
        private void GenerateID()
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);

            myConnection.Open();
            SqlCommand cmd1 = new SqlCommand("Select Count(EMP_ID) from Employee", myConnection);
            int addOneEmpID_Table1 = Convert.ToInt32(cmd1.ExecuteScalar());
            myConnection.Close();
            addOneEmpID_Table1++;
            emp_ID.Text = emp_ID.Text + addOneEmpID_Table1.ToString();

            myConnection.Open();
            SqlCommand cmd2 = new SqlCommand("Select Count(E_ID) from EmployeeMore", myConnection);
            int addOneEID_Table2 = Convert.ToInt32(cmd2.ExecuteScalar());
            myConnection.Close();
            addOneEID_Table2++;
            e_id.Text = e_id.Text + addOneEID_Table2.ToString();

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            SqlConnection myConnection = new SqlConnection(myConnectionString);
            

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "insert into [Employee] values(@EMP_ID,@EMP_NUM)";
            cmd.Parameters.AddWithValue("@EMP_ID", emp_ID.Text);
            cmd.Parameters.AddWithValue("@EMP_NUM", emp_num.Text);
            cmd.Connection = myConnection;
            myConnection.Open();
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            
            cmd.CommandText = "insert into [EmployeeMore]values(@E_ID,@EMP_NAME,@EMP_PASSWORD,@OCCUPATION,@SDATE)";
            cmd.Parameters.AddWithValue("@E_ID", e_id.Text);
            cmd.Parameters.AddWithValue("@EMP_NAME", txtEmp_name.Text);
            cmd.Parameters.AddWithValue("@EMP_PASSWORD", txtPassword.Text);
            cmd.Parameters.AddWithValue("@OCCUPATION", Occ.Text);
            cmd.Parameters.AddWithValue("@SDATE",txtSDate.Text);
            cmd.Connection = myConnection;
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();

            //GenerateID();
            //myConnection.Close();


            //SqlConnection myConnection = new SqlConnection(myConnectionString);
            ///*Open connection*/
            //String INSERT_QUERY1 = "insert into Employee(EMP_ID,EMP_NUM)" + "values(@EMP_ID,@EMP_NUM)";

            //SqlCommand cmd1 = new SqlCommand(INSERT_QUERY1, myConnection);

            //cmd1.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = emp_ID.Text;
            //cmd1.Parameters.Add("@EMP_NUM", SqlDbType.Int).Value = emp_num.Text;
            //if (myConnection.State == ConnectionState.Closed) { myConnection.Open(); }
            //cmd1.ExecuteNonQuery();
            //cmd1.Parameters.Clear();


            //String INSERT_QUERY2 = "insert into EmployeeMore(E_ID,EMP_NAME,EMP_PASSWORD,OCCUPATION,SDATE)" + "values(@E_ID,@EMP_NAME,@EMP_PASSWORD,@OCCUPATION,@SDATE)";

            //SqlCommand cmd2 = new SqlCommand(INSERT_QUERY2, myConnection);
            //cmd2.Parameters.Add("@E_ID", SqlDbType.Int).Value = e_id.Text;
            //cmd2.Parameters.Add("@EMP_NAME", SqlDbType.Int).Value = txtEmp_name.Text;
            //cmd2.Parameters.Add("@EMP_PASSWORD", SqlDbType.VarChar).Value = txtPassword.Text;
            //cmd2.Parameters.Add("@OCCUPATION", SqlDbType.VarChar).Value = Occ.Text;
            //cmd2.Parameters.Add("@SDATE", SqlDbType.Date).Value = txtSDate.Text;
            //if (myConnection.State == ConnectionState.Closed) { myConnection.Open(); }
            //cmd2.ExecuteNonQuery();
            //myConnection.Close();
            //cmd2.Parameters.Clear();
            /*--------------------------------*/
            //String myQuery = "insert into Employee(EMP_ID,EMP_NUM)" + "values(@EMP_ID,@EMP_NUM)" + "insert into EmployeeMore(E_ID,EMP_NAME,EMP_PASSWORD,OCCUPATION,SDATE)" + "values(@E_ID,@EMP_NAME,@EMP_PASSWORD,@OCCUPATION,@SDATE)";

            //SqlCommand cmd = new SqlCommand(myQuery,myConnection);

            //cmd.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = Convert.ToInt32(emp_ID.Text);
            //cmd.Parameters.Add("@EMP_NUM", SqlDbType.Int).Value = Convert.ToInt32(emp_num.Text);

            //cmd.Parameters.Add("@E_ID", SqlDbType.Int).Value = Convert.ToInt32(e_id.Text);
            //cmd.Parameters.Add("@EMP_NAME", SqlDbType.Int).Value = txtEmp_name.Text;
            //cmd.Parameters.Add("@EMP_PASSWORD", SqlDbType.VarChar).Value = txtPassword.Text;
            //cmd.Parameters.Add("@OCCUPATION", SqlDbType.VarChar).Value = Occ.Text;
            //cmd.Parameters.Add("@SDATE", SqlDbType.Date).Value = Convert.ToDateTime(txtSDate.Text);
            //if (myConnection.State == ConnectionState.Closed) { myConnection.Open(); }
            //cmd.ExecuteNonQuery();
            
            //cmd.Parameters.Clear();

            //myConnection.Close();
            //GenerateID();
            //Result.Text = "Successfully Inserted";
            //Response.Redirect("Login.aspx");
            
            /*---------------------------------------------------------------------*/
            //SqlConnection myConnection = new SqlConnection(myConnectionString);
            ///*Open connection*/
            //String INSERT_QUERY1 = "insert into Employee(EMP_ID,EMP_NUM)" + "values(@EMP_ID,@EMP_NUM)";

            //SqlCommand cmd1 = new SqlCommand(INSERT_QUERY1, myConnection);
            //cmd1.Parameters.Add("@EMP_ID", SqlDbType.Int).Value = emp_ID.Text;
            //cmd1.Parameters.Add("@EMP_NUM", SqlDbType.Int).Value = emp_num.Text;
            //if (myConnection.State == ConnectionState.Closed) { myConnection.Open(); }
            //cmd1.ExecuteNonQuery();


            //String INSERT_QUERY2 = "insert into EmployeeMore(E_ID,EMP_NAME,EMP_PASSWORD,OCCUPATION,SDATE)" + "values(@E_ID,@EMP_NAME,@EMP_PASSWORD,@OCCUPATION,@SDATE)";

            //SqlCommand cmd2 = new SqlCommand(INSERT_QUERY2, myConnection);
            //cmd2.Parameters.Add("@E_ID", SqlDbType.Int).Value = e_id.Text;
            //cmd2.Parameters.Add("@EMP_NAME", SqlDbType.Int).Value = txtEmp_name.Text;
            //cmd2.Parameters.Add("@EMP_PASSWORD", SqlDbType.VarChar).Value = txtPassword.Text;
            //cmd2.Parameters.Add("@OCCUPATION", SqlDbType.VarChar).Value = Occ.Text;
            //cmd2.Parameters.Add("@SDATE", SqlDbType.Date).Value = txtSDate.Text;
            //cmd2.ExecuteNonQuery();

            myConnection.Close();
            GenerateID();
            Result.Text = "Successfully Inserted";
            //Response.Redirect("Login.aspx");
        }
    }
}