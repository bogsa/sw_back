using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using sw.Entidades.Administracion.Coorporativo;
 

namespace sw.Entidades.Clientes.Cliente
{
    public class E_Clientes
    {
        public int IdCliente { get; set; }

        public int E_CoorporativoId { get; set; }
        public E_Coorporativo E_Coorporativo { get; set; }

        [Required]
        public string Nombre { get; set; }
        
        
        public string Telefono { get; set; }
        
        public string Email { get; set; }
        public Boolean Default { get; set; }
        public double Descuento { get; set; } 
        public Boolean  Dcto_Individual { get; set; }
        public Boolean Precio_Individual { get; set; }
        public int Precio_Asignado { get; set; }

    }
}
