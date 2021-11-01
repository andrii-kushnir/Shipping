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
using Region = ApiDelivery.Responses.Region;

namespace PostAPI
{
    public partial class DeliveryMain : Form
    {
        private readonly User _user;
        private readonly Controller _controller;

        private List<Region> _regions;
        private List<Area> _areas;
        private List<Warehouse> _warehouses;
        private List<Area> _areas2;
        private List<Warehouse> _warehouses2;
        private List<Tariff> _tariff;
        private List<Sender> _senders;
        private List<Reciver> _reciver;

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

            _cargoSource.DataSource = _cargoList;
            _dgvCategory.DataSource = _cargoSource;
            _dgvCategory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            _regions = Controller.GetRegionList();
            _cbRegion.Items.AddRange(_regions.Select(r => r.ToString()).ToArray());
            _cbRegion2.Items.AddRange(_regions.Select(r => r.ToString()).ToArray());

            _cbDeliveryType.Items.AddRange(Enum.GetValues(typeof(DeliveryType)).Cast<DeliveryType>().Select(c => c.ToString()).ToArray());
            _cbDeliveryType.SelectedIndex = 0;

        }

        private void BLogOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbRegion.SelectedIndex < 0)
                return;
            _cbArea.Text = "";
            _cbWarehouse.Text = "";
            _cbArea.Items.Clear();
            _areas = Controller.GetAreasList(_regions[_cbRegion.SelectedIndex].id);
            _cbArea.Items.AddRange(_areas.Select(d => d.ToString()).ToArray());
        }

        private void CbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cbArea.SelectedIndex < 0)
                return;
            _cbWarehouse.Items.Clear();
            _cbWarehouse.Text = "";
            _warehouses = Controller.GetWarehousesList(_regions[_cbRegion.SelectedIndex].externalId, _areas[_cbArea.SelectedIndex].id);
            _cbWarehouse.Items.AddRange(_warehouses.Select(d => d.ToString()).ToArray());
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

        private void Button1_Click(object sender, EventArgs e)
        {
            _regions = Controller.GetRegionList();
            _cbRegion.Items.AddRange(_regions.Select(r => r.ToString()).ToArray());
        }

        private void _btCreateShipment_Click(object sender, EventArgs e)
        {
            var invoices = Controller.GetClientInvoices(); // temp!!!!!!
            var client = Controller.CreateClient("Андрій", "Кушнір", "Батькович", "0681234567", _areas2[_cbArea2.SelectedIndex].id, "15-Квітня", "37", "112", _senders[0].id);
            return;


            _reciver = Controller.GetPosibleReciver(_senders[0].cityId, _senders[0].id);
            var receipt = new CreateReceipts()
            {
                culture = "uk-UA",
                flSave = "false",
                debugMode = "true",
                receiptsList = new List<ReceiptsList>
                {
                    new ReceiptsList
                    {
                        senderId = _senders[0].id,             // буде братись з таблиці
                        areasSendId = _senders[0].cityId,      // буде братись з таблиці
                        warehouseSendId = _warehouses[_cbWarehouse.SelectedIndex].id,  // буде братись з таблиці
                        areasResiveId = _areas2[_cbArea2.SelectedIndex].id,
                        warehouseResiveId = _warehouses2[_cbWarehouse2.SelectedIndex].id,
                        dateSend = DateTime.Now,
                        deliveryScheme = 0,
                        receiverName = _tbName.Text.Trim(),
                        receiverPhone = _tbPhone.Text.Trim(),
                        receiverType = false,
                        currency = 100000000,
                        InsuranceValue = 500,                  // ввести
                        payerInsuranceId = "",                 //не знаю
                        payerId = null,
                        payerType = 1,                         // ввести
                        paymentType = 0,                       //не знаю
                        paymentTypeInsuranse = 0,              //не знаю
                        deliveryAddress = "",                  // ввести //???????
                        deliveryContactName = "Тест Тест Тестович",  //?????
                        deliveryContactPhone = "0689559241",         //????? 
                        DeliveryComment = _rtbDescription.Text.Trim(),
                        ReturnDocuments = false,
                        climbingToFloor = 0,
                        EconomDelivery = true,
                        cashOnDeliveryType = 2,                      //?????
                        CashOnDeliveryValuta = 100000000,
                        CashOnDeliveryValue = 0,                     // ввести
                        CashOnDeliveryWarehouseId = _warehouses[_cbWarehouse.SelectedIndex].id,  // буде братись з таблиці
                        CashOnDeliveryPayerAccountId = "",           //?????
                        CashOnDeliverySenderFullName = "",           //?????
                        CashOnDeliverySenderPhone = "",              //?????
                        CashOnDeliveryReceiverFullName = "",         //?????
                        CashOnDeliveryReceiverPhone = "",            //?????
                        CashOnDeliveryDescription = "описание наложки",
                        descentFromFloor = 0,
                        category = _cargoList
                    }
                }
            };

            //Shipment = Controller.GetShipment(_tbShipmentUuid.Text.Trim());
            //if (Shipment == null)
            //{
            //    MessageBox.Show("Відправлення не знайдено!");
            //}
            //else
            //{
            //    var Statuses = Controller.GetStatuses(Shipment.barcode);
            //    //Controller.GetStatusesXml("ec449353-4e4f-3b6c-877b-0b93e8d45601", "1111111111111", out string result);
            //    if (Statuses != null && Statuses.Count != 0)
            //    {
            //        pictureBox1.Visible = false;
            //        dataGridView1.Visible = true;
            //        dataGridView1.DataSource = Statuses;
            //        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //    }
            //    else
            //    {
            //        MessageBox.Show("Відправлення не трекається. Ймовірно воно ще не відправлене.");
            //    }
            //}

        }

        private void _btAddCargo_Click(object sender, EventArgs e)
        {
            if (_cbWarehouse.SelectedIndex < 0 || _cbWarehouse2.SelectedIndex < 0)
            {
                MessageBox.Show("Введіть відділення доставки!");
                return;
            }
            _tariff = Controller.GetTariffCategory(_areas[_cbArea.SelectedIndex].id, _areas2[_cbArea2.SelectedIndex].id, _warehouses2[_cbWarehouse2.SelectedIndex].id);
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

        }
    }
}
