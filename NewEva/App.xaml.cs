using NewEva.VM;
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
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            MainWindow window = new MainWindow();
            window.Closed += OnClosed;
        }
        private void OnClosed(object sender, EventArgs e)
        {
            FileDelete.FileDel(); //удаление файлов
            Current.Shutdown();
        }
    }
}
