using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Budget_Tracking_and_Password_Keeping_System
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }



        private void hoverButton3_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            this.Hide();
            userForm.ShowDialog();
        }

        private void hoverButton1_Click(object sender, EventArgs e)
        {
            BudgetForm budget = new BudgetForm();
            this.Hide();
            budget.ShowDialog();
        }

        private void hoverButton4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("You will be exited and logged out automatically", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void hoverButton2_Click(object sender, EventArgs e)
        {
            PasswordForm passForm = new PasswordForm();
            this.Hide();
            passForm.ShowDialog();
        }
    }
}
