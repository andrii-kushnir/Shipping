using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PostAPI
{
    static class Program
    {
        internal const string FileUsers = "file015.dat";
        public static List<User> _users = new List<User>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Previously();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LogIn());
        }

        static void Previously()
        {
            var fileUsers = Path.GetTempPath() + FileUsers;
            if (!File.Exists(fileUsers))
            {
                MessageBox.Show("File Users not found");
            }
            else
            {
                try
                {
                    _users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(fileUsers));
                }
                catch
                {
                    MessageBox.Show("File Users not reading");
                }
            }
        }
    }
}
