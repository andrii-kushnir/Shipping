using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PostAPI
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();

            _cbOperator.SelectedIndex = 1;
        }

        private void _btLogIn_Click(object sender, EventArgs e)
        {
            var user = Program._users.Find(u => u.Login == _tbLogin.Text.Trim() && u.Password == HashPassword.Hash(_tbPassword.Text.Trim()));
            if (user == null)
            {
                MessageBox.Show("Логін або пароль не вірний!");
            }
            else
            {
                this.Visible = false;
                Form main;
                switch (_cbOperator.SelectedIndex)
                {
                    case 0:
                        main = new NovaPostMain(user);
                        main.ShowDialog();
                        break;
                    case 1:
                        main = new UkrPostMain(user);
                        main.ShowDialog();
                        break;
                    case 2:
                        main = new UkrPostMain(user, "Test");
                        main.ShowDialog();
                        break;
                    case 3:
                        main = new DeliveryMain(user);
                        main.ShowDialog();
                        break;
                }
                this.Close();
            }
        }

        private void _btRegistration_Click(object sender, EventArgs e)
        {
            Form reg = new Registration();
            reg.ShowDialog();
        }

        private void _btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _btLogIn_Click(sender, EventArgs.Empty);
            }
        }
    }
}
