namespace NewEva.DbLayer
{
    public class TempData
    {
        public int TempDataId { get; set; }
        public string Page { get; set; }
        //public string Json { get; set; }
        public byte[] CBOR { get; set; }
    }
}
