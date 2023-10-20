using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace RegistrationProject
{
    public partial class Registrar : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MERIC\SQLEXPRESS;Initial Catalog=StudentRegistration2023;Integrated Security=True");

        public Registrar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String tittle = "staff";

            Regex rege = new Regex(@"[^@\s]+@[^@\s]+\.[^@\s]+$");
            bool cond = rege.IsMatch(emailbox.Text);

            if (cond == false)
            {
                MessageBox.Show("Invalid Your Email Prease Try anather");
            }
            else
            {
                String sql = "INSERT INTO Registrar values(" + idbox.Text + ",'"+fname.Text+"','"+lname.Text+"','" + emailbox.Text + "','" + passwordbox.Text + "','"+tittle+"')";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                con.Open();
                sda.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Successful to Registrar");
                idbox.Text = "";
                fname.Text = "";
                lname.Text = "";
                emailbox.Text = "";
                passwordbox.Text = "";

            }


        }
    }
}
