using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using SystemProgrammingFirstTask.Entities;

namespace SystemProgrammingFirstTask
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<EncryptData> encryptDatas;
        public App()
        {
            encryptDatas = new List<EncryptData>();
        }
    }
}
