using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
            //encryptViewModel.AllDatas = new ObservableCollection<EncryptData>();
            //AddDataAsSync addDataAsSync = new AddDataAsSync(encryptViewModel);
            //Thread thread = new Thread(addDataAsSync.AddDataToEndataList);
            //thread.Start();
            /////////////////////////////////////////////////////////////////////
            //Thread thread2 = new Thread(addDataAsSync.AddDataToDeDataList);
            //thread2.Start();

            Helper helper = new Helper();
            AddDataAsSync addDataAsSync = new AddDataAsSync(encryptViewModel);
            //addDataAsSync.AllEnDatas = new ObservableCollection<EncryptData>();
            
            var isExist = File.Exists("configEndata.json");
            if (!isExist)
            {
                for (int i = 0; i < 20; i++)
                {
                    EncryptData encryptData = new EncryptData()
                    {
                        No = i + 1,
                        Text = "Salam - >" + i.ToString()
                    };

                    App.encryptDatas.Add(encryptData);
                }
                helper.EnDatas = new List<EncryptData>(addDataAsSync.AllEnDatas);
                helper.SeriailizeEndatasToJson();
            }
            else
            {
                //addDataAsSync.AllEnDatas = new ObservableCollection<EncryptData>(helper.DeserializeEnDatasFromJson());
                App.encryptDatas = helper.DeserializeEnDatasFromJson();
            }
            
            DataContext = encryptViewModel;

        }
    }
}
