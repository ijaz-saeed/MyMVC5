using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebMvc5.Models;
using PagedList;
using System.Threading.Tasks;
using WebMvc5.Core;

namespace WebMvc5.Controllers
{

    public class BlogController : BaseController
    {
        
        public BlogController()
        {
        }

        /// <summary>
        /// List Blogs
        /// </summary>
        /// <param name="searchString">search string</param>
        /// <param name="currentFilter">current search</param>
        /// <param name="page">page</param>
        /// <returns>List of Blogs</returns>
        // GET: /Blog/
        public async Task<ActionResult> Index(string searchString, string currentFilter, int? page)
        {
            int pageSize = Consts.PageSize;
            int pageNumber = (page ?? 1);

            var allData = blogRepo.GetAll().AsNoTracking();

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

            var asyncData = await Task.Run(() => { return allData.OrderByDescending(b => b.Id).ToPagedList(pageNumber, pageSize); });
            return View(asyncData);
        }

        /// <summary>
        /// Get all Data
        /// </summary>
        /// <returns></returns>
        // Ajax get experiment
        public async Task<ActionResult> Index2()
        {
            return View(await blogRepo.GetAll().AsNoTracking().ToListAsync());
        }

        /// <summary>
        /// Get Blog by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: /Blog/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await blogRepo.GetByIdAsync(id.Value);

            if (blog == null)
            {
                return HttpNotFound();
            }

            return View(blog);
        }

        // GET: /Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Blog/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Url,Description")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blogRepo.Add(blog);
                blogRepo.Save();
                return RedirectToAction("Index");
            }

            return View(blog);
        }

        // GET: /Blog/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await blogRepo.GetByIdAsync(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: /Blog/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Url,Description,RowVersion")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blogRepo.Edit(blog);
                blogRepo.Save();
                return RedirectToAction("Index");
            }
            return View(blog);
        }

        // GET: /Blog/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = await blogRepo.GetByIdAsync(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: /Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Blog blog = await blogRepo.GetByIdAsync(id);
            blogRepo.Delete(blog);
            blogRepo.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                blogRepo.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
