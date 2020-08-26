using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Report
    {
        public string Number { get; set; } //Номер отчета
        public DateTime DateVulation { get; set; } //Дата оценки
        public DateTime DateCompilation { get; set; } //Дата составления
    }
}
