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
                CurrentPage?.Write(nameToFile[CurrentPage.Name]);
                SetProperty(ref currentPage, value);
            }
        }
        
        private readonly Dictionary<string, string> nameToFile = new Dictionary<string, string> 
        { 
            { PageNames.ReportPage, "temp/ReportVM.json" }, 
            { PageNames.PrivatePersonPage, "temp/PrivatePersonVM.json" }, 
            { PageNames.FirstPage, "temp/FirstPageVM.json" },
            { PageNames.OrganizationPage, "temp/OrganizationVM.json" }
        };

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
            CurrentPage = PageVM.Read<ReportVM>(nameToFile[PageNames.ReportPage]) ?? new ReportVM();
        }

        //public void PrivatePersonAction()
        //{
        //    CurrentPage = new PrivatePersonVM();
        //}

        // Условие для выбора страницы Клиента
        public void FromReportAction()
        {
            //запуск метода создание файла и сохрание данных форм
            
            if (CurrentPage is ReportVM reportPage)
            {
                if (reportPage.IsPrivatePerson)
                {
                    CurrentPage = PageVM.Read<PrivatePersonVM>(nameToFile[PageNames.PrivatePersonPage]) ?? new PrivatePersonVM();
                }
                else if (reportPage.IsOrganization)
                {
                    CurrentPage = PageVM.Read<OrganizationVM>(nameToFile[PageNames.OrganizationPage]) ?? new OrganizationVM();
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
                
                CurrentPage = PageVM.Read<ReportVM>(nameToFile[PageNames.ReportPage]) ?? new ReportVM();
            }    
                
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
