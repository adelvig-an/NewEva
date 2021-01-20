using System;
using System.Collections.Generic;
using System.Text;
using Dadata;
using Dadata.Model;

namespace NewEva.Model
{
    public class DadataAdr
    {
        public static bool TypeGetAddress(string fullAddress, out Address address)
        {
            var token = "";
            var secret = "";

            var client = new CleanClientAsync(token, secret);
            try
            {
                var adr = client.Clean<Dadata.Model.Address>(fullAddress);
                address = new Address()
                {
                    AddressFull = adr.Result.result,
                    Index = adr.Result.postal_code,
                    Country = adr.Result.country,
                    Region = adr.Result.region_with_type,
                    District = adr.Result.area_with_type,
                    City = adr.Result.city_with_type,
                    Street = adr.Result.street_with_type,
                    House = adr.Result.house,
                    Room = adr.Result.flat
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
