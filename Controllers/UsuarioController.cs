using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_FloresHAdrian.Models;
namespace tl2_tp10_2023_FloresHAdrian.Controllers;

public class UsuarioController : Controller
{
    private readonly ILogger<UsuarioController> _logger;
    private IUsuariosRepository usuariosRepository;

    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
        usuariosRepository = new UsuariosRepository();
    }

    public IActionResult Index()
    {
        return View(usuariosRepository.GetAll());
    }

    [HttpGet]
    public IActionResult Create() // vista del form para ingresar
    {
        return View(new Usuario()); //??
    }

    [HttpPost]
    public IActionResult Create(Usuario usuario){
        usuariosRepository.Create(usuario);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Update(int id){
        return View(usuariosRepository.GetById(id));
    }

    [HttpPost]
    public IActionResult Update(Usuario usuario){
        usuariosRepository.Update(usuario.id,usuario);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id){
        usuariosRepository.Remove(id);
        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
