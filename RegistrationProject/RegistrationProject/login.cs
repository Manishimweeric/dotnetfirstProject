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
    public partial class login : Form
    {
        string staffchecked;
        Boolean f;
        SqlConnection con = new SqlConnection(@"Data Source=MERIC\SQLEXPRESS;Initial Catalog=StudentRegistration2023;Integrated Security=True");

        public login()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public string passworddecrypt(string passwordenc)
        {
            string shar = "pass#word@20223&#$###@";
            byte[] data = Convert.FromBase64String(passwordenc);
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider triples = new TripleDESCryptoServiceProvider();

            triples.Key = md5.ComputeHash(UTF8Encoding.UTF8.GetBytes(shar));
            triples.Mode = CipherMode.ECB;

            ICryptoTransform trans = triples.CreateDecryptor();
            byte[] result = trans.TransformFinalBlock(data, 0, data.Length);



            return UTF32Encoding.UTF8.GetString(result);

        }

       
        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            student st = new student();
            this.Hide();
            st.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            string Rsql = "select fname,lname,email,password,tittle from Registrar";

            SqlDataAdapter Rdd = new SqlDataAdapter(Rsql, con);
            DataSet dat = new DataSet();
            Rdd.Fill(dat, "registrar");


            bool ischecked = staff.Checked;

            if (ischecked)
            {
                staffchecked = "staff";

                /////////staffff login form//////////////////////
                if (dat.Tables.Count > 0)
                {
                    f = false;
                    DataTable tabl = dat.Tables[0];
                    foreach (DataRow row in tabl.Rows)
                    {
                        String title, Remail, Rpassword;

                        Remail = row["email"].ToString().Trim();
                        Rpassword = row["password"].ToString().Trim();
                        title = row["tittle"].ToString().Trim();

                        if (Remail == emailname.Text && Rpassword == passwor.Text && title == staffchecked)
                        {
                            //// to call your student dashboard
                            Registrardashboard das = new Registrardashboard();
                            das.veiw_data(row);
                            das.Show();
                            this.Hide();
                            f = true;
                            break;


                        }
                    }


                }
                


            }
            else
            {



                string sql = "select studentId,fullName,email,password,deptName,program from STUDENT INNER JOIN department ON department.deptId=student.deptId";

                SqlDataAdapter dd = new SqlDataAdapter(sql, con);
                DataSet data = new DataSet();
                dd.Fill(data, "student");


                /////student login form
                if (data.Tables.Count > 0)
                {
                    f = false;
                    DataTable table = data.Tables[0];
                    foreach (DataRow row in table.Rows)
                    {
                        String email, password;
                        email = row["email"].ToString().Trim();
                        password = passworddecrypt(row["password"].ToString().Trim());


                        if (email == emailname.Text && password == passwor.Text)
                        {
                            //// to call your student dashboard
                            dashbord dash = new dashbord();
                            dash.veiw_data(row);
                            dash.Show();
                            this.Hide();
                            f = true;
                            break;



                        }
                    }


                }
               
            }

            if(f==false)
            {
                message.Text = "Username or Password Incorrect ";
            }



        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Application.Exit();

        }
    }
}



