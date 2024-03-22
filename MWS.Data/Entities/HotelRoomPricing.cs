using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MWS.Data.Entities
{
    public partial class HotelRoomPricing
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? hotelRoomId { get; set; }
        public int? hotelTypeId { get; set; }
        public int? roomTypeId { get; set; }
        public double? price { get; set; }
        public int? numberOfAdult { get; set; }
        public int? numberOfChild { get; set; }
        public int? numberOfInfant { get; set; }

    }
}
