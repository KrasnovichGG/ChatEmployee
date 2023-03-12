using ChatEmployee.AllWindows;
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

        private async void BtnLog_Click(object sender, RoutedEventArgs e)
        {

            if(TbUserName.Text == "" || PbPassUser.Password == "")
            {
                MessageBox.Show("Не оставляйте поля незаполненными!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if ((bool)ChekSoxrUser.IsChecked)
            {
               await WriteToconfigFile($"Login: {TbUserName.Text}");   
               await WriteToconfigFile($"Password: {PbPassUser.Password}");   
            }
            
            var employee = App.dBChatEntities.Employee.FirstOrDefault(x => x.Username == TbUserName.Text && x.Password == PbPassUser.Password);
            if (employee == null)
            {
                MessageBox.Show("Такого пользователя не существует", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else
            {
                switch (employee.Department_Id)
                {
                    case 1:
                        MessageBox.Show($"Добрый день, {employee.Name}, {employee.Department.Name}", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Hand);
                        break;
                    case 2:
                        MessageBox.Show($"Добрый день, {employee.Name}, {employee.Department.Name}", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Hand);
                        break;
                    case 3:
                        MessageBox.Show($"Добрый день, {employee.Name}, {employee.Department.Name}", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Hand);
                        break;
                    case 4:
                        MessageBox.Show($"Добрый день, {employee.Name}, {employee.Department.Name}", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Hand);
                        break;
                    case 5:
                        MessageBox.Show($"Добрый день, {employee.Name}, {employee.Department.Name}", "Добро пожаловать!", MessageBoxButton.OK, MessageBoxImage.Hand);
                        break;
                }

                App.emp=employee;
                UserWin userWin = new UserWin();
                userWin.Show();
                Close();
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
                    sr.Close();
                }

                ChekSoxrUser.IsChecked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void ChekSoxrUser_Click(object sender, RoutedEventArgs e)
        {
            if (ChekSoxrUser.IsChecked == false)
            {
                TbUserName.Clear();
                PbPassUser.Clear();
                await WriteToconfigFile("");
            }
        }

        private async Task WriteToconfigFile(string str)
        {
            using (StreamWriter sw = new StreamWriter(App.ConfigFilePath))
            {
                await sw.WriteLineAsync(str);
                sw.Close();
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
