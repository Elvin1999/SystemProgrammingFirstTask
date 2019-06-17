using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SystemProgrammingFirstTask.Commands.DecryptCommand;
using SystemProgrammingFirstTask.Commands.EncryptCommand;
using SystemProgrammingFirstTask.Entities;

namespace SystemProgrammingFirstTask.ViewModels
{
    public class EncryptViewModel : BaseViewModel
    {
        public Thread Thread { get; set; }
        public Thread Thread2 { get; set; }
        public PlayCommand PlayCommand => new PlayCommand(this);
        public PauseCommand PauseCommand => new PauseCommand(this);
        public ResumeCommand ResumeCommand => new ResumeCommand(this);
        public DePlayCommand DePlayCommand => new DePlayCommand(this);
        public DePauseCommand DePauseCommand => new DePauseCommand(this);
        public DeResumeCommand DeResumeCommand => new DeResumeCommand(this);
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
        private int statethread1 = 0;
        public int StateThread1
        {
            get
            {
                return statethread1;

            }
            set
            {
                statethread1 = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(StateThread1)));
            }
        }
        private int statethread2 = 0;
        public int StateThread2
        {
            get
            {
                return statethread2;

            }
            set
            {
                statethread2 = value;
                OnPropertyChanged(new PropertyChangedEventArgs(nameof(StateThread2)));
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
