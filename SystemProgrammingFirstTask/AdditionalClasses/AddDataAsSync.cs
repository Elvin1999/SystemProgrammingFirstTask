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

        public List<EncryptData> AllEnDatas { get; set; }
        public List<DecryptData> AllDenDatas { get; set; }
        public AddDataAsSync(EncryptViewModel encryptViewModel)
        {
            this.encryptViewModel = encryptViewModel;
            AllEnDatas = App.encryptDatas;

        }

        public void AddDataToEndataList()
        {
            encryptViewModel.AllDatas = new ObservableCollection<EncryptData>();

            foreach (var item in AllEnDatas)
            {

                App.Current.Dispatcher.Invoke((Action)delegate
                {
                    encryptViewModel.AllDatas.Add(item);
                });

                Thread.Sleep(1000);
            }
            encryptViewModel.Thread.Suspend();
        }
        public void AddDataToDeDataList()
        {
            AllDenDatas = new List<DecryptData>();
            Thread.Sleep(1000);
            int i = 1;
            HashHelper hashHelper = new HashHelper();
            encryptViewModel.AllDecDatas = new ObservableCollection<DecryptData>();
            if (this.encryptViewModel.AllDatas.Count >= this.encryptViewModel.AllDecDatas.Count)
            {
                foreach (var item in AllEnDatas)
                {
                    if (this.encryptViewModel.AllDatas.Count > this.encryptViewModel.AllDecDatas.Count)
                    {
                        DecryptData decryptData = new DecryptData();
                        decryptData.No = i;
                        ++i;
                        
                        decryptData.Text = hashHelper.GetHashOfString(item.Text);
                        App.Current.Dispatcher.Invoke((Action)delegate // <--- HERE
                        {
                            encryptViewModel.AllDecDatas.Add(decryptData);
                        });
                        Thread.Sleep(1000);
                    }

                }
            }
            encryptViewModel.Thread2.Suspend();
        }
    }
}
