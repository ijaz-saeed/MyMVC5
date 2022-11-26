using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Core;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreMVCApp.Controllers
{
    [Authorize()]
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index(string currentFilter,
                    string searchString, int? page)
        {
            int pageSize = Consts.PageSize;
            int pageNumber = (page ?? 1);

            var allData = _blogService.GetAll().AsNoTracking();

            if (!string.IsNullOrEmpty(searchString))
            {
                page = 1;
                searchString = searchString.Trim();
            }
            else
            {
                searchString = string.IsNullOrEmpty(currentFilter) ? "" : currentFilter.Trim();
            }

            ViewBag.CurrentFilter = searchString;

            if (!string.IsNullOrEmpty(searchString))
            {
                allData = allData.Where(b => b.Url.Contains(searchString) || b.Description.Contains(searchString));
            }

            allData = allData.OrderByDescending(b => b.Id);
            return View(await _blogService.ToPaginatedListAsync(allData, pageNumber, pageSize));
        }

        public async Task<IActionResult> Get(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            var data = await _blogService.GetByIdAsync(id.Value);
            if (data == null)
            {
                return new NotFoundResult();
            }
            return View(data);

        }

        // GET: /Blog/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            var blog = await _blogService.GetByIdAsync(id.Value);
            if (blog == null)
            {
                return new NotFoundResult();
            }
            return View(blog);
        }

        // POST: /Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Edit([Bind( "Id","Url","Description","RowVersion")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _blogService.Edit(blog);
                _blogService.Save();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: /Blog/Create
        [Authorize(Roles = "Administrator")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Create([Bind( "Url", "Description")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _blogService.Add(blog);
                _blogService.Save();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            var data = await _blogService.GetByIdAsync(id.Value);
            if (data == null)
            {
                return new NotFoundResult();
            }
            return View(data);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
            {
                return new BadRequestResult();
            }

            var data = _blogService.GetByIdAsync(id).GetAwaiter().GetResult();
            if (data == null)
            {
                return new NotFoundResult();
            }

            _blogService.Delete(data);
            _blogService.Save();
            return RedirectToAction("Index");

        }

    }
}