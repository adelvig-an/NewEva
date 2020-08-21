using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Document
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Numebr { get; set; }
        public DateTime DateEvalution { get; set; }
        public DateTime DateCompilation { get; set; }
    }
}
