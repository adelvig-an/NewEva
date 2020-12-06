using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Category
    {
        public string Name { get; set; }
        public List<BuildingBase> Items { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
