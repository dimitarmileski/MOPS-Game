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
    public partial class Lvl15 : Form
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

        int platformSpeed1 = 3;
        int platformSpeed2 = 5;

        int points = 1;

        bool check0 = true;
        bool check1 = false;
        bool check2 = true;
        bool check3 = false;
        bool check4 = true;
        bool check5 = true;
        bool check6 = false;
        bool check7 = true;
        bool check_enemy1 = false;
        bool check_enemy2 = false;
        bool check_enemy3 = false;
        bool check_enemy4 = false;
        bool check_enemy5 = false;
        bool isCatched = false;
        bool isWin = false;
        bool glitch = false;

        //Thread for opening new win form
        private Thread th;

        //Level zero based
        public int level = 14;

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

        public Lvl15()
        {
            InitializeComponent();
            backgroundSound.SoundLocation = "Chase At Rush Hour.wav";
            win.SoundLocation = "GettingTheStar.wav";
            gameOver.SoundLocation = "GameOver.wav";
            backgroundSound.PlayLooping();
            
            this.DoubleBuffered = true;

            initPositions();


        }

        private void initPositions()
        {
            Star.Location = new Point(this.Width - (this.Width / 6), 5);

            Random rnd = new Random();

            block0.Location = new Point(rnd.Next(100, this.Width - 100), 420);
            enmy1.Location = new Point(block0.Location.X / 2, block0.Location.Y - enmy1.Height);
            enmy2.Location = new Point(block2.Location.X / 2, block2.Location.Y - enmy2.Height);
            enmy3.Location = new Point(block3.Location.X / 2, block3.Location.Y - enmy3.Height);
            enmy4.Location = new Point(block4.Location.X / 2, block4.Location.Y - enmy4.Height);
            enmy5.Location = new Point(block5.Location.X / 2, block5.Location.Y - enmy5.Height);

            block1.Location = new Point(rnd.Next(100, this.Width - 100), 320);
            block2.Location = new Point(rnd.Next(100, this.Width - 100), 220);
            block3.Location = new Point(rnd.Next(100, this.Width - 100), 120);
            block4.Location = new Point(rnd.Next(100, this.Width - 100), 20);
            block5.Location = new Point(rnd.Next(100, this.Width - 100), 520);
            block6.Location = new Point(rnd.Next(100, this.Width - 100), 620);
            block7.Location = new Point(rnd.Next(100, this.Width - 100), 720);


            player.Location = new Point(rnd.Next(100, this.Width - 100), this.Height - player.Height);
        }

        private void Lvl15_Load(object sender, EventArgs e)
        {

            //Full Screen
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            //

            GameOver.Location = new Point(this.Width / 2 - (GameOver.Width / 2), this.Height / 2 - (GameOver.Height / 2));
            GameOver.BringToFront();

            enmy1.Location = new Point(block0.Location.X / 2, block0.Location.Y - enmy1.Height);
            enmy2.Location = new Point(block2.Location.X / 2, block2.Location.Y - enmy2.Height);
            enmy3.Location = new Point(block3.Location.X / 2, block3.Location.Y - enmy3.Height);
            enmy4.Location = new Point(block4.Location.X / 2, block4.Location.Y - enmy4.Height);
            enmy5.Location = new Point(block5.Location.X / 2, block5.Location.Y - enmy5.Height);
        }


        private void Timer1_Tick(object sender, EventArgs e)
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
                enmy1.Enabled = false;
                enmy2.Enabled = false;
                enmy3.Enabled = false;
                enmy4.Enabled = false;
                enmy5.Enabled = false;

            }

            if (isWin == true)
            {
                backgroundSound.Stop();
                win.Play();
                //Win Animation 
                GameOver.Image = Image.FromFile("lvl15Win.gif");
                GameOver.Location = new Point(this.Width / 2 - (GameOver.Width / 2), this.Height / 2 - (GameOver.Height / 2));
                GameOver.Visible = true;
                //
                System.Threading.Thread.Sleep(900);
                player.Top = screen.Height - player.Height;
                points++;
               
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
                    enmy1.Left += 2;
                }
            }
            else
            {
                block0.Left -= 2;
                if (player.Bottom == block0.Top)
                {
                    player.Left -= 2;
                    enmy1.Left -= 2;
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
                    enmy1.Left += 2;
                }
            }
            else
            {
                block7.Left -= 2;
                if (player.Bottom == block7.Top)
                {
                    player.Left -= 2;
                    enmy1.Left -= 2;
                }
            }


            //enmy1 movement and wall collision
            if (enmy1.Right > block0.Right)
            {
                enmy1.Left = block0.Right - enmy1.Width;
                check_enemy1 = false;
                enmy1.Image = Image.FromFile("horseLeft.gif");
            }
            if (enmy1.Left < block0.Left)
            {
                enmy1.Left = block0.Left;
                check_enemy1 = true;
                enmy1.Image = Image.FromFile("horseRight.gif");
            }

            if (check_enemy1 == true) { enmy1.Left += 4; }

            else { enmy1.Left -= 4; }

            //collision with enmy1 (game over)
            if (player.Right > enmy1.Left && player.Left < enmy1.Right - player.Width && player.Bottom < enmy1.Bottom && player.Bottom > enmy1.Top)
            {
                isCatched = true;
            }

            if (player.Left < enmy1.Right && player.Right > enmy1.Left + player.Width && player.Bottom < enmy1.Bottom && player.Bottom > enmy1.Top)
            {

                isCatched = true;
            }


            //enmy2 movement and wall collision
            if (enmy2.Right > block2.Right)
            {
                enmy2.Left = block2.Right - enmy2.Width;
                check_enemy2 = false;
                enmy2.Image = Image.FromFile("princeLeft.gif");
            }
            if (enmy2.Left < block2.Left)
            {
                enmy2.Left = block2.Left;
                check_enemy2 = true;
                enmy2.Image = Image.FromFile("princeRight.gif");
            }

            if (check_enemy2 == true) { enmy2.Left += 4; }

            else { enmy2.Left -= 4; }

            //collision with enmy2 (game over)
            if (player.Right > enmy2.Left && player.Left < enmy2.Right - player.Width && player.Bottom < enmy2.Bottom && player.Bottom > enmy2.Top)
            {
                isCatched = true;
            }

            if (player.Left < enmy2.Right && player.Right > enmy2.Left + player.Width && player.Bottom < enmy2.Bottom && player.Bottom > enmy2.Top)
            {

                isCatched = true;
            }

            //enmy3 movement and wall collision
            if (enmy3.Right > block3.Right)
            {
                enmy3.Left = block3.Right - enmy3.Width;
                check_enemy3 = false;
                enmy3.Image = Image.FromFile("heroLeft.gif");
            }
            if (enmy3.Left < block3.Left)
            {
                enmy3.Left = block3.Left;
                check_enemy3 = true;
                enmy3.Image = Image.FromFile("heroRight.gif");
            }

            if (check_enemy3 == true) { enmy3.Left += 4; }

            else { enmy3.Left -= 4; }

            //collision with enmy3 (game over)
            if (player.Right > enmy3.Left && player.Left < enmy3.Right - player.Width && player.Bottom < enmy3.Bottom && player.Bottom > enmy3.Top)
            {
                isCatched = true;
            }

            if (player.Left < enmy3.Right && player.Right > enmy3.Left + player.Width && player.Bottom < enmy3.Bottom && player.Bottom > enmy3.Top)
            {

                isCatched = true;
            }



            //enmy4 movement and wall collision
            if (enmy4.Right > block4.Right)
            {
                enmy4.Left = block4.Right - enmy4.Width;
                check_enemy4 = false;
                enmy4.Image = Image.FromFile("cartLeft.gif");
            }
            if (enmy4.Left < block4.Left)
            {
                enmy4.Left = block4.Left;
                check_enemy4 = true;
                enmy4.Image = Image.FromFile("cartRight.gif");
            }

            if (check_enemy4 == false) { enmy4.Left += 4; }

            else { enmy4.Left -= 4; }

            //collision with enmy4 (game over)
            if (player.Right > enmy4.Left && player.Left < enmy4.Right - player.Width && player.Bottom < enmy4.Bottom && player.Bottom > enmy4.Top)
            {
                isCatched = true;
            }

            if (player.Left < enmy4.Right && player.Right > enmy4.Left + player.Width && player.Bottom < enmy4.Bottom && player.Bottom > enmy4.Top)
            {

                isCatched = true;
            }

            //enmy5 movement and wall collision
            if (enmy5.Right > block5.Right)
            {
                enmy5.Left = block5.Right - enmy5.Width;
                check_enemy5 = false;
                enmy5.Image = Image.FromFile("cucumberLeft.gif");
            }
            if (enmy5.Left < block5.Left)
            {
                enmy5.Left = block5.Left;
                check_enemy5 = true;
                enmy5.Image = Image.FromFile("cucumberRight.gif");
            }

            if (check_enemy5 == false) { enmy5.Left += 4; }

            else { enmy5.Left -= 4; }

            //collision with enmy4 (game over)
            if (player.Right > enmy5.Left && player.Left < enmy5.Right - player.Width && player.Bottom < enmy5.Bottom && player.Bottom > enmy5.Top)
            {
                isCatched = true;
            }

            if (player.Left < enmy5.Right && player.Right > enmy5.Left + player.Width && player.Bottom < enmy5.Bottom && player.Bottom > enmy5.Top)
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

        private void Lvl15_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = true; }

            if (e.KeyCode == Keys.Left) { left = true; }

            if (e.KeyCode == Keys.Escape)
            {
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

            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
                th = new Thread(restartForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }


        private void Lvl15_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right) { right = false; glitch = false; }

            if (e.KeyCode == Keys.Left) { left = false; glitch = false; }

            if (e.KeyCode == Keys.Space) { glitch = false; }
        }


        private void Lvl15_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
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
        private void BtnLevel_Click(object sender, EventArgs e)
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


        private void restartForm(object obj)
        {
            Application.Run(new Lvl15());
        }

        private void PicBoxSound_Click(object sender, EventArgs e)
        {
            if (soundToggle)
            {
                picBoxSound.Image = Image.FromFile("speakerOff.png");
                backgroundSound.Stop();
                soundToggle = false;
            }
            else
            {
                picBoxSound.Image = Image.FromFile("speakerOn.png");
                backgroundSound.PlayLooping();
                soundToggle = true;
            }

        }

       
    }
}

