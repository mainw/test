using AutoDbClassLibrary;
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

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для Authorize.xaml
    /// </summary>
    public partial class Authorize : Page
    {
        public Authorize()
        {
            InitializeComponent();
        }

        private void BtnGoToRegisterPage_Click(object sender, RoutedEventArgs e)
        {
            (App.Current.MainWindow as MainWindow).MainFrame.Content = new Registration();
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login = TBoxLogin.Text;
            string password = PBoxPassword.Password;
            if (login.Length != 0)
            {
                if (password.Length != 0)
                {
                    string str = CaptchaCreater.GetRandomText(6);
                    if (new DialogWindows.CaptchaWindow(str).ToString().ToLower() != str.ToLower())
                    {
                        Task.Run(() =>
                        {
                            MessageBox.Show("Не удалось пройти проверку");
                        });
                        await Task.Delay(10000);
                        return;
                    }
                    App._user = App._context.Users.FirstOrDefault(p => p.password == password && p.login == login);
                    if (App._user != null)
                    {
                        (App.Current.MainWindow as MainWindow).MainFrame.Content = new ProductListPage();
                    }
                    else
                        MessageBox.Show("Такого пользователя не существует");
                }
                else
                    MessageBox.Show("Введите пароль");
            }
            else
                MessageBox.Show("Введите логин");
        }
    }
}
