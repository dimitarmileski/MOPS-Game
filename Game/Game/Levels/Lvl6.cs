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
    public partial class Lvl6 : Form
    {
        //Thread for opening new win form
        private Thread th;

        public Lvl6()
        {
            InitializeComponent();
        }

        private void Lvl6_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnLevels_Click(object sender, EventArgs e)
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
