﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sw.Controladores.Model.Productos.Departamento
{
    public class PUT_Departamento
    {
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public int E_CorporativoId { get; set; }
        public Boolean Status { get; set; }
    }
}
