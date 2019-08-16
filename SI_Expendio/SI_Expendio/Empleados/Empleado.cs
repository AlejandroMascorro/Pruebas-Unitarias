using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SI_Expendio
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apelldo_p { get; set; }
        public string Apellido_m { get; set; }
        public string Fecha_registro { get; set; }
        public string RFC { get; set; }
        public string NSS { get; set; }

        public Empleado() { }

        public Empleado(int pId, string pNombre, string pApellido_p, string pApellido_m, string pFecha_reg, string pRFC, string pNSS)

        {
            this.Id = pId;
            this.Nombre = pNombre;
            this.Apelldo_p = pApellido_p;
            this.Apellido_m = pApellido_m;
            this.Fecha_registro = pFecha_reg;
            this.RFC = pRFC;
            this.NSS = pNSS;
        }
    }
}
