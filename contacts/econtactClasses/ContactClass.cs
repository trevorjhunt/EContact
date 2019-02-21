using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace contacts.econtactClasses
{
    class ContactClass
    {
        // getter and setter properties
        // acts as data carrier in our application
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        //selecting data from database
        public DataTable Select()
        {
            //step1: Db connection
            SqlConnection conn = new SqlConnection(myconnstrng);

            // 
            DataTable dt = new DataTable();
            try
            {
                // Step2: writing the sql query 
                string sql = "SELECT * FROM table_econtact";
                // creating the command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                // Creating the SQL adapter usind cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return dt;
        }

        //insert data into DB
        public bool Insert (ContactClass c)
        {
            //Creating a default return type and setting
            bool isSuccess = false;

            // Step1: connect database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                // Step2: Create a SQL query to insert data
                string sql = "INSERT INTO table_econtact (FirstName, LastName, ContactNo, Address, Gender) VALUES(@FirstName, @LastName, @ContactNo, @Address, @Gender)";
                // creating the command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);

                //Connection open here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // if query was succesfull then the number of rows will be greater than 0
                if(rows >  0)                
                    isSuccess = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        //update data in the DB
        public bool Update(ContactClass c)
        {
            //Creating a default return type and setting
            bool isSuccess = false;

            // Step1: connect database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                // Step2: Create a SQL query to update data in DB
                string sql = "UPDATE table_econtact SET FirstName=@FirstName, LastName=@LastName, ContactNo=@ContactNo, Address=@Address, Gender=@Gender WHERE ContactID=@ContactID";
                // creating the command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create parameters to add data
                cmd.Parameters.AddWithValue("@FirstName", c.FirstName);
                cmd.Parameters.AddWithValue("@LastName", c.LastName);
                cmd.Parameters.AddWithValue("@ContactNo", c.ContactNo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Gender", c.Gender);
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                //Connection open here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // if query was succesfull then the number of rows will be greater than 0
                if (rows > 0)
                    isSuccess = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }

        //delete data from the DB
        public bool Delete(ContactClass c)
        {
            //Creating a default return type and setting
            bool isSuccess = false;

            // Step1: connect database
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                // Step2: Create a SQL query to update data in DB
                string sql = "DELETE FROM table_econtact WHERE ContactID=@ContactID";

                // creating the command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create parameters to add data
                cmd.Parameters.AddWithValue("@ContactID", c.ContactID);

                //Connection open here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                // if query was succesfull then the number of rows will be greater than 0
                if (rows > 0)
                    isSuccess = true;
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return isSuccess;
        }
    }
}
