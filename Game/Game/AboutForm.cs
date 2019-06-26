using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game
{
    public partial class AboutForm : Form
    {
        //Thread for opening new win form
        private Thread th;

        public AboutForm()
        {
            InitializeComponent();
            this.BackColor = Color.White;
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }
        private void BtnMenu_Click_1(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(openNewWinForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openNewWinForm(object obj)
        {
            Application.Run(new MenuForm());
        }

    }
}
