using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WebMvc5.Core;
using WebMvc5.DAL;
using WebMvc5.DAL.IRepository;
using WebMvc5.ViewModels;

namespace WebMvc5.Controllers.api
{
    /// <summary>
    /// API for Blog
    /// </summary>
    public class BlogController : ApiController
    {
        private IBlogRepository blogRepo;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BlogController()
        {
            blogRepo = new BlogRepository();
        }

        /// <summary>
        /// Get Ping
        /// </summary>
        /// <returns>Pong</returns>
        [Route("api/blog/ping")]
        public IHttpActionResult GetPing()
        {
            return Ok("pong");
        }

        /// <summary>
        /// Get all Blogs
        /// </summary>
        /// <returns>List of Blogs</returns>
        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var allData = await blogRepo.GetAll().AsNoTracking().ToListAsync();

            return Ok(allData);
        }

        /// <summary>
        /// Get all Blogs by pagging
        /// </summary>
        /// <param name="page">page</param>
        /// <param name="size">page size</param>
        /// <returns>List of Blogs</returns>
        [HttpGet]
        [Route("api/blogsbypaging")]
        public async Task<IHttpActionResult> GetAllbyPaging(int? page, int? size)
        {
            var takePage = page ?? 1;
            var takeCount = size ?? Consts.PageSize; ;

            var calls = blogRepo.GetAll().AsNoTracking()
                .OrderBy(b => b.Id)
                            .Skip((takePage - 1) * takeCount)
                            .Take(takeCount);

            var calls2 = calls.Select(b => new BlogLiteVM { Id = b.Id, Description = b.Description, RowVersion = b.RowVersion, Url = b.Url });

            return Ok(await calls2.ToListAsync());
        }

    }
}
