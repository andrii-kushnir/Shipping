using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ApiDelivery;
using ApiDelivery.Requests;
using ApiDelivery.Responses;
using PostAPI.UtilityClass;
using Region = ApiDelivery.Responses.Region;

namespace PostAPI
{
    public partial class DeliveryMain : Form
    {
        private readonly User _user;
        private readonly Controller _controller;

        private List<Region> _regions;
        private List<Area> _areas1;
        private List<Warehouse> _warehouses1;
        private List<Area> _areas2;
        private List<Warehouse> _warehouses2;
        private List<Tariff> _tariff;
        private List<Sender> _senders;
        private Sender _sender;

        private readonly string[] _payer = { "Відправник(ми)", "Отримувач" };
        private readonly string[] _payerInsurance = { "Відправник(ми)", "Отримувач" };
        private readonly string[] _paymentType = { "Готівка", "Безгтівка" };

        private List<Cargo> _cargoList = new List<Cargo>();
        private BindingSource _cargoSource = new BindingSource() { AllowNew = false };

        public DeliveryMain()
        {
            InitializeComponent();
        }

        public DeliveryMain(User user) : this()
        {
            _user = user;
            _controller = new Controller(_user.DapiKey, _user.DapiSecretKey);
        }

        private void DeliveryMain_Load(object sender, EventArgs e)
        {
            _senders = Controller.GetSenderList();
            _sender = _senders[0];

            _cargoSource.DataSource = _cargoList;
            _dgvCategory.DataSource = _cargoSource;
            _dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            _regions = Controller.GetRegionList();
            _cbRegion1.Items.AddRange(_regions.Select(r => r.ToString()).ToArray());
            _cbRegion1.SelectedIndex = 21;
            _cbArea1.SelectedIndex = 8;
            _cbWarehouse1.SelectedIndex = 1;
            _cbRegion2.Items.AddRange(_regions.Select(r => r.ToString()).ToArray());

            _cbDeliveryType.Items.AddRange(Enum.GetValues(typeof(DeliveryType)).Cast<DeliveryType>().Select(c => c.ToString()).ToArray());
            _cbDeliveryType.SelectedIndex = 0;

            _cbPayerInsurance.Items.AddRange(_payerInsurance);
            _cbPayerInsurance.SelectedIndex = 0;

            _cbPayer.Items.AddRange(_payer);
            _cbPayer.SelectedIndex = 0;

            _cbPaymentType.Items.AddRange(_paymentType);
            _cbPaymentType.SelectedIndex = 0;

            _cbPaymentTypeInsuranse.Items.AddRange(_paymentType);
            _cbPaymentTypeInsuranse.SelectedIndex = 0;
        }

        private void BLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbRegion1.SelectedIndex < 0)
                return;
            _cbArea1.Text = "";
            _cbWarehouse1.Text = "";
            _cbArea1.Items.Clear();
            _areas1 = Controller.GetAreasList(_regions[_cbRegion1.SelectedIndex].id);
            _cbArea1.Items.AddRange(_areas1.Select(d => d.ToString()).ToArray());
        }

        private void CbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbArea1.SelectedIndex < 0)
                return;
            _cbWarehouse1.Items.Clear();
            _cbWarehouse1.Text = "";
            _warehouses1 = Controller.GetWarehousesList(_regions[_cbRegion1.SelectedIndex].externalId, _areas1[_cbArea1.SelectedIndex].id);
            _cbWarehouse1.Items.AddRange(_warehouses1.Select(d => d.ToString()).ToArray());
        }

        private void CbRegion2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbRegion2.SelectedIndex < 0)
                return;
            _cbArea2.Text = "";
            _cbWarehouse2.Text = "";
            _cbArea2.Items.Clear();
            _areas2 = Controller.GetAreasList(_regions[_cbRegion2.SelectedIndex].id);
            _cbArea2.Items.AddRange(_areas2.Select(d => d.ToString()).ToArray());
        }

        private void CbArea2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbArea2.SelectedIndex < 0)
                return;
            _cbWarehouse2.Items.Clear();
            _cbWarehouse2.Text = "";
            _warehouses2 = Controller.GetWarehousesList(_regions[_cbRegion2.SelectedIndex].externalId, _areas2[_cbArea2.SelectedIndex].id);
            _cbWarehouse2.Items.AddRange(_warehouses2.Select(d => d.ToString()).ToArray());
        }

        private void _btCreateShipment_Click(object sender, EventArgs e)
        {
            if (_cbArea1.SelectedIndex < 0 || _cbWarehouse1.SelectedIndex < 0 || _cbArea2.SelectedIndex < 0 || _cbWarehouse2.SelectedIndex < 0)
            {
                MessageBox.Show("Виберіть звідки і куди доставляти");
                return;
            }
            if (_tbInsuranceValue.Text.ParseInt() == 0)
            {
                MessageBox.Show("Введіть коректні дані");
                return;
            }
            //var invoices = Controller.GetClientInvoices();                            // temp!!!!!!
            //var recivers = Controller.GetPosibleReciver(_sender.cityId, _sender.id);  // temp!!!!!!

            var client = Controller.CreateClient(_tbFirstName.Text.Trim(), _tbLastName.Text.Trim(), _tbMiddleName.Text.Trim(), _tbPhone.Text.Trim(), _areas2[_cbArea2.SelectedIndex].id, "15-Квітня", "37", "115", _sender.id);
            var receipt = new CreateReceipts()
            {
                culture = "uk-UA",
                flSave = "true",
                debugMode = "false",
                receiptsList = new List<ReceiptsList>
                {
                    new ReceiptsList
                    {
                        areasSendId = _sender.cityId,                                    // буде братись з БД
                        warehouseSendId = _warehouses1[_cbWarehouse1.SelectedIndex].id,  // буде братись з БД
                        areasResiveId = _areas2[_cbArea2.SelectedIndex].id,
                        warehouseResiveId = _warehouses2[_cbWarehouse2.SelectedIndex].id,
                        deliveryScheme = _cbDeliveryType.SelectedIndex,
                        senderId = _sender.id,                                           // буде братись з БД
                        receiverName = client.account.Name,
                        receiverPhone = client.account.PhoneNumber,
                        receiverType = false,
                        payerType = _cbPayer.SelectedIndex,
                        paymentType = _cbPaymentType.SelectedIndex,
                        dateSend = DateTime.Now,
                        currency = 100000000,
                        InsuranceValue = _tbInsuranceValue.Text.ParseInt(),
                        payerInsuranceId = _cbPayerInsurance.SelectedIndex == 0 ? _sender.id : client.account.AccountId,
                        paymentTypeInsuranse = _cbPaymentTypeInsuranse.SelectedIndex, 
                        deliveryContactName = client.account.Name,
                        deliveryContactPhone = client.account.PhoneNumber,
                        DeliveryComment = _rtbDescription.Text.Trim(),
                        ReturnDocuments = false,
                        climbingToFloor = 0,
                        EconomDelivery = true,
                        //cashOnDeliveryType = 2,                      //?????
                        //CashOnDeliveryValuta = 100000000,
                        //CashOnDeliveryValue = 0,                     // ввести
                        //CashOnDeliveryWarehouseId = _warehouses1[_cbWarehouse1.SelectedIndex].id,  // буде братись з таблиці
                        //CashOnDeliveryPayerAccountId = "",           //?????
                        //CashOnDeliverySenderFullName = "",           //?????
                        //CashOnDeliverySenderPhone = "",              //?????
                        //CashOnDeliveryReceiverFullName = "",         //?????
                        //CashOnDeliveryReceiverPhone = "",            //?????
                        //CashOnDeliveryDescription = "описание наложки",
                        descentFromFloor = 0,
                        category = _cargoList
                    }
                }
            };
            var result = Controller.PostCreateReceipts(receipt);
        }

        private void _btAddCargo_Click(object sender, EventArgs e)
        {
            if (_cbWarehouse1.SelectedIndex < 0 || _cbWarehouse2.SelectedIndex < 0)
            {
                MessageBox.Show("Введіть відділення доставки!");
                return;
            }
            _tariff = Controller.GetTariffCategory(_areas1[_cbArea1.SelectedIndex].id, _areas2[_cbArea2.SelectedIndex].id, _warehouses2[_cbWarehouse2.SelectedIndex].id);
            using (var deliveryCargo = new DeliveryCargo(_tariff))
            {
                deliveryCargo.ShowDialog();
                if (deliveryCargo.cargo != null)
                {
                    _cargoList.Add(deliveryCargo.cargo);
                    ((BindingSource)_dgvCategory.DataSource).ResetBindings(false);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var fff = Controller.GetClientPaymentType(_sender.id);
            var ddd = Controller.GetPayer(_areas1[_cbArea1.SelectedIndex].id, _areas2[_cbArea2.SelectedIndex].id, _sender.id);
            var ggg = Controller.GetClientCards();
        }
    }
}
