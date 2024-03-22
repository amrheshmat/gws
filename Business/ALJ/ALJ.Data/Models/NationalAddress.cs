namespace ALJ.Data.Models
{

    public class NationalAddress
    {
        public long? BuildingNumber { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public long? ZipCode { get; set; }
        public long? AdditionalNumber { get; set; }

    }
}
