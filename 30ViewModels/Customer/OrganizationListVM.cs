﻿using NewEva.DbLayer;
using NewEva.Model;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace NewEva.VM.Customer
{
    public class OrganizationListVM : PageVM
    {
        public ObservableCollection<Organization>OrganizationList { get; set; }
        public Organization SelectedOrganization { get; set; }
        public OrganizationListVM(int selectedId = -1)
        {
            OrganizationList = new ObservableCollection<Organization>(DataBase.ReadAll<Customers>().Where(cust => cust.TypeCustomer == false).Select(сustomers => DataBase.ToOrganization(сustomers)));
            SelectedOrganization = OrganizationList.SingleOrDefault(organization => organization.Id == selectedId);
            DeleteCustomer = new RelayCommand(SelectedItems => DeleteSelectedCommand(SelectedItems));
        }

        public ICommand DeleteCustomer { get; } //Команда удаления Customer
        //Метод удаления Customer из списка
        public void DeleteSelectedCommand(object p)
        {
            IList selectedItems = (IList)p;
            foreach (var customer in selectedItems.OfType<Organization>().ToArray())
            {
                int deleteCustomer = DataBase.DeleteData<Customers>(customer.Id);
                if (deleteCustomer == 1)
                {
                    OrganizationList.Remove(customer);
                }
            }
        }

        public override byte[] GetCBOR()
        {
            throw new System.NotImplementedException();
        }

        public override void SetCBOR(byte[] b)
        {
            throw new System.NotImplementedException();
        }
    }
}
