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
        public App()
        {
            //FileDelete.FileDel(); //удаление файлов
        }

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
            // Shut things down 10 secs from now
            //Timer t = new Timer(
            //    (state) => { App.Current.Shutdown(); },
            //    null, 10000, -1);
        }



        //protected override void OnClosed(EventArgs e)
        //{
        //    base.OnClosed(e);

        //    // Shut things down 10 secs from now
        //    Timer t = new Timer(
        //        (state) => { App.Current.Shutdown(); },
        //        null, 10000, -1);
        //}

    }
}
