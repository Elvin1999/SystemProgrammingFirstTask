using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SystemProgrammingFirstTask.Entities;
using SystemProgrammingFirstTask.ViewModels;

namespace SystemProgrammingFirstTask.AdditionalClasses
{
    public class AddDataAsSync
    {
        public EncryptViewModel encryptViewModel { get; set; }
        public ObservableCollection<EncryptData> AllEnDatas { get; set; }
        public ObservableCollection<DecryptData> AllDenDatas { get; set; }
        public AddDataAsSync(EncryptViewModel encryptViewModel)
        {
            this.encryptViewModel = encryptViewModel;
            Helper helper = new Helper();
            var items = helper.DeserializeEnDatasFromJson();
            AllEnDatas = new ObservableCollection<EncryptData>(items);


        }
        public void AddDataToEndataList()
        {
            encryptViewModel.AllDatas = new ObservableCollection<EncryptData>();
            foreach (var item in AllEnDatas)
            {
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    encryptViewModel.AllDatas.Add(item);
                });
                Thread.Sleep(1000);
            }
        }
        public void AddDataToDeDataList()
        {
            AllDenDatas = new ObservableCollection<DecryptData>();
            Thread.Sleep(1000);
            foreach (var item in AllEnDatas)
            {
                DecryptData decryptData = new DecryptData();
                decryptData.Text = item.Text + "Decrytpt";
                AllDenDatas.Add(decryptData);
            }
            encryptViewModel.AllDecDatas = new ObservableCollection<DecryptData>();
            foreach (var item in AllDenDatas)
            {
                App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                {
                    encryptViewModel.AllDecDatas.Add(item);
                });
                Thread.Sleep(1000);
            }
        }
    }
}
