using System;
using System.Collections.Generic;
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
            set => SetProperty(ref currentPage, value);
        }

        public MainVM()
        {
            CurrentPage = new FirstPageVM();
            ReportPage = new RelayCommand(_=>ReportPageAction());
            FromReportPage = new RelayCommand(_ => FromReportAction());
            BackPage = new RelayCommand(_ => BackPageAction());
        }

        //Команда для кнопки "Отчет об оценке"
        public ICommand ReportPage { get; }
        public ICommand FromReportPage { get; }
        public ICommand BackPage { get; }
        //public ICommand NextPage { get; }

        //Команда для кнопки "Отчет об оценке"
        public void ReportPageAction()
        {
            CurrentPage = new ReportVM();
        }

        public void PrivatePersonAction()
        {
            CurrentPage = new PrivatePersonVM();
        }

        // Условие для выбора страницы Клиента
        public void FromReportAction()
        {
            if (CurrentPage is ReportVM reportPage)
            {
                if (reportPage.IsPrivatePerson)
                {
                    CurrentPage = new PrivatePersonVM();
                }
                else if (reportPage.IsOrganization)
                {
                    MessageBox.Show("Переход на страницу информации об Организации!");
                    //CurrentPage = new OrganizationVM();
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
            if (CurrentPage is PrivatePersonVM)
                CurrentPage = new ReportVM();
        }

        //public void NextPageAction()
        //{
        //    if (CurrentPage is PrivatePersonVM)
        //    {
        //        CurrentPage = new TypeObjectsVM();
        //    }
        //}
    }
}
