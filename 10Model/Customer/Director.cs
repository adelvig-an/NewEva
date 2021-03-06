﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewEva.Model
{
    public enum PowerOfAttorney
    {
        ArticlesOfAssociation, //Устав компаниии
        Attorney, //Доверенность
        Legislation //Законоательство
    }
    public class Director : Person
    {
        public string Position { get; set; } // Должность руководителя
        public PowerOfAttorney PowerOfAttorney { get; set; } //Действующий на основании (Устав, Доверенность, Закон)
        public string PowerOfAttorneyNumber { get; set; } //Номер доверенности
        public DateTime PowerOfAttorneyDate { get; set; } //Дата доверения
        public DateTime PowerOfAttorneyDateBefore { get; set; } //Дата "действует до"
        public virtual Organization Organization { get; set; }
    }
}
