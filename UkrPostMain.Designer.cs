
namespace PostAPI
{
    partial class UkrPostMain
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
            this._bLogOut = new System.Windows.Forms.Button();
            this._btGetIndex = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._cbHouse = new System.Windows.Forms.ComboBox();
            this._tbPostCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this._cbStreet = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this._cbCity = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this._cbDistrict = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this._cbRegion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this._btGetAddress = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _bLogOut
            // 
            this._bLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._bLogOut.Location = new System.Drawing.Point(1637, 25);
            this._bLogOut.Name = "_bLogOut";
            this._bLogOut.Size = new System.Drawing.Size(157, 42);
            this._bLogOut.TabIndex = 0;
            this._bLogOut.Text = "LogOut";
            this._bLogOut.UseVisualStyleBackColor = true;
            this._bLogOut.Click += new System.EventHandler(this._bLogOut_Click);
            // 
            // _btGetIndex
            // 
            this._btGetIndex.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._btGetIndex.Location = new System.Drawing.Point(91, 223);
            this._btGetIndex.Name = "_btGetIndex";
            this._btGetIndex.Size = new System.Drawing.Size(338, 44);
            this._btGetIndex.TabIndex = 1;
            this._btGetIndex.Text = "Отримати індекс";
            this._btGetIndex.UseVisualStyleBackColor = true;
            this._btGetIndex.Click += new System.EventHandler(this._btGetIndex_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1630, 881);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._btGetAddress);
            this.tabPage1.Controls.Add(this._cbHouse);
            this.tabPage1.Controls.Add(this._tbPostCode);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this._cbStreet);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this._cbCity);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this._cbDistrict);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this._cbRegion);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this._btGetIndex);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1622, 855);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Адреса & Індекс";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _cbHouse
            // 
            this._cbHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbHouse.FormattingEnabled = true;
            this._cbHouse.Location = new System.Drawing.Point(178, 166);
            this._cbHouse.Name = "_cbHouse";
            this._cbHouse.Size = new System.Drawing.Size(251, 28);
            this._cbHouse.TabIndex = 16;
            // 
            // _tbPostCode
            // 
            this._tbPostCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbPostCode.Location = new System.Drawing.Point(764, 23);
            this._tbPostCode.Name = "_tbPostCode";
            this._tbPostCode.Size = new System.Drawing.Size(100, 29);
            this._tbPostCode.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(652, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 14;
            this.label7.Text = "PostCode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(87, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Будинок:";
            // 
            // _cbStreet
            // 
            this._cbStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbStreet.FormattingEnabled = true;
            this._cbStreet.Location = new System.Drawing.Point(178, 130);
            this._cbStreet.Name = "_cbStreet";
            this._cbStreet.Size = new System.Drawing.Size(251, 28);
            this._cbStreet.TabIndex = 9;
            this._cbStreet.SelectedIndexChanged += new System.EventHandler(this._cbStreet_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(97, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Вулиця:";
            // 
            // _cbCity
            // 
            this._cbCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbCity.FormattingEnabled = true;
            this._cbCity.Location = new System.Drawing.Point(178, 95);
            this._cbCity.Name = "_cbCity";
            this._cbCity.Size = new System.Drawing.Size(251, 28);
            this._cbCity.TabIndex = 7;
            this._cbCity.SelectedIndexChanged += new System.EventHandler(this._cbCity_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(66, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Місто/село:";
            // 
            // _cbDistrict
            // 
            this._cbDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbDistrict.FormattingEnabled = true;
            this._cbDistrict.Location = new System.Drawing.Point(178, 58);
            this._cbDistrict.Name = "_cbDistrict";
            this._cbDistrict.Size = new System.Drawing.Size(251, 28);
            this._cbDistrict.TabIndex = 5;
            this._cbDistrict.SelectedIndexChanged += new System.EventHandler(this._cbDistrict_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(107, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Район:";
            // 
            // _cbRegion
            // 
            this._cbRegion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbRegion.FormattingEnabled = true;
            this._cbRegion.Location = new System.Drawing.Point(178, 22);
            this._cbRegion.Name = "_cbRegion";
            this._cbRegion.Size = new System.Drawing.Size(251, 28);
            this._cbRegion.TabIndex = 3;
            this._cbRegion.SelectedIndexChanged += new System.EventHandler(this._cbRegion_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(85, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Область:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1622, 855);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _btGetAddress
            // 
            this._btGetAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._btGetAddress.Location = new System.Drawing.Point(526, 77);
            this._btGetAddress.Name = "_btGetAddress";
            this._btGetAddress.Size = new System.Drawing.Size(338, 44);
            this._btGetAddress.TabIndex = 17;
            this._btGetAddress.Text = "Отримати адресу";
            this._btGetAddress.UseVisualStyleBackColor = true;
            this._btGetAddress.Click += new System.EventHandler(this._btGetAddress_Click);
            // 
            // UkrPostMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 884);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this._bLogOut);
            this.Name = "UkrPostMain";
            this.Text = "UkrPostMain";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _bLogOut;
        private System.Windows.Forms.Button _btGetIndex;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox _tbPostCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox _cbStreet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox _cbCity;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _cbDistrict;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox _cbRegion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox _cbHouse;
        private System.Windows.Forms.Button _btGetAddress;
    }
}