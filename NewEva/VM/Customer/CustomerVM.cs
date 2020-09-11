using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

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
            OrganizationPage = new RelayCommand(_ => OrganizationCommand());
            PrivatePersonPage = new RelayCommand(_ => PrivatePersonCommand());
            BackPage = new RelayCommand(_ => BackCommand());
        }

        public ICommand OrganizationPage { get; }
        public ICommand PrivatePersonPage { get; }
        public ICommand BackPage { get; }
        public void OrganizationCommand()
        {
            CurrentPage = new OrganizationVM();
        }
        public void PrivatePersonCommand()
        {
            CurrentPage = new PrivatePersonVM();
        }
        public void BackCommand()
        {
            if (CurrentPage is PrivatePersonVM)
                CurrentPage = new PrivatePersonListVM();
            else if (CurrentPage is OrganizationVM)
                CurrentPage = new OrganizationListVM();
        }
    }
}
