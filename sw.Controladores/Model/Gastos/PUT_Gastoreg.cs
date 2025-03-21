using sw.Entidades.Administracion.Coorporativo;
using sw.Entidades.Administracion.CentroTrabajo;
using sw.Entidades.Configuracion.Gastos;


namespace sw.Controladores.Model.Gastos
{
    public class PUT_Gastoreg
    {
        public int IdGastoreg { get; set; }
        public Decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public int E_GastoId { get; set; }
        public E_Gasto E_Gasto { get; set; }

    }
}
