using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebMvc5.DAL;
using WebMvc5.DAL.IRepository;
using WebMvc5.Models;
using PagedList;

namespace WebMvc5.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository blogRepo = new BlogRepository();

        // GET: /Blog/
        public ActionResult Index(int? page)
        {
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(blogRepo.GetAll().OrderByDescending(b=> b.Id).ToPagedList(pageNumber, pageSize));
        }

        // Ajax get experiment
        public ActionResult Index2()
        {
            return View(blogRepo.GetAll().ToList());
        }

        // GET: /Blog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogRepo.GetById(id.Value);
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogRepo.GetById(id.Value);
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
        public ActionResult Edit([Bind(Include = "Id,Url,Description")] Blog blog)
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
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = blogRepo.GetById(id.Value);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: /Blog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = blogRepo.GetById(id);
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
