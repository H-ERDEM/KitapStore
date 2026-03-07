using BookApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookApp.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {

    }

    public IActionResult Index(string searchString, int? category)
    {
        var books = Repository.Products.Where(p => p.IsActive).ToList();
        if (!string.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            books = books.Where(b => !string.IsNullOrEmpty(b.BookName) && b.BookName.ToLower().Contains(searchString.ToLower())).ToList();
        }

        if (category.HasValue && category != 0)
        {
            books = books.Where(b => b.CategoryId == category).ToList();
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category);
        return View(books);
    }

    public IActionResult Privacy()
    {
        return View(Repository.Products);
    }

    public IActionResult Admin()
    {
        return View(Repository.Products);
    }

    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductBook model, IFormFile? imageFile)
    {
        if (ModelState.IsValid)
        {
            model.BookId = (Repository.Products.Count > 0 ? Repository.Products.Max(p => p.BookId) : 0) + 1;
            
            if (imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                model.Image = "/img/" + randomName;
            }
            else
            {
                model.Image = "/img/1.png"; // Varsayılan resim
            }

            Repository.Products.Add(model);
            return RedirectToAction("Admin");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(model);
    }

    public IActionResult Edit(int? id)
    {
        if (id == null) return NotFound();
        var entity = Repository.Products.FirstOrDefault(p => p.BookId == id);
        if (entity == null) return NotFound();
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", entity.CategoryId);
        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, ProductBook model, IFormFile? imageFile)
    {
        if (id != model.BookId) return NotFound();

        if (ModelState.IsValid)
        {
            var entity = Repository.Products.FirstOrDefault(p => p.BookId == id);
            if (entity == null) return NotFound();

            if (imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extension}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                // Eski resmi sil (Varsayılan resimler hariç)
                if (!string.IsNullOrEmpty(entity.Image))
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", entity.Image.TrimStart('/'));
                    if (System.IO.File.Exists(oldPath) && Path.GetFileName(oldPath).Length > 10)
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }
                entity.Image = "/img/" + randomName;
            }

            entity.BookName = model.BookName;
            entity.PageCount = model.PageCount;
            entity.IsActive = model.IsActive;
            entity.CategoryId = model.CategoryId;

            return RedirectToAction("Admin");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", model.CategoryId);
        return View(model);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null) return NotFound();
        var entity = Repository.Products.FirstOrDefault(p => p.BookId == id);
        if (entity == null) return NotFound();
        return View(entity);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var entity = Repository.Products.FirstOrDefault(p => p.BookId == id);
        if (entity != null)
        {
            // Kitap silinirken resmini de sil (Varsayılan resimler hariç)
            if (!string.IsNullOrEmpty(entity.Image))
            {
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", entity.Image.TrimStart('/'));
                if (System.IO.File.Exists(oldPath) && Path.GetFileName(oldPath).Length > 10)
                {
                    System.IO.File.Delete(oldPath);
                }
            }
            Repository.DeleteProduct(entity);
        }
        return RedirectToAction("Admin");
    }

    public IActionResult Details(int? id)
    {
        if (id == null) return NotFound();
        var entity = Repository.Products.FirstOrDefault(p => p.BookId == id);
        if (entity == null) return NotFound();
        return View(entity);
    }

    public IActionResult CreateCategory()
    {
        return View();
    }

    [HttpPost]
    public IActionResult CreateCategory(Category model)
    {
        if (ModelState.IsValid)
        {
            model.CategoryId = (Repository.Categories.Count > 0 ? Repository.Categories.Max(c => c.CategoryId) : 0) + 1;
            Repository.Categories.Add(model);
            return RedirectToAction("Admin");
        }
        return View(model);
    }
}