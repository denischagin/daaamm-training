using Daamn.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Daamn.Pages
{
    /// <summary>
    /// Логика взаимодействия для Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var employee = DBConnection.DB.Employee.FirstOrDefault(x => x.Login == LoginField.Text && x.Password == PasswordField.Password);

            if (employee == null)
            {
                MessageBox.Show("Не удалось войти");
                return;
            }
            if (employee.Role.Name == "Admin")
            {
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow.Frame.Navigate(new AdminRequests());
            }

            MessageBox.Show("Успешная авторизация");
        }
    }
}
