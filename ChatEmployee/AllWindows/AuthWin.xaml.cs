using System;
using System.Collections.Generic;
using System.IO;
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

namespace ChatEmployee
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthWin : Window
    {
        public AuthWin()
        {
            InitializeComponent();
            CheckConfigFile();
            FillFromConfigFile();
            //TbUserName.Text = App.ConfigFilePath;
            //string pass = "Sasha";
            //var decodeStr = Decoding(pass); 
            //MessageBox.Show("зашифрованный пароль " + decodeStr);
            //MessageBox.Show("расшифрованный пароль " + EncodingStr(decodeStr));
        }

        private void CheckConfigFile()
        {
            if(!File.Exists(App.ConfigFilePath))
            {
                File.Create(App.ConfigFilePath);
            }
        }

        private void BtnCloseAPP_Click(object sender, RoutedEventArgs e)
        {
            var mes = MessageBox.Show("Приложение будет закрыто?", "Закрытие приложения!", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(mes == MessageBoxResult.Yes)
            {
                Close();
            }
            
        }

        private void BtnLog_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)ChekSoxrUser.IsChecked)
            {
                using (StreamWriter sw = new StreamWriter(App.ConfigFilePath))
                {
                    sw.WriteLine($"Login: {TbUserName.Text}");
                    sw.WriteLine($"Password: {PbPassUser.Password}");
                }
                return;
            }
        }

        private void FillFromConfigFile()
        {
            try
            {
                using (StreamReader sr = new StreamReader(App.ConfigFilePath))
                {
                    var str = sr.ReadLine();
                    if (String.IsNullOrEmpty(str))
                        return;

                    TbUserName.Text = str.Replace("Login: ", "");
                    PbPassUser.Password = sr.ReadLine().Replace("Password: ", "");
                }

                ChekSoxrUser.IsChecked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //public string Decoding(string s)
        //{
        //    return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
        //}
        //public string EncodingStr(string s)
        //{
        //    var encodebyte = Convert.FromBase64String(s);
        //    return Encoding.UTF8.GetString(encodebyte);
        //}
    }
}
