using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebMvc5.DAL;
using WebMvc5.DAL.IRepository;

namespace WebMvc5.Controllers.api
{
    public class BlogController : ApiController
    {
        private IBlogRepository blogRepo;
        public BlogController()
        {
            blogRepo = new BlogRepository();
        }
        [Route("api/blog/ping")]
        public IHttpActionResult GetPing()
        {
            return Ok("pong");
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var allData = blogRepo.GetAll().AsNoTracking().ToList();

            return Ok(allData);
        }
    }
}
