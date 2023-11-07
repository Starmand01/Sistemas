using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PuntodeVenta.Entidades;
using PuntodeVenta.Datos;

namespace PuntodeVenta.Negocio
{
    public class N_Familias
    {
        public static DataTable Listado_fa(string cTexto)
        {
            D_Familias Datos = new D_Familias();
            return Datos.Listado_fa(cTexto);
        }

        public static string Guardar_fa(int nOpcion, E_Familias oPropiedad)
        {
            D_Familias Datos = new D_Familias();
            return Datos.Guardar_fa(nOpcion, oPropiedad);
        }

        public static string Eliminar_fa(int Ncodigo)
        {
            D_Familias Datos = new D_Familias();
            return Datos.Eliminar_fa(Ncodigo);
        }
    }
}
