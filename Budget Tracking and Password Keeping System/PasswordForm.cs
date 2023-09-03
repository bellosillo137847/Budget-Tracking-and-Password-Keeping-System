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
    public partial class PasswordForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Joshua Bellosillo\OneDrive - STI College Santa Rosa\Documents\dbBTPKS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public PasswordForm()
        {
            InitializeComponent();
            LoadPassForm();
        }

        public void LoadPassForm()
        {
            int i = 0;
            dgvPassKeep.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbPK", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvPassKeep.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            dr.Close();
            con.Close();
        }

        private void hoverButton1_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.ShowDialog();
            this.Dispose();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PasswordModuleForm passModule = new PasswordModuleForm();
            passModule.ShowDialog();
            LoadPassForm();
        }

        private void dgvPassKeep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvPassKeep.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this account?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbPK WHERE source like '" + dgvPassKeep.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                    LoadPassForm();
                }
            }
        }
    }
}
