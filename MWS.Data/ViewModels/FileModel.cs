using Microsoft.AspNetCore.Http;

namespace MWS.Data.ViewModels
{
    public class FileModel
    {
        public List<IFormFile>? files { get; set; }
    }
}
