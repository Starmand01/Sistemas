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
    public class N_MesaAbierta
    {
        public static DataTable Listar_SubFamilias_RP(int nCodigo_pv)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Listar_SubFamilias_RP(nCodigo_pv);
        }

        public static DataTable ListarProductos_SubFamilias_RP(int nCodigo_pv, int nCodigo_sf)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.ListarProductos_SubFamilias_RP(nCodigo_pv,nCodigo_sf);
        }

        public static DataTable Busquedarapida_pr(string cTexto)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Busquedarapida_pr(cTexto);
        }

        public static DataTable Busqueda_cl(string cTexto)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Busqueda_cl(cTexto);
        }

        public static DataTable Guardar_RP(E_RegistroPedido oRP, DataTable Detalle_ticket)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Guadar_RP(oRP, Detalle_ticket);
        }

        public static DataTable Imprimir_comanda(string cImpresora, int nCodigo_ti)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Imprimir_comanda(cImpresora, nCodigo_ti);
        }

        public static DataTable Mostrar_Tickets_Mesa(int nCodigo_me)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Mostrar_Tickets_Mesa(nCodigo_me);
        }

        public static DataTable Mostrar_ticket(int nCodigo_ti)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Mostrar_ticket(nCodigo_ti);
        }

        public static DataTable ReImprimir_comanda(int nCodigo_ti)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.ReImprimir_comanda(nCodigo_ti);
        }

        public static DataTable Usuario_Admin(int nCodigo_us)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Usuario_Admin(nCodigo_us);
        }

        public static string Eliminar_ti(int nCodigo_ti, int nCodigo_me, string cObservacion)
        {
            D_MesaAbierta Datos = new D_MesaAbierta();
            return Datos.Eliminar_ti(nCodigo_ti, nCodigo_me, cObservacion);
        }
    }
}
