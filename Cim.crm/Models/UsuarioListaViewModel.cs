namespace Cim.crm.Models {
    public class UsuarioListaViewModel
{
    public int Id { get; set; }
    public string NombreCompleto { get; set; } = "";
    public string? Puesto { get; set; }
    public string Email { get; set; } = "";
    public string Rol { get; set; } = "";
    public bool Activo { get; set; }
    public DateTime FechaRegistro { get; set; }

   
    public bool EsUnoMismo { get; set; }

    public string Iniciales
    {
        get
        {
            var partes = NombreCompleto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length == 0) return Email.Length > 0 ? Email[..1].ToUpper() : "?";
            var ini = partes[0][..1];
            if (partes.Length > 1) ini += partes[1][..1];
            return ini.ToUpper();
        }
    }
}

}
