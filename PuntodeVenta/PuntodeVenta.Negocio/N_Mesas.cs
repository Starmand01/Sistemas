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
    public class N_Mesas
    {
        public static DataTable Listado_me(string cTexto)
        {
            D_Mesas Datos = new D_Mesas();
            return Datos.Listado_me(cTexto);
        }

        public static string Guardar_me(int nOpcion, E_Mesas oPropiedad)
        {
            D_Mesas Datos = new D_Mesas();
            return Datos.Guardar_me(nOpcion, oPropiedad);
        }

        public static string Eliminar_me(int Ncodigo)
        {
            D_Mesas Datos = new D_Mesas();
            return Datos.Eliminar_me(Ncodigo);
        }
        public static DataTable Listado_pv(string cTexto)
        {
            D_Mesas Datos = new D_Mesas();
            return Datos.Listado_pv(cTexto);
        }
    }
}
