using MWS.Data.Entities;

namespace SampleMVC.Models
{
    public class TourModel
    {
        public Tour? Tour { get; set; }
        public List<Include>? includes { get; set; }
        public List<AdditionalInformation>? additionalInformations { get; set; }
        public List<Exclude>? excludes { get; set; }
        public List<Expect>? expects { get; set; }
        public List<Pack>? packs { get; set; }
        public List<Day>? days { get; set; }
        public List<Language>? Languages { get; set; }
        public List<TourDay>? tourDays { get; set; }
        public List<TourLanguage>? tourLanguages { get; set; }
        public List<AdditionalActivity>? activities { get; set; }
        public List<TourAdditionalActivity>? tourAdditionalActivities { get; set; }
    }
}
