namespace Game.Levels
{
    partial class Lvl1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Lvl1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.screen = new System.Windows.Forms.Panel();
            this.btnLevels = new System.Windows.Forms.Button();
            this.Star = new System.Windows.Forms.PictureBox();
            this.player = new System.Windows.Forms.PictureBox();
            this.controls = new System.Windows.Forms.TextBox();
            this.score = new System.Windows.Forms.TextBox();
            this.block4 = new System.Windows.Forms.PictureBox();
            this.block3 = new System.Windows.Forms.PictureBox();
            this.block2 = new System.Windows.Forms.PictureBox();
            this.block0 = new System.Windows.Forms.PictureBox();
            this.bad_guy = new System.Windows.Forms.PictureBox();
            this.GameOver = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.block1 = new System.Windows.Forms.PictureBox();
            this.screen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Star)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bad_guy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameOver)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.block1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // screen
            // 
            this.screen.BackColor = System.Drawing.Color.Transparent;
            this.screen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.screen.Controls.Add(this.btnLevels);
            this.screen.Controls.Add(this.Star);
            this.screen.Controls.Add(this.player);
            this.screen.Controls.Add(this.controls);
            this.screen.Controls.Add(this.score);
            this.screen.Controls.Add(this.block4);
            this.screen.Controls.Add(this.block3);
            this.screen.Controls.Add(this.block2);
            this.screen.Controls.Add(this.block1);
            this.screen.Controls.Add(this.block0);
            this.screen.Controls.Add(this.bad_guy);
            this.screen.Controls.Add(this.GameOver);
            this.screen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.screen.Location = new System.Drawing.Point(0, 0);
            this.screen.Name = "screen";
            this.screen.Size = new System.Drawing.Size(1184, 819);
            this.screen.TabIndex = 1;
            // 
            // btnLevels
            // 
            this.btnLevels.Location = new System.Drawing.Point(12, 43);
            this.btnLevels.Name = "btnLevels";
            this.btnLevels.Size = new System.Drawing.Size(75, 23);
            this.btnLevels.TabIndex = 11;
            this.btnLevels.TabStop = false;
            this.btnLevels.Text = "Levels";
            this.btnLevels.UseVisualStyleBackColor = true;
            this.btnLevels.Click += new System.EventHandler(this.btnLevels_Click);
            // 
            // Star
            // 
            this.Star.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Star.Image = ((System.Drawing.Image)(resources.GetObject("Star.Image")));
            this.Star.Location = new System.Drawing.Point(584, 10);
            this.Star.Name = "Star";
            this.Star.Size = new System.Drawing.Size(32, 54);
            this.Star.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Star.TabIndex = 8;
            this.Star.TabStop = false;
            // 
            // player
            // 
            this.player.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.player.BackColor = System.Drawing.Color.Transparent;
            this.player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.player.Image = ((System.Drawing.Image)(resources.GetObject("player.Image")));
            this.player.Location = new System.Drawing.Point(262, 675);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(16, 32);
            this.player.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.player.TabIndex = 0;
            this.player.TabStop = false;
            // 
            // controls
            // 
            this.controls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controls.BackColor = System.Drawing.SystemColors.Info;
            this.controls.Enabled = false;
            this.controls.Location = new System.Drawing.Point(762, 3);
            this.controls.Name = "controls";
            this.controls.Size = new System.Drawing.Size(384, 22);
            this.controls.TabIndex = 10;
            this.controls.Text = "Move = left/right  Jump = space  Restart = enter  Exit = esc";
            // 
            // score
            // 
            this.score.BackColor = System.Drawing.SystemColors.Info;
            this.score.Enabled = false;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score.Location = new System.Drawing.Point(0, 0);
            this.score.Name = "score";
            this.score.Size = new System.Drawing.Size(143, 37);
            this.score.TabIndex = 6;
            // 
            // block4
            // 
            this.block4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.block4.BackColor = System.Drawing.Color.Transparent;
            this.block4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.block4.Image = global::Game.Properties.Resources._4;
            this.block4.Location = new System.Drawing.Point(588, 198);
            this.block4.Name = "block4";
            this.block4.Size = new System.Drawing.Size(75, 15);
            this.block4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.block4.TabIndex = 5;
            this.block4.TabStop = false;
            // 
            // block3
            // 
            this.block3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.block3.BackColor = System.Drawing.Color.Transparent;
            this.block3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.block3.Image = global::Game.Properties.Resources._3;
            this.block3.Location = new System.Drawing.Point(838, 298);
            this.block3.Name = "block3";
            this.block3.Size = new System.Drawing.Size(100, 15);
            this.block3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.block3.TabIndex = 4;
            this.block3.TabStop = false;
            // 
            // block2
            // 
            this.block2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.block2.BackColor = System.Drawing.Color.Transparent;
            this.block2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.block2.Image = global::Game.Properties.Resources._2;
            this.block2.Location = new System.Drawing.Point(238, 398);
            this.block2.Name = "block2";
            this.block2.Size = new System.Drawing.Size(125, 15);
            this.block2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.block2.TabIndex = 3;
            this.block2.TabStop = false;
            // 
            // block0
            // 
            this.block0.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.block0.BackColor = System.Drawing.Color.Transparent;
            this.block0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.block0.Image = global::Game.Properties.Resources._0;
            this.block0.Location = new System.Drawing.Point(338, 608);
            this.block0.Name = "block0";
            this.block0.Size = new System.Drawing.Size(500, 15);
            this.block0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.block0.TabIndex = 1;
            this.block0.TabStop = false;
            // 
            // bad_guy
            // 
            this.bad_guy.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bad_guy.BackColor = System.Drawing.Color.Transparent;
            this.bad_guy.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bad_guy.Image = ((System.Drawing.Image)(resources.GetObject("bad_guy.Image")));
            this.bad_guy.Location = new System.Drawing.Point(490, 530);
            this.bad_guy.Name = "bad_guy";
            this.bad_guy.Size = new System.Drawing.Size(81, 79);
            this.bad_guy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.bad_guy.TabIndex = 0;
            this.bad_guy.TabStop = false;
            // 
            // GameOver
            // 
            this.GameOver.Image = ((System.Drawing.Image)(resources.GetObject("GameOver.Image")));
            this.GameOver.Location = new System.Drawing.Point(0, 0);
            this.GameOver.Name = "GameOver";
            this.GameOver.Size = new System.Drawing.Size(1200, 700);
            this.GameOver.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.GameOver.TabIndex = 9;
            this.GameOver.TabStop = false;
            this.GameOver.Visible = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1;
            // 
            // block1
            // 
            this.block1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.block1.BackColor = System.Drawing.Color.Transparent;
            this.block1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.block1.Image = global::Game.Properties.Resources._1;
            this.block1.Location = new System.Drawing.Point(688, 498);
            this.block1.Name = "block1";
            this.block1.Size = new System.Drawing.Size(150, 15);
            this.block1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.block1.TabIndex = 2;
            this.block1.TabStop = false;
            // 
            // Lvl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 819);
            this.Controls.Add(this.screen);
            this.Name = "Lvl1";
            this.Text = "Lvl1";
            this.Load += new System.EventHandler(this.Lvl1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Lvl1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Lvl1_KeyUp);
            this.screen.ResumeLayout(false);
            this.screen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Star)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bad_guy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameOver)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.block1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel screen;
        private System.Windows.Forms.Button btnLevels;
        private System.Windows.Forms.PictureBox Star;
        private System.Windows.Forms.PictureBox player;
        private System.Windows.Forms.TextBox controls;
        private System.Windows.Forms.TextBox score;
        private System.Windows.Forms.PictureBox block4;
        private System.Windows.Forms.PictureBox block3;
        private System.Windows.Forms.PictureBox block2;
        private System.Windows.Forms.PictureBox block0;
        private System.Windows.Forms.PictureBox bad_guy;
        private System.Windows.Forms.PictureBox GameOver;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.PictureBox block1;
    }
}