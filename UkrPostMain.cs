using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiUkrPost;
using ApiUkrPost.Adresses;
using Newtonsoft.Json;

namespace PostAPI
{
    public partial class UkrPostMain : Form
    {
        private readonly User _user;
        private readonly Controller _controller;
        private readonly int message_long = 800;

        private List<Region> _regions;
        private List<District> _districts;
        private List<City> _cities;
        private List<Street> _streets;
        private List<House> _houses;
        public UkrPostMain()
        {
            InitializeComponent();
        }

        public UkrPostMain(User user) : this()
        {
            _user = user;
            _controller = new Controller(_user.AuthorizationBearer,_user.UserToken);

            _regions = _controller.GetRegions("");
            _cbRegion.Items.AddRange(_regions.Select(r => r.ToString()).ToArray());
            _cbRegion.SelectedIndex = 18;
        }

        private void _bLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _btGetIndex_Click(object sender, EventArgs e)
        {
            if (_cbDistrict.Text != "" && _cbCity.Text != "" && _cbStreet.Text != "" && _cbHouse.Text != "")
            {
                _tbPostCode.Text = _houses[_cbHouse.SelectedIndex].POSTCODE;
            }
        }

        private void _btGetAddress_Click(object sender, EventArgs e)
        {
            if (_tbPostCode.Text.Trim() != "" && int.TryParse(_tbPostCode.Text.Trim(), out int index) && index != 0)
            {
                var city = _controller.GetCityByPostcode(index);
                if (city != null)
                {
                    _cbDistrict.Text = city.DISTRICTUA;
                    _cbRegion.Text = city.REGIONUA;
                    _cbCity.Text = city.CITYUA;
                    return;
                }
            }
        }

        private void _cbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cbDistrict.Items.Clear();
            _cbDistrict.Text = "";
            _cbCity.Text = "";
            _cbStreet.Text = "";
            _cbHouse.Text = "";
            _districts = _controller.GetDistricts(Convert.ToInt64(_regions[_cbRegion.SelectedIndex].REGIONID), "");
            _cbDistrict.Items.AddRange(_districts.Select(d => d.ToString()).ToArray());
        }

        private void _cbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cbCity.Items.Clear();
            _cbCity.Text = "";
            _cbStreet.Text = "";
            _cbHouse.Text = "";
            _cities = _controller.GetCities(Convert.ToInt64(_regions[_cbRegion.SelectedIndex].REGIONID), Convert.ToInt64(_districts[_cbDistrict.SelectedIndex].DISTRICTID), "");
            _cbCity.Items.AddRange(_cities.Select(d => d.ToString()).ToArray());
        }

        private void _cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cbStreet.Items.Clear();
            _cbStreet.Text = "";
            _cbHouse.Text = "";
            _streets = _controller.GetStreets(Convert.ToInt64(_regions[_cbRegion.SelectedIndex].REGIONID), Convert.ToInt64(_districts[_cbDistrict.SelectedIndex].DISTRICTID), Convert.ToInt64(_cities[_cbCity.SelectedIndex].CITYID), "");
            _cbStreet.Items.AddRange(_streets.Select(d => d.ToString()).ToArray());
        }

        private void _cbStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cbHouse.Items.Clear();
            _cbHouse.Text = "";
            _houses = _controller.GetHouses(Convert.ToInt64(_streets[_cbStreet.SelectedIndex].STREETID), "");
            _cbHouse.Items.AddRange(_houses.Select(d => d.ToString()).ToArray());
        }
    }
}
