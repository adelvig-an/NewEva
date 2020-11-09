using NewEva.Model;
using NewEva.VM.Customer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace NewEva.VM
{
    public class ContractVM : PageVM
    {
        private PageVM currentPage;
        public PageVM CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage?.Write();
                SetProperty(ref currentPage, value);
            }
        }
        public IEnumerable<string> TypeCosts { get; }

        public ContractVM()
        {
            pages = new string[]
            {
                "PrivatePersonListVM",
                "OrganizationListVM"
            };
            TypeCosts = LocalStorage.TypeCosts;
            NewCustomerPage = new RelayCommand(_ => NewCustomerCommand());
        }

        private string[] pages;
        public string[] Pages
        {
            get => pages;
            set
            {
                SetProperty(ref pages, value);
            }
        }
        private int currentIndex;
        public int CurrentIndex
        {
            get => currentIndex;
            set
            {
                CurrentPage = CreatePageByName(pages[value]);
                SetProperty(ref currentIndex, value);
            }
        }
        public PageVM CreatePageByName(string pageName)
        {
            if (pageName == "PrivatePersonListVM")
                return new PrivatePersonListVM();
            else if (pageName == "OrganizationListVM")
                return new OrganizationListVM();
            else
                return null;
        }

        public ICommand NewCustomerPage { get; }
        public void NewCustomerCommand()
        {
            if (CurrentPage is PrivatePersonListVM)
                CurrentPage = new PrivatePersonVM();
            else if (CurrentPage is OrganizationListVM)
                CurrentPage = new OrganizationVM();
        }
    }
}
