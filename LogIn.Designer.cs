﻿namespace NovaPost
{
    partial class LogIn
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
            this._tbLogin = new System.Windows.Forms.TextBox();
            this._tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._btLogIn = new System.Windows.Forms.Button();
            this._btRegistration = new System.Windows.Forms.Button();
            this._btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _tbLogin
            // 
            this._tbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this._tbLogin.Location = new System.Drawing.Point(189, 52);
            this._tbLogin.Name = "_tbLogin";
            this._tbLogin.Size = new System.Drawing.Size(132, 29);
            this._tbLogin.TabIndex = 0;
            // 
            // _tbPassword
            // 
            this._tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this._tbPassword.Location = new System.Drawing.Point(189, 102);
            this._tbPassword.Name = "_tbPassword";
            this._tbPassword.Size = new System.Drawing.Size(132, 29);
            this._tbPassword.TabIndex = 1;
            this._tbPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this._tbPassword_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(121, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логін:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(102, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль:";
            // 
            // _btLogIn
            // 
            this._btLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this._btLogIn.Location = new System.Drawing.Point(42, 186);
            this._btLogIn.Name = "_btLogIn";
            this._btLogIn.Size = new System.Drawing.Size(92, 46);
            this._btLogIn.TabIndex = 4;
            this._btLogIn.Text = "Вхід";
            this._btLogIn.UseVisualStyleBackColor = true;
            this._btLogIn.Click += new System.EventHandler(this._btLogIn_Click);
            // 
            // _btRegistration
            // 
            this._btRegistration.AutoSize = true;
            this._btRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this._btRegistration.Location = new System.Drawing.Point(161, 186);
            this._btRegistration.Name = "_btRegistration";
            this._btRegistration.Size = new System.Drawing.Size(116, 46);
            this._btRegistration.TabIndex = 5;
            this._btRegistration.Text = "Реєстрація";
            this._btRegistration.UseVisualStyleBackColor = true;
            this._btRegistration.Click += new System.EventHandler(this._btRegistration_Click);
            // 
            // _btExit
            // 
            this._btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this._btExit.Location = new System.Drawing.Point(304, 186);
            this._btExit.Name = "_btExit";
            this._btExit.Size = new System.Drawing.Size(73, 46);
            this._btExit.TabIndex = 6;
            this._btExit.Text = "Вихід";
            this._btExit.UseVisualStyleBackColor = true;
            this._btExit.Click += new System.EventHandler(this._btExit_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 267);
            this.Controls.Add(this._btExit);
            this.Controls.Add(this._btRegistration);
            this.Controls.Add(this._btLogIn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbPassword);
            this.Controls.Add(this._tbLogin);
            this.MaximizeBox = false;
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _tbLogin;
        private System.Windows.Forms.TextBox _tbPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btLogIn;
        private System.Windows.Forms.Button _btRegistration;
        private System.Windows.Forms.Button _btExit;
    }
}