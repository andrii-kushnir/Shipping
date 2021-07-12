
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
            this._tbApartment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this._tbAddressId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this._btGetAddress = new System.Windows.Forms.Button();
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
            this._btGetClient = new System.Windows.Forms.Button();
            this._btClientChange = new System.Windows.Forms.Button();
            this._tbClienеIdChange = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this._tbClientId = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._cbClientType = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this._tbPhone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this._tbClientAddressId = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this._tbLastName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this._tbFirstName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this._btCreateClient = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this._btCreateShipment = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this._cbDeliveryType = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this._tbRecipient = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this._tbSender = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this._cbShipmentType = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
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
            this._btGetIndex.Location = new System.Drawing.Point(26, 261);
            this._btGetIndex.Name = "_btGetIndex";
            this._btGetIndex.Size = new System.Drawing.Size(403, 44);
            this._btGetIndex.TabIndex = 14;
            this._btGetIndex.Text = "Запам\"ятати адресу і отримати індекс";
            this._btGetIndex.UseVisualStyleBackColor = true;
            this._btGetIndex.Click += new System.EventHandler(this._btGetIndex_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1630, 881);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._tbApartment);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this._tbAddressId);
            this.tabPage1.Controls.Add(this.label6);
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
            this.tabPage1.Text = "Адреси & Індекс";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _tbApartment
            // 
            this._tbApartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbApartment.Location = new System.Drawing.Point(348, 210);
            this._tbApartment.Name = "_tbApartment";
            this._tbApartment.Size = new System.Drawing.Size(81, 29);
            this._tbApartment.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(105, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "Квартира(не обов\"язково):";
            // 
            // _tbAddressId
            // 
            this._tbAddressId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbAddressId.Location = new System.Drawing.Point(298, 328);
            this._tbAddressId.Name = "_tbAddressId";
            this._tbAddressId.Size = new System.Drawing.Size(131, 29);
            this._tbAddressId.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(105, 334);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "ID створеної адреси:";
            // 
            // _btGetAddress
            // 
            this._btGetAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._btGetAddress.Location = new System.Drawing.Point(526, 77);
            this._btGetAddress.Name = "_btGetAddress";
            this._btGetAddress.Size = new System.Drawing.Size(338, 44);
            this._btGetAddress.TabIndex = 19;
            this._btGetAddress.Text = "Отримати адресу";
            this._btGetAddress.UseVisualStyleBackColor = true;
            this._btGetAddress.Click += new System.EventHandler(this._btGetAddress_Click);
            // 
            // _cbHouse
            // 
            this._cbHouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbHouse.FormattingEnabled = true;
            this._cbHouse.Location = new System.Drawing.Point(178, 166);
            this._cbHouse.Name = "_cbHouse";
            this._cbHouse.Size = new System.Drawing.Size(251, 28);
            this._cbHouse.TabIndex = 11;
            // 
            // _tbPostCode
            // 
            this._tbPostCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbPostCode.Location = new System.Drawing.Point(764, 23);
            this._tbPostCode.Name = "_tbPostCode";
            this._tbPostCode.Size = new System.Drawing.Size(100, 29);
            this._tbPostCode.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(652, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 24);
            this.label7.TabIndex = 17;
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
            this.tabPage2.Controls.Add(this._btGetClient);
            this.tabPage2.Controls.Add(this._btClientChange);
            this.tabPage2.Controls.Add(this._tbClienеIdChange);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this._tbClientId);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this._cbClientType);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this._tbPhone);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this._tbClientAddressId);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this._tbLastName);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this._tbFirstName);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this._btCreateClient);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1622, 855);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Клієнти";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // _btGetClient
            // 
            this._btGetClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._btGetClient.Location = new System.Drawing.Point(935, 268);
            this._btGetClient.Name = "_btGetClient";
            this._btGetClient.Size = new System.Drawing.Size(338, 44);
            this._btGetClient.TabIndex = 36;
            this._btGetClient.Text = "Отримати клієнта";
            this._btGetClient.UseVisualStyleBackColor = true;
            this._btGetClient.Click += new System.EventHandler(this._btGetClient_Click);
            // 
            // _btClientChange
            // 
            this._btClientChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._btClientChange.Location = new System.Drawing.Point(935, 152);
            this._btClientChange.Name = "_btClientChange";
            this._btClientChange.Size = new System.Drawing.Size(338, 44);
            this._btClientChange.TabIndex = 33;
            this._btClientChange.Text = "Змінити дані клієнта";
            this._btClientChange.UseVisualStyleBackColor = true;
            this._btClientChange.Click += new System.EventHandler(this._btClientChange_Click);
            // 
            // _tbClienеIdChange
            // 
            this._tbClienеIdChange.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbClienеIdChange.Location = new System.Drawing.Point(875, 219);
            this._tbClienеIdChange.Name = "_tbClienеIdChange";
            this._tbClienеIdChange.Size = new System.Drawing.Size(398, 29);
            this._tbClienеIdChange.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.Location = new System.Drawing.Point(752, 225);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(117, 20);
            this.label15.TabIndex = 34;
            this.label15.Text = "uuid клієнта:";
            // 
            // _tbClientId
            // 
            this._tbClientId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbClientId.Location = new System.Drawing.Point(226, 358);
            this._tbClientId.Name = "_tbClientId";
            this._tbClientId.Size = new System.Drawing.Size(398, 29);
            this._tbClientId.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(3, 364);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(219, 20);
            this.label14.TabIndex = 31;
            this.label14.Text = "uuid створеного клієнта:";
            // 
            // _cbClientType
            // 
            this._cbClientType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbClientType.FormattingEnabled = true;
            this._cbClientType.Location = new System.Drawing.Point(414, 222);
            this._cbClientType.Name = "_cbClientType";
            this._cbClientType.Size = new System.Drawing.Size(210, 28);
            this._cbClientType.TabIndex = 29;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(282, 225);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 20);
            this.label13.TabIndex = 28;
            this.label13.Text = "Тип клієнта:";
            // 
            // _tbPhone
            // 
            this._tbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbPhone.Location = new System.Drawing.Point(414, 170);
            this._tbPhone.Name = "_tbPhone";
            this._tbPhone.Size = new System.Drawing.Size(210, 29);
            this._tbPhone.TabIndex = 27;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(245, 176);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(159, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = "Номер телефону:";
            // 
            // _tbClientAddressId
            // 
            this._tbClientAddressId.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbClientAddressId.Location = new System.Drawing.Point(414, 119);
            this._tbClientAddressId.Name = "_tbClientAddressId";
            this._tbClientAddressId.Size = new System.Drawing.Size(131, 29);
            this._tbClientAddressId.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(309, 125);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = "ID адреси:";
            // 
            // _tbLastName
            // 
            this._tbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbLastName.Location = new System.Drawing.Point(414, 66);
            this._tbLastName.Name = "_tbLastName";
            this._tbLastName.Size = new System.Drawing.Size(210, 29);
            this._tbLastName.TabIndex = 23;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(245, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 20);
            this.label10.TabIndex = 22;
            this.label10.Text = "Прізвище клієнта:";
            // 
            // _tbFirstName
            // 
            this._tbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbFirstName.Location = new System.Drawing.Point(414, 21);
            this._tbFirstName.Name = "_tbFirstName";
            this._tbFirstName.Size = new System.Drawing.Size(210, 29);
            this._tbFirstName.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(290, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 20);
            this.label9.TabIndex = 20;
            this.label9.Text = "Ім\"я клієнта:";
            // 
            // _btCreateClient
            // 
            this._btCreateClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._btCreateClient.Location = new System.Drawing.Point(286, 281);
            this._btCreateClient.Name = "_btCreateClient";
            this._btCreateClient.Size = new System.Drawing.Size(338, 44);
            this._btCreateClient.TabIndex = 30;
            this._btCreateClient.Text = "Створити клієнта";
            this._btCreateClient.UseVisualStyleBackColor = true;
            this._btCreateClient.Click += new System.EventHandler(this._btCreateClient_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this._cbShipmentType);
            this.tabPage3.Controls.Add(this.label23);
            this.tabPage3.Controls.Add(this._btCreateShipment);
            this.tabPage3.Controls.Add(this.textBox4);
            this.tabPage3.Controls.Add(this.textBox3);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this._cbDeliveryType);
            this.tabPage3.Controls.Add(this.label22);
            this.tabPage3.Controls.Add(this.label21);
            this.tabPage3.Controls.Add(this.label20);
            this.tabPage3.Controls.Add(this.label19);
            this.tabPage3.Controls.Add(this.label18);
            this.tabPage3.Controls.Add(this._tbRecipient);
            this.tabPage3.Controls.Add(this.label17);
            this.tabPage3.Controls.Add(this._tbSender);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1622, 855);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Створення відправлення";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // _btCreateShipment
            // 
            this._btCreateShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._btCreateShipment.Location = new System.Drawing.Point(669, 42);
            this._btCreateShipment.Name = "_btCreateShipment";
            this._btCreateShipment.Size = new System.Drawing.Size(338, 44);
            this._btCreateShipment.TabIndex = 53;
            this._btCreateShipment.Text = "Створити відправлення";
            this._btCreateShipment.UseVisualStyleBackColor = true;
            this._btCreateShipment.Click += new System.EventHandler(this._btCreateShipment_Click);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(210, 419);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(128, 29);
            this.textBox4.TabIndex = 52;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(210, 364);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(128, 29);
            this.textBox3.TabIndex = 50;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.Location = new System.Drawing.Point(210, 309);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(128, 29);
            this.textBox2.TabIndex = 48;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(210, 254);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(128, 29);
            this.textBox1.TabIndex = 46;
            // 
            // _cbDeliveryType
            // 
            this._cbDeliveryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbDeliveryType.FormattingEnabled = true;
            this._cbDeliveryType.Location = new System.Drawing.Point(210, 200);
            this._cbDeliveryType.Name = "_cbDeliveryType";
            this._cbDeliveryType.Size = new System.Drawing.Size(398, 28);
            this._cbDeliveryType.TabIndex = 44;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(131, 425);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(73, 20);
            this.label22.TabIndex = 51;
            this.label22.Text = "висота:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(126, 370);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 20);
            this.label21.TabIndex = 49;
            this.label21.Text = "ширина:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label20.Location = new System.Drawing.Point(116, 315);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(88, 20);
            this.label20.TabIndex = 47;
            this.label20.Text = "довжина:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label19.Location = new System.Drawing.Point(152, 260);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 20);
            this.label19.TabIndex = 45;
            this.label19.Text = "вага:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(75, 203);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(129, 20);
            this.label18.TabIndex = 43;
            this.label18.Text = "тип доставки:";
            // 
            // _tbRecipient
            // 
            this._tbRecipient.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbRecipient.Location = new System.Drawing.Point(210, 104);
            this._tbRecipient.Name = "_tbRecipient";
            this._tbRecipient.Size = new System.Drawing.Size(398, 29);
            this._tbRecipient.TabIndex = 40;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(49, 110);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(155, 20);
            this.label17.TabIndex = 39;
            this.label17.Text = "uuid одержувача:";
            // 
            // _tbSender
            // 
            this._tbSender.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._tbSender.Location = new System.Drawing.Point(210, 49);
            this._tbSender.Name = "_tbSender";
            this._tbSender.Size = new System.Drawing.Size(398, 29);
            this._tbSender.TabIndex = 38;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label16.Location = new System.Drawing.Point(46, 55);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(158, 20);
            this.label16.TabIndex = 37;
            this.label16.Text = "uuid відправника:";
            // 
            // _cbShipmentType
            // 
            this._cbShipmentType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._cbShipmentType.FormattingEnabled = true;
            this._cbShipmentType.Location = new System.Drawing.Point(210, 151);
            this._cbShipmentType.Name = "_cbShipmentType";
            this._cbShipmentType.Size = new System.Drawing.Size(398, 28);
            this._cbShipmentType.TabIndex = 42;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(38, 154);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(166, 20);
            this.label23.TabIndex = 41;
            this.label23.Text = "тип відправлення:";
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
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
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
        private System.Windows.Forms.TextBox _tbAddressId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox _tbApartment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button _btCreateClient;
        private System.Windows.Forms.TextBox _tbFirstName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox _tbLastName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox _tbClientAddressId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox _tbPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox _cbClientType;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox _tbClientId;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button _btClientChange;
        private System.Windows.Forms.TextBox _tbClienеIdChange;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button _btGetClient;
        private System.Windows.Forms.TextBox _tbSender;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox _tbRecipient;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox _cbDeliveryType;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Button _btCreateShipment;
        private System.Windows.Forms.ComboBox _cbShipmentType;
        private System.Windows.Forms.Label label23;
    }
}