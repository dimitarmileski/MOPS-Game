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
    public partial class LevelsForm : Form
    {

        //Thread for opening new win form
        private Thread th;

        private string levelSelected;


        //Levels Picture Box
        private List<PictureBox> levelsBoxes;

        public LevelsForm()
        {
            InitializeComponent();
            levelSelected = "";
            
            initLevelsBoxes();
            
        }

        private void LevelsForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void initLevelsBoxes()
        {
            levelsBoxes = new List<PictureBox>();

            levelsBoxes.Add(picBoxLvl1);
            levelsBoxes.Add(picBoxLvl2);
            levelsBoxes.Add(picBoxLvl3);
            levelsBoxes.Add(picBoxLvl4);
            levelsBoxes.Add(picBoxLvl5);
            levelsBoxes.Add(picBoxLvl6);
            levelsBoxes.Add(picBoxLvl7);
            levelsBoxes.Add(picBoxLvl8);
            levelsBoxes.Add(picBoxLvl9);
            levelsBoxes.Add(picBoxLvl10);
            levelsBoxes.Add(picBoxLvl11);
            levelsBoxes.Add(picBoxLvl12);
            levelsBoxes.Add(picBoxLvl13);
            levelsBoxes.Add(picBoxLvl14);
            levelsBoxes.Add(picBoxLvl15);

            for (int i = 0; i < levelsBoxes.Count(); i++)
            {
                if (LevelsState.levelPassed[i]) 
                    levelsBoxes[i].BackColor = Color.YellowGreen;
                else
                    levelsBoxes[i].BackColor = Color.Crimson;
            }

        }

        private void BtnMenu_Click(object sender, EventArgs e)
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

        private void openLevelForm()
        {
            this.Close();
            th = new Thread(openLevel);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void openLevel(object obj)
        {
            switch (levelSelected)
            {
                case "1":
                    Application.Run(new Levels.Lvl1());
                    break;
                case "2":
                    Application.Run(new Levels.Lvl2());
                    break;
                case "3":
                    Application.Run(new Levels.Lvl3());
                    break;
                case "4":
                    Application.Run(new Levels.Lvl4());
                    break;
                case "5":
                    Application.Run(new Levels.Lvl5());
                    break;
                case "6":
                    Application.Run(new Levels.Lvl6());
                    break;
                case "7":
                    Application.Run(new Levels.Lvl7());
                    break;
                case "8":
                    Application.Run(new Levels.Lvl8());
                    break;
                case "9":
                    Application.Run(new Levels.Lvl9());
                    break;
                case "10":
                    Application.Run(new Levels.Lvl10());
                    break;
                case "11":
                    Application.Run(new Levels.Lvl11());
                    break;
                case "12":
                    Application.Run(new Levels.Lvl12());
                    break;
                case "13":
                    Application.Run(new Levels.Lvl13());
                    break;
                case "14":
                    Application.Run(new Levels.Lvl14());
                    break;
                case "15":
                    Application.Run(new Levels.Lvl15());
                    break;
                default:
                    break;
            }

        }

        private void picBoxLvl1_Click(object sender, EventArgs e)
        {
            levelSelected = "1";
            openLevelForm();
        }

        private void picBoxLvl2_Click(object sender, EventArgs e)
        {
            levelSelected = "2";
            openLevelForm();
        }

        private void picBoxLvl3_Click(object sender, EventArgs e)
        {
            levelSelected = "3";
            openLevelForm();
        }

        private void picBoxLvl4_Click(object sender, EventArgs e)
        {
            levelSelected = "4";
            openLevelForm();
        }

        private void picBoxLvl5_Click(object sender, EventArgs e)
        {
            levelSelected = "5";
            openLevelForm();
        }

        private void picBoxLvl6_Click(object sender, EventArgs e)
        {
            levelSelected = "6";
            openLevelForm();
        }

        private void picBoxLvl7_Click(object sender, EventArgs e)
        {
            levelSelected = "7";
            openLevelForm();
        }

        private void picBoxLvl8_Click(object sender, EventArgs e)
        {
            levelSelected = "8";
            openLevelForm();
        }

        private void picBoxLvl9_Click(object sender, EventArgs e)
        {
            levelSelected = "9";
            openLevelForm();
        }

        private void picBoxLvl10_Click(object sender, EventArgs e)
        {
            levelSelected = "10";
            openLevelForm();
        }

        private void picBoxLvl11_Click(object sender, EventArgs e)
        {
            levelSelected = "11";
            openLevelForm();
        }

        private void picBoxLvl12_Click(object sender, EventArgs e)
        {
            levelSelected = "12";
            openLevelForm();
        }

        private void picBoxLvl13_Click(object sender, EventArgs e)
        {
            levelSelected = "13";
            openLevelForm();
        }

        private void picBoxLvl14_Click(object sender, EventArgs e)
        {
            levelSelected = "14";
            openLevelForm();
        }

        private void picBoxLvl15_Click(object sender, EventArgs e)
        {
            levelSelected = "15";
            openLevelForm();
        }

        
    }
}
