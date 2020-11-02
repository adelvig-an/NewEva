using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM
{
    public class OverviewVM : PageVM
    {
        private PageVM currentPage;
        public PageVM CurrentPage
        {
            get => currentPage;
            set
            {
                CurrentPage?.Write();
                SetProperty(ref currentPage, value);
            }
        }

        public OverviewVM()
        {
            CurrentPage = new ReportVM();
        }
    }
}
