using ASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
    public class EmployeeController : Controller
    {
		public ActionResult Index(int departmentId)
		{
			DataManipulation data = new DataManipulation();
			List<Employee> employeeList = data.Employees.Where(emp => emp.DepartmentId == departmentId).ToList();

			return View(employeeList);
		}

		public ActionResult Details(int id)
		{
			DataManipulation data = new DataManipulation();
			Employee employee = data.Employees.Single(emp => emp.EmployeeId == id);

			return View(employee);
		}
	}
}