using ChatEmployee.DB;
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
    /// Логика взаимодействия для WinChat.xaml
    /// </summary>
    public partial class WinChat : Window
    {
        public Employee_ChatRoom chat;
        public WinChat(Employee_ChatRoom chatRoomEmployee)
        {
            InitializeComponent();
            chat = chatRoomEmployee;
        }
    }
}
