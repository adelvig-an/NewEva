using Microsoft.EntityFrameworkCore;
using NewEva.DbLayer;
using NewEva.VM.Customer;
using NewEva.VM.ObjectOfEvaluation;
using NewEva.VM.ObjectOfEvaluation.Flat;
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
                CurrentPage?.WriteCBOR();
                SetProperty(ref currentPage, value);
            }
        }

        private readonly IDialogService dialogService;

        private readonly ApplicationContext context = new ApplicationContext();

        public MainVM(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            CurrentPage = new ReportValidVM();
            NewReport = new RelayCommand(_ => NewReportAcion());
            //CustomerOpen = new RelayCommand(_ => dialogService.Show(new CustomerVM()));
            context.Database.EnsureCreated();
            context.People.Load();
            context.Addresses.Load();
            context.Directors.Load();
            context.PrivatePersons.Load();
            context.Organizations.Load();
            context.Customers.Load();
            context.Contracts.Load();
            context.Reports.Load();
        }

        public ICommand NewReport { get; }
        public void NewReportAcion()
        {
            CurrentPage = new OverviewVM();
        }

        ////Команда для кнопки "Отчет об оценке"
        //public ICommand ReportPage { get; }
        //public ICommand BackPage { get; }
        //public ICommand NextPage { get; }
        //public ICommand CustomerOpen { get; }
        ////Команда для кнопки "Отчет об оценке"
        //public void ReportPageAction()
        //{
        //    CurrentPage = PageVM.Read<ReportVM>() ?? new ReportVM();
        //}
        //// Возвращение на предыдущую страницу
        //public void BackPageAction()
        //{

        //    if (CurrentPage is PrivatePersonVM || CurrentPage is OrganizationVM)
        //    {
        //        //запуск метода для чтения сохраненного файла данных форм
        //        CurrentPage = PageVM.Read<ReportVM>() ?? new ReportVM();
        //    }
        //    else if (CurrentPage is TypeObjectsVM)
        //    {
        //        CurrentPage = PageVM.Read<PrivatePersonVM>() ?? new PrivatePersonVM();
        //    }

        //}
        ////Переход на следующую страницу
        //public void NextPageAction()
        //{
        //    if (CurrentPage is PrivatePersonVM || CurrentPage is OrganizationVM)
        //    {
        //        //CurrentPage = PageVM.Read<TypeObjectsVM>() ??  new TypeObjectsVM();
        //        CurrentPage = new TypeObjectsVM();
        //    }
        //}
    }
}
