using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Windows.Input;

namespace NewEva.VM.Customer
{
    public class PrivatePersonListVM : PageVM
    {
        public ObservableCollection<PrivatePerson> PrivatePersonList { get; set; }
        public PrivatePerson SelectedPrivatePerson { get; set; }

        public PrivatePersonListVM(int selectedId = -1)
        {
            PrivatePersonList = new ObservableCollection<PrivatePerson>(DataBase.ReadAll<Customers>().Where(cust => cust.TypeCustomer == true).Select(сustomers => DataBase.ToPrivatePerson(сustomers)));
            SelectedPrivatePerson = PrivatePersonList.SingleOrDefault(privatePerson => privatePerson.Id == selectedId);
            DeleteCustomer = new RelayCommand(SelectedItems => DeleteSelectedCommand(SelectedItems));
        }

        public ICommand DeleteCustomer { get; } //Команда удаления Customer
        
        //Обработчик команды удаления Customer из списка
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
