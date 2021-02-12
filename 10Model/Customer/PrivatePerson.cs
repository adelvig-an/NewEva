using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEva.Model
{
    public class PrivatePerson : Person
    {
        public string Serial { get; set; } //Серия документа
        public string Number { get; set; } //Номер документа
        public string Division { get; set; } //Кем выдан документ
        public string DivisionCode { get; set; } //Код подразделения
        public DateTime? DivisionDate { get; set; } //Дата выдачи
        public Address AddressRegistration { get; set; }
        public Address AddressActual { get; set; }
    }
}
