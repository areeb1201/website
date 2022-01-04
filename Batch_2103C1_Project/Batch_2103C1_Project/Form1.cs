using Batch_2103C1_Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Batch_2103C1_Project
{
    public partial class Form1 : Form
    {
        student_logic_layer db = new student_logic_layer();
        tbl_user u = new tbl_user();
        public Form1()
        {
            InitializeComponent();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            u.u_name = textBox1.Text;
            u.u_email = textBox2.Text;
            u.contact = textBox3.Text;

            int i = db.insert(u);

            if (i!=0 || i!=-1)
            {
                dataGridView1.DataSource = db.getAllRecords();
                MessageBox.Show("Data Successfully Inserted...");
            }
            else
            {
                MessageBox.Show("Data Not Inserted....");
            }
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CheckBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (CheckBox1.Checked)
            {
                u = db.get_records_with_id(Convert.ToInt32(textBox7.Text));

                if (u!=null)
                {
                    textBox6.Text = u.u_name;
                    textBox5.Text = u.u_email;
                    textBox4.Text = u.contact;
                }
                else
                {
                    MessageBox.Show("No Record Found..");
                }
            }
        }
    }
}
