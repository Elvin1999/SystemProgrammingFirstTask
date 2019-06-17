using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SystemProgrammingFirstTask.ViewModels;

namespace SystemProgrammingFirstTask.Commands.DecryptCommand
{
   public class DePauseCommand:ICommand
    {
        public DePauseCommand(EncryptViewModel encryptViewModel)
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
            EncryptViewModel.StateThread2 = 2;
            if (EncryptViewModel.Thread2.ThreadState != System.Threading.ThreadState.Suspended)
                EncryptViewModel.Thread2.Suspend();
            else
                EncryptViewModel.Thread2.Resume();
        }
    }
}
