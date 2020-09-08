using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NewEva.VM
{
    public abstract class Command : ICommand
    {
        protected ViewModelBase viewModel;
        public Command(ViewModelBase viewModelBase)
        {
            viewModel = viewModelBase;
        }

        public event EventHandler CanExecuteChanged;

        public abstract bool CanExecute(object parameter);
        public abstract void Execute(object parameter);
    }
}
