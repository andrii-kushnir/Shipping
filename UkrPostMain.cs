using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiUkrPost;
using ApiUkrPost.Adresses;
using ApiUkrPost.Base;
using PostAPI.UtilityClass;
using GemBox.Pdf;
using Newtonsoft.Json;
using Region = ApiUkrPost.Adresses.Region;

namespace PostAPI
{
    public partial class UkrPostMain : Form
    {
        private readonly User _user;
        private readonly Controller _controller;

        private static string _authorizationBearerTracking = "ec449353-4e4f-3b6c-877b-0b93e8d45601";

        private List<Region> _regions;
        private List<District> _districts;
        private List<City> _cities;
        private List<Street> _streets;
        private List<House> _houses;

        public AddressDto Address;
        public ClientDto Client;
        public ShipmentDto Shipment;
        public GroupDto Group;

        public UkrPostMain()
        {
            InitializeComponent();
        }

        public UkrPostMain(User user, string server = "") : this()
        {
            _user = user;
            _authorizationBearerTracking = "ec449353-4e4f-3b6c-877b-0b93e8d45601";
            if (server == "Test")
            {
                _controller = new Controller(_user.AuthorizationBearer, _user.UserToken, _authorizationBearerTracking, "Test");
            }
            else
            {
                _controller = new Controller(_user.AuthorizationBearer, _user.UserToken, _authorizationBearerTracking);
            }
        }

        private void _bLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _btGetIndex_Click(object sender, EventArgs e)
        {
            if (_cbDistrict.Text != "" && _cbCity.Text != "" && _cbStreet.Text != "" && _cbHouse.Text != "")
            {
                if (_tbPostCode.Text.Trim() != "" && int.TryParse(_tbPostCode.Text.Trim(), out int index) && index != 0)
                {
                    if (index == Convert.ToInt32(_houses[_cbHouse.SelectedIndex].POSTCODE))
                    {
                        Address = Controller.CreateAddress(index.ToString(),
                                                           _regions[_cbRegion.SelectedIndex].ToString(),
                                                           _districts[_cbDistrict.SelectedIndex].ToString(),
                                                           _cities[_cbCity.SelectedIndex].ToString(),
                                                           _streets[_cbStreet.SelectedIndex].ToString(),
                                                           _houses[_cbHouse.SelectedIndex].HOUSENUMBERUA,
                                                           _tbApartment.Text.Trim());
                    }
                    else
                    {
                        MessageBox.Show("Індекс і адреса не відповідають один онному!");
                        return;
                    }
                }
            }
            else
            {
                if (_tbPostCode.Text.Trim() != "" && int.TryParse(_tbPostCode.Text.Trim(), out int index) && index != 0)
                {
                    Address = Controller.CreateAddress(index.ToString(),
                                   _regions[_cbRegion.SelectedIndex].ToString(),
                                   _districts[_cbDistrict.SelectedIndex].ToString(),
                                   _cities[_cbCity.SelectedIndex].ToString());
                }
                else
                {
                    MessageBox.Show("Введіть індекс!");
                    return;
                }
            }

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

        private void _btGetAddress_Click(object sender, EventArgs e)
        {
            if (_tbPostCode.Text.Trim() != "" && int.TryParse(_tbPostCode.Text.Trim(), out int index) && index != 0)
            {
                var city = Controller.GetCityByPostcode(index);
                if (city == null) return;

                var region = _regions.FindIndex(r => r.REGIONUA == city.REGIONUA);
                _cbRegion.SelectedIndex = region;

                _districts = Controller.GetDistricts(Convert.ToInt64(_regions[region].REGIONID), city.DISTRICTUA);
                if (_districts == null || _districts.Count == 0) return;
                _cbDistrict.Items.Clear();
                _cbDistrict.Items.AddRange(_districts.Select(d => d.ToString()).ToArray());
                _cbDistrict.SelectedIndex = 0;

                _cities = Controller.GetCities(Convert.ToInt64(_regions[region].REGIONID), Convert.ToInt64(_districts[0].DISTRICTID), city.CITYUA);
                if (_cities == null || _cities.Count == 0) return;
                _cbCity.Items.Clear();
                _cbCity.Items.AddRange(_cities.Select(d => d.ToString()).ToArray());
                _cbCity.SelectedIndex = 0;

                _streets = Controller.GetStreets(Convert.ToInt64(_regions[region].REGIONID), Convert.ToInt64(_districts[0].DISTRICTID), Convert.ToInt64(_cities[0].CITYID), "");
                if (_streets == null || _streets.Count == 0) return;
                _cbStreet.Items.Clear();
                _cbStreet.Items.AddRange(_streets.Select(d => d.ToString()).ToArray());
                _cbStreet.Text = "";
                _cbHouse.Text = "";
                _tbApartment.Text = "";
            }
        }

        private void _cbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbRegion.SelectedIndex < 0)
                return;
            _cbDistrict.Items.Clear();
            _cbDistrict.Text = "";
            _cbCity.Text = "";
            _cbStreet.Text = "";
            _cbHouse.Text = "";
            _districts = Controller.GetDistricts(Convert.ToInt64(_regions[_cbRegion.SelectedIndex].REGIONID), "");
            _cbDistrict.Items.AddRange(_districts.Select(d => d.ToString()).ToArray());
        }

        private void _cbDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbDistrict.SelectedIndex < 0)
                return;
            _cbCity.Items.Clear();
            _cbCity.Text = "";
            _cbStreet.Text = "";
            _cbHouse.Text = "";
            _cities = Controller.GetCities(Convert.ToInt64(_regions[_cbRegion.SelectedIndex].REGIONID), Convert.ToInt64(_districts[_cbDistrict.SelectedIndex].DISTRICTID), "");
            _cbCity.Items.AddRange(_cities.Select(d => d.ToString()).ToArray());
        }

        private void _cbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbCity.SelectedIndex < 0)
                return;
            _cbStreet.Items.Clear();
            _cbStreet.Text = "";
            _cbHouse.Text = "";
            _streets = Controller.GetStreets(Convert.ToInt64(_regions[_cbRegion.SelectedIndex].REGIONID), Convert.ToInt64(_districts[_cbDistrict.SelectedIndex].DISTRICTID), Convert.ToInt64(_cities[_cbCity.SelectedIndex].CITYID), "");
            _cbStreet.Items.AddRange(_streets.Select(d => d.ToString()).ToArray());
        }

        private void _cbStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbStreet.SelectedIndex < 0)
                return;
            _cbHouse.Items.Clear();
            _cbHouse.Text = "";
            _houses = Controller.GetHouses(Convert.ToInt64(_streets[_cbStreet.SelectedIndex].STREETID), "");
            _cbHouse.Items.AddRange(_houses.Select(d => d.ToString()).ToArray());
        }
        private void _cbHouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbHouse.SelectedIndex < 0)
                return;
            _tbPostCode.Text = _houses[_cbHouse.SelectedIndex].POSTCODE;
        }

        private void _btCreateClient_Click(object sender, EventArgs e)
        {
            if (_tbFirstName.Text.Trim() != "" && _tbLastName.Text.Trim() != "" && _tbClientAddressId.Text != "" && _tbPhone.Text.Trim() != "" && _cbClientType.Text != "")
            {
                Client = Controller.CreateClient(_tbFirstName.Text.Trim(), _tbLastName.Text.Trim(), _tbMiddleName.Text.Trim(), Convert.ToInt64(_tbClientAddressId.Text), _tbPhone.Text.Trim(), (ClientIndivType)_cbClientType.SelectedIndex);
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
                Client = Controller.GetClient(_tbClienеIdChange.Text.Trim());
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
                double? postPay = null;
                if (_tbPostPay.Text.Trim() != "" && double.TryParse(_tbPostPay.Text.Trim(), out double pay) && pay != 0)
                {
                    postPay = pay;
                }

                Shipment = Controller.CreateShipment(_tbSender.Text.Trim(), 
                                                     _tbRecipient.Text.Trim(), 
                                                     (DeliveryType)_cbDeliveryType.SelectedIndex, 
                                                     (ShipmentType)_cbShipmentType.SelectedIndex,
                                                     _cbPaidByRecipient.SelectedIndex == 0 ? true : false,
                                                     _cbReview.Checked,
                                                     postPay,
                                                     postPay == null ? true : _cbPostPayPaidByRecipient.Checked,
                                                     weight, 
                                                     length, 
                                                     _tbWidth.Text.ParseNullableInt(), 
                                                     _tbHeight.Text.ParseNullableInt(), 
                                                     _tbDeclaredPrice.Text.ParseNullableInt(),
                                                     _rtbDescription.Text.Trim());
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
                Shipment = Controller.GetShipment(_tbShipmentUuid.Text.Trim());
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
                    _cbPaidByRecipient.SelectedIndex = Shipment.paidByRecipient ? 0 : 1;
                    _cbReview.Checked = Shipment.checkOnDelivery;
                    
                    if (Shipment.postPay != 0)
                    {
                        _tbPostPay.Text = Shipment.postPay.ToString();
                        _cbPostPayPaidByRecipient.Checked = Shipment.postPayPaidByRecipient;
                    }
                    else
                    {
                        _cbPostPayPaidByRecipient.Checked = true;
                    }
                    _tbWeight.Text = Shipment.parcels[0].weight.ToString();
                    _tbLength.Text = Shipment.parcels[0].length.ToString();
                    _tbDeclaredPrice.Text = Shipment.parcels[0].declaredPrice.ToString();
                    _rtbDescription.Text = Shipment.description;
                }
            }
        }

        private void _btClients_Click(object sender, EventArgs e)
        {
            if (_tbPhoneClient.Text.Trim() != "")
            {
                var clients = Controller.GetClients(_tbPhoneClient.Text.Trim());
                //Controller.GetClientsXml(_user.AuthorizationBearer, _user.UserToken, _tbPhoneClient.Text.Trim(), out string result);
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
                var shipments = Controller.GetShipmentBySender(_tbSenderAll.Text.Trim());
                //Controller.GetShipmentBySenderXml(_user.AuthorizationBearer, _user.UserToken, _tbSenderAll.Text.Trim(), out string result);
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

        private void _btShipmentDelete_Click(object sender, EventArgs e)
        {
            if (_tbShipmentDelete.Text.Trim() != "")
            {
                var shipments = Controller.GetShipment(_tbShipmentDelete.Text.Trim());
                if (shipments == null)
                {
                    MessageBox.Show("Відправлення не знайдено!");
                }
                else
                {
                    if (Controller.DeleteShipment(_tbShipmentDelete.Text.Trim()))
                    {
                        MessageBox.Show("Відправлення видалено!");
                    }
                    else
                    {
                        MessageBox.Show("Відправлення не видалено!");
                    }
                }
            }
        }

        private void _btGetSticker_Click(object sender, EventArgs e)
        {
            var fileNameJPG = Path.GetTempPath() + Guid.NewGuid().ToString() + ".jpg";

            var fileNamePDF = Controller.GetStickerFile(_tbShipmentUuid.Text.Trim());
            if (fileNamePDF == null) return;

            ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            using (PdfDocument document = PdfDocument.Load(fileNamePDF))
            {
                document.Save(fileNameJPG);
            }
            dataGridView1.Visible = false;
            pictureBox1.Visible = true;
            pictureBox1.Image = Image.FromFile(fileNameJPG);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void _btSaveFile_Click(object sender, EventArgs e)
        {
            var fileNamePDF = Controller.GetStickerFile(_tbShipmentUuid.Text.Trim());
            if (fileNamePDF != null)
            {
                var saveFileDialog = new SaveFileDialog() { Filter = "PDF-files|*.pdf" };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(fileNamePDF, saveFileDialog.FileName, true);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_tbAddressId.Text.Trim() != "" && long.TryParse(_tbAddressId.Text.Trim(), out long id) && id != 0)
            {
                Address = Controller.GetAddressByID(id);
                if (Address == null) return;

                var region = _regions.FindIndex(r => r.REGIONUA == Address.region);
                _cbRegion.SelectedIndex = region;

                _districts = Controller.GetDistricts(Convert.ToInt64(_regions[region].REGIONID), Address.district);
                if (_districts == null || _districts.Count == 0) return;
                _cbDistrict.Items.Clear();
                _cbDistrict.Items.AddRange(_districts.Select(d => d.ToString()).ToArray());
                _cbDistrict.SelectedIndex = 0;

                _cities = Controller.GetCities(Convert.ToInt64(_regions[region].REGIONID), Convert.ToInt64(_districts[0].DISTRICTID), Address.city);
                if (_cities == null || _cities.Count == 0) return;
                _cbCity.Items.Clear();
                _cbCity.Items.AddRange(_cities.Select(d => d.ToString()).ToArray());
                _cbCity.SelectedIndex = 0;

                _streets = Controller.GetStreets(Convert.ToInt64(_regions[region].REGIONID), Convert.ToInt64(_districts[0].DISTRICTID), Convert.ToInt64(_cities[0].CITYID), Address.street);
                if (_streets == null || _streets.Count == 0) return;
                _cbStreet.Items.Clear();
                _cbStreet.Items.AddRange(_streets.Select(d => d.ToString()).ToArray());
                _cbStreet.SelectedIndex = 0;

                _houses = Controller.GetHouses(Convert.ToInt64(_streets[0].STREETID), Address.houseNumber);
                if (_houses == null || _houses.Count == 0) return;
                _cbHouse.Items.Clear();
                _cbHouse.Items.AddRange(_houses.Select(d => d.ToString()).ToArray());
                _cbHouse.SelectedIndex = 0;

                _tbApartment.Text = Address.apartmentNumber;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_tbClientAddressId.Text != "" && _tbPhone.Text.Trim() != "")
            {
                Client = Controller.CreateClientArbitrary(Convert.ToInt64(_tbClientAddressId.Text), _tbPhone.Text.Trim());
            }
        }

        private void UkrPostMain_Load(object sender, EventArgs e)
        {
            _regions = Controller.GetRegions("");
            _cbRegion.Items.AddRange(_regions.Select(r => r.ToString()).ToArray());
            _cbRegion.SelectedIndex = 18;

            _cbClientType.Items.AddRange(Enum.GetValues(typeof(ClientIndivType)).Cast<ClientIndivType>().Select(c => c.ToString()).ToArray());
            _cbClientType.SelectedIndex = 0;

            _cbShipmentType.Items.AddRange(Enum.GetValues(typeof(ShipmentType)).Cast<ShipmentType>().Select(c => c.ToString()).ToArray());
            _cbShipmentType.SelectedIndex = 1;

            _cbDeliveryType.Items.AddRange(Enum.GetValues(typeof(DeliveryType)).Cast<DeliveryType>().Select(c => c.ToString()).ToArray());
            _cbDeliveryType.SelectedIndex = 0;

            _cbPaidByRecipient.Items.AddRange(new string[] { "Платить одержувач", "Платить відправник" });
            _cbPaidByRecipient.SelectedIndex = 0;

            _cbPostPayPaidByRecipient.Checked = true;
        }

        private void _tbPostCode_Leave(object sender, EventArgs e)
        {
            if (_tbPostCode.Text.Trim() != "" && int.TryParse(_tbPostCode.Text.Trim(), out int index) && index != 0)
            {
                var city = Controller.GetCityByPostcode(index);
                if (city == null)
                {
                    _tbPostCode.Text = "";
                    _cbDistrict.Items.Clear();
                    _cbDistrict.Text = "";
                    _cbCity.Text = "";
                    _cbStreet.Text = "";
                    _cbHouse.Text = "";
                    _tbApartment.Text = "";
                    MessageBox.Show("Такий індекс не знайдений!");
                }
                else
                {
                    var region = _regions.FindIndex(r => r.REGIONUA == city.REGIONUA);
                    _cbRegion.SelectedIndex = region;

                    _districts = Controller.GetDistricts(Convert.ToInt64(_regions[region].REGIONID), city.DISTRICTUA);
                    if (_districts == null || _districts.Count == 0) return;
                    _cbDistrict.Items.Clear();
                    _cbDistrict.Items.AddRange(_districts.Select(d => d.ToString()).ToArray());
                    _cbDistrict.SelectedIndex = 0;

                    _cities = Controller.GetCities(Convert.ToInt64(_regions[region].REGIONID), Convert.ToInt64(_districts[0].DISTRICTID), city.CITYUA);
                    if (_cities == null || _cities.Count == 0) return;
                    _cbCity.Items.Clear();
                    _cbCity.Items.AddRange(_cities.Select(d => d.ToString()).ToArray());
                    _cbCity.SelectedIndex = 0;

                    _streets = Controller.GetStreets(Convert.ToInt64(_regions[region].REGIONID), Convert.ToInt64(_districts[0].DISTRICTID), Convert.ToInt64(_cities[0].CITYID), "");
                    if (_streets == null || _streets.Count == 0) return;
                    _cbStreet.Items.Clear();
                    _cbStreet.Items.AddRange(_streets.Select(d => d.ToString()).ToArray());
                    _cbStreet.Text = "";
                    _cbHouse.Text = "";
                    _tbApartment.Text = "";
                }
            }
        }

        private void _btStatuses_Click(object sender, EventArgs e)
        {
            if (_tbShipmentUuid.Text.Trim() != "")
            {
                Shipment = Controller.GetShipment(_tbShipmentUuid.Text.Trim());
                if (Shipment == null)
                {
                    MessageBox.Show("Відправлення не знайдено!");
                }
                else
                {
                    var Statuses = Controller.GetStatuses(Shipment.barcode);
                    //Controller.GetStatusesXml("ec449353-4e4f-3b6c-877b-0b93e8d45601", "1111111111111", out string result);
                    if (Statuses != null && Statuses.Count != 0)
                    {
                        pictureBox1.Visible = false;
                        dataGridView1.Visible = true;
                        dataGridView1.DataSource = Statuses;
                        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    }
                    else
                    {
                        MessageBox.Show("Відправлення не трекається. Ймовірно воно ще не відправлене.");
                    }
                }
            }
        }

        private void _btPostpay_Click(object sender, EventArgs e)
        {
            if (_tbShipmentUuid.Text.Trim() != "")
            {
                Shipment = Controller.GetShipment(_tbShipmentUuid.Text.Trim());
                if (Shipment == null)
                {
                    MessageBox.Show("Відправлення не знайдено!");
                }
                else
                {
                    var Postpay = Controller.GetPostpay(Shipment.barcode);
                    if (Postpay != null && Postpay.lastStatus != null)
                    {
                        MessageBox.Show($"Статус {Postpay.lastStatus}. {Postpay.lastStatusNameUa}. Дата {Postpay.lastStatusTime}.");
                    }
                    else
                    {
                        MessageBox.Show("Післяоплата не знайдена. Або післяоплата відсутня або відправлення ще не отримане.");
                    }
                }
            }
        }

        private void _btCreateGroup_Click(object sender, EventArgs e)
        {
            //var ggg = Controller.GetShipmentByGroup("6281b7f8-cc8f-43c1-a2fe-fef840d5e22f");
            if (_tbGroupName.Text.Trim() != "")
            {
                Group = Controller.CreateGroup(_tbGroupName.Text.Trim(), ShipmentType.STANDARD);
                if (Group != null)
                    _tbGroupUuid.Text = Group.uuid;
            }
        }

        private void _btToGroup_Click(object sender, EventArgs e)
        {
            if (_tbGroupUuid.Text.Trim() != "" && _tbShipmentUuid.Text.Trim() != "")
            {
                var result = Controller.AddShipmentToGroup(_tbGroupUuid.Text.Trim(), _tbShipmentUuid.Text.Trim());
                MessageBox.Show(result.message);
            }
        }

        private void _btGetShipments_Click(object sender, EventArgs e)
        {
            if (_tbGroupUuid.Text.Trim() != "")
            {
                var list = Controller.GetShipmentByGroup(_tbGroupUuid.Text.Trim());
                if (list != null)
                {
                    _dgvShipmentsInGroup.DataSource = list.OrderBy(s => s.lastModified).ToList();
                    _dgvShipmentsInGroup.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
        }

        private void _btToGroup1_Click(object sender, EventArgs e)
        {
            if (_tbGroupUuid.Text.Trim() != "" && _tbShipmentGroupUuid.Text.Trim() != "")
            {
                var result = Controller.AddShipmentToGroup(_tbGroupUuid.Text.Trim(), _tbShipmentGroupUuid.Text.Trim());
                MessageBox.Show(result.message);
            }
        }

        private void _btGetForma103_Click(object sender, EventArgs e)
        {
            if (_tbGroupUuid.Text.Trim() != "")
            {
                var file = Controller.GetForm103(_tbGroupUuid.Text.Trim());
            }
        }
    }
}
