using MagazinOnline.Models;
using MagazinOnline.Models.DatabaseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MagazinOnline.Controllers
{
    public class MagazinController : Controller
    {
        public ActionResult MagazinOnline()
        {
            ViewBag.Message = "Vizualizați stocul magazinului dumneavoastră";
            return View();
        }

    }
}