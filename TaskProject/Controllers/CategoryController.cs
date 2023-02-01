using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskProject.Data;
using TaskProject.Models;

namespace TaskProject.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Category
        public IActionResult Index()
        {
            IEnumerable<Category> categoryList = _context.categories;
              return View(categoryList);
        }

        // GET: Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
			_context.categories.Add(category);
			_context.SaveChanges();
			return RedirectToAction("Index");
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var category = _context.categories.Find(id);
            var model = new Category
            {
                Values = _context.categories.Select(x => new SelectListItem
                {
                    Value = String.Join("$", new string[]
                    {
                        x.ParentCategoryId.ToString(),
                        x.CategoryId.ToString()
                    }),
                    Text = x.Name
                })
            };
            ViewBag.message = model.Values;
            return View(category);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditPOSt(Category category)
        {
            _context.categories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Category/Delete/5
        public IActionResult Delete(int? id)
        {

            var category = _context.categories.Find(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Category obj)
        {

            var subCategoris = _context.categories.Where(modal => modal.ParentCategoryId == obj.CategoryId);
            _context.categories.RemoveRange(subCategoris);
            _context.categories.Remove(obj);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        // Get action for Subcategory
        public IActionResult SubCategory(int id)
        {
            ViewBag.id = id;
            return View();
        }

        [HttpPost, ActionName("SubCategory")]
        [ValidateAntiForgeryToken]
        public IActionResult SubCategory(Category obj)
        {
                _context.categories.Add(obj);
                _context.SaveChanges();
                return RedirectToAction("Index");
        }
        private bool CategoryExists(int id)
        {
          return _context.categories.Any(e => e.CategoryId == id);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var categoryList = _context.categories.ToList();
            return Json(new{ data=categoryList});
        }
        #endregion
    }
}
