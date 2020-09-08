using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM.Customer
{
    public class CustomerVM : ViewModelBase
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

        public CustomerVM()
        {
            CurrentPage = new PrivatePersonListVM();
        }
    }
}
