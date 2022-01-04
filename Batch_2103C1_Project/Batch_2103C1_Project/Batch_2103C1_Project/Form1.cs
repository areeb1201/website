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
              
            }

        private void button1_Click_1(object sender, EventArgs e)
        {
            u.u_name = textBox1.Text;
            u.u_email = textBox2.Text;
            u.u_contact = textBox3.Text;


            int i = db.insert(u);
            if (i != 0 || i != 0)
            {
                MessageBox.Show("Data Successfuly Insert.....");


            }
            else
            {
                MessageBox.Show("Data Not Successfuly Insert.....");
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
 }

