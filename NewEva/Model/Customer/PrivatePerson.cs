﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class PrivatePerson : Person
    {
        public string Type { get; set; } //Тип документа подтверждающего личность
        public string Serial { get; set; } //Серия документа
        public string Number { get; set; } //Номер документа
        public string Issued { get; set; } //Кем выдан документ
        public string Division { get; set; } //Код подразделения
        public DateTime DateIssued { get; set; } //Дата выдачи
    }
}