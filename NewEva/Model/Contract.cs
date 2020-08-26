using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Contract
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Number { get; set; }
        public DateTime DateContract { get; set; }
        public string Target { get; set; }
        public string TypeCost { get; set; }
    }
}
