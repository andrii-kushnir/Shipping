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

namespace PostAPI
{
    public partial class DeliveryCargo : Form
    {
        private List<CargoCategory> _cargoCategory;
        private List<Tariff> _tariff;
        private readonly string[] _isEconomList = { "Так", "Ні" };

        public Cargo cargo { get; set; } = null;

        public DeliveryCargo(List<Tariff> tariff)
        {
            _tariff = tariff;
            InitializeComponent();
        }

        private void DeliveryCargo_Load(object sender, EventArgs e)
        {
            _cbCategoryTariff.Items.AddRange(_tariff.Select(r => r.ToString()).ToArray());
            _cbCategoryTariff.SelectedIndex = 0;

            _cargoCategory = Controller.GetCargoCategory();
            _cbCargoCategory.Items.AddRange(_cargoCategory.Select(r => r.ToString()).ToArray());

            _cbIsEconom.Items.AddRange(_isEconomList);
            _cbIsEconom.SelectedIndex = 0;
        }

        private void _btAdd_Click(object sender, EventArgs e)
        {
            cargo = new Cargo();
            if (_cbCategoryTariff.SelectedIndex < 0 || _cbCargoCategory.SelectedIndex < 0)
            {
                cargo = null;
                return;
            }
            cargo.categoryId = _tariff[_cbCategoryTariff.SelectedIndex].id;
            cargo.cargoCategoryId = _cargoCategory[_cbCargoCategory.SelectedIndex].id;
            try
            {
                cargo.countPlace = int.Parse(_tbCountPlace.Text);
                cargo.helf = float.Parse(_tbHelf.Text);
                cargo.size = float.Parse(_tbSize.Text);
            }
            catch (Exception ex) when (ex is FormatException || ex is OverflowException)
            {
                MessageBox.Show("Некорректно введені дані!");
                cargo = null;
                return;
            }
            cargo.isEconom = _cbIsEconom.SelectedIndex == 0;
            Close();
        }

        private void _btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
