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
    public class N_Area_Despacho
    {
        public static DataTable Listado_ad(string cTexto)
        {
            D_Area_Despacho Datos = new D_Area_Despacho();
            return Datos.Listado_ad(cTexto);
        }

        public static string Guardar_ad(int nOpcion, E_Area_Despacho oPropiedad)
        {
            D_Area_Despacho Datos = new D_Area_Despacho();
            return Datos.Guardar_ad(nOpcion, oPropiedad);
        }

        public static string Eliminar_ad(int Ncodigo)
        {
            D_Area_Despacho Datos = new D_Area_Despacho();
            return Datos.Eliminar_ad(Ncodigo);
        }
    }
}
