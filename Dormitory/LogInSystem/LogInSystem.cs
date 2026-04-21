using DormitoryObjects.Fabrics;
using DormitoryObjects.Services;
using LogInSystem.Fabrics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogInSystem
{
    public partial class LogInSystem : Form
    {
        UserService userService;
        DbFactory dbFactory;
        public LogInSystem()
        {
            InitializeComponent();
        }

        private async void EnterTheSystem_Click(object sender, EventArgs e)
        {
            string login = LoginInput.Text;
            string password = PasswordInput.Text;
            string connectionString = GetConnectionString(login, password);

            dbFactory = new DbFactory(connectionString, DormitoryObjects.Databases.DatabaseType.MSDormitoryDatabase);
            userService = new UserService(dbFactory);

            EnterTheSystem.Enabled = false;
            try
            {
                var user = await userService.GetUserByLogin(login);
                if (user != null)
                {
                    LoginInput.BackColor = Color.White;
                    PasswordInput.BackColor = Color.White;
                    var form=GUIFabric.CreateUser(user);
                    form.ShowDialog();
                }
                else
                {
                    LoginInput.BackColor = Color.MistyRose;
                    PasswordInput.BackColor = Color.MistyRose;
                    MessageBox.Show("Неверный логин или пароль.");
                }
            }
            catch (Exception ex)
            {
                LoginInput.BackColor = Color.MistyRose;
                PasswordInput.BackColor = Color.MistyRose;
                MessageBox.Show("Неверный логин или пароль.");
            }
            finally
            {
                EnterTheSystem.Enabled = true;
            }

        }

        public static string GetConnectionString(string login, string password)
        {
            string baseConnectionString = ConfigurationManager.ConnectionStrings["DormitoryBase"].ConnectionString;

            var builder = new SqlConnectionStringBuilder(baseConnectionString);

            builder.UserID = login;
            builder.Password = password;

            return builder.ToString();
        }
    }
}
