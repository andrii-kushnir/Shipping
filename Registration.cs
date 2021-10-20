using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PostAPI
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
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
                    ApiKeyNovaPost = _tbApiKey.Text.Trim() == "" ? null : _tbApiKey.Text.Trim(),
                    AuthorizationBearer = _tbBearer.Text.Trim() == "" ? null : _tbBearer.Text.Trim(),
                    UserToken = _tbToken.Text.Trim() == "" ? null : _tbToken.Text.Trim(),
                    DapiKey = _tbDapiKey.Text.Trim() == "" ? null : _tbDapiKey.Text.Trim(),
                    DapiSecretKey = _tbDapiSecretKey.Text.Trim() == "" ? null : _tbDapiSecretKey.Text.Trim()
                };
                if (Program._users.Any(u => u.Login == user.Login))
                {
                    MessageBox.Show("Такий користувач уже існує!");
                }
                else
                {
                    Program._users.Add(user);
                    File.WriteAllText(Path.GetTempPath() + Program.FileUsers, JsonConvert.SerializeObject(Program._users));
                    Close();
                }
            }
        }
    }
}
