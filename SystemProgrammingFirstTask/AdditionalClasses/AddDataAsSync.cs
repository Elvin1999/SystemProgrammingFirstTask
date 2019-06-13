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
        public AddDataAsSync(EncryptViewModel encryptViewModel)
        {
            this.encryptViewModel = encryptViewModel;
            Helper helper = new Helper();
            var items = helper.DeserializeEnDatasFromJson();
            AllEnDatas = new ObservableCollection<EncryptData>(items);

        }
        public void AddDataToAnotherList()
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
    }
}
