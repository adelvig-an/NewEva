using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Foundation
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Number { get; set; }
        public DateTime DateContract { get; set; }
        public string Target { get; set; }
        public string TypeCost { get; set; }
    }
}
