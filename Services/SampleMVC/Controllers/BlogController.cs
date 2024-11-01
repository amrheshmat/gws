using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Infrustructure.Repositories;
using SampleMVC.Models;
using System.Reflection.Metadata;
using TripBusiness.Ibusiness;

namespace SampleMVC.Controllers
{
    public class BlogController : Controller
    {
        private IRepository _repo;
        private ILocalizationService _localizationService;
        IWebHostEnvironment _appEnvironment;
        public BlogController(IRepositoryFactory repo, IWebHostEnvironment appEnvironment, ILocalizationService localizationService)
        {
            _repo = repo.Create("AGGRDB");
            _appEnvironment = appEnvironment;
            _localizationService = localizationService;
        }

        [Route("BlogSingle/{id}")]
        public async Task<IActionResult> BlogSingle(int id)//index page
        {
            Blog blog = await _repo.Filter<Blog>(e => e.blogId == id).FirstOrDefaultAsync();
            List<Blog> recentLogs = await _repo.Filter<Blog>(e => e.blogId == id && e.isActive == "Y").ToListAsync();
            List<TourAttachment> attachments = await _repo.Filter<TourAttachment>(e => e.tourId == id && e.type =="blog").ToListAsync();
            List<TourAttachment> tourAttachments = new List<TourAttachment>();
            var recentbLogs = recentLogs.OrderByDescending(e => e.creationDate).ToList().Take(3);
            foreach (var b in recentbLogs)
            {
                List<TourAttachment> tourAttachment = new List<TourAttachment>();
                tourAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == b.blogId && e.type == "blog").ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    tourAttachments.Add(attachment);
                }
            }
            ViewBag.currentId = id;
            ViewBag.attachments = attachments;
            ViewBag.blog = blog;
            ViewBag.recentLogs = recentLogs;
            return View(tourAttachments);
        }
            [AuthAttribute("blog", "blog")]
        public async Task<IActionResult> Blog()//index page
        {
            List<Blog> blogs = await _repo.GetAll<Blog>().ToListAsync();
            List<TourViewModel> list = new List<TourViewModel>();
            foreach (Blog blog in blogs)
            {
                TourViewModel tourViewModel = new TourViewModel();
                var lang = _repo.Filter<Language>(e => e.languageId == blog.languageId).FirstOrDefault()?.languageName;
                tourViewModel.languageName = lang;
                tourViewModel.title = blog.title;
                tourViewModel.tourId = blog.blogId;
                tourViewModel.isActive = blog.isActive;
                list.Add(tourViewModel);
            }
            ViewBag.blogs = list;
            return View();

        }
        [AuthAttribute("Add", "blog")]
        public async Task<IActionResult> Add()//index page
        {
            List<Day> days = await _repo.GetAll<Day>().ToListAsync();
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            List<AdditionalActivity> activities = await _repo.GetAll<AdditionalActivity>().ToListAsync();
            ViewBag.languages = languages;
            ViewBag.activities = activities;
            ViewBag.days = days;
            return View();
        }
        [AuthAttribute("add", "blog")]
        [HttpPost]
        public async Task<Response> Add([FromBody] Blog blog)//index page
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Add");
            blog.creationDate = DateTime.Now;
            var createdBlog = _repo.Create(blog);
            _repo.SaveChanges();
            var id = createdBlog?.blogId;
            if (id != null)
            {
                response.Status = true;
                response.Message = _localizationService.Localize("Added");
                return response;
            }
            response.Status = false;
            response.Message = _localizationService.Localize("AddedError");
            return response;

        }
        [AuthAttribute("Edit", "blog")]
        [Route("Blog/Edit/{id}")]
        public async Task<IActionResult> Edit(int id)//index page
        {
            Blog blog = new Blog();
            blog = await _repo.Filter<Blog>(e => e.blogId == id).FirstOrDefaultAsync();
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            ViewBag.languages = languages;
            ViewBag.blog = blog;
            return View(blog);

        }
        [Route("Blog/GetAttachmentById/{id}")]
        [HttpGet]
        public async Task<List<TourAttachment>> GetAttachmentById(int id)//index page
        {
            List<TourAttachment> blogAttachment = await _repo.Filter<TourAttachment>(e => e.tourId == id && e.type == "blog").ToListAsync();
            List<Blog> blogs = await _repo.GetAll<Blog>().ToListAsync();
            ViewBag.blogs = blogs;
            return blogAttachment;

        }
        [AuthAttribute("Edit", "blog")]
        [HttpPost]
        public async Task<Response> Edit([FromBody] Blog blogModel)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Update");
            blogModel.creationDate = DateTime.Now;
            //var rolePermissions = _repo.Filter<Blog>(e => e.blogId == blogModel.blogId).ToList();
            var Blog = _repo.Update<Blog>(blogModel);
            _repo.SaveChanges();
            if (Blog != null)
            {
                response.Status = true;
                response.Message = _localizationService.Localize("Updated");
                return response;
            }
            response.Status = false;
            response.Message = _localizationService.Localize("UpdatedError");
            return response;
        }
        [HttpPost]
        [Route("Blog/Upload")]
        public async Task<IActionResult> Upload([FromQuery] int blogId)
        {
            if (ModelState.IsValid)
            {
                List<TourAttachment> attachments = _repo.Filter<TourAttachment>(e => e.tourId == blogId && e.type == "blog").ToList();
                _repo.context.RemoveRange(attachments);
                _repo.SaveChanges();
                var files = Request.Form.Files;

                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Files");

                //create folder if not exist
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                //get file extension
                foreach (var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file.FileName);
                    var myUniqueFileName = string.Format(@"{0}", Guid.NewGuid());
                    TourAttachment blogAttachment = new TourAttachment();
                    blogAttachment.type = "blog";
                    blogAttachment.tourId = blogId;
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
                return Ok("Uploaded");
            }
            List<Blog> blogs = await _repo.GetAll<Blog>().ToListAsync();
            ViewBag.blogs = blogs;
            return NotFound("NotFound");
        }
        [HttpGet]
        [Route("Blog/Delete/{blogId}")]
        public async Task<Response> Delete(int blogId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Delete");
            var blog = _repo.Filter<Blog>(e => e.blogId == blogId).FirstOrDefault();
            if (blog != null)
            {
               _repo.Delete<Blog>(blog);
                await _repo.context.SaveChangesAsync();
                response.Status = true;
                response.Message = _localizationService.Localize("Deleted");
                return response;
            }
            response.Status = false;
            response.Message = _localizationService.Localize("DeletedError");
            return response;
        }
        [HttpGet]
        [Route("Blog/Active/{blogId}")]
        public async Task<Response> Active(int blogId)
        {
            Response response = new Response();
            response.Title = _localizationService.Localize("Active");
            var blog = _repo.Filter<Blog>(e => e.blogId == blogId).FirstOrDefault();
            if (blog != null)
            {
                if (blog.isActive == null || blog.isActive == "N")
                    blog.isActive = "Y";
                else
                    blog.isActive = "N";
                _repo.context.Update(blog);
                await _repo.context.SaveChangesAsync();
                response.Status = true;
                response.Message = _localizationService.Localize("Done");
                return response;
            }
            response.Status = false;
            response.Message = _localizationService.Localize("AciveError");
            return response;
        }
    }
}
