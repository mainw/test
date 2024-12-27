using AutoDbClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1.DialogWindows
{
    /// <summary>
    /// Логика взаимодействия для CaptchaWindow.xaml
    /// </summary>
    public partial class CaptchaWindow : Window
    {
        public CaptchaWindow(string str)
        {
            InitializeComponent();
            using (MemoryStream ms = new MemoryStream())
            {
                CaptchaCreater.GetSimpleCaptcha(str).Save(ms, ImageFormat.Bmp);
                ms.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.EndInit();
                img.Source = bi;
            }
            helpTextBlock.Text = "Подтвердите, что вы не робот";
            responceTextBox.MaxLength = str.Length;
        }
        public string ResponceValue
        {
            get { return responceTextBox.Text; }
        }
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (responceTextBox.Text.Length == responceTextBox.MaxLength)
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show($"Должно быть {responceTextBox.MaxLength} символов");
            }
        }
        public static implicit operator string(CaptchaWindow value)
        {
            if (value.ShowDialog() == true)
            {
                return value.ResponceValue;
            }
            return null;
        }
    }
}
