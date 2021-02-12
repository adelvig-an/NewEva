using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEva.Model
{
    public class Organization
    {
        public int Id { get; set; }
        public string NameFullOpf { get; set; } //Полное наименование
        public string NameShortOpf { get; set; } //Сокращенное наименование
        public string Opf { get; set; } //Организационно-правовая форма
        public long OGRN { get; set; } //ОГРН
        public DateTime? OGRNDate { get; set; } //Дата регистрации
        public int INN { get; set; } //ИНН
        public int KPP { get; set; } //КПП
        public string Bank { get; set; } //Название банка
        public int BIK { get; set; } //БИК Банка
        public long PayAccount { get; set; } //Расчетный счет
        public long CorrAccount { get; set; } //Корреспондентский счет
        public int DirectorId { get; set; }
        public virtual Address AddressRegistration { get; set; }
        public virtual Address AddressActual { get; set; }
    }
}
