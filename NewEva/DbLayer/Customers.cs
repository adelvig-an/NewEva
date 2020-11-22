using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.DbLayer
{
    public class Customers
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool TypeCustomer { get; set; }
        public string SecondName { get; set; } //Фамилия
        public string FirstName { get; set; } //Имя
        public string MiddleName { get; set; } //Отчество
        public string TypePassport { get; set; } //Тип документа подтверждающего личность
        public string Serial { get; set; } //Серия документа
        public string Number { get; set; } //Номер документа
        public string Issued { get; set; } //Кем выдан документ
        public string Division { get; set; } //Код подразделения
        public DateTime? DateIssued { get; set; } //Дата выдачи
        public string NameFull { get; set; } //Полное наименование
        public string NameShort { get; set; } //Сокращенное наименование
        public string OrganizationForm { get; set; } //Организационно-правовая форма
        public int OGRN { get; set; } //ОГРН
        public DateTime? DateRegistration { get; set; } //Дата регистрации
        public int INN { get; set; } //ИНН
        public int KPP { get; set; } //КПП
        public string NameBank { get; set; } //Название банка
        public int BIK { get; set; } //БИК Банка
        public int PayAccount { get; set; } //Расчетный счет
        public int CorrAccount { get; set; } //Корреспондентский счет
        public string Position { get; set; } // Должность руководителя
        public string TypeAttorney { get; set; } //Действующий на основании (Устав, Доверенность, Закон)
        public string NumberAttorney { get; set; } //Номер доверенности
        public DateTime? DateAttorney { get; set; } //Дата доверения
        public DateTime? DateAttorneyBefore { get; set; } //Дата "действует до"
        public string AddressFullRegistration { get; set; } //Адрес полностью
        public int IndexRegistration { get; set; } //Индекс
        public string CountryRegistration { get; set; } //Страна
        public string RegionRegistration { get; set; } //Субъект (область, край)
        public string DistrictRegistration { get; set; } //Район
        public string CityRegistration { get; set; } //Город, населенный пункт
        public string StreetRegistration { get; set; } //Улица
        public string HouseRegistration { get; set; } //Номер дома
        public string RoomRegistration { get; set; } //Номер помещения
        public string AddressFullActual { get; set; } //Адрес полностью
        public bool AddressMatch { get; set; } //Соответствие адреса регистрации и фактического
        public int IndexActual { get; set; } //Индекс
        public string CountryActual { get; set; } //Страна
        public string RegionActual { get; set; } //Субъект (область, край)
        public string DistrictActual { get; set; } //Район
        public string CityActual { get; set; } //Город, населенный пункт
        public string StreetActual { get; set; } //Улица
        public string HouseActual { get; set; } //Номер дома
        public string RoomActual { get; set; } //Номер помещения
    }
}
