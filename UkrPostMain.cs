using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiUkrPost;
using Newtonsoft.Json;

namespace NovaPost
{
    public partial class UkrPostMain : Form
    {
        private readonly User _user;
        private readonly Controller _controller;
        private readonly int message_long = 800;
        public UkrPostMain()
        {
            InitializeComponent();
            var ggg = _controller.GetRegions("");
            comboBox1.Items.AddRange(_controller.GetRegions("").ToArray());

        }

        public UkrPostMain(User user) : this()
        {
            _user = user;
            _controller = new Controller(_user.ApiKeyNovaPost, "b3d460fb-32a7-4dfe-81e6-8670b5e47a48");
        }

        private void _bLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //var rrrr = _controller.CreateAddress("07401", "Київська", "Київський", "Бровари", "Котляревського", "37", "119");
            //var dddd = _controller.GetAddressByID(3362077);

            var ggg = _controller.GetRegions("Тернопіль");
            var hhh = _controller.GetDistricts(19, "Бережанський");
            var kkk = _controller.GetCities(19, 997, "Тернопіль");
            var lll = _controller.GetStreets(19, 997, 10761, "15");
            var ttt = _controller.GetHouses(51454, "");
            var uuu = _controller.GetPostoffices(10761);
        }
    }
}
