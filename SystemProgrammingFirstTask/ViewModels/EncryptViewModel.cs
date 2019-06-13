using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemProgrammingFirstTask.Entities;

namespace SystemProgrammingFirstTask.ViewModels
{
   public class EncryptViewModel : BaseViewModel
    {
        private ObservableCollection<EncryptData> allData;
        public ObservableCollection<EncryptData> AllDatas
        {
            get
            {
                return allData;
            }
            set
            {
                allData = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(AllDatas)));
            }
        }
        private ObservableCollection<DecryptData> allDecData;
        public ObservableCollection<DecryptData> AllDecDatas
        {
            get
            {
                return allDecData;
            }
            set
            {
                allDecData = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(AllDecDatas)));
            }
        }
    }
}
