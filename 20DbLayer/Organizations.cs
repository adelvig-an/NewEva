using SQLite;
using System;

namespace NewEva.DbLayer
{
    public class Organizations
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name_full_opf { get; set; } //Полное наименование
        public string Name_short_opf { get; set; } //Сокращенное наименование
        public string Opf { get; set; } //Организационно-правовая форма
        public long OGRN { get; set; } //ОГРН
        public DateTime? OGRN_date { get; set; } //Дата регистрации
        public int INN { get; set; } //ИНН
        public int KPP { get; set; } //КПП
        public string Bank { get; set; } //Название банка
        public int BIK { get; set; } //БИК Банка
        public long Pay_account { get; set; } //Расчетный счет
        public long Corr_account { get; set; } //Корреспондентский счет
        [Indexed]
        public int Id_directors { get; set; }
        [Indexed]
        public int Id_addresses_registration { get; set; }
        [Indexed]
        public int Id_addresses_actual { get; set; }
    }
}
