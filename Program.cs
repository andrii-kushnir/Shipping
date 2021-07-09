using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NovaPost
{
    static class Program
    {
        public static List<User> _users;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Previously();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn(_users));
        }

        static void Previously()
        {
            _users = new List<User>();

            string pathCurrent = Directory.GetCurrentDirectory();
            var fileUsers = pathCurrent + "\\users.txt";
            if (!File.Exists(fileUsers))
            {
                File.Create(fileUsers);
            }
            else
            {
                var ln = File.ReadAllLines(fileUsers);
                for (int i = 0; i < ln.Length; i++)
                {
                    var user = new User
                    {
                        Login = ln[i],
                        Password = ln[i + 1],
                        ApiKeyNovaPost = ln[i + 2]
                    };
                    _users.Add(user);
                    i += 2;
                }
            }
        }
    }
}
