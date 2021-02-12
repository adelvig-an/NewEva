using System;

namespace NewEva.Model
{
    public class Report
    {
        public int Id { get; set; }
        public string Number { get; set; } //Номер отчета
        public DateTime? VulationDate { get; set; } //Дата оценки
        public DateTime? CompilationDate { get; set; } //Дата составления
        public DateTime? InspectionDate { get; set; } //Дата осмотра
        public string InspectionFeaures { get; set; } //Особенности проведения осмотра
        public int ContractId { get; set; }
        //public int AppraiserId { get; set; }
    }
}
