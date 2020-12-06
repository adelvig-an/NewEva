using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.DbLayer
{
    class Appraisers
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string FullName { get; set; } //Полное имя 
        public string SecondName { get; set; } //Фамилия
        public string FirstName { get; set; } //Имя
        public string MiddleName { get; set; } //Отчество
        public DateTime? GettingStarted { get; set; } //Год начала работы
        public int Experience { get; set; } //Опыт работы

        //Информация об образовании
        public string Diplom { get; set; } //Название специальности
        public string Serial { get; set; } //Сери диплома
        public int Number { get; set; } //Номер диплома
        public DateTime? DateDiplom { get; set; } //Дата выдачи диплома
        public string Universety { get; set; } //Название Университета

        //Информация о СРО
        public string NameSRO { get; set; } //Название СРО
        public int NumberRegistry { get; set; } //Регистрационный номер
        public DateTime? DateRegistry { get; set; } //Дата регистрации в СРО
        //[Indexed]
        //public int OrganizationsOfAppraisersId { get; set; }
    }
}
