using SampleMVC.Models;
using SampleMVC.Models;

namespace MWS.Data.Entities
{
	public class BlogViewModel
    {
		public Blog? blog { get; set; }
        public List<TourAttachment>? attachments { get; set; }
	}
}
