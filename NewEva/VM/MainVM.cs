using NewEva.DbLayer;
using NewEva.VM.Customer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace NewEva.VM
{
    public class MainVM : ViewModelBase
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

        public MainVM()
        {
            CurrentPage = new FirstPageVM();
            ReportPage = new RelayCommand(_=>ReportPageAction());
            FromReportPage = new RelayCommand(_ => FromReportAction());
            BackPage = new RelayCommand(_ => BackPageAction());
            NextPage = new RelayCommand(_ => NextPageAction());
            Customer = new RelayCommand(_ => new CustomerVM());
        }

        //Команда для кнопки "Отчет об оценке"
        public ICommand ReportPage { get; }
        public ICommand FromReportPage { get; }
        public ICommand BackPage { get; }
        public ICommand NextPage { get; }
        public ICommand Customer { get; }

        //Команда для кнопки "Отчет об оценке"
        public void ReportPageAction()
        {
            CurrentPage = PageVM.Read<ReportVM>() ?? new ReportVM();
        }

        // Условие для выбора страницы Клиента
        public void FromReportAction()
        {
            //запуск метода создание файла и сохрание данных форм
            
            if (CurrentPage is ReportVM reportPage)
            {
                if (reportPage.IsPrivatePerson)
                {
                    CurrentPage = PageVM.Read<PrivatePersonVM>() ?? new PrivatePersonVM();
                }
                else if (reportPage.IsOrganization)
                {
                    CurrentPage = PageVM.Read<OrganizationVM>() ?? new OrganizationVM();
                }
                else
                {
                    MessageBox.Show("Выберите Тип клиента!");
                }
            }
        }

        // Возвращение на предыдущую страницу
        public void BackPageAction()
        {
            
            if (CurrentPage is PrivatePersonVM || CurrentPage is OrganizationVM)
            {
                //запуск метода для чтения сохраненного файла данных форм
                CurrentPage = PageVM.Read<ReportVM>() ?? new ReportVM();
            }
            else if (CurrentPage is TypeObjectsVM)
            {
                CurrentPage = PageVM.Read<PrivatePersonVM>() ?? new PrivatePersonVM();
            }
                
        }
        //Переход на следующую страницу
        public void NextPageAction()
        {
            if (CurrentPage is PrivatePersonVM || CurrentPage is OrganizationVM)
            {
                //CurrentPage = PageVM.Read<TypeObjectsVM>() ??  new TypeObjectsVM();
                CurrentPage = new TypeObjectsVM();
            }
        }
    }
}
