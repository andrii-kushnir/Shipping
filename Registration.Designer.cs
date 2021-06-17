namespace NovaPost
{
    partial class Registration
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._tbPassword = new System.Windows.Forms.TextBox();
            this._tbLogin = new System.Windows.Forms.TextBox();
            this._tbPassword1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._tbApiKey = new System.Windows.Forms.TextBox();
            this._btRegistration = new System.Windows.Forms.Button();
            this._btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label2.Location = new System.Drawing.Point(99, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 24);
            this.label2.TabIndex = 7;
            this.label2.Text = "Пароль:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label1.Location = new System.Drawing.Point(118, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "Логін:";
            // 
            // _tbPassword
            // 
            this._tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this._tbPassword.Location = new System.Drawing.Point(201, 103);
            this._tbPassword.Name = "_tbPassword";
            this._tbPassword.Size = new System.Drawing.Size(132, 29);
            this._tbPassword.TabIndex = 5;
            // 
            // _tbLogin
            // 
            this._tbLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this._tbLogin.Location = new System.Drawing.Point(201, 53);
            this._tbLogin.Name = "_tbLogin";
            this._tbLogin.Size = new System.Drawing.Size(132, 29);
            this._tbLogin.TabIndex = 4;
            // 
            // _tbPassword1
            // 
            this._tbPassword1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this._tbPassword1.Location = new System.Drawing.Point(201, 153);
            this._tbPassword1.Name = "_tbPassword1";
            this._tbPassword1.Size = new System.Drawing.Size(132, 29);
            this._tbPassword1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label3.Location = new System.Drawing.Point(99, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "API Key:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this.label4.Location = new System.Drawing.Point(22, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 24);
            this.label4.TabIndex = 11;
            this.label4.Text = "Пароль(повтор):";
            // 
            // _tbApiKey
            // 
            this._tbApiKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this._tbApiKey.Location = new System.Drawing.Point(201, 203);
            this._tbApiKey.Name = "_tbApiKey";
            this._tbApiKey.Size = new System.Drawing.Size(334, 29);
            this._tbApiKey.TabIndex = 10;
            // 
            // _btRegistration
            // 
            this._btRegistration.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this._btRegistration.Location = new System.Drawing.Point(76, 275);
            this._btRegistration.Name = "_btRegistration";
            this._btRegistration.Size = new System.Drawing.Size(174, 51);
            this._btRegistration.TabIndex = 12;
            this._btRegistration.Text = "Зареєструватись";
            this._btRegistration.UseVisualStyleBackColor = true;
            this._btRegistration.Click += new System.EventHandler(this._btRegistration_Click);
            // 
            // _btExit
            // 
            this._btExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this._btExit.Location = new System.Drawing.Point(323, 275);
            this._btExit.Name = "_btExit";
            this._btExit.Size = new System.Drawing.Size(174, 51);
            this._btExit.TabIndex = 13;
            this._btExit.Text = "Вихід";
            this._btExit.UseVisualStyleBackColor = true;
            this._btExit.Click += new System.EventHandler(this._btExit_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 356);
            this.Controls.Add(this._btExit);
            this.Controls.Add(this._btRegistration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._tbApiKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this._tbPassword1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._tbPassword);
            this.Controls.Add(this._tbLogin);
            this.MaximizeBox = false;
            this.Name = "Registration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Реєстрація";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _tbPassword;
        private System.Windows.Forms.TextBox _tbLogin;
        private System.Windows.Forms.TextBox _tbPassword1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _tbApiKey;
        private System.Windows.Forms.Button _btRegistration;
        private System.Windows.Forms.Button _btExit;
    }
}