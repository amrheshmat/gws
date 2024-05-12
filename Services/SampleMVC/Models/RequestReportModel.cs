namespace MWS.Data.Entities
{
    public partial class RequestReportModel
    {

        public decimal? id { get; set; }
        public string? tourName { get; set; }
        public string? phone { get; set; }
        public string? email { get; set; }
        public string? name { get; set; }
        public string? status { get; set; }
        public string? countryName { get; set; }
        public string? tourDate { get; set; }
        public int? numberOfAdult { get; set; }
        public int? numberOfChild { get; set; }
        public int? numberOfInfant { get; set; }
    }
}
