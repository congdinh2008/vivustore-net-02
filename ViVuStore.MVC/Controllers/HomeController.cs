using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ViVuStore.MVC.Data;
using ViVuStore.MVC.Models;
using ViVuStore.MVC.Repositories;
using ViVuStore.MVC.UnitOfWork;

namespace ViVuStore.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUnitOfWork _unitOfWork;

    public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    public IActionResult Index()
    {
        _unitOfWork.CategoryRepository.Add(new Category
        {
            Name = "Test Category",
            Description = "Test Description"
        });
        _unitOfWork.SaveChanges();
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
