using ChatEmployee.DB;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChatEmployee
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public static readonly string ConfigFilePath = Path.GetTempPath() + "config.ini";
        public static DBChatEntities dBChatEntities = new DBChatEntities();
        public static Employee emp;
        public static Department dep;
        public static ChatRoom chatR;
        public static ChatMessage chatM;
    }
}
