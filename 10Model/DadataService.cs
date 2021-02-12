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
                    FederalDistrict = adr.federal_district,
                    RegionKladrId = adr.region_kladr_id,
                    RegionWthType = adr.region_with_type,
                    RegionType = adr.region_type,
                    RegionTypeFull = adr.region_type_full,
                    Region = adr.region,
                    AreaKladrId = adr.area_kladr_id,
                    AreaWithType = adr.area_with_type,
                    AreaType = adr.area_type,
                    AreaTypeFull = adr.area_type_full,
                    Area = adr.area,
                    CityKladrId = adr.city_district_kladr_id,
                    CityWithType = adr.city_with_type,
                    CityType = adr.city_type,
                    CityTypeFull = adr.city_type_full,
                    City = adr.city,
                    CityDistrictWithType = adr.city_district_with_type,
                    CityDistrictType = adr.city_district_type,
                    CityDistrictTypeFull = adr.city_district_type_full,
                    CityDistrict = adr.city_district,
                    SettlementKladrId = adr.settlement_kladr_id,
                    SettlemenWithType = adr.settlement_with_type,
                    SettlemenType = adr.settlement_type,
                    SettlemenTypeFull = adr.settlement_type_full,
                    Settlemen = adr.settlement,
                    StreetKladrId = adr.street_kladr_id,
                    StreetWithType = adr.street_with_type,
                    StreetType = adr.street_type,
                    StreetTypeFull = adr.street_type_full,
                    Street = adr.street,
                    HouseKladrId = adr.house_kladr_id,
                    HouseType = adr.house_type,
                    HouseTypeFull = adr.house_type_full,
                    House = adr.house,
                    BlockType = adr.block_type,
                    BloctTypeFull = adr.block_type_full,
                    Block = adr.block,
                    FlatType = adr.flat_type,
                    FlatTypeFull = adr.flat_type_full,
                    Flat = adr.flat
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
                FederalDistrict = address.federal_district,
                RegionKladrId = address.region_kladr_id,
                RegionWthType = address.region_with_type,
                RegionType = address.region_type,
                RegionTypeFull = address.region_type_full,
                Region = address.region,
                AreaKladrId = address.area_kladr_id,
                AreaWithType = address.area_with_type,
                AreaType = address.area_type,
                AreaTypeFull = address.area_type_full,
                Area = address.area,
                CityKladrId = address.city_district_kladr_id,
                CityWithType = address.city_with_type,
                CityType = address.city_type,
                CityTypeFull = address.city_type_full,
                City = address.city,
                CityDistrictWithType = address.city_district_with_type,
                CityDistrictType = address.city_district_type,
                CityDistrictTypeFull = address.city_district_type_full,
                CityDistrict = address.city_district,
                SettlementKladrId = address.settlement_kladr_id,
                SettlemenWithType = address.settlement_with_type,
                SettlemenType = address.settlement_type,
                SettlemenTypeFull = address.settlement_type_full,
                Settlemen = address.settlement,
                StreetKladrId = address.street_kladr_id,
                StreetWithType = address.street_with_type,
                StreetType = address.street_type,
                StreetTypeFull = address.street_type_full,
                Street = address.street,
                HouseKladrId = address.house_kladr_id,
                HouseType = address.house_type,
                HouseTypeFull = address.house_type_full,
                House = address.house,
                BlockType = address.block_type,
                BloctTypeFull = address.block_type_full,
                Block = address.block,
                FlatType = address.flat_type,
                FlatTypeFull = address.flat_type_full,
                Flat = address.flat
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
