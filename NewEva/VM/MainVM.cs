using NewEva.DbLayer;
using NewEva.VM.Customer;
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
                CurrentPage?.Write();
                SetProperty(ref currentPage, value);
            }
        }

        private readonly IDialogService dialogService;
        
        public MainVM(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            CurrentPage = new OverviewVM();
            
            //CustomerOpen = new RelayCommand(_ => dialogService.Show(new CustomerVM()));
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
