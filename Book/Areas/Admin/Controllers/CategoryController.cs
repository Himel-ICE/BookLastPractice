using Book.DataAccess.Data;
using Book.DataAccess.Repository.IRepository;
using Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Category> categories = _unitOfWork.Category.GetAll().ToList();
            return View(categories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj == null || obj.Name == obj.DisplayOrder.ToString())
                ModelState.AddModelError("Name", "Name and Display Order can not be same");

            if ((obj.Name != null) && (obj.DisplayOrder != null))
            {
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id);
            return View(categoryFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if ((obj.Name != null) && (obj.DisplayOrder != null))
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Category? category = _unitOfWork.Category.Get(u => u.Id == id);
            return View(category);
        }
        [HttpPost]
        public IActionResult Delete(Category obj)
        {
            if ((obj.Name != null) && (obj.DisplayOrder != null))
            {
                _unitOfWork.Category.Remove(obj);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
        }
    }
}
