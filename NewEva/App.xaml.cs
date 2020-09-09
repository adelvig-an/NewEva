using NewEva.DbLayer;
using NewEva.VM;
using NewEva.VM.Customer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace NewEva
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public DisplayRootRegistry DisplayRootRegistry { get; }

        public App()
        {
            DisplayRootRegistry.RegisterWindowType<MainVM, MainWindow>();
            DisplayRootRegistry.RegisterWindowType<CustomerVM, CustomerWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var simpleDialog = new SimpleDialog();
            simpleDialog.Show(new CustomerVM()); 
            Current.Shutdown();
        }
        private void OnClosed(object sender, EventArgs e)
        {
            DataBase.DeleteTempData(); //удаление файлов
            Current.Shutdown();
        }
    }
}
