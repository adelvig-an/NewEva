using SQLite;


namespace NewEva.DbLayer
{
    public class Addresses
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Address_full { get; set; } //Адрес полностью
        public string Index { get; set; } //Индекс
        public string Country { get; set; } //Страна
        public string Federal_district { get; set; } //Федеральный округ
        public string Region_kladr_id { get; set; } //КЛАДР-код региона
        public string Region_wth_type { get; set; } //Регион с типом
        public string Region_type { get; set; } //Тип региона (сокращенный)
        public string Region_type_full { get; set; } //Тип региона
        public string Region { get; set; } //Регион
        public string Area_kladr_id { get; set; } //КЛАДР-код района
        public string Area_wth_type { get; set; } //Район в регионе с типом
        public string Area_type { get; set; } //Тип района в регионе (сокращенный)
        public string Area_type_full { get; set; } //Тип района в регионе
        public string Area { get; set; } //Район в регионе
        public string City_kladr_id { get; set; } //КЛАДР-код города
        public string City_wth_type { get; set; } //Город с типом
        public string City_type { get; set; } //Тип города (сокращенный)
        public string City_type_full { get; set; } //Тип города
        public string City { get; set; } //Город
        public string CityDistrictWithType { get; set; } //Район города с типом
        public string CityDistrictType { get; set; } //Тип района города (сокращенный)
        public string CityDistrictTypeFull { get; set; } //Тип района города
        public string CityDistrict { get; set; } //Район города
        public string Settlement_kladr_id { get; set; } //КЛАДР-код населенного пункта
        public string Settlemen_wth_type { get; set; } //Населенный пункт с типом
        public string Settlemen_type { get; set; } //Тип населенного пункта (сокращенный)
        public string Settlemen_type_full { get; set; } //Тип населенного пункта
        public string Settlemen { get; set; } //Населенный пункт
        public string Street_kladr_id { get; set; } //КЛАДР-код улицы
        public string Street_wth_type { get; set; } //Улица с типом
        public string Street_type { get; set; } //Тип улицы (сокращенный)
        public string Street_type_full { get; set; } //Тип улицы
        public string Street { get; set; } //Улица
        public string House_kladr_id { get; set; } //КЛАДР-код дома
        public string House_type { get; set; } //Тип дома (сокращенный)
        public string House_type_full { get; set; } //Тип дома
        public string House { get; set; } //Номер дома
        public string Block_type { get; set; } //Тип корпуса/строения (сокращенный)
        public string Bloct_type_full { get; set; } //Тип корпуса/строения
        public string Block { get; set; } //Номер корпуса/строения
        public string Entrance { get; set; } //Подъезд
        public string Floor { get; set; } //Этаж
        public string Flat_type { get; set; } //Тип квартиры (сокращенный)
        public string Flat_type_full { get; set; } //Тип квартиры
        public string Flat { get; set; } //Квартиры
    }
}
