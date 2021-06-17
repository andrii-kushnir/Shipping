using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NovaPost
{
    public partial class Registration : Form
    {
        private List<User> _users;

        public Registration()
        {
            InitializeComponent();
        }

        public Registration(List<User> users) :this()
        {
            _users = users;
        }

        private void _btExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void _btRegistration_Click(object sender, EventArgs e)
        {
            if (_tbPassword.Text.Trim() != _tbPassword1.Text.Trim())
            {
                MessageBox.Show("Паролі не співпадають!");
            }
            else if (_tbLogin.Text.Trim() == String.Empty || _tbPassword.Text.Trim() == String.Empty)
            {
                MessageBox.Show("Логін чи пароль не може бути пустим!");
            }
            else
            {
                var user = new User
                {
                    Login = _tbLogin.Text.Trim(),
                    Password = HashPassword.Hash(_tbPassword.Text.Trim()),
                    ApiKey = _tbApiKey.Text.Trim()
                };
                if (_users.Any(u => u.Login == user.Login))
                {
                    MessageBox.Show("Такий користувач уже існує!");
                }
                else
                {
                    _users.Add(user);
                    string pathCurrent = Directory.GetCurrentDirectory();
                    var fileUsers = pathCurrent + "\\users.txt";
                    using (StreamWriter w = new StreamWriter(fileUsers, true, Encoding.GetEncoding(1251)))
                    {
                        w.WriteLine(user.Login);
                        w.WriteLine(user.Password);
                        w.WriteLine(user.ApiKey);
                    }
                    Close();
                }
            }
        }
    }
}
