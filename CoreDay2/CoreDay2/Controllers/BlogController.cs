using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDay2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CoreDay2.Controllers
{
	public class BlogController : Controller
	{
		BlogContext db;
		public BlogController(BlogContext db)
		{
			this.db = db;
		}
		public IActionResult Index()
		{
			return View(db.posts.ToList());
		}
		public IActionResult create()
		{
			SelectList st = new SelectList(db.blogs.ToList(), "Id", "title");
			ViewBag.Blog = st;
			return View();
		}
		[HttpPost]
		public IActionResult create(Post p)
		{
			db.posts.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult details(int id)
		{
			Post p = db.posts.Where(b => b.Id == id).SingleOrDefault();
			return View(p);
		}
		
		public IActionResult edit(int id)
		{
			Post p = db.posts.Where(b => b.Id == id).SingleOrDefault();
			SelectList st = new SelectList(db.blogs.ToList(), "Id", "title");
			ViewBag.Blog = st;
			return View(p);
		}
		[HttpPost]
		public IActionResult edit(Post p)
		{
			db.Entry(p).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public IActionResult delete(int id)
		{
			Post p = db.posts.Where(b => b.Id == id).SingleOrDefault();
			db.Remove(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}
