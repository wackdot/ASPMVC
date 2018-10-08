using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}

		public string Details(string id, string name)
		{
			return "Id " + id + " Name " + name;
		}

		public ActionResult CountryList()
		{
			ViewBag.Countries = new List<string>()
			{
				"India",
				"US",
				"UK",
				"Canada"
			};

			ViewData["Countries"] = new List<string>()
			{
				"India",
				"US",
				"UK",
				"Canada"
			};

			return View();
		}
	}
}