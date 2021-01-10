using NewEva.DbLayer;
using NewEva.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace NewEva.VM
{
    public class ReportValidVM : PageVM
    {
        private PageVM currentPage;
        public PageVM CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage?.WriteCBOR();
                SetProperty(ref currentPage, value);
            }
        }

        public ObservableCollection<Report>ReportList { get; set; }
        //public ObservableCollection<Contract> ContractList { get; set; }
        public Report SelectedReport { get; set; }

        public ReportValidVM(int selectedId = -1)
        {
            //ContractList = new ObservableCollection<Contract>(DataBase.ReadAll<Contracts>().Select(contracts => DataBase.ToContract(contracts)));
            ReportList = new ObservableCollection<Report>(DataBase.ReadAll<Reports>().Select(reports => DataBase.ToReport(reports))); //Получение писка из базы данных
            SelectedReport = ReportList.SingleOrDefault(report => report.Id == selectedId);
            DeleteReport = new RelayCommand(SelectedItems => DeleteSelectedCommand(SelectedItems));
        }

        public ICommand DeleteReport { get; } //Команда удаления Report

        //Обработчик команды удаления Report из списка
        public void DeleteSelectedCommand(object p)
        {
            IList selectedItems = (IList)p;
            foreach (var report in selectedItems.OfType<Report>().ToArray())
            {
                int deleteCustomer = DataBase.DeleteData<Reports>(report.Id);
                if (deleteCustomer == 1)
                {
                    ReportList.Remove(report);
                }
            }
        }

        public override byte[] GetCBOR()
        {
            throw new NotImplementedException();
        }

        public override void SetCBOR(byte[] b)
        {
            throw new NotImplementedException();
        }
    }
}
