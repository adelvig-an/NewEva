using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Qualification
    {
        public string Title { get; set; } //Название квалификационного аттестата
        public int Number { get; set; } //Номер квалификационного аттестата
        public DateTime DateFrom { get; set; } //Дата "от"
        public DateTime DateBefore { get; set; } //Дата "до"
    }
}
