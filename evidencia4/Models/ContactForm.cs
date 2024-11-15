namespace evidencia4.Models;

using Microsoft.AspNetCore.Mvc;

using System.ComponentModel.DataAnnotations;

public class ContactForm
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "Por favor ingrese un email válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El teléfono es requerido")]
    [Phone(ErrorMessage = "Por favor ingrese un número de teléfono válido")]
    [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Por favor seleccione su sabor favorito")]
    public string FavoriteFlavor { get; set; }

    [Required(ErrorMessage = "El mensaje es requerido")]
    [StringLength(500, MinimumLength = 10, ErrorMessage = "El mensaje debe tener entre 10 y 500 caracteres")]
    public string Message { get; set; }

    [Range(18, 100, ErrorMessage = "Debe ser mayor de 18 años")]
    public int Age { get; set; }
}

public class HomeController : Controller
{
    [HttpGet]
    public IActionResult Contact()
    {
        return View(new ContactForm());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Contact(ContactForm model)
    {
        if (ModelState.IsValid)
        {
        
            TempData["Success"] = "¡Gracias por contactarnos! Nos pondremos en contacto pronto.";
            return RedirectToAction("Contact");
        }
        return View(model);
    }
}