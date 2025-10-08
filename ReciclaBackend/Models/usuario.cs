namespace ReciclaBackend.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // Guardar la contraseña hasheada
        public string Rol { get; set; } = "Usuario"; // Rol inicial (Req. 11)
        public int PuntosAcumulados { get; set; } = 0; // Puntos iniciales (Req. 9)
    }
}