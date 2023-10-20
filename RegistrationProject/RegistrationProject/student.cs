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
using System.Security.Cryptography;

namespace RegistrationProject
{
    public partial class student : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=MERIC\SQLEXPRESS;Initial Catalog=StudentRegistration2023;Integrated Security=True");
        public student()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            login log = new login();
            this.Hide();
            log.ShowDialog();
        }

        private void student_Load(object sender, EventArgs e)
        {
            fetchdepdate();
        }

        public string passwordencrypt(string passworddecrypt)
        {
            string shar = "pass#word@20223&#$###@";
            byte[] data = UTF32Encoding.UTF8.GetBytes(passworddecrypt);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider triples = new TripleDESCryptoServiceProvider();
            triples.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(shar));
            triples.Mode = CipherMode.ECB;

            ICryptoTransform trans = triples.CreateEncryptor();
            byte[] result = trans.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(result);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            String dpassw = passwordencrypt(passwordbox.Text);

            Regex rege = new Regex(@"[^@\s]+@[^@\s]+\.[^@\s]+$");
            bool cond = rege.IsMatch(emailbox.Text);

            if (cond == false)
            {
                MessageBox.Show("Invalid Your Email Prease Try anather");
            }
            else
            {
   
                SqlCommand sc = new SqlCommand("INSERT INTO STUDENT values(" + idbox.Text + ",'" + fullnamebox.Text + "','" + emailbox.Text + "','" + dpassw + "'," + comboBox1.SelectedValue + ",'" + comboBox2.Text + "','student')", con);
                con.Open();
                sc.ExecuteNonQuery();
                MessageBox.Show("Register student Successful");

                idbox.Text = "";
                fullnamebox.Text = "";
                passwordbox.Text = "";
                emailbox.Text = "";
                comboBox2.Text = "";


            }




        }


        public void fetchdepdate()
        {
            String sql = "SELECT  * from department";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "department");
            comboBox1.DataSource = ds.Tables["department"];
            comboBox1.DisplayMember = "deptName";
            comboBox1.ValueMember = "deptId";
        }
    }
}
