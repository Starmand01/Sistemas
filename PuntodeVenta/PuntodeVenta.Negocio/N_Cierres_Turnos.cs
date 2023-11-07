using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using PuntodeVenta.Datos;
using PuntodeVenta.Entidades;

namespace PuntodeVenta.Negocio
{
    public class N_Cierres_Turnos
    {
        public static string Abrir_turno(string cFecha_ct, int nCodigo_pv, int nCodigo_tu)
        {
            D_Cierres_Turnos Datos = new D_Cierres_Turnos();
            return Datos.Abrir_turno(cFecha_ct, nCodigo_pv, nCodigo_tu);
        }

        public static string Cerrar_turno(string cFecha_ct, int nCodigo_pv, int nCodigo_tu)
        {
            D_Cierres_Turnos Datos = new D_Cierres_Turnos();
            return Datos.Cerrar_turno(cFecha_ct, nCodigo_pv, nCodigo_tu);
        }

        public static DataTable Listado_pv(string cTexto)
        {
            D_Cierres_Turnos Datos = new D_Cierres_Turnos();
            return Datos.Listado_pv(cTexto);
        }

        public static DataTable Estado_gestion_turno_pv(int nCodigo_pv)
        {
            D_Cierres_Turnos Datos = new D_Cierres_Turnos();
            return Datos.Estado_gestion_turno_pv(nCodigo_pv);
        }
    }
}
