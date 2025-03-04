using Book.DataAccess.Data;
using Book.DataAccess.Repository.IRepository;
using Book.Models;
using Book.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Book.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> obj = _unitOfWork.Product.GetAll(includeProperties:"Category").ToList();
            return View(obj);
        }
        //public IActionResult TestCategories()
        //{
        //    var categories = _unitOfWork.Category.GetAll().ToList();
        //    return Json(categories);
        //}

        public IActionResult Upsert(int? Id)
        {
            
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().ToList()
                .Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };
            if (Id == null || Id == 0)
            {
                return View(productVM);
            }
            else
            {
                productVM.Product = _unitOfWork.Product.Get(u => u.Id == Id);
                return View(productVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\product");

                    if(!string.IsNullOrEmpty(obj.Product.ImageURL))
                    {
                            var oldImagePath = 
                                Path.Combine(wwwRootPath, obj.Product.ImageURL.TrimStart('/'));

                            if (System.IO.File.Exists(oldImagePath))
                                System.IO.File.Delete(oldImagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                            file.CopyTo(fileStream);
                    }
                    obj.Product.ImageURL = @"\images\product\" + fileName;
                }

                if (obj.Product.Id == 0 || obj.Product.Id == null)
                    _unitOfWork.Product.Add(obj.Product);
                else
                    _unitOfWork.Product.Update(obj.Product);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
            }
            else
            {
                    obj.CategoryList = _unitOfWork.Category.GetAll().ToList()
                    .Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                    return View(obj);
            }
            
        }
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null)
        //        return NotFound();
        //    Product? ProductFromDb = _unitOfWork.Product.Get(u => u.Id == id);
        //    return View(ProductFromDb);
        //}
        //[HttpPost]
        //public IActionResult Edit(ProductVM obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Product.Update(obj.Product);
        //        _unitOfWork.Save();
        //        return RedirectToAction("Index", "Product");
        //    }
        //    return View(obj);
        //}
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();
            Product? product = _unitOfWork.Product.Get(u => u.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult Delete(ProductVM obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Remove(obj.Product);
                _unitOfWork.Save();
                return RedirectToAction("Index", "Product");
            }
            return View(obj);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll(int id)
        {
            List<Product> obj = _unitOfWork.Product.GetAll(includeProperties: "Category").ToList();
            return Json(new {data = obj});
        }

        #endregion

    }
}
