using SQLite;
using System;


namespace NewEva.DbLayer
{
    class Appraisers
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime? Started_date { get; set; } //Год начала работы
        //Информация об образовании
        public string Diplom { get; set; } //Название специальности
        public string Serial { get; set; } //Сери диплома
        public int Number { get; set; } //Номер диплома
        public DateTime? Diplom_date { get; set; } //Дата выдачи диплома
        public string Universety { get; set; } //Название Университета

        //Информация о СРО
        public string SRO { get; set; } //Название СРО
        public int SRO_registry { get; set; } //Регистрационный номер
        public DateTime? SRO_registry_date { get; set; } //Дата регистрации в СРО
        [Indexed]
        public int Id_people { get; set; }
        [Indexed]
        public int Id_organizations_appraisers { get; set; }
        [Indexed]
        public int Id_insurence_policies { get; set; }
    }
}
