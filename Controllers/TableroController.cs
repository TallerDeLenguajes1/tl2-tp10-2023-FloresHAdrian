using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_FloresHAdrian.Models;
namespace tl2_tp10_2023_FloresHAdrian.Controllers;

public class TableroController : Controller
{
    private readonly ILogger<TableroController> _logger;
    private ITableroRepository tablerosRepository;

    public TableroController(ILogger<TableroController> logger)
    {
        _logger = logger;
        tablerosRepository = new TableroRepository();
    }

    public IActionResult Index()
    {
        return View(tablerosRepository.GetAll());
    }

    [HttpGet]
    public IActionResult Create() // vista del form para ingresar
    {
        var tablero = new Tablero();
        tablero.IdUsuarioPropietario = 99;
        return View(tablero); //??
    }

    [HttpPost]
    public IActionResult Create(Tablero tablero){
        tablerosRepository.Create(tablero);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id){
        return View(tablerosRepository.GetById(id));
    }

    [HttpPost]
    public IActionResult Update(Tablero Tablero){
        tablerosRepository.Update(Tablero.Id,Tablero);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id){
        tablerosRepository.Remove(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
