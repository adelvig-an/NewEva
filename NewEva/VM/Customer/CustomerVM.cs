using NewEva.DbLayer;
using NewEva.Model;
using NewEva.VM.Customer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            SaveBackPage = new RelayCommand(_ => SaveBackCommand());
            ClosedWindow = new RelayCommand(_ => ClosedCommand());
            
        }

        public ICommand OrganizationPage { get; }
        public ICommand PrivatePersonPage { get; }
        public ICommand OrganizationListPage { get; }
        public ICommand PrivatePersonListPage { get; }
        public ICommand BackPage { get; }
        public ICommand SaveBackPage { get; }
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

        //Команда сохранения данных в БД и возвращения к списку
        public void SaveBackCommand()
        {
            if (CurrentPage is PrivatePersonVM privatePersonVM)
            {
                privatePersonVM.AddPrivatePerson();
                CurrentPage = new PrivatePersonListVM();
            }
            else if (CurrentPage is OrganizationVM organizationVM)
            {
                organizationVM.AddOrganization();
                CurrentPage = new OrganizationListVM();
            }

            //this.OnClosingRequest(); //Закрытие окна
        }

        //Команда закрытия окна
        public void ClosedCommand()
        {
            this.OnClosingRequest();
        }

        
    }
}
