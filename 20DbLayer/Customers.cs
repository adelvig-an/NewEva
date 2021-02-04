﻿using SQLite;

namespace NewEva.DbLayer
{
    public class Customers
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public bool Type_customer { get; set; }
        [Indexed]
        public int Id_private_pirsons { get; set; }
        [Indexed]
        public int Id_organizations { get; set; }
    }
}
