using NewEva.VM;
using NewEva.VM.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NewEva
{
    public class SimpleDialog : IDialogService
    {
        public void Show(ViewModelBase viewModel)
        {
            var displayRootRegistry = (Application.Current as App).displayRootRegistry;
            displayRootRegistry.ShowModalPresentation(viewModel);
        }
    }
}
