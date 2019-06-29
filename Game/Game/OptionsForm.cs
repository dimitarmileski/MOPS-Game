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
    public partial class OptionsForm : Form
    {
        //Thread for opening new win form
        private Thread th;

        public OptionsForm()
        {
            InitializeComponent();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            //Full Screen
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //
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

        private void chkSound_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkSound.Checked)
            {
               //Code for checked
            }
        }

       
    }
}
