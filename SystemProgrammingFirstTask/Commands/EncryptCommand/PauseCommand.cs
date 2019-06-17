﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SystemProgrammingFirstTask.ViewModels;

namespace SystemProgrammingFirstTask.Commands.EncryptCommand
{
    public class PauseCommand : ICommand
    {
        public PauseCommand(EncryptViewModel encryptViewModel)
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
            EncryptViewModel.StateThread1 = 2;
            if(EncryptViewModel.Thread.ThreadState!= System.Threading.ThreadState.Suspended)
            EncryptViewModel.Thread.Suspend();
            else
                EncryptViewModel.Thread.Resume();

        }
    }
}
