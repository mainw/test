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
using WpfApp1.Db;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public ProductListPage()
        {
            InitializeComponent();
            fioTextBlock.Text = App._user.fio;
        }

        private void UploadData()
        {

            ProductListView.ItemsSource = App._context.Products.ToList();
        }

        private void EditProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (ProductListView.SelectedItem is Product product)
            {
                (App.Current.MainWindow as MainWindow).MainFrame.Content = new Pages.AddEditPage(product);
            }
            else
                MessageBox.Show("Выберите товар");
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.MainWindow as MainWindow).MainFrame.Content = new Pages.AddEditPage();
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UploadData();
        }

        private void FilterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UploadData();
        }

        private void SortBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UploadData();
        }
    }
}
