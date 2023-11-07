using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuntodeVenta.Entidades
{
    public class E_RegistroPedido
    {
        public string Fecha_emision { get; set; }
        public int Codigo_cl { get; set; }
        public string Nrodocumento_cl { get; set; }
        public string Cliente { get; set; }
        public int Codigo_me { get; set; }
        public decimal Total_ti {get;set; }
        public int Codigo_tu { get; set; }
        public int Codigo_us { get; set; }
    }
}
