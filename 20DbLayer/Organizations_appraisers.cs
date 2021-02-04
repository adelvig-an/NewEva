using SQLite;

namespace NewEva.DbLayer
{
    class Organizations_appraisers
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int Id_organizations { get; set; }
        [Indexed]
        public int Id_insurance_policies { get; set; }
    }
}
