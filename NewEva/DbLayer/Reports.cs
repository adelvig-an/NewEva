using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.DbLayer
{
    public class Reports
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Number { get; set; } //Номер отчета
        public DateTime? DateVulation { get; set; } //Дата оценки
        public DateTime? DateCompilation { get; set; } //Дата составления
        public DateTime? DateOfInspection { get; set; } //Дата осмотра
        //[Indexed]
        //public int ContractsId { get; set; }
    }
}
