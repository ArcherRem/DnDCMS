namespace DnDCMS
{
    partial class Form1
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
            this.btn_DM = new System.Windows.Forms.Button();
            this.btn_Player = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_DM
            // 
            this.btn_DM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btn_DM.Location = new System.Drawing.Point(151, 12);
            this.btn_DM.Name = "btn_DM";
            this.btn_DM.Size = new System.Drawing.Size(111, 57);
            this.btn_DM.TabIndex = 5;
            this.btn_DM.Text = "DM";
            this.btn_DM.UseVisualStyleBackColor = true;
            this.btn_DM.Click += new System.EventHandler(this.btn_DM_Click);
            // 
            // btn_Player
            // 
            this.btn_Player.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btn_Player.Location = new System.Drawing.Point(12, 12);
            this.btn_Player.Name = "btn_Player";
            this.btn_Player.Size = new System.Drawing.Size(111, 57);
            this.btn_Player.TabIndex = 4;
            this.btn_Player.Text = "Player";
            this.btn_Player.UseVisualStyleBackColor = true;
            this.btn_Player.Click += new System.EventHandler(this.btn_Player_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 87);
            this.Controls.Add(this.btn_DM);
            this.Controls.Add(this.btn_Player);
            this.Name = "Form1";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_DM;
        private System.Windows.Forms.Button btn_Player;
    }
}

