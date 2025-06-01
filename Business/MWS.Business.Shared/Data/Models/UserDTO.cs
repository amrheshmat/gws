using MWS.Data.Entities;

namespace MWS.Business.Shared.Data.Models
{
    public class UserDTO
    {
        public string? userId { get; set; }
        public string? userName { get; set; }
        public string? token { get; set; }
        public string? status { get; set; }
        public string? mobile { get; set; }
        public string? roleId { get; set; }
        public string? email { get; set; }
        public List<Permission> permissions { get; set; } = [];

    }
}
