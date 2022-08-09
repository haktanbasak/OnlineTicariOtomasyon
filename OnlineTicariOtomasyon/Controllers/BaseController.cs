using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        protected Context db;

        public BaseController()
        {
            if(db == null)
            {
                db = new Context();
            }
        }
    }
}