﻿using System;

namespace NewEva.Model
{
    public class PrivatePerson : Person
    {
        public int Id { get; set; }
        public string Serial { get; set; } //Серия документа
        public string Number { get; set; } //Номер документа
        public string Division { get; set; } //Кем выдан документ
        public string DivisionCode { get; set; } //Код подразделения
        public DateTime? DivisionDate { get; set; } //Дата выдачи
    }
}
