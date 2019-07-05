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
    public partial class Lvl1 : Form
    {

        System.Media.SoundPlayer backgroundSound = new System.Media.SoundPlayer();
        System.Media.SoundPlayer win = new System.Media.SoundPlayer();
        System.Media.SoundPlayer gameOver = new System.Media.SoundPlayer();
        private static bool soundToggle = true;

        bool right;
        bool left;
        bool jump;

        int G = 20;
        int Force;

        int platformSpeed1 = 0;
        int platformSpeed2 = 0;

        int points = 1;

        bool check0 = true;
        bool check1 = false;
        bool check2 = true;
        bool check3 = false;
        bool check4 = true;
        bool check5 = true;
        bool check6 = false;
        bool check7 = true;
        bool check_guy1 = false;
        bool isCatched = false;
        bool isWin = false;
        bool glitch = false;

        //Thread for opening new win form
        private Thread th;

        //Level zero based
        public int level = 0;

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

        public Lvl1()
        { 
            InitializeComponent();
            backgroundSound.SoundLocation = "Mall.wav";
            win.SoundLocation = "GettingTheStar.wav";
            gameOver.SoundLocation = "GameOver.wav";
            backgroundSound.PlayLooping();
            score.Text = "Score : " + points;
            score.ForeColor = Color.Black;
            this.DoubleBuffered = true;

            initPositions();

          
        }

        private void initPositions()
        {
            Star.Location = new Point(this.Width-(this.Width/6), 5);

            Random rnd = new Random();

            block0.Location = new Point(rnd.Next(100, this.Width - 100), 420);
            bad_guy.Location = new Point(block0.Location.X /2, block0.Location.Y - bad_guy.Height);

            block1.Location = new Point(rnd.Next(100, this.Width - 100), 320);
            block2.Location = new Point(rnd.Next(100, this.Width - 100), 220);
            block3.Location = new Point(rnd.Next(100, this.Width - 100), 120);
            block4.Location = new Point(rnd.Next(100, this.Width - 100), 20);
            block5.Location = new Point(rnd.Next(100, this.Width - 100), 520);
            block6.Location = new Point(rnd.Next(100, this.Width - 100), 620);
            block7.Location = new Point(rnd.Next(100, this.Width - 100), 720);

            player.Location = new Point(rnd.Next(100, this.Width - 100), this.Height - player.Height);
        }

        private void Lvl1_Load(object sender, EventArgs e)
        {

            //Full Screen
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //

            GameOver.Location = new Point(this.Width / 2 - (GameOver.Width / 2), this.Height / 2 - (GameOver.Height / 2));
            GameOver.BringToFront();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //player textures
            if (left == false && right == false && jump == false) { player.Image = Image.FromFile("dogstanding.gif"); } //standing 
            if (left == true && jump == true) { player.Image = Image.FromFile("dogleftjump.gif"); } //jumping to the left side
            if (right == true && jump == true) { player.Image = Image.FromFile("dogrightjump.gif"); } //jumping to the right side
            if (left == true && jump == false && glitch == false) { player.Image = Image.FromFile("dogwalkingleft.gif"); glitch = true; } //moving to the left side
            if (right == true && jump == false && glitch == false) { player.Image = Image.FromFile("dogwalkingright.gif"); glitch = true; } //moving to the right side
            if (left == false && right == false && jump == true) { player.Image = Image.FromFile("dogjump.gif"); } //jumping on one place
          
            if (isCatched == true) //game over (when in contact with badGuy
            {
                timer1.Stop();
                backgroundSound.Stop();
                gameOver.Play();
                GameOver.Visible = true;
                player.Enabled = false;
                bad_guy.Enabled = false;

            }

            if (isWin == true)
            {
                backgroundSound.Stop();
                win.Play();
                //Win Animation 
                GameOver.Image = Image.FromFile("lvl1Win.gif");
                GameOver.Location = new Point(this.Width / 2 - (GameOver.Width / 2), this.Height / 2 - (GameOver.Height / 2));
                GameOver.Visible = true;
                //
                System.Threading.Thread.Sleep(900);
                player.Top = screen.Height - player.Height;
                points++;
                score.Text = "Score = " + points;
                if (platformSpeed1 < 6) { platformSpeed1++; }
                if (points < 12) { platformSpeed2++; }
                isWin = false;
                backgroundSound.Play();


                LevelsState.levelPassed[level] = true;

            }


            if (right == true) //player moving right
            {
                player.Left += 6;
            }

            if (left == true) //player moving left
            {
                player.Left -= 6;
            }

            if (jump == true) //falling (if player jumped)
            {
                player.Top -= Force;
                Force -= 1;
            }

            if (player.Top + player.Height >= screen.Height)
            {
                player.Top = screen.Height - player.Height; // does not fall tru bottom!
                jump = false;
            }

            else
            {
                player.Top += 5; // just falling/gravity
            }

            // player side (window) collision
            if (player.Right > screen.Right) //right wall
            {
                player.Left = screen.Width - player.Width;
                right = false;
            }

            if (player.Left < screen.Left) //left wall
            {
                player.Left = screen.Left;
                left = false;
            }
            //

            // here we give collision to every block
            physics(block0);
            physics(block1);
            physics(block2);
            physics(block3);
            physics(block4);
            physics(block5);
            physics(block6);
            physics(block7);

            //block0 movement and wall collision
            if (block0.Right > screen.Right)
            {
                block0.Left = screen.Width - block0.Width;
                check0 = false;
            }
            if (block0.Left < screen.Left)
            {
                block0.Left = screen.Left;
                check0 = true;
            }
            if (check0 == true)
            {
                block0.Left += 2;
                if (player.Bottom == block0.Top)
                {
                    player.Left += 2;
                    bad_guy.Left += 2;
                }
            }
            else
            {
                block0.Left -= 2;
                if (player.Bottom == block0.Top)
                {
                    player.Left -= 2;
                    bad_guy.Left -= 2;
                }
            }

            //block1 movement and wall collision
            if (block1.Right > screen.Right)
            {
                block1.Left = screen.Width - block1.Width;
                check1 = false;
            }

            if (block1.Left < screen.Left)
            {
                block1.Left = screen.Left;
                check1 = true;
            }

            if (check1 == true)
            {
                block1.Left += (2 + platformSpeed1);
                if (player.Bottom == block1.Top)
                {
                    player.Left += (2 + platformSpeed1);
                }
            }

            else
            {
                block1.Left -= (2 + platformSpeed1);
                if (player.Bottom == block1.Top)
                {
                    player.Left -= (2 + platformSpeed1);
                }
            }

            //block2 movement and wall collision
            if (block2.Right > screen.Right)
            {
                block2.Left = screen.Width - block2.Width;
                check2 = false;
            }

            if (block2.Left < screen.Left)
            {
                block2.Left = screen.Left;
                check2 = true;
            }

            if (check2 == true)
            {
                block2.Left += (3 + platformSpeed2);
                if (player.Bottom == block2.Top)
                {
                    player.Left += (3 + platformSpeed2);
                }
            }

            else
            {
                block2.Left -= (3 + platformSpeed2);
                if (player.Bottom == block2.Top)
                {
                    player.Left -= (3 + platformSpeed2);
                }
            }

            //block3 movement and wall collision
            if (block3.Right > screen.Right)
            {
                block3.Left = screen.Width - block3.Width;
                check3 = false;
            }

            if (block3.Left < screen.Left)
            {
                block3.Left = screen.Left;
                check3 = true;
            }

            if (check3 == true)
            {
                block3.Left += (4 + platformSpeed1);
                if (player.Bottom == block3.Top)
                {
                    player.Left += (4 + platformSpeed1);
                }
            }

            else
            {
                block3.Left -= (4 + platformSpeed1);
                if (player.Bottom == block3.Top)
                {
                    player.Left -= (4 + platformSpeed1);
                }
            }

            //block4 movement and wall collision
            if (block4.Right > screen.Right)
            {
                block4.Left = screen.Width - block4.Width;
                check4 = false;
            }

            if (block4.Left < screen.Left)
            {
                block4.Left = screen.Left;
                check4 = true;
            }

            if (check4 == true)
            {
                block4.Left += (5 + platformSpeed2);
                if (player.Bottom == block4.Top)
                {
                    player.Left += (5 + platformSpeed2);
                }
            }

            else
            {
                block4.Left -= (5 + platformSpeed2);
                if (player.Bottom == block4.Top)
                {
                    player.Left -= (5 + platformSpeed2);
                }
            }


            //block5 movement and wall collision
            if (block5.Right > screen.Right)
            {
                block5.Left = screen.Width - block5.Width;
                check5 = false;
            }

            if (block5.Left < screen.Left)
            {
                block5.Left = screen.Left;
                check5 = true;
            }

            if (check5 == true)
            {
                block5.Left += (5 + platformSpeed2);
                if (player.Bottom == block5.Top)
                {
                    player.Left += (5 + platformSpeed2);
                }
            }

            else
            {
                block5.Left -= (5 + platformSpeed2);
                if (player.Bottom == block5.Top)
                {
                    player.Left -= (5 + platformSpeed2);
                }
            }


            //block6 movement and wall collision
            if (block6.Right > screen.Right)
            {
                block6.Left = screen.Width - block6.Width;
                check6 = false;
            }

            if (block6.Left < screen.Left)
            {
                block6.Left = screen.Left;
                check6 = true;
            }

            if (check6 == true)
            {
                block6.Left += (2 + platformSpeed1);
                if (player.Bottom == block6.Top)
                {
                    player.Left += (2 + platformSpeed1);
                }
            }

            else
            {
                block6.Left -= (2 + platformSpeed1);
                if (player.Bottom == block6.Top)
                {
                    player.Left -= (2 + platformSpeed1);
                }
            }


            //block7 movement and wall collision
            if (block7.Right > screen.Right)
            {
                block7.Left = screen.Width - block7.Width;
                check7 = false;
            }
            if (block7.Left < screen.Left)
            {
                block7.Left = screen.Left;
                check7 = true;
            }
            if (check7 == true)
            {
                block7.Left += 2;
                if (player.Bottom == block7.Top)
                {
                    player.Left += 2;
                    bad_guy.Left += 2;
                }
            }
            else
            {
                block7.Left -= 2;
                if (player.Bottom == block7.Top)
                {
                    player.Left -= 2;
                    bad_guy.Left -= 2;
                }
            }

            //bad_guy movement and wall collision
            if (bad_guy.Right > block0.Right)
            {
                bad_guy.Left = block0.Right - bad_guy.Width;
                check_guy1 = false;
                bad_guy.Image = Image.FromFile("bigbadleft.gif");
            }
            if (bad_guy.Left < block0.Left)
            {
                bad_guy.Left = block0.Left;
                check_guy1 = true;
                bad_guy.Image = Image.FromFile("bigbadright.gif");
            }

            if (check_guy1 == true) { bad_guy.Left += 4; }

            else { bad_guy.Left -= 4; }

            //collision with bad_guy (game over)
            if (player.Right > bad_guy.Left && player.Left < bad_guy.Right - player.Width && player.Bottom < bad_guy.Bottom && player.Bottom > bad_guy.Top)
            {
                isCatched = true;
            }

            if (player.Left < bad_guy.Right && player.Right > bad_guy.Left + player.Width && player.Bottom < bad_guy.Bottom && player.Bottom > bad_guy.Top)
            {

                isCatched = true;
            }

            //collision with star (win)
            if (player.Right > Star.Left && player.Left < Star.Right - player.Width && player.Bottom < Star.Bottom && player.Bottom > Star.Top)
            {
                isWin = true;
            }

            if (player.Left < Star.Right && player.Right > Star.Left + player.Width && player.Bottom < Star.Bottom && player.Bottom > Star.Top)
            {

                isWin = true;
            }

        }

        public void physics(System.Windows.Forms.PictureBox block)
        {
            // top collision 
            if (player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = false;
                Force = 0;
                player.Top = block.Location.Y - player.Height;
            }

            // simple fall
            if (!(player.Left + player.Width > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width) && player.Top + player.Height >= block.Top && player.Top < block.Top)
            {
                jump = true;
            }

            //bottom collision
            if (player.Left + player.Width - 1 > block.Left && player.Left + player.Width < block.Left + block.Width + player.Width && player.Top - block.Bottom <= 10 && player.Top - block.Top > -10)
            {
                Force = -1;
            }
        }

        private void Lvl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = true; }

            if (e.KeyCode == Keys.Left) { left = true; }

            if (e.KeyCode == Keys.Escape) {
                this.Close();
                th = new Thread(openNewWinForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }

            if (jump != true)
            {
                if (e.KeyCode == Keys.Space)
                {
                    jump = true;
                    Force = G;
                }
            }

            if (e.KeyCode == Keys.Enter) {
                this.Close();
                th = new Thread(restartForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }


        private void Lvl1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = false; glitch = false; }

            if (e.KeyCode == Keys.Left) { left = false; glitch = false; }

            if (e.KeyCode == Keys.Space) { glitch = false; }
        }


        private void Lvl1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                    e.IsInputKey = true;
                    break;
            }
        }
        private void BtnLevels_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to quit this level?", "Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            backgroundSound.Stop();

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


        private void restartForm(object obj) {
            Application.Run(new Lvl1());
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (soundToggle)
            {
                picBoxSound.Image = Image.FromFile("speakerOff.png");
                backgroundSound.Stop();
                soundToggle = false;
            }
            else {
                picBoxSound.Image = Image.FromFile("speakerOn.png");
                backgroundSound.PlayLooping();
                soundToggle = true;
            }
           
        }

       
    }
}

