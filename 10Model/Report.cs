using NewEva.Model.Contractor;
using System;
using System.ComponentModel.DataAnnotations;

namespace NewEva.Model
{
    public class Report
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Number { get; set; } //Номер отчета
        [Required]
        public DateTime? VulationDate { get; set; } //Дата оценки
        [Required]
        public DateTime? CompilationDate { get; set; } //Дата составления
        [Required]
        public DateTime? InspectionDate { get; set; } //Дата осмотра
        [Required]
        public string InspectionFeaures { get; set; } //Особенности проведения осмотра
        public int ContractId { get; set; }
        public virtual Contract Contract { get; set; }
        public int AppraiserId { get; set; }
        public virtual Appraiser Appraiser { get; set; }
    }
}
