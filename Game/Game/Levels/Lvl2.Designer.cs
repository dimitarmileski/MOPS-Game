namespace Game.Levels
{
    partial class Lvl2
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
            this.btnLevels.Location = new System.Drawing.Point(13, 13);
            this.btnLevels.Name = "btnLevels";
            this.btnLevels.Size = new System.Drawing.Size(75, 23);
            this.btnLevels.TabIndex = 0;
            this.btnLevels.Text = "Levels";
            this.btnLevels.UseVisualStyleBackColor = true;
            this.btnLevels.Click += new System.EventHandler(this.btnLevels_Click);
            // 
            // Lvl2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLevels);
            this.Name = "Lvl2";
            this.Text = "Lvl2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLevels;
    }
}