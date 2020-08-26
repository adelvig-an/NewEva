using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class PrivatePerson : Person
    {
        public string Type { get; set; } //Тип документа подтверждающего личность
        public int Serial { get; set; } //Серия документа
        public int Number { get; set; } //Номер документа
        public string Issued { get; set; } //Кем выдан документ
        public int Division { get; set; } //Код подразделения
        public DateTime DateIssued { get; set; } //Дата выдачи
    }
}
