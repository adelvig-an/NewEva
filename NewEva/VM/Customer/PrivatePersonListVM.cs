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
            PrivatePersonList = new ObservableCollection<PrivatePerson>(DataBase.ReadAll<Customers>())
            {
                 
            };
  
        }
    }
}
