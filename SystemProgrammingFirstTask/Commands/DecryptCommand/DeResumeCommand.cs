using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SystemProgrammingFirstTask.ViewModels;

namespace SystemProgrammingFirstTask.Commands.DecryptCommand
{
    public class DeResumeCommand : ICommand
    {
        public DeResumeCommand(EncryptViewModel encryptViewModel)
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
            if (EncryptViewModel.Thread2.ThreadState == System.Threading.ThreadState.Suspended)
                EncryptViewModel.Thread2.Resume();
            else
                this.EncryptViewModel.Thread2.Suspend();
        }
    }
}
