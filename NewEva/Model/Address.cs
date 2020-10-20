using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Address
    {
        public string AddressFull { get; set; } //Адрес полностью
        public string Index { get; set; } //Индекс
        public string Country { get; set; } //Страна
        public string Region { get; set; } //Субъект (область, край)
        public string District { get; set; } //Район
        public string City { get; set; } //Город, населенный пункт
        public string Street { get; set; } //Улица
        public string House { get; set; } //Номер дома
        public string Room { get; set; } //Номер помещения
    }
}
