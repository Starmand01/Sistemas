﻿using System;
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
    public class N_Unidades_Medidas
    {
        public static DataTable Listado_um(string cTexto)
        {
            D_Unidades_Medidas Datos = new D_Unidades_Medidas();
            return Datos.Listado_um(cTexto);
        }

        public static string Guardar_um(int nOpcion, E_Unidades_Medidas oPropiedad)
        {
            D_Unidades_Medidas Datos = new D_Unidades_Medidas();
            return Datos.Guardar_um(nOpcion, oPropiedad);
        }

        public static string Eliminar_um(int Ncodigo)
        {
            D_Unidades_Medidas Datos = new D_Unidades_Medidas();
            return Datos.Eliminar_um(Ncodigo);
        }
    }
}
