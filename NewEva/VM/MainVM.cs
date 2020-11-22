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
            BackPage = new RelayCommand(_ => BackCommand());
            SaveBackPage = new RelayCommand(_ => SaveBackCommand(), _ => CurrentPage.IsValid);
            //CustomerOpen = new RelayCommand(_ => dialogService.Show(new CustomerVM()));
        }
        public ICommand SaveBackPage { get; }
        public ICommand BackPage { get; }
        //Обработчик команды сохранения данных в БД и возвращения к списку
        public void SaveBackCommand()
        {
            if (CurrentPage is PrivatePersonVM privatePersonVM)
            {
                privatePersonVM.Validate();
                if (!privatePersonVM.IsValid)
                {
                    return;
                }
                if (privatePersonVM.IsEdit)
                {
                    privatePersonVM.UpdatePrivatePerson();
                    var id = privatePersonVM.Id;
                    CurrentPage = new PrivatePersonListVM(id);
                }
                else
                {
                    var id = privatePersonVM.AddPrivatePerson();
                    CurrentPage = new PrivatePersonListVM(id);
                }

            }
            else if (CurrentPage is OrganizationVM organizationVM)
            {
                organizationVM.Validate();
                if (!organizationVM.IsValid)
                {
                    return;
                }
                if (organizationVM.IsEdit)
                {
                    organizationVM.UpdateOrganization();
                    var id = organizationVM.Id;
                    CurrentPage = new OrganizationListVM(id);
                }
                else
                {
                    var id = organizationVM.AddOrganization();
                    CurrentPage = new OrganizationListVM(id);
                }
                
            }

            //this.OnClosingRequest(); //Закрытие окна
        }
        public void BackCommand()
        {
            if (CurrentPage is PrivatePersonVM)
                CurrentPage = new PrivatePersonListVM();
            else if (CurrentPage is OrganizationVM)
                CurrentPage = new OrganizationListVM();
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
