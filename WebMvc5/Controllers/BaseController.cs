using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMvc5.DAL;
using WebMvc5.DAL.IRepository;

namespace WebMvc5.Controllers
{
    public class BaseController: Controller
    {
        protected IBlogRepository blogRepo;

        public BaseController()
        {
            blogRepo = new BlogRepository();
        }
    }
}