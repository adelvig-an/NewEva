using Dadata;

namespace NewEva.Model
{
    public class DadataAdr
    {
        public static bool TypeGetAddress(string fullAddress, out Address address)
        {
            

            var client = new CleanClientSync(token, secret);
            try
            {
                var adr = client.Clean<Dadata.Model.Address>(fullAddress);
                address = new Address()
                {
                    AddressFull = adr.result,
                    Index = adr.postal_code,
                    Country = adr.country,
                    Region = adr.region_with_type,
                    District = adr.area_with_type,
                    City = adr.city_with_type,
                    Street = adr.street_with_type,
                    House = adr.house,
                    Room = adr.flat
                };
                return true;
            }
            catch
            {
                address = null;
                return false;
            }
        }
    }
}
