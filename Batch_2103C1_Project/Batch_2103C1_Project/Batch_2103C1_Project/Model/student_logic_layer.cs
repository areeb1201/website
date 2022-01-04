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

        private string connectionstring = ConfigurationManager.ConnectionStrings["db"].ConnectionString;


        public int insert(tbl_user u)
        {
            int msg = -1;

            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                SqlCommand cmd = new SqlCommand("insert_into_user", conn);
                conn.Open();
                cmd.Parameters.Add("@u_name", SqlDbType.VarChar, 50).Value = u.u_name;

                cmd.Parameters.Add("@u_email", SqlDbType.VarChar, 50).Value = u.u_email;

                cmd.Parameters.Add("@u_contact", SqlDbType.VarChar, 50).Value = u.u_contact;

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

        //insert method end....

        public List<tbl_user> getAllrecord()
        {
            List<tbl_user> li = new List<tbl_user>(); // list 
            try
            {
                SqlConnection conn = new SqlConnection(connectionstring);
                SqlCommand cmd = new SqlCommand("view_all_records", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tbl_user us = new tbl_user();

                    us.u_id = Convert.ToInt32(rdr["u_id"].ToString());
                    us.u_name = rdr["u_name"].ToString();
                    us.u_email = rdr["u_email"].ToString();
                    us.u_contact = rdr["u_contact"].ToString();

                    li.Add(us);



                }
            }
            catch (Exception)

            {
                MessageBox.Show("Some Error");

                // thorw
            }

            return li;

        }

        //delete



        public int delete(int id)
        {
            int msg = -1;
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {

                SqlCommand cmd = new SqlCommand("delete_records", conn);
                conn.Open();
                cmd.Parameters.Add("@u_id", SqlDbType.Int).Value = id;
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

        List<tbl_user> li = db.searchrecords(textBox8.Text);
        dataGridView1.DataSource=li;

    }

    private void button4_Click(object sender, EventArgs e)
    {
        student_logic_layer slm = new student_logic_layer();
        int msg = slm.delete(Convert.ToInt32(textBox9.Text));
        if (msg == -1)
        {
            MessageBox.Show("data could not be deleted");

        }
        else
        {
            MessageBox.Show("data deleted successfully");
        }

        dataGridView1.DataSource = db.getAllRecords();

    }
}

}
