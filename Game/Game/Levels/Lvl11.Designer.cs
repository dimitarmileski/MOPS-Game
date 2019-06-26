namespace Game.Levels
{
    partial class Lvl11
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
            this.btnLevels = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLevels
            // 
            this.btnLevels.BackColor = System.Drawing.Color.DarkGray;
            this.btnLevels.Font = new System.Drawing.Font("Consolas", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLevels.ForeColor = System.Drawing.Color.White;
            this.btnLevels.Location = new System.Drawing.Point(-4, -3);
            this.btnLevels.Name = "btnLevels";
            this.btnLevels.Size = new System.Drawing.Size(208, 64);
            this.btnLevels.TabIndex = 26;
            this.btnLevels.TabStop = false;
            this.btnLevels.Text = "< Levels";
            this.btnLevels.UseVisualStyleBackColor = false;
            this.btnLevels.Click += new System.EventHandler(this.BtnLevels_Click_1);
            // 
            // Lvl11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLevels);
            this.Name = "Lvl11";
            this.Text = "Lvl11";
            this.Load += new System.EventHandler(this.Lvl11_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLevels;
    }
}