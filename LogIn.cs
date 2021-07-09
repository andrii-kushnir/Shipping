using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NovaPost
{
    public partial class LogIn : Form
    {
        private List<User> _users;

        public LogIn()
        {
            InitializeComponent();

            _cbOperator.SelectedIndex = 1;
        }

        public LogIn(List<User> users) : this()
        {
            _users = users;
        }

        private void _btLogIn_Click(object sender, EventArgs e)
        {
            var user = _users.Find(u => u.Login == _tbLogin.Text.Trim() && u.Password == HashPassword.Hash(_tbPassword.Text.Trim()));
            if (user == null)
            {
                MessageBox.Show("Логін або пароль не вірний!");
            }
            else
            {
                if (_cbOperator.SelectedIndex == 0)
                {
                    Form main = new MainForm(user);
                    this.Visible = false;
                    main.ShowDialog();
                    Close();
                }
                else
                {
                    Form main = new UkrPostMain(user);
                    this.Visible = false;
                    main.ShowDialog();
                    Close();
                }
            }
        }

        private void _btRegistration_Click(object sender, EventArgs e)
        {
            Form reg = new Registration(_users);
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
