using Microsoft.AspNetCore.Mvc;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class UploadController : BaseController
    {
        private readonly ILogger<UploadController> _logger;
        private IRepository _repo;
        private readonly ILanguageService _languageService;
        private readonly IMailService mailService;
        public UploadController(IMailService mailService, ILanguageService languageService, ILocalizationService localizationService, ILogger<UploadController> logger, IRepositoryFactory repo)
       : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            this.mailService = mailService;
            _languageService = languageService;
        }

        public IActionResult Index()
        {
            ViewBag.languages = _repo.GetAll<Language>().ToList();
            return View();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles([FromForm] UserModel model)
        {
            var files = Request.Form.Files;
            if (files.Count == 0)
            {
                return BadRequest("No files uploaded.");
            }

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine("wwwroot\\Uploads", file.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            }
            return Ok(new { Message = "Files uploaded successfully!" });
        }
    }

}
