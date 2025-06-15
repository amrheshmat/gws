using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using Newtonsoft.Json;
using SampleMVC.Controllers;
using SampleMVC.Models;
using TripBusiness.Ibusiness;

namespace GeneralService.Controllers
{
    public class ProfileController : BaseController
    {
        private readonly ILogger<ProfileController> _logger;
        private IRepository _repo;
        private ILocalizationService _localizationService;
        private ISecurity _security;
        private IWebHostEnvironment _env;
        public ProfileController(IWebHostEnvironment env, ILogger<ProfileController> logger, IRepositoryFactory repo, ISecurity security, ILanguageService languageService, ILocalizationService localizationService) : base(languageService, localizationService)
        {
            _logger = logger;
            _repo = repo.Create("AGGRDB");
            _security = security;
            _env = env;
            _localizationService = localizationService;
        }
        public async Task<IActionResult> Index()
        {
            var currentUser = HttpContext.Session.GetString("currentUser");
            UserDTO currentUserModel = JsonConvert.DeserializeObject<UserDTO>(currentUser);
            ViewData["users"] = await Localize("users");
            if (currentUser == null)
                return RedirectToAction("Index", "Login");
            ViewBag.NumberOfUsers = _repo.GetAll<User>().ToList().Count();
            ViewBag.NumberOfRoles = _repo.GetAll<Role>().ToList().Count();
            ViewBag.languages = _repo.GetAll<Language>().ToList();
            var user = _repo.Filter<User>(e => e.userName == currentUserModel.userName).FirstOrDefault();
            var subscriber = _repo.Filter<Subscriber>(e => e.userId == user!.userId).FirstOrDefault();
            var userPacakges = _repo.Filter<Package>(e => e.user_id == user!.userId).ToList();
            var availability = _repo.Filter<Availability>(e => e.userId == user!.userId).FirstOrDefault();
            var categories = _repo.GetAll<Category>().ToList(); // Load from database
            var cities = _repo.GetAll<City>().ToList(); // Load from database
            Attachment attachment = _repo.Filter<Attachment>(e => e.elementId == user!.userId && e.type == "Profile").FirstOrDefault();
            var subscriberCategories = _repo.Filter<UserCategory>(e => e.user_id == user!.userId).ToList();
            List<string> categoriesList = new List<string>();
            foreach (var subscriberCategory in subscriberCategories)
            {
                var category = categories.Where(e => e.id == subscriberCategory.category_id).FirstOrDefault();
                string categoryName = category.id.ToString();
                categoriesList.Add(categoryName);
            }
            var model = new ProfileModel
            {
                userId = currentUserModel?.userId,
                basicInfo = new BasicInfoModel
                {
                    FullName = user!.fullName,
                    Email = user.email,
                    Phone = user.mobile,
                    City = subscriber.city,
                    ProfilePicPath = attachment?.attachmentPath,
                    bio = subscriber.bio,
                    experience_years = subscriber.experience_years,
                    SelectedCategories = categoriesList,
                    AvailableCategories = categories.Select(c => new SelectListItem
                    {
                        Value = c.id.ToString(),
                        Text = c.name
                    }).ToList(),
                    Cities = cities
                },
                availability = new AvailabilityModel
                {
                    fromDay = availability?.fromDay,
                    toDay = availability?.toDay,
                    fromHour = availability?.fromHour,
                    toHour = availability?.toHour,
                    fromPeriod = availability?.fromPeriod,
                    toPeriod = availability?.toPeriod,
                },
                packageInfo = new PackageModel
                {
                    userPackages = userPacakges,
                }
            };
            return View(model);
        }
        [HttpPost]
        public async Task<Response> UpdateBasicInfo([FromForm] ProfileModel profileModel)
        {

            BasicInfoModel basicInfo = profileModel.basicInfo;
            Response response = new Response();
            response.Status = false;
            var profilePic = Request.Form.Files;
            try
            {
                User user = _repo.Filter<User>(e => e.userId == decimal.Parse(profileModel.userId)).FirstOrDefault();
                user.email = basicInfo.Email;
                user.fullName = basicInfo.FullName;
                user.mobile = basicInfo.Phone;
                _repo.Update<User>(user);
                _repo.SaveChanges();
                Subscriber subscriber = _repo.Filter<Subscriber>(e => e.userId == decimal.Parse(profileModel.userId)).FirstOrDefault();
                subscriber.city = basicInfo.City;
                subscriber.experience_years = basicInfo.experience_years;
                subscriber.bio = basicInfo.bio;
                _repo.Update<Subscriber>(subscriber);
                _repo.SaveChanges();
                List<UserCategory> oldUserCategory = _repo.Filter<UserCategory>(e => e.user_id == user.userId).ToList();
                foreach (UserCategory category in oldUserCategory)
                {
                    _repo.Delete<UserCategory>(category);
                }
                _repo.SaveChanges();
                foreach (var category in basicInfo.SelectedCategories)
                {
                    UserCategory userCategory = new UserCategory();
                    userCategory.user_id = int.Parse(profileModel.userId);
                    userCategory.category_id = int.Parse(category);
                    _repo.Create<UserCategory>(userCategory);
                    _repo.SaveChanges();
                }
                if (profilePic != null)
                {
                    Upload(int.Parse(profileModel.userId), profilePic, "Profile");
                }
                response.Message = "Basic information updated";
                response.Status = true;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "an error occurred";
            }
            return response;
        }

        [HttpPost]
        public async Task<Response> AddUpdatePackageInfo([FromForm] ProfileModel profileModel)
        {
            PackageModel packageInfo = profileModel.packageInfo;
            Response response = new Response();
            response.Status = false;
            try
            {
                if (packageInfo != null && packageInfo.id != null)
                {
                    Package package = _repo.Filter<Package>(e => e.user_id == int.Parse(profileModel.userId)
                    && e.id == int.Parse(packageInfo.id)).FirstOrDefault();
                    package.title = packageInfo.title;
                    package.price = packageInfo.price;
                    package.duration = packageInfo.duration;
                    package.description = packageInfo.description;
                    package.deliverables = packageInfo.deliverables;
                    _repo.Update<Package>(package);
                    _repo.SaveChanges();
                    response.Message = "Package information updated";
                    response.Status = true;
                }
                else
                {

                    List<Package> packages = _repo.Filter<Package>(e => e.user_id == int.Parse(profileModel.userId)).ToList();
                    if (packages.Count < 3)
                    {
                        Package package = new Package();
                        package.user_id = int.Parse(profileModel.userId);
                        package.title = packageInfo.title;
                        package.price = packageInfo.price;
                        package.duration = packageInfo.duration;
                        package.description = packageInfo.description;
                        package.deliverables = packageInfo.deliverables;
                        _repo.Create<Package>(package);
                        _repo.SaveChanges();
                        response.Message = "new package created";
                        response.Status = true;
                    }
                    else
                    {
                        response.Message = "You already have 3 package";
                        response.Status = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "an error occurred";
            }
            return response;
        }
        [HttpPost]
        public async Task<Response> AddUpdateAvailability([FromForm] ProfileModel profileModel)
        {
            AvailabilityModel availabilityModel = profileModel.availability;
            Response response = new Response();
            response.Status = false;
            try
            {
                if (availabilityModel != null)
                {
                    Availability oldAvailability = _repo.Filter<Availability>(e => e.userId == int.Parse(profileModel.userId)).FirstOrDefault();
                    if (oldAvailability != null)
                    {
                        oldAvailability.userId = int.Parse(profileModel.userId);
                        oldAvailability.fromHour = availabilityModel.fromHour;
                        oldAvailability.toHour = availabilityModel.toHour;
                        oldAvailability.fromDay = availabilityModel.fromDay;
                        oldAvailability.toDay = availabilityModel.toDay;
                        oldAvailability.fromPeriod = availabilityModel.fromPeriod;
                        oldAvailability.toPeriod = availabilityModel.toPeriod;
                        _repo.Update<Availability>(oldAvailability);
                        _repo.SaveChanges();
                        response.Message = "Availability saved";
                        response.Status = true;
                    }
                    else
                    {
                        Availability availability = new Availability();
                        availability.userId = int.Parse(profileModel.userId);
                        availability.fromHour = availabilityModel.fromHour;
                        availability.toHour = availabilityModel.toHour;
                        availability.fromDay = availabilityModel.fromDay;
                        availability.toDay = availabilityModel.toDay;
                        availability.fromPeriod = availabilityModel.fromPeriod;
                        availability.toPeriod = availabilityModel.toPeriod;
                        _repo.Create<Availability>(availability);
                        _repo.SaveChanges();
                        response.Message = "Availability saved";
                        response.Status = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "an error occurred";
            }
            return response;
        }

        [HttpGet]
        [Route("Profile/DeletePackage/{packageId}")]
        public async Task<Response> DeletePackage(int packageId)
        {
            Response response = new Response();
            response.Status = false;
            try
            {
                if (packageId != null)
                {
                    Package package = _repo.Filter<Package>(e => e.id == packageId).FirstOrDefault();
                    _repo.Delete<Package>(package);
                    _repo.SaveChanges();
                    response.Message = "Package deleted";
                    response.Status = true;
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "an error occurred";
            }
            return response;
        }
        private void Upload(int userId, IFormFileCollection files, string fileType)
        {
            if (ModelState.IsValid)
            {
                List<Attachment> attachments = _repo.Filter<Attachment>(e => e.elementId == userId && e.type == fileType).ToList();
                _repo.context.RemoveRange(attachments);
                _repo.SaveChanges();

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file.FileName);
                    var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
                    Attachment blogAttachment = new Attachment();
                    blogAttachment.type = fileType;
                    blogAttachment.elementId = userId;
                    blogAttachment.attachmentName = file.Name;
                    blogAttachment.attachmentPath = myUniqueFileName + fileInfo.Extension;
                    _repo.Create(blogAttachment);
                    _repo.SaveChanges();
                    string fileName = myUniqueFileName + fileInfo.Extension;
                    string fileNameWithPath = Path.Combine(path, fileName);

                    using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
            }
        }
        [HttpPost("Profile/upload")]
        public async Task<Response> UploadFiles()
        {
            Response response = new Response();
            response.Status = false;
            try
            {
                var currentUser = HttpContext.Session.GetString("currentUser");
                UserDTO currentUserModel = JsonConvert.DeserializeObject<UserDTO>(currentUser);
                var files = Request.Form.Files;
                if (files == null || files.Count == 0)
                {
                    response.Status = false;
                    response.Message = "No files uploaded";
                    return response;
                }
                if (files.Count <= 5)
                {
                    Upload(int.Parse(currentUserModel.userId), files, "Portofolio");
                    response.Status = true;
                    response.Message = "Files updated successfully!";
                }
                else
                {
                    response.Status = false;
                    response.Message = " Only 5 files are allowed!";
                }
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = "an error occurred";
            }
            return response;
        }

        [Route("Profile/GetAttachmentById/{id}")]
        [HttpGet]
        public async Task<List<Attachment>> GetAttachmentById(int id)
        {
            List<Attachment> portofolioAttachment = await _repo.Filter<Attachment>(e => e.elementId == id && e.type == "Portofolio").ToListAsync();
            return portofolioAttachment;

        }
    }
}
