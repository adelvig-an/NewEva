using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;

namespace NewEva.VM.Customer
{
    public class PrivatePersonListVM : PageVM
    {
        public ObservableCollection<PrivatePerson> PrivatePersonList { get; set; }

        public PrivatePersonListVM()
        {
            PrivatePersonList = new ObservableCollection<PrivatePerson>(DataBase.ReadAll<Customers>().Where(cust => cust.TypeCustomer == true).Select(сustomers => DataBase.ToPrivatePerson(сustomers)))
            {
                 
            };
        }


    }
}
