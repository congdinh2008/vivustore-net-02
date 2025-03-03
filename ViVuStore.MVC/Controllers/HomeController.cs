using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViVuStore.MVC.Models;
using ViVuStore.MVC.Services;

namespace ViVuStore.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ICategoryService _categoryService;
    public HomeController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        int result = _categoryService.Add(new Category
        {
            Name = "Fashion",
            Description = "This is fashion category",
        });

        ViewBag.Message = result > 0 ? "Success" : "Failed";

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
