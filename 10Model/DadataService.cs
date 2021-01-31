using Dadata;
using System.Linq;

namespace NewEva.Model
{
    public class DadataService
    {
        

        public static bool TypeGetAddress(string fullAddress, out Address address)
        {

            var token = "";
            var secret = "";

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

        public static bool GetSuggestions(string fullAddress, out Address[] addresses)
        {
            var token = "";

            var client = new SuggestClientSync(token);
            try
            {
                var adr = client.SuggestAddress(fullAddress);

                addresses = adr.suggestions.Select(address => ToAddress(address)).ToArray();

                return true;

            }
            catch
            {
                addresses = null;
                return false;
            }
        }

        public static Address ToAddress(Dadata.Model.Address address)
        {
            return new Address
            {
                AddressFull = address.result,
                Index = address.postal_code,
                Country = address.country,
                Region = address.region_with_type,
                District = address.area_with_type,
                City = address.city_with_type,
                Street = address.street_with_type,
                House = address.house,
                Room = address.flat
            };
        }

        public static Address ToAddress(Dadata.Model.Suggestion<Dadata.Model.Address> suggestion)
        {
            // ToDo: проверить что содержится в suggestion.data.result изначально
            suggestion.data.result = suggestion.value;
            return ToAddress(suggestion.data);
        }
    }
}
