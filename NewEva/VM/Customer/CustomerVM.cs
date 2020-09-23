using NewEva.DbLayer;
using NewEva.Model;
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
            SaveClosedWindow = new RelayCommand(_ => SaveClosedCommand());
            ClosedWindow = new RelayCommand(_ => ClosedCommand());
            DeleteCustomer = new RelayCommand(SelectedItems => DeleteSelectedCommand(SelectedItems));
        }

        public ICommand OrganizationPage { get; }
        public ICommand PrivatePersonPage { get; }
        public ICommand OrganizationListPage { get; }
        public ICommand PrivatePersonListPage { get; }
        public ICommand BackPage { get; }
        public ICommand SaveClosedWindow { get; }
        public ICommand ClosedWindow { get; }
        public ICommand DeleteCustomer { get; } //Команда удаления Customer
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

        //Команда сохранения данных в БД и закрытия окна
        public void SaveClosedCommand()
        {
            if (CurrentPage is PrivatePersonVM privatePersonVM) 
                privatePersonVM.AddPrivatePerson();
            else if (CurrentPage is OrganizationVM organizationVM)
                organizationVM.AddOrganization();
            //this.OnClosingRequest();
        }

        //Команда закрытия окна
        public void ClosedCommand()
        {
            this.OnClosingRequest();
        }

        //Метод удаления Customer из списка
        public void DeleteSelectedCommand(object p)
        {
            IList selectedItems = (IList)p;
            foreach (var customer in selectedItems.OfType<PrivatePerson>().ToArray())
            {
                int deleteCustomer = DataBase.DeleteData<Customers>(customer.Id);
                if (deleteCustomer == 1)
                {
                    PrivatePersonList.Remove(customer);
                }
            }
        }
    }
}
