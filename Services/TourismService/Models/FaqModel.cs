namespace SampleMVC.Models
{
    public class FaqModel
    {
        public int? faqId { get; set; }

        public string? question { get; set; }
        public string? answer { get; set; }
        public int? orderId { get; set; }
        public int? languageId { get; set; }
        public string? languageName { get; set; }
    }
}
