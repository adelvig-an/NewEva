using System;
using System.Collections.Generic;
using System.Text;

namespace NewEva.Model
{
    public class Contractor
    {
        public int Id { get; set; }
        public string TypeOrg { get; set; }
        public string Title { get; set; }
        public int OGRN { get; set; }
        public DateTime DateOrg { get; set; }
        public int INN { get; set; }
        public int KPP { get; set; }
        public int PayentAccount { get; set; }
        public string TitleBank { get; set; }
        public int BIK { get; set; }
        public string AddressReg { get; set; }
        public int IndexReg { get; set; }
        public string CountryReg { get; set; }
        public string RegionReg { get; set; }
        public string DistrictReg { get; set; }
        public string CityReg { get; set; }
        public string StreetReg { get; set; }
        public string NumberHouseReg { get; set; }
        public int NumberRoomReg { get; set; }
        public string AddressActual { get; set; }
        public int IndexActual { get; set; }
        public string CountryActual { get; set; }
        public string RegionActual { get; set; }
        public string DistrictActual { get; set; }
        public string CityActual { get; set; }
        public string StreetActual { get; set; }
        public string NumberHouseActual { get; set; }
        public int NumberRoomActual { get; set; }
    }
}
