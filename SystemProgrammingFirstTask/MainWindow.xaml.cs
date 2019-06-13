using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using SystemProgrammingFirstTask.AdditionalClasses;
using SystemProgrammingFirstTask.Entities;
using SystemProgrammingFirstTask.ViewModels;

namespace SystemProgrammingFirstTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            EncryptViewModel encryptViewModel = new EncryptViewModel();
            AddDataAsSync addDataAsSync = new AddDataAsSync(encryptViewModel);
            Thread thread = new Thread(addDataAsSync.AddDataToEndataList);
            thread.Start();
            Thread thread2 = new Thread(addDataAsSync.AddDataToDeDataList);
            thread2.Start();
            //for (int i = 0; i < 10; i++)
            //{
            //    EncryptData encryptData = new EncryptData()
            //    {
            //        No = i + 1, Text = "Salam" + i.ToString()
            //    };
            //    encryptViewModel.AllDatas.Add(encryptData);
            //}
            //Helper helper = new Helper();
            //helper.EnDatas = encryptDatas;
            //helper.SeriailizeEndatasToJson();

            DataContext = encryptViewModel;
    
        }
    }
}
