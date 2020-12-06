using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.DbLayer
{
    public class TempData
    {
        [PrimaryKey]
        public string Page { get; set; }
        public string Json { get; set; }
    }
}
