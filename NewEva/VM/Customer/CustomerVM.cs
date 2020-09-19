using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NewEva.VM.Customer
{
    public class CustomerVM : CloseableViewModel
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
            OrganizationListPage = new RelayCommand(_ => OrganizationListCommand());
            PrivatePersonListPage = new RelayCommand(_ => PrivatePersonListCommand());
            BackPage = new RelayCommand(_ => BackCommand());
            SaveClosedWindow = new RelayCommand(_ => SaveClosedCommand());
            ClosedWindow = new RelayCommand(_ => ClosedCommand());
        }

        public ICommand OrganizationPage { get; }
        public ICommand PrivatePersonPage { get; }
        public ICommand OrganizationListPage { get; }
        public ICommand PrivatePersonListPage { get; }
        public ICommand BackPage { get; }
        public ICommand SaveClosedWindow { get; }
        public ICommand ClosedWindow { get; }
        public void OrganizationCommand()
        {
            CurrentPage = new OrganizationVM();
        }
        public void PrivatePersonCommand()
        {
            CurrentPage = new PrivatePersonVM();
        }
        public void OrganizationListCommand()
        {
            CurrentPage = new OrganizationListVM();
        }
        public void PrivatePersonListCommand()
        {
            CurrentPage = new PrivatePersonListVM();
        }
        public void BackCommand()
        {
            if (CurrentPage is PrivatePersonVM)
                CurrentPage = new PrivatePersonListVM();
            else if (CurrentPage is OrganizationVM)
                CurrentPage = new OrganizationListVM();
        }

        public void SaveClosedCommand()
        {
            if (CurrentPage is PrivatePersonVM privatePersonVM) 
            { 
                privatePersonVM.AddPrivatePerson();
            }
            this.OnClosingRequest();
        }



        public void ClosedCommand()
        {
            this.OnClosingRequest();
        }
    }
}
