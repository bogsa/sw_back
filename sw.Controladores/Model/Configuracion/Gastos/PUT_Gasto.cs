using sw.Entidades.Administracion.Coorporativo;

namespace sw.Controladores.Model.Configuracion.Gastos
{
    public class PUT_Gasto
    {
        public int IdGasto { get; set; }
        public string Descripcion { get; set; }

        public int E_CorporativoId { get; set; }
        public E_Coorporativo E_Corporativo { get; set; }
    }
}
