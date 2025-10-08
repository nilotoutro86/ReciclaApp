using Microsoft.AspNetCore.Mvc;
using ReciclaBackend.Data;
using ReciclaBackend.Models;
// Usaremos un DTO simple para recibir los datos del frontend

// Clase simple para recibir los datos de registro
public class RegisterDto
{
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    // Inyección de dependencia para acceder a la DB
    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto request)
    {
        // En un sistema real, aquí se verificaría si el email ya existe y se harían validaciones.
        // Para simplificar, usaremos la contraseña sin hashear (¡NO HACER EN PRODUCCIÓN!)

        var nuevoUsuario = new Usuario
        {
            Nombre = request.Nombre,
            Email = request.Email,
            // **NOTA IMPORTANTE**: En un proyecto real se debe usar una función de hash (ej. BCrypt)
            PasswordHash = request.Password, 
            Rol = "Usuario",
            PuntosAcumulados = 0
        };

        _context.Usuarios.Add(nuevoUsuario);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Usuario registrado con éxito." });
    }
}