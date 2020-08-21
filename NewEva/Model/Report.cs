using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Report
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public DateTime DateVulation { get; set; }
        public DateTime DateCompilation { get; set; }
    }
}
