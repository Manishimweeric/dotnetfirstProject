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
    public partial class Registrardashboard : Form
    {

        string statuss,pchange,stid;
        SqlConnection con = new SqlConnection(@"Data Source=MERIC\SQLEXPRESS;Initial Catalog=StudentRegistration2023;Integrated Security=True");

        public Registrardashboard()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        public void veiw_data(DataRow row)
        {



           fname.Text = row["fname"].ToString();
            lname.Text = row["lname"].ToString();
          


        }



        private void Registrardashboard_Load(object sender, EventArgs e)
        {

            DateTime now =  DateTime.Now;
            datat.Text = now.ToString();


        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

      

       

        /// <summary>
        /// //////METHODS OF SELECT DATA IN DATABASE
        /// </summary>
        /// 

            ///DISPLAY DEPARTMENT REQUEST
        public void changedepartmentdisplay()
        {
            String sql = "SELECT  studentId,currentMethod,newMethod,status from request   where action='changedepartment' AND status='pending'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            DataTable ds = new DataTable();
            sda.Fill(ds);

            dataGridView2.DataSource = ds;
        }

       //SELECT PROGRAM REQUEST
        public void changeprogramdisplay()
        {
            String sql = "SELECT  studentId,currentMethod,newMethod,status from request where action='changeprogram' AND status='pending'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            DataTable ds = new DataTable();
            sda.Fill(ds);

            dataGridView1.DataSource = ds;


        }
        // DISPLAY DESSERTAION REQUEST

        public void dessertiondisplay()
        {
            String sql = "SELECT  studentId,pname,reason,status from requestB   where action='dessertion' AND status='pending'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            DataTable ds = new DataTable();
            sda.Fill(ds);

            dataGridView5.DataSource = ds;

        }

        ///DISPLAY CLAIM REQUEST


        public void claimdisplay()
        {
            String sql = "SELECT  studentId,pname,reason,status from requestB   where action='claim' AND status='pending'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            DataTable ds = new DataTable();
            sda.Fill(ds);

            dataGridView3.DataSource = ds;

        }

        //DISPLAY INTERNASHIP REQUEST

        public void internashipdisplay()
        {

            String sql = "SELECT  studentId,pname,reason,status from requestB   where action='internaship' AND status='pending'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            DataTable ds = new DataTable();
            sda.Fill(ds);

            dataGridView4.DataSource = ds;
        }

       
        /// ////////////////////////////////////////////////////////////////////////
      
      
        private void deptarmenrequest_Enter(object sender, EventArgs e)
        {

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            login log = new login();
            this.Hide();
            log.ShowDialog();
            
        }


        //collection of data gridview

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                statuss = row.Cells[3].Value.ToString();
                pchange = row.Cells[2].Value.ToString();
                stid = row.Cells[0].Value.ToString();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                statuss = row.Cells[3].Value.ToString();
                pchange = row.Cells[2].Value.ToString();
                stid = row.Cells[0].Value.ToString();
            }

        }
        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView3.SelectedRows)
            {
                statuss = row.Cells[3].Value.ToString();
                pchange = row.Cells[2].Value.ToString();
                stid = row.Cells[0].Value.ToString();
            }



        }


        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            foreach (DataGridViewRow row in dataGridView4.SelectedRows)
            {
                statuss = row.Cells[3].Value.ToString();
                pchange = row.Cells[2].Value.ToString();
                stid = row.Cells[0].Value.ToString();
            }

        }


        private void dataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView5.SelectedRows)
            {
                statuss = row.Cells[3].Value.ToString();
                pchange = row.Cells[2].Value.ToString();
                stid = row.Cells[0].Value.ToString();
            }

        }

        //////////////////////////////////////////end of data grideview////////////////////////////////////////////////////////////





        //////////////////////////////////////=links/////////////////////////////
        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            deptarmenrequest.Visible = false;
            changeprogramrequest.Visible = false;
            claim.Visible = true;
            internaship.Visible = false;
            dessertion.Visible = false;


            claimdisplay();


        }

        ///////////////////////////////////
        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            deptarmenrequest.Visible = false;
            changeprogramrequest.Visible = false;
            claim.Visible = false;
            internaship.Visible = true;
            dessertion.Visible = false;

            internashipdisplay();


        }
        //////////////////////////
        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            deptarmenrequest.Visible = false;
            changeprogramrequest.Visible = false;
            claim.Visible = false;
            internaship.Visible = false;
            dessertion.Visible = true;


            dessertiondisplay();

        }

        ////////////////////////////////////////////////////////////
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            deptarmenrequest.Visible = true;
            changeprogramrequest.Visible = false;
            claim.Visible = false;
            internaship.Visible = false;
            dessertion.Visible = false;

            changedepartmentdisplay();


        }

        ////////////////////////////////////////////
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            changeprogramrequest.Visible = true;
            deptarmenrequest.Visible = false;
            claim.Visible = false;
            internaship.Visible = false;
            dessertion.Visible = false;

            changeprogramdisplay();




        }
        ///////////////////////////////////////////////




        private void changeprogrambtn_Click(object sender, EventArgs e)
        {

             ////update to student
            SqlCommand sc = new SqlCommand("UPDATE STUDENT SET deptId='"+pchange+"' where studentId='"+stid+"' ", con);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Approval Successful");

            ///////sea approval to status

            SqlCommand sd = new SqlCommand("UPDATE request SET status='APPROVAL' where studentId='" + stid + "' AND action='changeprogram' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();

            changeprogramdisplay();


        }

        private void denychangeprogrambtn_Click(object sender, EventArgs e)
        {
             
            SqlCommand sd = new SqlCommand("UPDATE request SET status='DENY' where studentId='" + stid + "' AND action='changeprogram' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DENY Successful");

            changeprogramdisplay();


        }

        ////////////////////////////////////////////////////////////////////////////////////

        private void DENYCHANGEDEPARTMENT_Click(object sender, EventArgs e)
        {

            SqlCommand sd = new SqlCommand("UPDATE request SET status='DENY' where studentId='" + stid + "' AND action='changedepartment' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DENY Successful");

            changedepartmentdisplay();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ////update to student
            SqlCommand sc = new SqlCommand("UPDATE STUDENT SET deptId='" + pchange + "' where studentId='" + stid + "' ", con);
            con.Open();
            sc.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Approval Successful");

            ///////sea approval to status

            SqlCommand sd = new SqlCommand("UPDATE request SET status='APPROVAL' where studentId='" + stid + "' AND action='changedepartment' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();

            changedepartmentdisplay();
        }

        /////////////////////////////////////////////////////////////////



        private void claimbtnapproval_Click(object sender, EventArgs e)
        {


            SqlCommand sd = new SqlCommand("UPDATE requestB SET status='APPROVAL',actor='"+lname.Text+"' where studentId='" + stid + "' AND action='claim' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Approval claim Successful");
            claimdisplay();

        }

        
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void denyclaimbtn_Click(object sender, EventArgs e)
        {


            SqlCommand sd = new SqlCommand("UPDATE requestB SET status='DENY',actor='" + lname.Text + "' where studentId='" + stid + "' AND action='claim' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DENY claim Successful");

            claimdisplay();
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////


        private void INTERNASHIPAPP_Click(object sender, EventArgs e)
        {


            SqlCommand sd = new SqlCommand("UPDATE requestB SET status='APPROVAL',actor='" + lname.Text + "' where studentId='" + stid + "' AND action='internaship' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Approval internaship Successful");

            internashipdisplay();


        }

        private void DENYINTERNASHIP_Click(object sender, EventArgs e)
        {

            SqlCommand sd = new SqlCommand("UPDATE requestB SET status='DENY',actor='" + lname.Text + "' where studentId='" + stid + "' AND action='internaship' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DENY claim Successful");
            internashipdisplay();

        }

      
        ///////////////////////////////////////////////////////////////////////////////////////////////
        

        private void dessertionbtnappr_Click(object sender, EventArgs e)
        {
            SqlCommand sd = new SqlCommand("UPDATE requestB SET status='APPROVAL',actor='" + lname.Text + "' where studentId='" + stid + "' AND action='dessertion' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Approval Dessertion Successful");

            dessertiondisplay();

        }

        private void fname_Click(object sender, EventArgs e)
        {

        }

        private void denydessertionbtn_Click(object sender, EventArgs e)
        {



            SqlCommand sd = new SqlCommand("UPDATE requestB SET status='DENY',actor='" + lname.Text + "' where studentId='" + stid + "' AND action='dessertion' ", con);
            con.Open();
            sd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DENY Dessertion Successful");


            dessertiondisplay();

        }

          




        

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {





        }
    }
}
