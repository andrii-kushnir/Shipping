namespace NovaPost
{
    partial class MainForm
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
            this._tcMain = new System.Windows.Forms.TabControl();
            this._tpAddress = new System.Windows.Forms.TabPage();
            this._tcAddress = new System.Windows.Forms.TabControl();
            this._tpCities = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this._btSendCities = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._tpAreas = new System.Windows.Forms.TabPage();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this._tpWarehouses = new System.Windows.Forms.TabPage();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this._tpDocuments = new System.Windows.Forms.TabPage();
            this._tcDocuments = new System.Windows.Forms.TabControl();
            this._tpDocumentList = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this._tpTracking = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._tbCreateTTN = new System.Windows.Forms.TabPage();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button8 = new System.Windows.Forms.Button();
            this.GenTTN = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this._tcMain.SuspendLayout();
            this._tpAddress.SuspendLayout();
            this._tcAddress.SuspendLayout();
            this._tpCities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this._tpAreas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            this._tpWarehouses.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            this._tpDocuments.SuspendLayout();
            this._tcDocuments.SuspendLayout();
            this._tpDocumentList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this._tpTracking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this._tbCreateTTN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _tcMain
            // 
            this._tcMain.Controls.Add(this._tpAddress);
            this._tcMain.Controls.Add(this._tpDocuments);
            this._tcMain.Dock = System.Windows.Forms.DockStyle.Left;
            this._tcMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this._tcMain.Location = new System.Drawing.Point(0, 0);
            this._tcMain.Name = "_tcMain";
            this._tcMain.SelectedIndex = 0;
            this._tcMain.Size = new System.Drawing.Size(1253, 670);
            this._tcMain.TabIndex = 1;
            // 
            // _tpAddress
            // 
            this._tpAddress.BackColor = System.Drawing.Color.Silver;
            this._tpAddress.Controls.Add(this._tcAddress);
            this._tpAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this._tpAddress.Location = new System.Drawing.Point(4, 33);
            this._tpAddress.Name = "_tpAddress";
            this._tpAddress.Padding = new System.Windows.Forms.Padding(3);
            this._tpAddress.Size = new System.Drawing.Size(1245, 633);
            this._tpAddress.TabIndex = 0;
            this._tpAddress.Text = "Адреса";
            // 
            // _tcAddress
            // 
            this._tcAddress.Controls.Add(this._tpCities);
            this._tcAddress.Controls.Add(this._tpAreas);
            this._tcAddress.Controls.Add(this._tpWarehouses);
            this._tcAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tcAddress.Location = new System.Drawing.Point(3, 3);
            this._tcAddress.Name = "_tcAddress";
            this._tcAddress.SelectedIndex = 0;
            this._tcAddress.Size = new System.Drawing.Size(1239, 627);
            this._tcAddress.TabIndex = 0;
            // 
            // _tpCities
            // 
            this._tpCities.BackColor = System.Drawing.Color.Silver;
            this._tpCities.Controls.Add(this.label6);
            this._tpCities.Controls.Add(this.dataGridView1);
            this._tpCities.Controls.Add(this._btSendCities);
            this._tpCities.Controls.Add(this.textBox3);
            this._tpCities.Controls.Add(this.textBox2);
            this._tpCities.Controls.Add(this.textBox1);
            this._tpCities.Controls.Add(this.label3);
            this._tpCities.Controls.Add(this.label2);
            this._tpCities.Controls.Add(this.label1);
            this._tpCities.Location = new System.Drawing.Point(4, 33);
            this._tpCities.Name = "_tpCities";
            this._tpCities.Padding = new System.Windows.Forms.Padding(3);
            this._tpCities.Size = new System.Drawing.Size(1231, 590);
            this._tpCities.TabIndex = 0;
            this._tpCities.Text = "Міста";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label6.Location = new System.Drawing.Point(549, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "* - поле не обов\"язкове";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(3, 151);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 80;
            this.dataGridView1.Size = new System.Drawing.Size(1225, 436);
            this.dataGridView1.TabIndex = 7;
            // 
            // _btSendCities
            // 
            this._btSendCities.Location = new System.Drawing.Point(645, 63);
            this._btSendCities.Name = "_btSendCities";
            this._btSendCities.Size = new System.Drawing.Size(247, 50);
            this._btSendCities.TabIndex = 6;
            this._btSendCities.Text = "Send";
            this._btSendCities.UseVisualStyleBackColor = true;
            this._btSendCities.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(233, 116);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(292, 29);
            this.textBox3.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(233, 73);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(76, 29);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = "0";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(233, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 29);
            this.textBox1.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Строка пошуку*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(117, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Сторінка*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Індентифікатор міста*";
            // 
            // _tpAreas
            // 
            this._tpAreas.BackColor = System.Drawing.Color.Silver;
            this._tpAreas.Controls.Add(this.dataGridView4);
            this._tpAreas.Controls.Add(this.button4);
            this._tpAreas.Location = new System.Drawing.Point(4, 33);
            this._tpAreas.Name = "_tpAreas";
            this._tpAreas.Padding = new System.Windows.Forms.Padding(3);
            this._tpAreas.Size = new System.Drawing.Size(1231, 590);
            this._tpAreas.TabIndex = 1;
            this._tpAreas.Text = "Області";
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView4.Location = new System.Drawing.Point(3, 151);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.RowHeadersWidth = 80;
            this.dataGridView4.Size = new System.Drawing.Size(1225, 436);
            this.dataGridView4.TabIndex = 8;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(503, 35);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(247, 50);
            this.button4.TabIndex = 7;
            this.button4.Text = "Send";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // _tpWarehouses
            // 
            this._tpWarehouses.BackColor = System.Drawing.Color.Silver;
            this._tpWarehouses.Controls.Add(this.dataGridView5);
            this._tpWarehouses.Controls.Add(this.button5);
            this._tpWarehouses.Controls.Add(this.textBox10);
            this._tpWarehouses.Controls.Add(this.label14);
            this._tpWarehouses.Location = new System.Drawing.Point(4, 33);
            this._tpWarehouses.Name = "_tpWarehouses";
            this._tpWarehouses.Size = new System.Drawing.Size(1231, 590);
            this._tpWarehouses.TabIndex = 2;
            this._tpWarehouses.Text = "Відділення";
            // 
            // dataGridView5
            // 
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView5.Location = new System.Drawing.Point(0, 154);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.RowHeadersWidth = 80;
            this.dataGridView5.Size = new System.Drawing.Size(1231, 436);
            this.dataGridView5.TabIndex = 9;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(584, 36);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(247, 50);
            this.button5.TabIndex = 8;
            this.button5.Text = "Send";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(215, 36);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(292, 29);
            this.textBox10.TabIndex = 4;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(46, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(152, 24);
            this.label14.TabIndex = 1;
            this.label14.Text = "Стрічка пошуку*";
            // 
            // _tpDocuments
            // 
            this._tpDocuments.BackColor = System.Drawing.Color.Silver;
            this._tpDocuments.Controls.Add(this._tcDocuments);
            this._tpDocuments.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F);
            this._tpDocuments.Location = new System.Drawing.Point(4, 33);
            this._tpDocuments.Name = "_tpDocuments";
            this._tpDocuments.Padding = new System.Windows.Forms.Padding(3);
            this._tpDocuments.Size = new System.Drawing.Size(1245, 633);
            this._tpDocuments.TabIndex = 1;
            this._tpDocuments.Text = "Експрес-накладні";
            // 
            // _tcDocuments
            // 
            this._tcDocuments.Controls.Add(this._tpDocumentList);
            this._tcDocuments.Controls.Add(this._tpTracking);
            this._tcDocuments.Controls.Add(this._tbCreateTTN);
            this._tcDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tcDocuments.Location = new System.Drawing.Point(3, 3);
            this._tcDocuments.Name = "_tcDocuments";
            this._tcDocuments.SelectedIndex = 0;
            this._tcDocuments.Size = new System.Drawing.Size(1239, 627);
            this._tcDocuments.TabIndex = 0;
            // 
            // _tpDocumentList
            // 
            this._tpDocumentList.BackColor = System.Drawing.Color.Silver;
            this._tpDocumentList.Controls.Add(this.button7);
            this._tpDocumentList.Controls.Add(this.textBox11);
            this._tpDocumentList.Controls.Add(this.label15);
            this._tpDocumentList.Controls.Add(this.dataGridView3);
            this._tpDocumentList.Controls.Add(this.textBox9);
            this._tpDocumentList.Controls.Add(this.checkBox1);
            this._tpDocumentList.Controls.Add(this.textBox8);
            this._tpDocumentList.Controls.Add(this.textBox7);
            this._tpDocumentList.Controls.Add(this.textBox6);
            this._tpDocumentList.Controls.Add(this.label13);
            this._tpDocumentList.Controls.Add(this.button1);
            this._tpDocumentList.Controls.Add(this.label12);
            this._tpDocumentList.Controls.Add(this.label11);
            this._tpDocumentList.Controls.Add(this.label10);
            this._tpDocumentList.Controls.Add(this.label9);
            this._tpDocumentList.Controls.Add(this.label8);
            this._tpDocumentList.Location = new System.Drawing.Point(4, 33);
            this._tpDocumentList.Name = "_tpDocumentList";
            this._tpDocumentList.Padding = new System.Windows.Forms.Padding(3);
            this._tpDocumentList.Size = new System.Drawing.Size(1231, 590);
            this._tpDocumentList.TabIndex = 0;
            this._tpDocumentList.Text = "Одержати список ЕН";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(861, 74);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(247, 50);
            this.button7.TabIndex = 23;
            this.button7.Text = "DELETE!!!";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(749, 14);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(433, 29);
            this.textBox11.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(641, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(102, 24);
            this.label15.TabIndex = 21;
            this.label15.Text = "Видалити:";
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(6, 193);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(1219, 391);
            this.dataGridView3.TabIndex = 20;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(196, 154);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(132, 29);
            this.textBox9.TabIndex = 19;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(196, 128);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(196, 84);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(52, 29);
            this.textBox8.TabIndex = 17;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(196, 49);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(132, 29);
            this.textBox7.TabIndex = 16;
            this.textBox7.Text = "31.12.2021";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(196, 14);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(132, 29);
            this.textBox6.TabIndex = 15;
            this.textBox6.Text = "01.01.2021";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label13.Location = new System.Drawing.Point(345, 173);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(127, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "* - поле не обов\"язкове";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(360, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(247, 50);
            this.button1.TabIndex = 13;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(30, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(153, 24);
            this.label12.TabIndex = 4;
            this.label12.Text = "Конкретна дата";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(51, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 24);
            this.label11.TabIndex = 3;
            this.label11.Text = "Посторінкаво";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(94, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 24);
            this.label10.TabIndex = 2;
            this.label10.Text = "Сторінка";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(109, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 24);
            this.label9.TabIndex = 1;
            this.label9.Text = "Дата по";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(121, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 24);
            this.label8.TabIndex = 0;
            this.label8.Text = "Дата з";
            // 
            // _tpTracking
            // 
            this._tpTracking.BackColor = System.Drawing.Color.Silver;
            this._tpTracking.Controls.Add(this.dataGridView2);
            this._tpTracking.Controls.Add(this.button3);
            this._tpTracking.Controls.Add(this.textBox5);
            this._tpTracking.Controls.Add(this.textBox4);
            this._tpTracking.Controls.Add(this.label7);
            this._tpTracking.Controls.Add(this.label5);
            this._tpTracking.Controls.Add(this.label4);
            this._tpTracking.Location = new System.Drawing.Point(4, 33);
            this._tpTracking.Name = "_tpTracking";
            this._tpTracking.Padding = new System.Windows.Forms.Padding(3);
            this._tpTracking.Size = new System.Drawing.Size(1231, 590);
            this._tpTracking.TabIndex = 1;
            this._tpTracking.Text = "Трекінг ЕН";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 118);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1222, 466);
            this.dataGridView2.TabIndex = 13;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(585, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(247, 50);
            this.button3.TabIndex = 12;
            this.button3.Text = "Send";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(233, 74);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(218, 29);
            this.textBox5.TabIndex = 11;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(233, 31);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(218, 29);
            this.textBox4.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label7.Location = new System.Drawing.Point(457, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "* - поле не обов\"язкове";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 24);
            this.label5.TabIndex = 1;
            this.label5.Text = "Телофон*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(170, 24);
            this.label4.TabIndex = 0;
            this.label4.Text = "Номер документа";
            // 
            // _tbCreateTTN
            // 
            this._tbCreateTTN.BackColor = System.Drawing.Color.Silver;
            this._tbCreateTTN.Controls.Add(this.button6);
            this._tbCreateTTN.Controls.Add(this.textBox12);
            this._tbCreateTTN.Controls.Add(this.pictureBox1);
            this._tbCreateTTN.Controls.Add(this.button8);
            this._tbCreateTTN.Controls.Add(this.GenTTN);
            this._tbCreateTTN.Location = new System.Drawing.Point(4, 33);
            this._tbCreateTTN.Name = "_tbCreateTTN";
            this._tbCreateTTN.Size = new System.Drawing.Size(1231, 590);
            this._tbCreateTTN.TabIndex = 2;
            this._tbCreateTTN.Text = "Створення ТТН";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(32, 177);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(488, 29);
            this.textBox12.TabIndex = 17;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(577, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(651, 584);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(32, 212);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(247, 50);
            this.button8.TabIndex = 15;
            this.button8.Text = "Print Document (PDF)";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.GetPdf_Click);
            // 
            // GenTTN
            // 
            this.GenTTN.Location = new System.Drawing.Point(32, 22);
            this.GenTTN.Name = "GenTTN";
            this.GenTTN.Size = new System.Drawing.Size(247, 50);
            this.GenTTN.TabIndex = 14;
            this.GenTTN.Text = "Generate TTN";
            this.GenTTN.UseVisualStyleBackColor = true;
            this.GenTTN.Click += new System.EventHandler(this.GenTTN_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button2.Location = new System.Drawing.Point(1259, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 29);
            this.button2.TabIndex = 1;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(32, 268);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(247, 50);
            this.button6.TabIndex = 18;
            this.button6.Text = "Print Marking (PDF)";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.GetMarking_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 670);
            this.Controls.Add(this.button2);
            this.Controls.Add(this._tcMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Робота з Новою Поштою";
            this._tcMain.ResumeLayout(false);
            this._tpAddress.ResumeLayout(false);
            this._tcAddress.ResumeLayout(false);
            this._tpCities.ResumeLayout(false);
            this._tpCities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this._tpAreas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            this._tpWarehouses.ResumeLayout(false);
            this._tpWarehouses.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            this._tpDocuments.ResumeLayout(false);
            this._tcDocuments.ResumeLayout(false);
            this._tpDocumentList.ResumeLayout(false);
            this._tpDocumentList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this._tpTracking.ResumeLayout(false);
            this._tpTracking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this._tbCreateTTN.ResumeLayout(false);
            this._tbCreateTTN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl _tcMain;
        private System.Windows.Forms.TabPage _tpAddress;
        private System.Windows.Forms.TabPage _tpDocuments;
        private System.Windows.Forms.TabControl _tcAddress;
        private System.Windows.Forms.TabPage _tpCities;
        private System.Windows.Forms.TabPage _tpAreas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _btSendCities;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TabControl _tcDocuments;
        private System.Windows.Forms.TabPage _tpDocumentList;
        private System.Windows.Forms.TabPage _tpTracking;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridView dataGridView4;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TabPage _tpWarehouses;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TabPage _tbCreateTTN;
        private System.Windows.Forms.Button GenTTN;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Button button6;
    }
}

