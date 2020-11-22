using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM
{
    public class OverviewVM : PageVM
    {
        private PageVM reportPage;
        public PageVM ReportPage
        {
            get => reportPage;
            set
            {
                reportPage?.Write();
                SetProperty(ref reportPage, value);
            }
        }

        public OverviewVM()
        {
            ReportPage = new ReportVM();
        }
    }
}
