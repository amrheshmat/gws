using Microsoft.AspNetCore.Mvc;
using MWS.Infrustructure.Repositories;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class CheckoutController : Controller
    {
        private ILocalizationService _localizationService;
        private IRepository _repo;
        private IMailService _mailService;
        public CheckoutController(IMailService mailService, ILocalizationService localizationService, IRepositoryFactory repo)
        {
            _repo = repo.Create("AGGRDB");
            _localizationService = localizationService;
            _mailService = mailService;
        }
        [Route("checkout")]
        public async Task<IActionResult> index()//index page
        {
            return View();
        }
    }
}
