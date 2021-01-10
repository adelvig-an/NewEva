using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.DbLayer
{
    public class TempData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Page { get; set; }
        public string Json { get; set; }
        public byte[] CBOR { get; set; }
        [Indexed]
        public int ReportsId { get; set; }
    }
}
