using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NewEva.VM.Customer
{
    public class CustomerCommand : Command
    {
        private CustomerWindow customerWindow;

        public CustomerCommand(ViewModelBase viewModelBase) : base(viewModelBase)
        {

        }

        public override bool CanExecute(object parameter) => customerWindow == null; 
        public override void Execute(object parameter)
        {
            var window = new CustomerWindow
            {
                Owner = Application.Current.MainWindow
            };

            window.Closed += OnWindowClosed;

            customerWindow = window;
            window.ShowDialog();
        }

        private void OnWindowClosed(object sender, EventArgs e)
        {
            ((Window)sender).Closed -= OnWindowClosed;
            customerWindow = null;
        }
    }
}
