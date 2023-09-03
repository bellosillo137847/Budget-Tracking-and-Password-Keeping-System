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
    public partial class BudgetModuleForm : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Joshua Bellosillo\OneDrive - STI College Santa Rosa\Documents\dbBTPKS.mdf"";Integrated Security=True;Connect Timeout=30");
        SqlCommand cm = new SqlCommand();
        int zero = 0;
        public BudgetModuleForm()
        {
            InitializeComponent();
            txtPrice.Text = zero.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to ADD this to your expenses?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                cm = new SqlCommand("INSERT INTO tbBudget (pname, pdesc, pqty, pprice, ptotal, pdate)VALUES(@pname, @pdesc, @pqty, @pprice, @ptotal, @pdate)", con);
                cm.Parameters.AddWithValue("@pname", txtPName.Text);
                cm.Parameters.AddWithValue("@pdesc", txtDesc.Text);
                cm.Parameters.AddWithValue("@pqty", Convert.ToInt32(UDQty.Text));
                cm.Parameters.AddWithValue("@pprice", Convert.ToInt32(txtPrice.Text));
                cm.Parameters.AddWithValue("@ptotal", Convert.ToInt32(txtTotal.Text));
                cm.Parameters.AddWithValue("@pdate", dtBudget.Value);
                con.Open();
                cm.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("New expense(s) has been added successfully");
                Clear();

            }
        }

        private void UDQty_ValueChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt32(UDQty.Value) > 0)
            {
                int total = Convert.ToInt32(UDQty.Value) * Convert.ToInt32(txtPrice.Text);
                txtTotal.Text = total.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            txtDesc.Clear();
            txtPName.Clear();
            txtPrice.Text = zero.ToString();
            txtTotal.Clear();
            UDQty.Value = 0;
            dtBudget.Value = DateTime.Now;
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(txtPrice.Text) > 0)
                {
                    UDQty.Enabled = true;
                }
                else if (txtPrice.Text == "" || Convert.ToInt32(txtPrice.Text) == 0)
                {
                    UDQty.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                UDQty.Enabled = false;
                return;
            }
        }
    }
}
