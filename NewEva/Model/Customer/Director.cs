using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Director : Person
    {
        public string Position { get; set; } // Должность руководителя
        public string TypeAttorney { get; set; } //Действующий на основании (Устав, Доверенность, Закон)
        public string NumberAttorney { get; set; } //Номер доверенности
        public DateTime? DateAttorney { get; set; } //Дата доверения
        public DateTime? DateAttorneyBefore { get; set; } //Дата "действует до"
    }
}
