using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using SystemProgrammingFirstTask.AdditionalClasses;
using SystemProgrammingFirstTask.ViewModels;

namespace SystemProgrammingFirstTask.Commands.EncryptCommand
{
    public class PlayCommand : ICommand
    {
        public PlayCommand(EncryptViewModel encryptViewModel)
        {
            EncryptViewModel = encryptViewModel;
        }
        public event EventHandler CanExecuteChanged;
        public EncryptViewModel EncryptViewModel { get; set; }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            AddDataAsSync addDataAsSync = new AddDataAsSync(EncryptViewModel);
            EncryptViewModel.Thread = new Thread(addDataAsSync.AddDataToEndataList);
            EncryptViewModel.Thread.Start();
        }
    }
}
