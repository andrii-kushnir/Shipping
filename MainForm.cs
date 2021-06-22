using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Api;
using Documents = Api.Requests.Documents;
using GemBox.Pdf;


namespace NovaPost
{
    public partial class MainForm : Form
    {
        private readonly User _user;
        private readonly Controller _controller;
        private readonly int message_long = 800;
        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(User user) : this()
        {
            _user = user;
            _controller = new Controller(_user.ApiKey);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int page;
            try
            {
                page = Int32.Parse(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Сторінка - введіть число");
                return;
            }

            var result = _controller.SendAddressCities(textBox1.Text.Trim(), page, textBox3.Text.Trim());

            if (!result.Success)
            {
                if (result.Message.Length < message_long) MessageBox.Show(result.Message);
                return;
            }
            dataGridView1.DataSource = result.Response.data;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //var info = JsonConvert.DeserializeObject<Info>(response.info.ToString());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var documents = new List<Documents>
            {
                new Documents { DocumentNumber = textBox4.Text.Trim(), Phone = textBox5.Text.Trim()}
            };

            var result = _controller.TrackingDocumentStatusDocuments(documents);

            if (!result.Success)
            {
                if (result.Message.Length < message_long) MessageBox.Show(result.Message);
                return;
            }

            dataGridView2.DataSource = result.Response.data;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //var warning = result.Response.warnings[0].ID_20400048799000;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DateTime? dateFrom = null, dateTo = null, dateTime = null;
            if (textBox6.Text.Trim() != "")
            {
                try
                {
                    dateFrom = DateTime.Parse(textBox6.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Не корректна 'Дата з'");
                    return;
                }
            }

            if (textBox7.Text.Trim() != "")
            {
                try
                {
                    dateTo = DateTime.Parse(textBox7.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Не корректна 'Дата по'");
                    return;
                }
            }

            string page = null, getFullList = null;
            if (textBox8.Text.Trim() != "")
            {
                try
                {
                    page = Int32.Parse(textBox8.Text).ToString();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Сторінка - введіть число");
                    return;
                }
            }
            if (checkBox1.Checked)
            {
                getFullList = "1";
            }

            if (textBox9.Text.Trim() != "")
            {
                try
                {
                    dateTime = DateTime.Parse(textBox9.Text.Trim());
                }
                catch (FormatException)
                {
                    MessageBox.Show("Не корректна 'Конкретна дата'");
                    return;
                }
            }

            var result = _controller.SendInternetDocumentDocumentList(dateFrom, dateTo, page, getFullList, dateTime);

            if (!result.Success)
            {
                if (result.Message.Length < message_long) MessageBox.Show(result.Message);
                return;
            }

            dataGridView3.DataSource = result.Response.data;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = _controller.SendAddressAreas();
            if (!result.Success)
            {
                if (result.Message.Length < message_long) MessageBox.Show(result.Message);
                return;
            }

            dataGridView4.DataSource = result.Response.data;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var result = _controller.SendAddressWarehouses(textBox10.Text.Trim());
            if (!result.Success)
            {
                if (result.Message.Length < message_long) MessageBox.Show(result.Message);
                return;
            }

            dataGridView5.DataSource = result.Response.data;
            dataGridView5.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox11.Text.Trim() != "")
            {
                var result = _controller.SendInternetDocumentDelete(textBox11.Text.Trim());
                if (!result.Success)
                {
                    if (result.Message.Length < message_long) MessageBox.Show(result.Message);
                    return;
                }
                MessageBox.Show("Видалено успішно: " + result.Response.data.First().Ref);
            }
        }

        private void GenTTN_Click(object sender, EventArgs e)
        {
            var result = _controller.SendInternetDocumentSave();
            if (!result.Success)
            {
                if (result.Message.Length < message_long) MessageBox.Show(result.Message);
                return;
            }
            var ttt = result.Response;
        }

        private void GetPdf_Click(object sender, EventArgs e)
        {
            //_controller.PrintMarking(textBox12.Text.Trim());

            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            using (PdfDocument document = PdfDocument.Load(@"c:\temp\111.pdf"))
            {
                document.Save(@"c:\temp\111.jpg");
            }
            pictureBox1.Image = Image.FromFile(@"c:\temp\111.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
