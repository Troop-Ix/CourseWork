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
    /// <summary>
    /// Форма для входа в систему
    /// </summary>
    public partial class LogInSystem : Form
    {
        UserService userService;
        DbFactory dbFactory;
        RepositoryFactory repositoryFactory;
        public LogInSystem()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Попытка входа в систему на основе введённых логина и пароля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void EnterTheSystem_Click(object sender, EventArgs e)
        {
            string login = LoginInput.Text;
            string password = PasswordInput.Text;

            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                LoginInput.BackColor = Color.MistyRose;
                PasswordInput.BackColor = Color.MistyRose;
                MessageBox.Show("Введите логин и пароль");
                return; 
            }

            LoginInput.BackColor = Color.White;
            PasswordInput.BackColor = Color.White;

            string connectionString = GetConnectionString(login, password);

            dbFactory = new DbFactory(connectionString, DormitoryObjects.Databases.DatabaseType.MSDormitoryDatabase);
            repositoryFactory = new RepositoryFactory();
            userService = new UserService(dbFactory, repositoryFactory);

            EnterTheSystem.Enabled = false;
            try
            {
                var user = await userService.GetUserByLogin(login);
                if (user != null)
                {
                    LoginInput.BackColor = Color.White;
                    PasswordInput.BackColor = Color.White;
                    var form=GUIFabric.CreateUser(user, dbFactory);
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
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
                MessageBox.Show($"Ошибка базы данных: {ex.Message}");
            }
            finally
            {
                EnterTheSystem.Enabled = true;
            }

        }
        /// <summary>
        /// Формирование строки подключения из введённых логина и пароля
        /// </summary>
        /// <param name="login">Логин пользователя</param>
        /// <param name="password">Пароль пользователя</param>
        /// <returns></returns>
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
