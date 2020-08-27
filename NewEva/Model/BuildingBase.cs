    using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public abstract class BuildingBase
    {
        public string Name { get; }
        protected BuildingBase(string name) =>
            Name = name;
        public override string ToString() => Name;
    }
}
