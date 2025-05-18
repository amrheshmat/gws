using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MWS.Business.Shared;
using MWS.Business.Shared.Data.Models;
using MWS.Data.Entities;
using MWS.Data.ViewModels;
using MWS.Infrustructure.Repositories;
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

        [Route("blogs")]
        public async Task<IActionResult> Index()//index page
        {
            List<Attachment> attachments = await _repo.Filter<Attachment>(e => e.type == "blog").ToListAsync();
            List<Blog> blogs = _repo.Filter<Blog>(e => e.isActive == "Y").OrderByDescending(e => e.blogId).Take(2).ToList();
            List<Attachment> tourAttachments = new List<Attachment>();
            List<Attachment> recentAttachments = new List<Attachment>();
            foreach (var b in blogs)
            {
                List<Attachment> tourAttachment = new List<Attachment>();
                tourAttachment = await _repo.Filter<Attachment>(e => e.elementId == b.blogId && e.type == "blog").ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    tourAttachments.Add(attachment);
                }
            }
            List<Blog> recentLogs = await _repo.Filter<Blog>(e => e.isActive == "Y").ToListAsync();
            var recentbLogs = recentLogs.OrderByDescending(e => e.creationDate).ToList().Take(3);
            foreach (var b in recentbLogs)
            {
                List<Attachment> tourAttachment = new List<Attachment>();
                tourAttachment = await _repo.Filter<Attachment>(e => e.elementId == b.blogId && e.type == "blog").ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    recentAttachments.Add(attachment);
                }
            }
            int lastId = blogs.Select(e => e.blogId).ToList().Min();
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            foreach (var lan in languages)
            {
                List<Attachment> tourAttachment = new List<Attachment>();
                tourAttachment = await _repo.Filter<Attachment>(e => e.elementId == lan.languageId && e.type == "language").ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    tourAttachments.Add(attachment);
                }
            }
            ViewBag.languages = languages;
            ViewBag.toursAttachments = tourAttachments;
            int blogsCount = _repo.GetAll<Blog>().ToList().Count;
            double blogsPaginationCount = (double)blogsCount / 2;
            ViewBag.attachments = attachments;
            ViewBag.recentAttachments = recentAttachments;
            ViewBag.blogs = blogs;
            ViewBag.recentLogs = recentbLogs;
            ViewBag.blogsCount = Math.Ceiling(blogsPaginationCount);
            ViewBag.lastId = lastId;
            return View(tourAttachments);
        }
        [HttpGet]
        [Route("getBlogs")]
        public async Task<IActionResult> getBlogs()
        {
            List<Blog> blogs = await _repo.GetAll<Blog>().ToListAsync();
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            List<BlogViewModel> list = new List<BlogViewModel>();
            foreach (Blog blog in blogs)
            {
                BlogViewModel blogViewModel = new BlogViewModel();
                var lang = _repo.Filter<Language>(e => e.languageId == blog.languageId).FirstOrDefault()?.languageName;
                blogViewModel.languageName = lang;
                blogViewModel.title = blog.title;
                blogViewModel.blogId = blog.blogId;
                blogViewModel.isActive = blog.isActive;
                list.Add(blogViewModel);
            }
            return Json(new { data = list });
        }
        [Route("BlogSingle/{id}")]
        public async Task<IActionResult> BlogSingle(int id)
        {
            Blog blog = await _repo.Filter<Blog>(e => e.blogId == id).FirstOrDefaultAsync();

            List<Blog> recentbLogs = new List<Blog>();
            if (blog?.seokeyWords != "" && blog?.seokeyWords != null)
            {
                List<string> keyWords = blog?.seokeyWords.Split(",").ToList();
                recentbLogs = _repo.Filter<Blog>(e => e.blogId != id && keyWords.Any(x => e.seokeyWords.Contains(x)) && e.isActive == "Y").OrderByDescending(e => e.creationDate).ToList();
            }
            else
                recentbLogs = await _repo.Filter<Blog>(e => e.isActive == "Y").OrderByDescending(e => e.creationDate).Take(3).ToListAsync();
            List<Attachment> attachments = await _repo.Filter<Attachment>(e => e.elementId == id && e.type == "blog").ToListAsync();
            List<Attachment> tourAttachments = new List<Attachment>();
            foreach (var b in recentbLogs)
            {
                List<Attachment> tourAttachment = new List<Attachment>();
                tourAttachment = await _repo.Filter<Attachment>(e => e.elementId == b.blogId && e.type == "blog").ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    tourAttachments.Add(attachment);
                }
            }
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            foreach (var lan in languages)
            {
                List<Attachment> tourAttachment = new List<Attachment>();
                tourAttachment = await _repo.Filter<Attachment>(e => e.elementId == lan.languageId && e.type == "language").ToListAsync();
                foreach (var attachment in tourAttachment)
                {
                    tourAttachments.Add(attachment);
                }
            }
            ViewBag.languages = languages;
            ViewBag.currentId = id;
            ViewBag.attachments = attachments;
            ViewBag.toursAttachments = tourAttachments;
            ViewBag.blog = blog;
            ViewBag.recentLogs = recentbLogs;
            return View(tourAttachments);
        }
        [AuthAttribute("blog", "blog")]
        public async Task<IActionResult> Blog()
        {
            List<Blog> blogs = await _repo.GetAll<Blog>().ToListAsync();
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            List<BlogViewModel> list = new List<BlogViewModel>();
            foreach (Blog blog in blogs)
            {
                BlogViewModel blogViewModel = new BlogViewModel();
                var lang = _repo.Filter<Language>(e => e.languageId == blog.languageId).FirstOrDefault()?.languageName;
                blogViewModel.languageName = lang;
                blogViewModel.title = blog.title;
                blogViewModel.blogId = blog.blogId;
                blogViewModel.isActive = blog.isActive;
                list.Add(blogViewModel);
            }
            ViewBag.blogs = list;
            ViewBag.languages = languages;
            return View();

        }
        [AuthAttribute("Add", "blog")]
        public async Task<IActionResult> Add()
        {
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            ViewBag.languages = languages;
            return View();
        }
        [AuthAttribute("add", "blog")]
        [HttpPost]
        public async Task<Response> AddOrUpdate(BlogViewModel blogModel)
        {
            if (blogModel.blogId == null)
            {
                var files = Request.Form.Files;
                Response response = new Response();
                Blog blog = new Blog();
                blog.title = blogModel.title;
                blog.description = blogModel.description;
                blog.languageId = blogModel.languageId;
                blog.creationDate = DateTime.Now;
                response.Title = _localizationService.Localize("Add");
                var createdBlog = _repo.Create(blog);
                _repo.SaveChanges();
                var id = createdBlog?.blogId;
                if (id != null)
                {
                    Upload(id.Value, files);
                    response.Status = true;
                    response.Message = _localizationService.Localize("Added");
                    return response;
                }
                response.Status = false;
                response.Message = _localizationService.Localize("AddedError");
                return response;
            }
            else
            {
                return await Edit(blogModel);
            }
        }
        [AuthAttribute("Edit", "blog")]
        [Route("Blog/Edit/{id}")]
        public async Task<Blog> Edit(int id)
        {
            Blog blog = new Blog();
            blog = await _repo.Filter<Blog>(e => e.blogId == id).FirstOrDefaultAsync();
            List<Language> languages = await _repo.GetAll<Language>().ToListAsync();
            ViewBag.languages = languages;
            ViewBag.blog = blog;
            return blog;

        }
        [Route("Blog/GetAttachmentById/{id}")]
        [HttpGet]
        public async Task<List<Attachment>> GetAttachmentById(int id)
        {
            List<Attachment> blogAttachment = await _repo.Filter<Attachment>(e => e.elementId == id && e.type == "blog").ToListAsync();
            List<Blog> blogs = await _repo.GetAll<Blog>().ToListAsync();
            ViewBag.blogs = blogs;
            return blogAttachment;

        }
        public async Task<Response> Edit(BlogViewModel blogModel)
        {
            Response response = new Response();
            Blog blog = new Blog();
            blog.title = blogModel.title;
            blog.blogId = blogModel.blogId.Value;
            blog.description = blogModel.description;
            blog.languageId = blogModel.languageId;
            response.Title = _localizationService.Localize("Update");
            //var rolePermissions = _repo.Filter<Blog>(e => e.blogId == blogModel.blogId).ToList();
            var Blog = _repo.Update<Blog>(blog);
            _repo.SaveChanges();
            if (Blog != null)
            {
                var files = Request.Form.Files;
                Upload(blogModel.blogId.Value, files);
                response.Status = true;
                response.Message = _localizationService.Localize("Updated");
                return response;
            }
            response.Status = false;
            response.Message = _localizationService.Localize("UpdatedError");
            return response;
        }
        private void Upload(int blogId, IFormFileCollection files)
        {
            if (ModelState.IsValid)
            {
                List<Attachment> attachments = _repo.Filter<Attachment>(e => e.elementId == blogId && e.type == "blog").ToList();
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
                    blogAttachment.type = "blog";
                    blogAttachment.elementId = blogId;
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

        //[HttpGet]
        //[Route("Blog/GetPagination/{pageId}")]
        //public async Task<List<BlogViewModel>> GetPagination(string pageId)
        //{
        //    List<TourAttachment> attachments = await _repo.Filter<TourAttachment>(e => e.type == "blog").ToListAsync();
        //    List<Blog> blogs = _repo.Filter<Blog>(e => e.isActive == "Y").OrderByDescending(e => e.blogId).Skip(int.Parse(pageId) * 2).Take(2).ToList();
        //    List<BlogViewModel> viewModelList = new List<BlogViewModel>();
        //    foreach (var b in blogs)
        //    {
        //       BlogViewModel model = new BlogViewModel();
        //        model.blog = b;
        //        model.attachments = await _repo.Filter<TourAttachment>(e => e.tourId == b.blogId && e.type == "blog").ToListAsync();
        //        viewModelList.Add(model);
        //    }
        //    int lastId = blogs.Select(e => e.blogId).ToList().Min();
        //    Seo homeSeo = await _repo.GetAll<Seo>().FirstOrDefaultAsync();
        //    homeSeo.title = homeSeo.title + " - Our Blogs";
        //    ViewBag.homeSeo = homeSeo;
        //    int blogsCount = _repo.GetAll<Blog>().ToList().Count;
        //    double blogsPaginationCount = (double)blogsCount / 2;
        //    ViewBag.attachments = attachments;
        //    ViewBag.blogs = blogs;
        //    ViewBag.blogsCount = Math.Ceiling(blogsPaginationCount);
        //    ViewBag.lastId = lastId;
        //    return viewModelList;

        //}
    }
}
