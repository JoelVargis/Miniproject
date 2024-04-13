using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ktunotifications
{
    public partial class login : Form
    {
        database db=new database();
        public login()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;    
        }

        

        private void closebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
         
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter your college mail id")
            {
                textBox1.Text= string.Empty;
                textBox1.ForeColor = Color.SteelBlue;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(IsValidEmail(textBox1.Text))
                {
                    if (comboBox2.SelectedIndex == 0)
                    {
                        MessageBox.Show("please select your semester", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlCommand cmd= new SqlCommand(@"INSERT INTO [dbo].[user_details]
                        ([email]         ,[semester])
                        VALUES
                        ('"+textBox1.Text+"','"+comboBox2.SelectedItem.ToString()+"')", db.GetCon());
                        db.OpenCon();
                        cmd.ExecuteNonQuery();
                        db.CloseCon();
                    }
                }
                else
                {
                    textBox1.Text = string.Empty;
                    MessageBox.Show("please enter your valid college mail id", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                textBox1.Text = "Enter your college mail id";
                textBox1.ForeColor= SystemColors.InactiveCaption;
            }
        }

      
        

        private void comboBox2_Leave(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex>0)
            {
                comboBox2.SelectedIndex = comboBox2.SelectedIndex;
                comboBox2.ForeColor = Color.SteelBlue;
            }
            else
            {
                comboBox2.ForeColor=SystemColors.InactiveCaption;
            }
        }

        static bool IsValidEmail(string email)
        {
            // Regular expression for validating email addresses
            string emailPattern = @"^pta[a-z0-9]*@cek\.ac\.in$";

            // Check if the email matches the pattern
            return Regex.IsMatch(email, emailPattern, RegexOptions.IgnoreCase);
        }

        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            comboBox2.ForeColor = SystemColors.InactiveCaption;
        }
    }
}
