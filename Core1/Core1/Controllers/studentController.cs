using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core1.Controllers
{
	public class studentController : Controller
	{
		ITIContext db;
		public studentController(ITIContext db)
		{
			this.db = db;
		}
		public IActionResult Index()
		{
			return View(db.Students.Include(d=>d.Dept).ToList());
		}
		public IActionResult create()
		{
			List<Department> dept = db.Departments.ToList();
			SelectList d = new SelectList(dept, "DeptID", "DeptName");
			ViewBag.dept = d;
			return View();
		}
		[HttpPost]
		public IActionResult create(Student s)
		{
			if (ModelState.IsValid)
			{
				db.Students.Add(s);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			else
			{
				List<Department> dept = db.Departments.ToList();
				SelectList d = new SelectList(dept, "DeptID", "DeptName");
				ViewBag.dept = d;
				return View();
			}
		}
		public ActionResult edit(int id)
		{
			Student s = db.Students.Where(n => n.StId == id).SingleOrDefault();
			List<Department> d = db.Departments.ToList();
			SelectList dept = new SelectList(d, "DeptId", "DeptName");
			ViewBag.dept = dept;
			return View(s);
		}
		[HttpPost]
		public ActionResult edit(Student s)
		{
			if (ModelState.IsValid)
			{
				db.Entry(s).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("index");
			}
			else
			{
				List<Department> dept = db.Departments.ToList();
				SelectList d = new SelectList(dept, "DeptId", "DeptName");
				ViewBag.dept = d;
				return View(s);
			}

		}
		public IActionResult delete(int id)
		{
			Student s = db.Students.Where(n => n.StId == id).SingleOrDefault();
			db.Students.Remove(s);
			db.SaveChanges();
			return RedirectToAction("index");
		}
	
	}
}

