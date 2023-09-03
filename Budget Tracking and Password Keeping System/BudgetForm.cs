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
    public partial class BudgetForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Joshua Bellosillo\OneDrive - STI College Santa Rosa\Documents\dbBTPKS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;

        public BudgetForm()
        {
            InitializeComponent();
            LoadBudget();
        }

        private void hoverButton1_Click(object sender, EventArgs e)
        {
            MainForm main = new MainForm();
            main.ShowDialog();
            this.Dispose();
        }

        public void LoadBudget()
        {
            int i = 0;
            dgvBudget.Rows.Clear();
            cm = new SqlCommand("SELECT * FROM tbBudget", con);
            con.Open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                dgvBudget.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), Convert.ToDateTime(dr[5].ToString()).ToString("dd/MM/yyyy"));
            }
            dr.Close();
            con.Close();
        }

        private void dgvBudget_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvBudget.Columns[e.ColumnIndex].Name;
            if(colName == "Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    con.Open();
                    cm = new SqlCommand("DELETE FROM tbBudget WHERE ptotal like '" + dgvBudget.Rows[e.RowIndex].Cells[5].Value.ToString() + "'", con);
                    cm.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record has been successfully deleted!");
                    LoadBudget();
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            BudgetModuleForm budgetForm = new BudgetModuleForm();
            budgetForm.ShowDialog();
            LoadBudget();
        }
    }
}
