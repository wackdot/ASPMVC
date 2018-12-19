using ASPMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
	public class EmployeeController : Controller
	{
		public ActionResult Index()
		{
			EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
			List<Employee> employees = employeeBusinessLayer.Employees.ToList();

			return View(employees);
		}

		[HttpGet]
		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(FormCollection fc)
		{
			Employee employee = new Employee();
			employee.Name = fc["Name"];
			employee.Gender = fc["Gender"];
			employee.City = fc["City"];
			employee.DepartmentId = Convert.ToInt32(fc["DepartmentId"]);

			EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
			employeeBusinessLayer.AddEmployee(employee);

			return RedirectToAction("Index");
		}

		//[HttpPost]
		//public ActionResult Create(string name, string gender, string city, int departmentId)
		//{
		//	Employee employee = new Employee();
		//	employee.Name = name;
		//	employee.Gender = gender;
		//	employee.City = city;
		//	employee.DepartmentId = departmentId;

		//	EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
		//	employeeBusinessLayer.AddEmployee(employee);

		//	return RedirectToAction("Index");
		//}
	}
}