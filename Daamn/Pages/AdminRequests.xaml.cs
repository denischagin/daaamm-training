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
    /// Логика взаимодействия для AdminRequests.xaml
    /// </summary>
    public partial class AdminRequests : Page
    {
        public AdminRequests()
        {
            InitializeComponent();
            StatusComboBox.ItemsSource = DBConnection.DB.Status.ToList();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            DBConnection.DB.Request.ToList();
            RequestsGrid.ItemsSource = DBConnection.DB.Request.Local;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.DB.SaveChanges();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            Request request = RequestsGrid.SelectedItem as Request; 
            if (request == null)
            {
                MessageBox.Show("Выберите элемент запроса");
                return;
            }

            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.Frame.Navigate(new UpdateRequestForm(request.Id));
        }

        private void Create_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            mainWindow.Frame.Navigate(new CreateRequestForm());
        }
    }
}
