using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.RightsManagement;
using System.Text;

namespace NewEva.VM.Customer
{
    public class PrivatePersonListVM : PageVM
    {
        public ObservableCollection<PrivatePerson> PrivatePersonList { get; }

        public PrivatePersonListVM()
        {
            PrivatePersonList = new ObservableCollection<PrivatePerson>()
            {
                 
            };
        }

        //public static Customers ReadCustomer()
        //{
        //    var customer = select * from Customers;
        //    return DataBase.Read<Customers>(customer);
        //}
    }
}
