using System.Collections.Generic;

namespace sw.Controladores.Model.Administracion.Coorporativo
{
    public class GET_CorpEmpSuc
    {
        public int id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public List<GET_Emp> children { get; set; }


    }
}
