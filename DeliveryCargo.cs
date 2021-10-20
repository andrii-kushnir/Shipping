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
using ApiDelivery.Responses;

namespace PostAPI
{
    public partial class DeliveryCargo : Form
    {
        private List<CargoCategory> _cargoCategory;
        List<Tariff> _tariff;

        public DeliveryCargo(List<Tariff> tariff)
        {
            _tariff = tariff;
            InitializeComponent();
        }

        private void DeliveryCargo_Load(object sender, EventArgs e)
        {
            _cargoCategory = Controller.GetCargoCategory();
            _cbCargoCategory.Items.AddRange(_cargoCategory.Select(r => r.ToString()).ToArray());
            _cbCategoryTariff.Items.AddRange(_tariff.Select(r => r.ToString()).ToArray());
        }
    }
}
