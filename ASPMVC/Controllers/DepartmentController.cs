using ASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
    public class DepartmentController : Controller
    {
		public ActionResult Index()
		{
			DataManipulation data = new DataManipulation();
			List<Department> departments = data.Departments.ToList();

			return View(departments);
		}
	}
}