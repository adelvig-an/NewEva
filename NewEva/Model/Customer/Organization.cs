using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Organization
    {
        public int Id { get; set; }
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
    }
}
