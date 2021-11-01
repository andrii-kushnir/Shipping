using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace PostAPI
{
    static class Program
    {
        internal static string FileUsers = Directory.GetCurrentDirectory() + @"\" + "UserInfo.dat";
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
            if (!File.Exists(FileUsers))
            {
                MessageBox.Show("File Users not found");
            }
            else
            {
                try
                {
                    _users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(FileUsers));
                }
                catch
                {
                    MessageBox.Show("File Users not reading");
                }
            }
        }
    }
}
