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
using System.Windows.Shapes;

namespace ChatEmployee.AllWindows
{
    /// <summary>
    /// Логика взаимодействия для UserFinder.xaml
    /// </summary>
    public partial class UserFinder : Window
    {
        public UserFinder()
        {
            InitializeComponent();
            LstEmployee.ItemsSource = App.dBChatEntities.Employee.ToList();
        }

        private void TbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            var search = App.dBChatEntities.Employee.ToList();
            search = search.Where(x => x.Name.ToLower().Contains(TbSearch.Text.ToLower())).ToList();
            LstEmployee.ItemsSource = search.ToList();
        }
    }
}
