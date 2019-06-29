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

namespace Game.Levels
{
    public partial class Lvl4 : Form
    {
        //Thread for opening new win form
        private Thread th;

        public Lvl4()
        {
            InitializeComponent();
        }

        private void Lvl4_Load(object sender, EventArgs e)
        {
            //Full Screen
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //
        }

        private void BtnLevels_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to quit this level?", "Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                th = new Thread(openNewWinForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }

        private void openNewWinForm(object obj)
        {
            Application.Run(new LevelsForm());
        }

        
    }
}
