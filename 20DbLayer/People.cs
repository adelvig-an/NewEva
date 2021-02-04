using SQLite;

namespace NewEva.DbLayer
{
    public class People
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Second_name { get; set; } //Фамилия
        public string First_name { get; set; } //Имя
        public string Middle_name { get; set; } //Отчество
    }
}
