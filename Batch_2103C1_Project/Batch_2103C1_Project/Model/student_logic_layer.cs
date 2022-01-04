using Batch_2103C1_Project.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_2103C1_Project.Model
{
    class student_logic_layer
    {
        // jab bhi database ko ksi bhi class ya form se link karna hoga to hum is trah link karwaenge...

        // link for  database connection ....
        private string connectionstring = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
        // link for  database connection ....


        // data insert karne k liye  function create karenge tak use dusre ksi form / class me call karwasken


        public int insert(tbl_user u)
        {
            int msg = -1; // ye is lye tak error ko bad me check kia jasake

            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                SqlCommand cmd = new SqlCommand("insert_into_user", conn);
                conn.Open();

                cmd.Parameters.Add("@u_name", SqlDbType.VarChar, 50).Value = u.u_name;
                cmd.Parameters.Add("@u_email", SqlDbType.VarChar, 40).Value = u.u_email;
                cmd.Parameters.Add("@contact", SqlDbType.VarChar, 40).Value = u.contact;

                cmd.CommandType = CommandType.StoredProcedure;

                msg = cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                msg = 0;

                throw;
            }




            return msg;
        }

        public List<tbl_user> getAllRecords()
        {

            List<tbl_user> li = new List<tbl_user>();

            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("view_all_Records", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    tbl_user us = new tbl_user();

                    us.u_id = Convert.ToInt32(rdr["u_id"].ToString());
                    us.u_name = rdr["u_name"].ToString();
                    us.u_email = rdr["u_email"].ToString();
                    us.contact = rdr["contact"].ToString();

                    li.Add(us);


                }
            }
            catch (Exception)
            {
                MessageBox.Show("Some Error");

                throw;
            }

            return li;

        }

        public tbl_user get_records_with_id(int u_id)
        {
            tbl_user us = new tbl_user();

            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("get_records_with_id", conn);
                cmd.Parameters.Add("@u_id", SqlDbType.Int).Value = u_id;
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();

                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    us.u_id = Convert.ToInt32(rdr["u_id"].ToString());
                    us.u_name = rdr["u_name"].ToString();
                    us.u_email = rdr["u_email"].ToString();
                    us.contact = rdr["contact"].ToString();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No Record Found..");
                // throw;
            }
            return us;
        }

        public int update(tbl_user uvm)
        {
            int msg = 1;
            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                SqlCommand cmd = new SqlCommand("update_records", conn);
                conn.Open();
                cmd.Parameters.Add("@u_id", SqlDbType.Int).Value = uvm.u_id;
                cmd.Parameters.Add("@u_name", SqlDbType.VarChar, 50).Value = uvm.u_name;
                cmd.Parameters.Add("@u_email", SqlDbType.VarChar, 50).Value = uvm.u_email;
                cmd.Parameters.Add("@u_contact", SqlDbType.VarChar, 50).Value = uvm.u_contact;

                cmd.CommandType = CommandType.StoredProcedure;

                msg = cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                msg = 0;
            }
            return msg;
        }


    
