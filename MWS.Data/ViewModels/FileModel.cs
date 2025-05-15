using Microsoft.AspNetCore.Http;

namespace MWS.Data.ViewModels
{
    public class FileModel
    {
        public int? elemntId { get; set; }
        public List<IFormFile>? files { get; set; }
    }
}
