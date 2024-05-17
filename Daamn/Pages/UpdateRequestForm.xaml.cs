using Daamn.Context;
using Daamn.DB;
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
    /// Логика взаимодействия для UpdateRequestForm.xaml
    /// </summary>
    public partial class UpdateRequestForm : Page
    {
        public Request CurrentRequest;
        public UpdateRequestForm(decimal id)
        {
            InitializeComponent();
            CurrentRequest = DBConnection.DB.Request.FirstOrDefault(x => x.Id == id);
            UpdateForm.DataContext = CurrentRequest;
            StatusCombo.ItemsSource = DBConnection.DB.Status.ToList();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DBConnection.DB.SaveChanges();
                MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
                mainWindow.Frame.Navigate(new AdminRequests());
            }
            catch
            {
                MessageBox.Show("Ошибка валидации");
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                DBConnection.DB.Entry(CurrentRequest).Reload();
            }
            catch
            {

            }

            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.Frame.Navigate(new AdminRequests());


        }
    }
}
