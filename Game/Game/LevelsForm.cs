using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
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

        //Levels State Serilization
        private string FileName;
        public static bool[] levelPassed = new bool[15];

        public LevelsForm()
        {
            InitializeComponent();
            levelSelected = "";
            this.DoubleBuffered = true;
            this.BackColor = Color.White;

            initLevelsBoxes();

            for (int i = 0; i < levelPassed.Count(); i++)
            {
                levelPassed[i] = LevelsState.levelPassed[i];
            }

        }

        protected override CreateParams CreateParams // this activates DB and removes flickering and tearing!
        {
            get
            {
                // Activate double buffering at the form level.  All child controls will be double buffered as well.
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void LevelsForm_Load(object sender, EventArgs e)
        {
            //Full Screen
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //

            lvlPnl.Size = new Size(this.Width, this.Height / 2);
            lvlPnl.Location = new Point(0, this.Height / 2 - (lvlPnl.Height / 2));

            for (int i = 0; i < levelsBoxes.Count(); i++)
            {
                levelsBoxes[i].Size = new Size(this.Width / 15, this.Height);
            }


            for (int i = 0; i < levelsBoxes.Count(); i++)
            {
                Label label = new Label();

                label.Text = "Level " + (i + 1);

                label.Location = new Point(levelsBoxes[i].Location.X, levelsBoxes[i].Location.Y + levelsBoxes[i].Height / 3);
                label.BringToFront();
                label.Size = new Size(levelsBoxes[i].Width, 80);
                label.BackColor = Color.DarkGray;
                label.TextAlign = ContentAlignment.MiddleCenter;
                label.Font = new Font("Consolas", 10, FontStyle.Bold);
                label.ForeColor = Color.White;
                this.Controls.Add(label);
            }

            lblHelp.Location = new Point(this.Width / 2 - (lblHelp.Width), this.Height - 20);
            lblHelp.Text = "Click on level to play";
            lblHelp.ForeColor = Color.DarkGray;

            lblGreen.Location = new Point(this.Width / 2 - (lblGreen.Width), this.Height - 50);
            lblGreen.ForeColor = Color.DarkGray;

            lblYellow.Location = new Point(this.Width / 2 - (lblGreen.Width), this.Height - 70);
            lblYellow.ForeColor = Color.DarkGray;

            lblPassed.Location = new Point(this.Width / 2, this.Height - 50);
            lblPassed.ForeColor = Color.DarkGray;
            lblNotPassed.Location = new Point(this.Width / 2, this.Height - 70);
            lblNotPassed.ForeColor = Color.DarkGray;
            lblHelp.ForeColor = Color.DarkGray;

            picBoxDog.Location = new Point(this.Width - picBoxDog.Width, this.Height - picBoxDog.Height);


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
                    levelsBoxes[i].BackColor = Color.Goldenrod;
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
            if (LevelsState.levelPassed[0])
                openLevelForm();
        }

        private void picBoxLvl3_Click(object sender, EventArgs e)
        {
            levelSelected = "3";
            if (LevelsState.levelPassed[1])
                openLevelForm();
        }

        private void picBoxLvl4_Click(object sender, EventArgs e)
        {
            levelSelected = "4";
            if (LevelsState.levelPassed[2])
                openLevelForm();
        }

        private void picBoxLvl5_Click(object sender, EventArgs e)
        {
            levelSelected = "5";
            if (LevelsState.levelPassed[3])
                openLevelForm();
        }

        private void picBoxLvl6_Click(object sender, EventArgs e)
        {
            levelSelected = "6";
           if (LevelsState.levelPassed[4])
                openLevelForm();
        }

        private void picBoxLvl7_Click(object sender, EventArgs e)
        {
            levelSelected = "7";
            if (LevelsState.levelPassed[5])
                openLevelForm();
        }

        private void picBoxLvl8_Click(object sender, EventArgs e)
        {
            levelSelected = "8";
            if (LevelsState.levelPassed[6])
                openLevelForm();
        }

        private void picBoxLvl9_Click(object sender, EventArgs e)
        {
            levelSelected = "9";
            if (LevelsState.levelPassed[7])
                openLevelForm();
        }

        private void picBoxLvl10_Click(object sender, EventArgs e)
        {
            levelSelected = "10";
            if (LevelsState.levelPassed[8])
                openLevelForm();
        }

        private void picBoxLvl11_Click(object sender, EventArgs e)
        {
            levelSelected = "11";
            if (LevelsState.levelPassed[9])
                openLevelForm();
        }

        private void picBoxLvl12_Click(object sender, EventArgs e)
        {
            levelSelected = "12";
            if (LevelsState.levelPassed[10])
                openLevelForm();
        }

        private void picBoxLvl13_Click(object sender, EventArgs e)
        {
            levelSelected = "13";
            if (LevelsState.levelPassed[11])
                openLevelForm();
        }

        private void picBoxLvl14_Click(object sender, EventArgs e)
        {
            levelSelected = "14";
            if (LevelsState.levelPassed[12])
                openLevelForm();
        }

        private void picBoxLvl15_Click(object sender, EventArgs e)
        {
            levelSelected = "15";
            if (LevelsState.levelPassed[13])
                openLevelForm();
        }


        //Levels State Serilization

        private void saveFile()
        {
            if (FileName == null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "LevelsState file (*.lvl)|*.level";
                saveFileDialog.Title = "Save LevelsState doc";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileName = saveFileDialog.FileName;
                }
            }
            if (FileName != null)
            {
                using (FileStream fileStream = new FileStream(FileName, FileMode.Create))
                {

                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fileStream, levelPassed);
                }
            }
        }
        private void openFile()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "LevelsState file (*.lvl)|*.level";
            openFileDialog.Title = "Open LevelsState file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileName = openFileDialog.FileName;
                try
                {
                    using (FileStream fileStream = new FileStream(FileName, FileMode.Open))
                    {
                        IFormatter formater = new BinaryFormatter();
                        levelPassed = (bool [])formater.Deserialize(fileStream);


                        for (int i = 0; i < levelPassed.Count(); i++)
                        {
                            LevelsState.levelPassed[i] = levelPassed[i];
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not read file: " + FileName);
                    FileName = null;
                    return;
                }
                Invalidate(true);
            }
            restartForm();
        }

        private void restartForm()
        {
            this.Close();
            th = new Thread(LevelsFormOpen);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public void LevelsFormOpen()
        {
            Application.Run(new LevelsForm());
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFile();
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LevelsState.levelPassed.Count(); i++)
            {
                LevelsState.levelPassed[i] = false;
            }
            restartForm();
        }

        private void SaveAsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FileName = null;
            saveFile();
        }

       
    }
}


