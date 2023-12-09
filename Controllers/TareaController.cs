using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_FloresHAdrian.Models;
namespace tl2_tp10_2023_FloresHAdrian.Controllers;

public class TareaController : Controller
{
    private readonly ILogger<TareaController> _logger;
    private ITareaRepository tareasRepository;

    public TareaController(ILogger<TareaController> logger)
    {
        _logger = logger;
        tareasRepository = new TareaRepository();
    }

    public IActionResult Index()
    {
        return View(tareasRepository.GetAllByTableId(1));
    }

    [HttpGet]
    public IActionResult Create() // vista del form para ingresar
    {
        var tarea = new Tarea();
        tarea.IdTablero = 1;
        return View(new Tarea()); //??
    }

    [HttpPost]
    public IActionResult Create(Tarea tarea){
        tareasRepository.Create(tarea.IdTablero, tarea);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id){
        return View(tareasRepository.GetById(id));
    }

    [HttpPost]
    public IActionResult Update(Tarea Tarea){
        tareasRepository.Update(Tarea.Id,Tarea);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id){
        tareasRepository.Remove(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
