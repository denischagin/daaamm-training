using Daamn.Context;
using Daamn.DB;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
    /// Логика взаимодействия для CreateRequestForm.xaml
    /// </summary>
    public partial class CreateRequestForm : Page
    {
        public CreateRequestForm()
        {
            InitializeComponent();
            CreateForm.DataContext = new Request() { AdditionalDate = DateTime.Now };
            StatusCombo.ItemsSource = DBConnection.DB.Status.ToList();
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            var currentRequest = CreateForm.DataContext as Request;

            string[] requiredFields = new string[] {
                currentRequest.Description, currentRequest.Equipment,
                currentRequest.TypeReject,
            };

            if (!requiredFields.All(f => !string.IsNullOrWhiteSpace(f)) || currentRequest.StatusId == 0)
            {
                MessageBox.Show("Вы не все заполнили поля");
                return;
            }

            DBConnection.DB.Request.Add(currentRequest);
            DBConnection.DB.SaveChanges();

            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.Frame.Navigate(new AdminRequests());
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.Frame.Navigate(new AdminRequests());
        }
    }
}
