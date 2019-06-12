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
    public partial class MenuForm : Form
    {

        public enum MenuItemSelected {
            Levels,
            Options,
            About
        }

        //Thread for opening new win form
        private Thread th;

        public MenuItemSelected menuItemSelected;

        public MenuForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void btnStart_Click(object sender, EventArgs e) {

            menuItemSelected = MenuItemSelected.Levels;
            openNewForm();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            menuItemSelected = MenuItemSelected.About;
            openNewForm();
        }

        private void btnOptions_Click(object sender, EventArgs e)
        {
          
            menuItemSelected = MenuItemSelected.Options;
            openNewForm();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        public void openNewForm() {
            this.Close();
            th = new Thread(openNewWinForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }


         void openNewWinForm(object obj)
        {
            if (menuItemSelected == MenuItemSelected.Levels)
            {
                Application.Run(new LevelsForm());
            }
            else if (menuItemSelected == MenuItemSelected.Options) {
                Application.Run(new OptionsForm());
            }
            else if(menuItemSelected == MenuItemSelected.About)
            {
                Application.Run(new AboutForm());
            }

        }


    }
}
