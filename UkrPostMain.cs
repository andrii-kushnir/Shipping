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
using ApiUkrPost.Base;
using Newtonsoft.Json;

namespace PostAPI
{
    public partial class UkrPostMain : Form
    {
        private readonly User _user;
        private readonly Controller _controller;
        //private readonly int message_long = 800;

        private const string SenderAddress = "188358418";
        private const string SenderUuid = "1bd2e07e-52a6-4eda-bd48-60624153d5d8";
        private const string AddressMy = "188510591";
        private const string UuidMy = "d13743c3-1803-4e6f-b48a-535e997494fa";

        private List<Region> _regions;
        private List<District> _districts;
        private List<City> _cities;
        private List<Street> _streets;
        private List<House> _houses;

        public AddressDto Address;
        public ClientDto Client;
        public ShipmentDto Shipment;

        public UkrPostMain()
        {
            InitializeComponent();
        }

        public UkrPostMain(User user, string server = "") : this()
        {
            _user = user;
            if (server == "Test")
            {
                _controller = new Controller(_user.AuthorizationBearer, _user.UserToken, "Test");
            }
            else
            {
                _controller = new Controller(_user.AuthorizationBearer, _user.UserToken);
            }
            _regions = _controller.GetRegions("");
            _cbRegion.Items.AddRange(_regions.Select(r => r.ToString()).ToArray());
            _cbRegion.SelectedIndex = 18;

            _cbClientType.Items.AddRange(Enum.GetValues(typeof(ClientIndivType)).Cast<ClientIndivType>().Select(c => c.ToString()).ToArray());
            _cbClientType.SelectedIndex = 0;

            _cbShipmentType.Items.AddRange(Enum.GetValues(typeof(ShipmentType)).Cast<ShipmentType>().Select(c => c.ToString()).ToArray());
            _cbShipmentType.SelectedIndex = 1;

            _cbDeliveryType.Items.AddRange(Enum.GetValues(typeof(DeliveryType)).Cast<DeliveryType>().Select(c => c.ToString()).ToArray());
            _cbDeliveryType.SelectedIndex = 0;

            _tbSender.Text = SenderUuid;
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

                Address = _controller.CreateAddress(_houses[_cbHouse.SelectedIndex].POSTCODE,
                                                          _regions[_cbRegion.SelectedIndex].ToString(),
                                                          _districts[_cbDistrict.SelectedIndex].ToString(),
                                                          _cities[_cbCity.SelectedIndex].ToString(),
                                                          _streets[_cbStreet.SelectedIndex].ToString(),
                                                          _houses[_cbHouse.SelectedIndex].HOUSENUMBERUA,
                                                          _tbApartment.Text.Trim());
                if (Address != null)
                {
                    _tbAddressId.Text = Address.id.ToString();
                    _tbClientAddressId.Text = Address.id.ToString();
                }
                else
                {
                    _tbAddressId.Text = "Не створено";
                }
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

        private void _btCreateClient_Click(object sender, EventArgs e)
        {
            if (_tbFirstName.Text.Trim() != "" && _tbLastName.Text.Trim() != "" && _tbClientAddressId.Text != "" && _tbPhone.Text.Trim() != "" && _cbClientType.Text != "")
            {
                Client = _controller.CreateClient(_tbFirstName.Text.Trim(), _tbLastName.Text.Trim(), _tbMiddleName.Text.Trim(), Convert.ToInt64(_tbClientAddressId.Text), _tbPhone.Text.Trim(), (ClientIndivType)_cbClientType.SelectedIndex);
                if (Client != null)
                {
                    _tbClientId.Text = Client.uuid.ToString();
                    _tbRecipient.Text = Client.uuid.ToString();
                }
                else
                {
                    _tbClientId.Text = "Не створено";
                }
            }
        }

        private void _btClientChange_Click(object sender, EventArgs e)
        {
            if (_tbClienеIdChange.Text.Trim() != "" && _tbFirstName.Text.Trim() != "" && _tbLastName.Text.Trim() != "" && _tbClientAddressId.Text != "" && _tbPhone.Text.Trim() != "" && _cbClientType.Text != "")
            {
                Client = _controller.ChangeClient(_tbClienеIdChange.Text.Trim(), _tbFirstName.Text.Trim(), _tbLastName.Text.Trim(), _tbMiddleName.Text.Trim(), Convert.ToInt64(_tbClientAddressId.Text), _tbPhone.Text.Trim(), (ClientIndivType)_cbClientType.SelectedIndex);
                if (Client == null)
                {
                    MessageBox.Show("Дані клієнта не змінені");
                }
                else
                {
                    MessageBox.Show("Дані клієнта змінені!!!");
                }
            }
        }

        private void _btGetClient_Click(object sender, EventArgs e)
        {
            if (_tbClienеIdChange.Text.Trim() != "")
            {
                Client = _controller.GetClient(_tbClienеIdChange.Text.Trim());
                if (Client == null)
                {
                    MessageBox.Show("Клієнта не знайдено!");
                }
                else
                {
                    _tbFirstName.Text = Client.firstName;
                    _tbLastName.Text = Client.lastName;
                    _tbMiddleName.Text = Client.middleName;
                    _tbClientAddressId.Text = Client.addressId.ToString();
                    _tbPhone.Text = Client.phoneNumber;
                    _cbClientType.Text = Client.type.ToString();
                }
            }
        }

        private void _btCreateShipment_Click(object sender, EventArgs e)
        {
            if (_tbSender.Text.Trim() != "" && _tbRecipient.Text.Trim() != "" && _cbShipmentType.Text != "" && _cbDeliveryType.Text != "" && int.TryParse(_tbWeight.Text.Trim(), out int weight) && int.TryParse(_tbLength.Text.Trim(), out int length))
            {
                // ДОРОБИТИ!!!!!!!!!!!!!!
                Shipment = _controller.CreateShipment(_tbSender.Text.Trim(), _tbRecipient.Text.Trim(), (DeliveryType)_cbDeliveryType.SelectedIndex, (ShipmentType)_cbShipmentType.SelectedIndex, weight, length, Convert.ToInt32(_tbWidth.Text), Convert.ToInt32(_tbHeight.Text), Convert.ToInt32(_tbDeclaredPrice.Text), "Test!! Test");
                if (Shipment == null)
                {
                    MessageBox.Show("Відправлення не створено!");
                }
                else
                {
                    _tbShipmentUuid.Text = Shipment.uuid.ToString();
                }
            }
        }

        private void _btGetShipment_Click(object sender, EventArgs e)
        {
            if (_tbShipmentUuid.Text.Trim() != "")
            {
                Shipment = _controller.GetShipment(_tbShipmentUuid.Text.Trim());
                if (Shipment == null)
                {
                    MessageBox.Show("Відправлення не знайдено!");
                }
                else
                {
                    _tbSender.Text = Shipment.sender.uuid.ToString();
                    _tbRecipient.Text = Shipment.recipient.uuid.ToString();
                    _cbShipmentType.Text = Shipment.type.ToString();
                    _cbDeliveryType.Text = Shipment.deliveryType.ToString();
                    _tbWeight.Text = Shipment.parcels[0].weight.ToString();
                    _tbLength.Text = Shipment.parcels[0].length.ToString();
                }
            }
        }

        private void _btClients_Click(object sender, EventArgs e)
        {
            if (_tbPhoneClient.Text.Trim() != "")
            {
                var clients = _controller.GetClients(_tbPhoneClient.Text.Trim());
                if (clients == null)
                {
                    MessageBox.Show("Клієнтів не знайдено!");
                }
                else
                {
                    _dgvClients.DataSource = clients;
                    _dgvClients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }

        private void _btGetShipmentBySender_Click(object sender, EventArgs e)
        {
            if (_tbSenderAll.Text.Trim() != "")
            {
                var shipments = _controller.GetShipmentBySender(_tbSenderAll.Text.Trim());
                if (shipments == null)
                {
                    MessageBox.Show("Відправлення не знайдено!");
                }
                else
                {
                    _dgvShipments.DataSource = shipments.OrderBy(s => s.lastModified).ToList();
                    _dgvShipments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }
    }
}
