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

namespace Budget_Tracking_and_Password_Keeping_System
{
    public partial class PasswordModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Joshua Bellosillo\OneDrive - STI College Santa Rosa\Documents\dbBTPKS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        public PasswordModuleForm()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to add this new account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cm = new SqlCommand("INSERT INTO tbPK (source, purpose, pkuser, pkpass)VALUES(@source, @purpose, @pkuser, @pkpass)", con);
                cm.Parameters.AddWithValue("@source", txtPKsource.Text);
                cm.Parameters.AddWithValue("@purpose", txtPKpurpose.Text);
                cm.Parameters.AddWithValue("@pkuser", txtPKuser.Text);
                cm.Parameters.AddWithValue("@pkpass", txtPKpass.Text);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New account has been added successfully");
                Clear();

            }
        }

        public void Clear()
        {
            txtPKuser.Clear();
            txtPKpass.Clear();
            txtPKsource.Clear();
            txtPKpurpose.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
