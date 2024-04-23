using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Configuracion.CentroTrabajo    
{
    public class POST_CentroTrabajo
    {
        public int E_EmpresaId { get; set; }

        public string Nombre { get; set; }
        public string Responsable { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Cve_Gerente { get; set; }
        public string Serie { get; set; }
        public Boolean Activo { get; set; }
        public int FolioInicial { get; set; }
        public string LugarExpedicion { get; set; }
        public string MensajePersonal { get; set; }
  public string TipoCentroTrabajo { get; set; }


    }
}
