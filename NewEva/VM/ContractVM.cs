using NewEva.Model;
using NewEva.VM.Customer;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.VM
{
    public class ContractVM : PageVM
    {
        private PageVM customerPage;
        public PageVM CustomerPage
        {
            get => customerPage;
            set
            {
                customerPage?.Write();
                SetProperty(ref customerPage, value);
            }
        }

        public IEnumerable<string> TypeCosts { get; }

        public ContractVM()
        {
            customerPage = new PrivatePersonVM();
            TypeCosts = LocalStorage.TypeCosts;

        }
    }
}
