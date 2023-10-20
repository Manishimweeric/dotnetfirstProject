using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RegistrationProject
{
    public partial class dashbord : Form
    {

        Boolean f;

        SqlConnection con = new SqlConnection(@"Data Source=MERIC\SQLEXPRESS;Initial Catalog=StudentRegistration2023;Integrated Security=True");

        public dashbord()
        {
            InitializeComponent();
        }

         public void veiw_data(DataRow row)
        {

            

            studentid.Text = row["studentId"].ToString();
            studentName.Text = row["fullName"].ToString();
             department.Text = row["deptName"].ToString();
            programNAm.Text = row["program"].ToString();
          

        }

        public void changedepartmentdisplay()
        {
           

           
        }



        public void notification()
        {

          
            String sql = "SELECT  status,studentId,action from request ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet data = new DataSet();
            sda.Fill(data, "request");

            /////////for change depatrment

            if (data.Tables.Count > 0)
            {
                f = false;
                DataTable table = data.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    String stidd, action, statuss;
                    stidd = row["studentId"].ToString();
                    action = row["action"].ToString().Trim();
                    statuss = row["status"].ToString().Trim();


                    if (stidd == studentid.Text && action == "changedepartment")
                    {
                        message2.Text = statuss;
                        f = true;

                    }
                }    
            }
            if (f == false)
            {
                message2.Text = "NO REQUEST";
            }



            /////////////////////for program 
            if (data.Tables.Count > 0)
            {
                f = false;
                DataTable table = data.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    String stidd, action, statuss;
                    stidd = row["studentId"].ToString();
                    action = row["action"].ToString().Trim();
                    statuss = row["status"].ToString().Trim();


                    if (stidd == studentid.Text && action == "changeprogram")
                    {
                        message1.Text = statuss;
                        f = true;

                    }

                }
            }
            if (f == false)
            {
                message1.Text = "NO REQUEST";
            }


            //////////////// for claiming
            ///////////////////////////////////

            String sql2 = "SELECT  status,studentId,action from requestB   ";
            SqlDataAdapter sd = new SqlDataAdapter(sql2, con);
            DataSet dat = new DataSet();
            sd.Fill(dat, "requestB");

            if (dat.Tables.Count > 0)
            {
                f = false;
                DataTable table1 = dat.Tables[0];
                foreach (DataRow row in table1.Rows)
                {
                    String stidd, action, statuss;
                    stidd = row["studentId"].ToString();
                    action = row["action"].ToString().Trim();
                    statuss = row["status"].ToString().Trim();


                    if (stidd == studentid.Text && action == "claim")
                    {
                        massage3.Text = statuss;
                        f = true;
                    }
                }

            }
        
            if (f == false)
            {
                massage3.Text = "NO REQUEST";
            }


            //////for internaship//////////////////////////
            if (dat.Tables.Count > 0)
            {
                f = false;
                DataTable table1 = dat.Tables[0];
                foreach (DataRow row in table1.Rows)
                {
                    String stidd, action, statuss;
                    stidd = row["studentId"].ToString();
                    action = row["action"].ToString().Trim();
                    statuss = row["status"].ToString().Trim();


                    if (stidd == studentid.Text && action == "internaship")
                    {
                        massage4.Text = statuss;
                        f = true;
                    }
                }

            }

            if (f == false)
            {
                massage4.Text = "NO REQUEST";
            }

            ///////////////////dessertion//////////////////////
            if (dat.Tables.Count > 0)
            {
                f = false;
                DataTable table1 = dat.Tables[0];
                foreach (DataRow row in table1.Rows)
                {
                    String stidd, action, statuss;
                    stidd = row["studentId"].ToString();
                    action = row["action"].ToString().Trim();
                    statuss = row["status"].ToString().Trim();


                    if (stidd == studentid.Text && action == "dessertion")
                    {
                        message5.Text = statuss;
                        f = true;
                    }
                }

            }

            if (f == false)
            {
                message5.Text = "NO REQUEST";
            }


            ////////////////////////////////////////////ending/////////////////////////

        }


        private void dashbord_Load(object sender, EventArgs e)
        {
            notification();

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            changepr.Visible = true;
            transfer.Visible = false;
            claim.Visible = false;
            internaship.Visible = false;
            desssertion.Visible = false;


        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            transfer.Visible = true;
            changepr.Visible =false;
            claim.Visible = false;
            internaship.Visible = false;
            desssertion.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {


            String sqldepa = "SELECT  status,studentId,action from request ";
            SqlDataAdapter sda = new SqlDataAdapter(sqldepa, con);
            DataSet data = new DataSet();
            sda.Fill(data, "request");

            /////////for change depatrment

            if (data.Tables.Count > 0)
            {
                f = false;
                DataTable table = data.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    String stidd, action, statuss;
                    stidd = row["studentId"].ToString();
                    action = row["action"].ToString().Trim();
                    statuss = row["status"].ToString().Trim();


                    if (stidd == studentid.Text && action == "changedepartment")
                    {
                        MessageBox.Show("YOUR ALLOWED TO CHANGE DEPARTMENT  ONLY ONE THEN YOUR ALREADY EXIST");
                        f = true;

                        depatname.Text = "";
                        resondepa.Text = "";

                        break;
                    }
                }
            }
            if (f == false)
            {



                String sql = "INSERT INTO request values(" + studentid.Text + ",'" + department.Text + "','" + depatname.SelectedValue + "','" + resondepa.Text + "','changedepartment','PENDING')";
                SqlDataAdapter sdadepa = new SqlDataAdapter(sql, con);
                con.Open();
                sdadepa.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your Request Submited");
                depatname.Text = "";
                resondepa.Text = "";

                notification();

            }


        }

        public void fetchdepdate()
        {
            String sql = "SELECT  * from department";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            sda.Fill(ds, "department");
            depatname.DataSource = ds.Tables["department"];
            depatname.DisplayMember = "deptName";
            depatname.ValueMember = "deptId";
        }

        private void transfer_Enter(object sender, EventArgs e)
        {
            fetchdepdate();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String sqlpro = "SELECT  status,studentId,action from request ";
            SqlDataAdapter sda = new SqlDataAdapter(sqlpro, con);
            DataSet data = new DataSet();
            sda.Fill(data, "request");

            /////////for change depatrment

            if (data.Tables.Count > 0)
            {
                f = false;
                DataTable table = data.Tables[0];
                foreach (DataRow row in table.Rows)
                {
                    String stidd, action, statuss;
                    stidd = row["studentId"].ToString();
                    action = row["action"].ToString().Trim();
                    statuss = row["status"].ToString().Trim();


                    if (stidd == studentid.Text && action == "changeprogram")
                    {
                        MessageBox.Show("YOUR ALLOWED TO CHANGE PROGRAM ONLY ONE THEN YOUR ALREADY EXIST");
                        f = true;
                      

                        comboBox2.Text = "";
                        rason.Text = "";
                        break;


                    }
                }
            }
            if (f == false)
            {




                String sql = "INSERT INTO request values(" + studentid.Text + ",'" + programNAm.Text + "','" + comboBox2.Text + "','" + rason.Text + "','changeprogram','PENDING')";
                SqlDataAdapter sd = new SqlDataAdapter(sql, con);
                con.Open();
                sd.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your Request Submited");

                comboBox2.Text = "";
                rason.Text = "";

                notification();
            }

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            login log = new login();
            this.Hide();
            log.ShowDialog();
        }

        private void INTERNASHIPBTN_Click(object sender, EventArgs e)
        {

            String sql2 = "SELECT  status,studentId,action from requestB   ";
            SqlDataAdapter sd = new SqlDataAdapter(sql2, con);
            DataSet dat = new DataSet();
            sd.Fill(dat, "requestB");

            if (dat.Tables.Count > 0)
            {
                f = false;
                DataTable table1 = dat.Tables[0];
                foreach (DataRow row in table1.Rows)
                {
                    String stidd, action, statuss;
                    stidd = row["studentId"].ToString();
                    action = row["action"].ToString().Trim();
                    statuss = row["status"].ToString().Trim();


                    if (stidd == studentid.Text && action == "internaship")
                    {
                        MessageBox.Show("YOUR ALLOWED TO REQUEST INTERNASHIP ONLY ONE THEN YOUR ALREADY EXIST THANKS!!");
                        f = true;
                        internashipReason.Text = "";

                        break;
                    }
                }

            }

            if (f == false)
            {


                String sql = "INSERT INTO requestB values(" + studentid.Text + ",'" + department.Text + "','" + internashipReason.Text + "','internaship','PENDING','null')";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                con.Open();
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your Internaship Request Submited");

                internashipReason.Text = "";

                notification();


            }


        }

        private void claimbtn_Click(object sender, EventArgs e)
        {


            String sql = "INSERT INTO requestB values(" + studentid.Text + ",'" + department.Text + "','" + claimreason.Text + "','claim','PENDING','null')";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);
            con.Open();
            sda.SelectCommand.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Your Claim Request Submited");

            claimreason.Text = "";

            notification();


        }

        private void dessbtn_Click(object sender, EventArgs e)
        {


            String sql2 = "SELECT  status,studentId,action from requestB   ";
            SqlDataAdapter sd = new SqlDataAdapter(sql2, con);
            DataSet dat = new DataSet();
            sd.Fill(dat, "requestB");

            if (dat.Tables.Count > 0)
            {
                f = false;
                DataTable table1 = dat.Tables[0];
                foreach (DataRow row in table1.Rows)
                {
                    String stidd, action, statuss;
                    stidd = row["studentId"].ToString();
                    action = row["action"].ToString().Trim();
                    statuss = row["status"].ToString().Trim();


                    if (stidd == studentid.Text && action == "dessertion")
                    {
                        MessageBox.Show("YOUR ALLOWED TO REQUEST DESSERTION ONLY ONE THEN YOUR ALREADY EXIST THANKS!!");
                        f = true;

                        dessreson.Text = "";
                        break;
                    }
                }

            }

            if (f == false)
            {

                String sql = "INSERT INTO requestB values(" + studentid.Text + ",'" + department.Text + "','" + dessreson.Text + "','dessertion','PENDING','null')";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);
                con.Open();
                sda.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Your Dessertion Request Submited");

                dessreson.Text = "";

                notification();

            }

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            changepr.Visible = false;
            transfer.Visible = false;
            claim.Visible = true;
            internaship.Visible = false;
            desssertion.Visible = false;

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            changepr.Visible = false;
            transfer.Visible = false;
            claim.Visible = false;
            internaship.Visible = true;
            desssertion.Visible = false;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            changepr.Visible = false;
            transfer.Visible = false;
            claim.Visible = false;
            internaship.Visible = false;
            desssertion.Visible = true;
        }

        private void desssertion_Enter(object sender, EventArgs e)
        {

        }

        private void claim_Enter(object sender, EventArgs e)
        {

        }
    }
}
