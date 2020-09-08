using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Appraiser : Person
    {
        public DateTime GettingStarted { get; set; } //Год начала работы
        public int Experience { get; set; } //Опыт работы
        //Информация об образовании
        public string Diploma { get; set; } //Название специальности
        public string Serial { get; set; } //Сери диплома
        public int Number { get; set; } //Номер диплома
        public DateTime DateDiploma { get; set; } //Дата выдачи диплома
        public string Universety { get; set; } //Название Университета
        //Информация о СРО
        public string SRO { get; set; } //Название СРО
        public int NumberRegistry { get; set; } //Регистрационный номер
        public DateTime DateRegistry { get; set; } //Дата регистрации в СРО
    }
}
