using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using events.tac.local.Business;

namespace events.tac.local.Controllers
{
    public class NavigationController : Controller
    {
        private readonly NavigationBuilder _builder;

        public NavigationController() : this(new NavigationBuilder()) { }

        public NavigationController(NavigationBuilder builder)
        {
            _builder = builder;
        }

        public ActionResult Index()
        {
            return View(_builder.Build());
        }
    }
}