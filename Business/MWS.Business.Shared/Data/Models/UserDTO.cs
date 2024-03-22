using MWS.Data.Entities;

namespace MWS.Business.Shared.Data.Models
{
    public class UserDTO
    {
        public System.String? userName { get; set; }

        public System.String? token { get; set; }
        public System.String? mobile { get; set; }
        public System.String? roleId { get; set; }
        public int? email { get; set; }
        public List<Permission> permissions { get; set; } = [];

    }
}
