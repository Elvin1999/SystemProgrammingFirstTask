using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SystemProgrammingFirstTask.AdditionalClasses;
using SystemProgrammingFirstTask.ViewModels;

namespace SystemProgrammingFirstTask.Commands.DecryptCommand
{
    public class DePlayCommand : ICommand
    {
        public DePlayCommand(EncryptViewModel encryptViewModel)
        {
            EncryptViewModel = encryptViewModel;
        }
        public EncryptViewModel EncryptViewModel { get; set; }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            EncryptViewModel.StateThread1 = 1;
            AddDataAsSync addDataAsSync = new AddDataAsSync(EncryptViewModel);
            EncryptViewModel.Thread2 = new Thread(addDataAsSync.AddDataToDeDataList);
            EncryptViewModel.Thread2.Start();
        }
    }
}
