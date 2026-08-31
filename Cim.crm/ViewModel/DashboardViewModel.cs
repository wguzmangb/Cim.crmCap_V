using Cim.crm.Models;

namespace Cim.crm.ViewModel {
    public class DashboardViewModel {

        
    public string Saludo { get; set; } = "Hola";
    public string NombreUsuario { get; set; } = "";


    public bool VeTodaLaCartera { get; set; }


    public int TotalEmpresas { get; set; }
    public int TotalContactos { get; set; }
    public int ProspectosPorAtender { get; set; }
    public int OportunidadesAbiertas { get; set; }
    public decimal ValorEmbudo { get; set; }


    public int ActividadesVencidas { get; set; }
    public List<Actividad> ActividadesPendientes { get; set; } = new();


    public List<Empresa> UltimasEmpresas { get; set; } = new();
    public List<EtapaResumen> Embudo { get; set; } = new();

    public bool SistemaVacio =>
        TotalEmpresas == 0 && TotalContactos == 0 && ProspectosPorAtender == 0;
}


public class EtapaResumen
{
    public string Etapa { get; set; } = "";
    public int Cuantas { get; set; }
    public decimal Importe { get; set; }

    
    public int Porcentaje { get; set; }
}

}
