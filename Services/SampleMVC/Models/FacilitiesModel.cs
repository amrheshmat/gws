namespace SampleMVC.Models
{
    public class FacilitiesModel
    {
        public int? facilitiesId { get; set; }

        public string? title { get; set; }
        public string? description { get; set; }
        public string? imagePath { get; set; }
        public int? orderId { get; set; }
        public int? languageId { get; set; }
        public string? languageName { get; set; }
    }
}
