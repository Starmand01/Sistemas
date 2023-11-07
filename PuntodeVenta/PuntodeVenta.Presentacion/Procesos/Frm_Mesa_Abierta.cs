using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sol_PuntoVenta.Negocio;
using Sol_PuntoVenta.Entidades;
using System.IO;

namespace Sol_PuntoVenta.Presentacion.Procesos
{
    public partial class Frm_Mesa_Abierta : Form
    {
        #region "Mis Variables"
            int nCodigo_cl=0;
        #endregion

        #region "Variables para Generar Comandas"
        private int x1Codigo_ti;
        private string x1Impresora;
        private string x1Descripcion_pv;
        private string x1Fecha_emision;
        private string x1Descripcion_tu;
        private string x1Nombre_us;
        private string x1Descripcion_ca;
        private string x1Descripcion_me;
        private string x1Cliente;
        private string x1Nrodocumento_cl;
        private string x1obsanulado_ti;

        public int X1Codigo_ti { get => x1Codigo_ti; set => x1Codigo_ti = value; }
        public string X1Impresora { get => x1Impresora; set => x1Impresora = value; }
        public string X1Descripcion_pv { get => x1Descripcion_pv; set => x1Descripcion_pv = value; }
        public string X1Fecha_emision { get => x1Fecha_emision; set => x1Fecha_emision = value; }
        public string X1Descripcion_tu { get => x1Descripcion_tu; set => x1Descripcion_tu = value; }
        public string X1Nombre_us { get => x1Nombre_us; set => x1Nombre_us = value; }
        public string X1Descripcion_ca { get => x1Descripcion_ca; set => x1Descripcion_ca = value; }
        public string X1Descripcion_me { get => x1Descripcion_me; set => x1Descripcion_me = value; }
        public string X1Cliente { get => x1Cliente; set => x1Cliente = value; }
        public string X1Nrodocumento_cl { get => x1Nrodocumento_cl; set => x1Nrodocumento_cl = value; }
        public string X1obsanulado_ti { get => X1obsanulado_ti; set => X1obsanulado_ti = value; }
        #endregion

        #region "Variables y Propiedades"
        DataTable TablaDetalle = new DataTable();
        private int _Codigo_pr1;
        private string _Descripcion_pr1;
        private string _Preciounitario_pr1;
        private string _Impresora1;
        private Image _Imagen_pr1;
        private string _Archivo_txt1;

        public int Codigo_pr1 { get => _Codigo_pr1; set => _Codigo_pr1 = value; }
        public string Descripcion_pr1 { get => _Descripcion_pr1; set => _Descripcion_pr1 = value; }
        public string Preciounitario_pr1 { get => _Preciounitario_pr1; set => _Preciounitario_pr1 = value; }
        public string Impresora1 { get => _Impresora1; set => _Impresora1 = value; }
        public Image Imagen_pr1 { get => _Imagen_pr1; set => _Imagen_pr1 = value; }
        public string Archivo_txt1 { get => _Archivo_txt1; set => _Archivo_txt1 = value; }
       

        #endregion

        #region "Método de llenado de los productos"
        private void LlenarListadoProductos( FlowLayoutPanel Contenedor)
        {
            Contenedor.Controls.Clear();
            int nCodigo_pv, nCodigo_sf;
            byte[] bImagen = new byte[0];
            DataTable Tabla1 = new DataTable();
            
            nCodigo_pv =Convert.ToInt32(Lbl_codigo_pv.Text);
            nCodigo_sf = Convert.ToInt32(Dgv_listado_sf.CurrentRow.Cells["codigo_sf"].Value);

            Tabla1 = N_MesaAbierta.ListarProductos_SubFamilias_RP(nCodigo_pv, nCodigo_sf);
            if (Tabla1.Rows.Count>0)
            {
                for (int nFila = 0; nFila <= Tabla1.Rows.Count-1; nFila++)
                {
                    Codigo_pr1 =Convert.ToInt32(Tabla1.Rows[nFila][0]);
                    Descripcion_pr1= Convert.ToString(Tabla1.Rows[nFila][1]);
                    Preciounitario_pr1= Convert.ToString(Tabla1.Rows[nFila][2]);

                    bImagen = (byte[])Tabla1.Rows[nFila][3];
                    MemoryStream ms = new MemoryStream(bImagen);
                    Imagen_pr1 = Image.FromStream(ms);

                    Impresora1 = Convert.ToString(Tabla1.Rows[nFila][4]);
                    Archivo_txt1 = Lbl_archivo_txt.Text.Trim();

                    //Creamos el control producto para cargar en el Layout 
                    Controles.MiProducto oProducto = new Controles.MiProducto();
                    oProducto.Codigo_pr = Codigo_pr1;
                    oProducto.Descripcion_pr = Descripcion_pr1;
                    oProducto.Preciounitario_pr = Preciounitario_pr1;
                    oProducto.Imagen_pr= Imagen_pr1;
                    oProducto.Impresora = Impresora1.Trim();
                    oProducto.Archivo_txt = Archivo_txt1;

                    //Añadimos el control producto al Layout
                    Contenedor.Controls.Add(oProducto);
                }
            }
            
        }

        private void Crear_TablaDetalle()
        {
            this.TablaDetalle = new DataTable("TablaDetalles");
            this.TablaDetalle.Columns.Add("Descripcion_pr", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Preciounitario_pr", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Cantidad", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Total", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Obs", System.Type.GetType("System.String"));
            this.TablaDetalle.Columns.Add("Codigo_pr", System.Type.GetType("System.Int32"));
            this.TablaDetalle.Columns.Add("Impresora", System.Type.GetType("System.String"));

            Dgv_detalle.DataSource = this.TablaDetalle;

            Dgv_detalle.Columns[0].Width = 210;
            Dgv_detalle.Columns[0].HeaderText="PRODUCTO";
            Dgv_detalle.Columns[1].Width = 75;
            Dgv_detalle.Columns[1].HeaderText = "P.UNIT.";
            Dgv_detalle.Columns[2].Width = 75;
            Dgv_detalle.Columns[2].HeaderText = "CANTIDAD";
            Dgv_detalle.Columns[3].Width = 75;
            Dgv_detalle.Columns[3].HeaderText = "TOTAL S/.";
            Dgv_detalle.Columns[4].Width = 40;
            Dgv_detalle.Columns[4].HeaderText = "OBS.";
            Dgv_detalle.Columns[5].Visible = false;
            Dgv_detalle.Columns[6].Visible = false;


        }

        private void Agregar_item(string cDescripcion_pr,
                                  string cPreciounitario_pr,
                                  string cCantidad,
                                  string cTotal,
                                  string cObs,
                                  int nCodigo_pr,
                                  string cImpresora)
        {
            DataRow Fila = TablaDetalle.NewRow();
            Fila["Descripcion_pr"] = cDescripcion_pr;
            Fila["Preciounitario_pr"] = cPreciounitario_pr;
            Fila["Cantidad"] = cCantidad;
            Fila["Total"] = cTotal;
            Fila["Obs"] = cObs;
            Fila["Codigo_pr"] = nCodigo_pr;
            Fila["Impresora"] = cImpresora;
            this.TablaDetalle.Rows.Add(Fila);
        }
        #endregion

        #region "Método para busqueda rápida de productos"
        private void Formato_busqueda_pr()
        {
            Dgv_1.Columns[0].Width = 250;
            Dgv_1.Columns[0].HeaderText = "PRODUCTO";
            Dgv_1.Columns[1].Width = 60;
            Dgv_1.Columns[1].HeaderText = "P.UNIT.";
            Dgv_1.Columns[2].Width = 250;
            Dgv_1.Columns[2].HeaderText = "SUBFAMILIA";
            Dgv_1.Columns[3].Visible = false;
            Dgv_1.Columns[4].Visible = false;
        }

        private void Busquedarapida_pr(string cTexto)
        {
            try
            {
                Dgv_1.DataSource = N_MesaAbierta.Busquedarapida_pr(cTexto);
                this.Formato_busqueda_pr();
            }
            catch (Exception ex) 
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_dgv_busqueda_pr()
        {
            string bDescripcion_pr;
            string bPreciounitario_pr;
            int bCodigo_pr;
            string bImpresora;

            bDescripcion_pr =Convert.ToString(Dgv_1.CurrentRow.Cells["descripcion_pr"].Value);
            bPreciounitario_pr = Convert.ToString(Dgv_1.CurrentRow.Cells["precio_unitario"].Value);
            bCodigo_pr = Convert.ToInt32(Dgv_1.CurrentRow.Cells["codigo_pr"].Value);
            bImpresora = Convert.ToString(Dgv_1.CurrentRow.Cells["impresora"].Value);

            this.Agregar_item(bDescripcion_pr,
                              bPreciounitario_pr,
                              "1.00",
                              bPreciounitario_pr,
                              "",
                              bCodigo_pr,
                              bImpresora);

            TablaDetalle.AcceptChanges();
            const int nColumna = 3;
            decimal nSuma = 0;
            foreach (DataGridViewRow nRow in Dgv_detalle.Rows)
            {
                nSuma += Convert.ToDecimal(nRow.Cells[nColumna].Value);
            }
            Lbl_total.Text = Convert.ToString(nSuma);
        }
        #endregion

        #region "Método para busqueda de Clientes"
        private void Formato_busqueda_cl()
        {
            Dgv_2.Columns[0].Width = 50;
            Dgv_2.Columns[0].HeaderText = "TIPO DOC.";
            Dgv_2.Columns[1].Width = 120;
            Dgv_2.Columns[1].HeaderText = "NRO. DOC..";
            Dgv_2.Columns[2].Width = 290;
            Dgv_2.Columns[2].HeaderText = "CLIENTE";
            Dgv_2.Columns[3].Visible = false;
            
        }

        private void Busqueda_cl(string cTexto)
        {
            try
            {
                Dgv_2.DataSource = N_MesaAbierta.Busqueda_cl(cTexto);
                this.Formato_busqueda_cl();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Selecciona_dgv_busqueda_cl()
        {            
            Txt_cliente.Text = Convert.ToString(Dgv_2.CurrentRow.Cells["cliente"].Value);
            Txt_nrodocumento.Text = Convert.ToString(Dgv_2.CurrentRow.Cells["nrodocumento_cl"].Value);
            nCodigo_cl = Convert.ToInt32(Dgv_2.CurrentRow.Cells["codigo_cl"].Value);
        }
        #endregion

        #region "Imprimir Comanda"
        private void Imprimir(object sender, PrintPageEventArgs e)
        {
            DataTable TablaImprimir = new DataTable();
            Font Font1 = new Font("Arial",10,FontStyle.Regular,GraphicsUnit.Point);
            Font Font2 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            Font Font3 = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);
            int Ancho = 250;
            int y = 20;

            e.Graphics.DrawString("Comanda Ticket # "+x1Codigo_ti,Font1,Brushes.Black,new RectangleF(0,y+=20,Ancho,20));
            e.Graphics.DrawString("Punto de Venta: " + x1Descripcion_pv, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Fecha emisión: " + X1Fecha_emision, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Turno: " + x1Descripcion_tu, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Usuario: " + X1Nombre_us, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Cargo: " + X1Descripcion_ca, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Mesa # " + X1Descripcion_me, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Cliente: " + X1Cliente, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Nro. Doc.: " + x1Nrodocumento_cl, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("-------- PRODUCTOS --------: ", Font2, Brushes.Black, new RectangleF(0, y += 30, Ancho, 20));
            //Imprimir detalle de la comanda
            TablaImprimir = N_MesaAbierta.Imprimir_comanda(X1Impresora,X1Codigo_ti);
            for (int yFila = 0; yFila <= TablaImprimir.Rows.Count-1; yFila++)
            {
                e.Graphics.DrawString(Convert.ToString(TablaImprimir.Rows[yFila][0]) +" "+
                                      Convert.ToString(TablaImprimir.Rows[yFila][1]),
                                      Font3, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
                //observación por cada producto
                string yObs = Convert.ToString(TablaImprimir.Rows[yFila][2]);
                if (yObs.Length>0)
                {
                    e.Graphics.DrawString("    |-> "+yObs,
                                    Font3, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
                }
                //fin de la observación
            }
            //fin de comanda x impresora
        }

        private void Reimprimir(object sender, PrintPageEventArgs e)
        {
            DataTable TablaImprimir = new DataTable();
            Font Font1 = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            Font Font2 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            Font Font3 = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);
            int Ancho = 250;
            int y = 20;

            e.Graphics.DrawString("<REIMPRESIÓN> ", Font1, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Comanda Ticket # " + x1Codigo_ti, Font1, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Punto de Venta: " + x1Descripcion_pv, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Fecha emisión: " + X1Fecha_emision, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Turno: " + x1Descripcion_tu, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Usuario: " + X1Nombre_us, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Cargo: " + X1Descripcion_ca, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Mesa # " + X1Descripcion_me, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Cliente: " + X1Cliente, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Nro. Doc.: " + x1Nrodocumento_cl, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("-------- PRODUCTOS --------: ", Font2, Brushes.Black, new RectangleF(0, y += 30, Ancho, 20));
            //Imprimir detalle de la comanda
            TablaImprimir = N_MesaAbierta.Imprimir_comanda(X1Impresora, X1Codigo_ti);
            for (int yFila = 0; yFila <= TablaImprimir.Rows.Count - 1; yFila++)
            {
                e.Graphics.DrawString(Convert.ToString(TablaImprimir.Rows[yFila][0]) + " " +
                                      Convert.ToString(TablaImprimir.Rows[yFila][1]),
                                      Font3, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
                //observación por cada producto
                string yObs = Convert.ToString(TablaImprimir.Rows[yFila][2]);
                if (yObs.Length > 0)
                {
                    e.Graphics.DrawString("    |-> " + yObs,
                                    Font3, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
                }
                //fin de la observación
            }
            //fin de comanda x impresora
        }

        private void Reimprimir_anulado(object sender, PrintPageEventArgs e)
        {
            DataTable TablaImprimir = new DataTable();
            Font Font1 = new Font("Arial", 10, FontStyle.Regular, GraphicsUnit.Point);
            Font Font2 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point);
            Font Font3 = new Font("Arial", 7, FontStyle.Regular, GraphicsUnit.Point);
            int Ancho = 250;
            int y = 20;

            e.Graphics.DrawString("<ANULACIÓN DE CUENTA> ", Font1, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Comanda Ticket # " + x1Codigo_ti, Font1, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("MOTIVO: " + x1obsanulado_ti, Font1, Brushes.Black, new RectangleF(0, y += 20, Ancho, 50));

            e.Graphics.DrawString("Punto de Venta: " + x1Descripcion_pv, Font2, Brushes.Black, new RectangleF(0, y += 50, Ancho, 20));
            e.Graphics.DrawString("Fecha emisión: " + X1Fecha_emision, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Turno: " + x1Descripcion_tu, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Usuario: " + X1Nombre_us, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Cargo: " + X1Descripcion_ca, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Mesa # " + X1Descripcion_me, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Cliente: " + X1Cliente, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("Nro. Doc.: " + x1Nrodocumento_cl, Font2, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
            e.Graphics.DrawString("-------- PRODUCTOS --------: ", Font2, Brushes.Black, new RectangleF(0, y += 30, Ancho, 20));
            //Imprimir detalle de la comanda
            TablaImprimir = N_MesaAbierta.Imprimir_comanda(X1Impresora, X1Codigo_ti);
            for (int yFila = 0; yFila <= TablaImprimir.Rows.Count - 1; yFila++)
            {
                e.Graphics.DrawString(Convert.ToString(TablaImprimir.Rows[yFila][0]) + " " +
                                      Convert.ToString(TablaImprimir.Rows[yFila][1]),
                                      Font3, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
                //observación por cada producto
                string yObs = Convert.ToString(TablaImprimir.Rows[yFila][2]);
                if (yObs.Length > 0)
                {
                    e.Graphics.DrawString("    |-> " + yObs,
                                    Font3, Brushes.Black, new RectangleF(0, y += 20, Ancho, 20));
                }
                //fin de la observación
            }
            //fin de comanda x impresora
        }
        #endregion

        #region "Mostrar Tickets de la Mesa"
        private void Formato_tickets()
        {
            Dgv_tickets.Columns[0].Width = 100;
            Dgv_tickets.Columns[0].Visible = false;
            Dgv_tickets.Columns[0].ReadOnly = true;
            Dgv_tickets.Columns[1].Width = 100;
            Dgv_tickets.Columns[1].ReadOnly = true;
            Dgv_tickets.Columns[1].HeaderText = "CÓDIGO TI";
            Dgv_tickets.Columns[2].Width = 240;
            Dgv_tickets.Columns[2].ReadOnly = true;
            Dgv_tickets.Columns[2].HeaderText = "CLIENTE";
            Dgv_tickets.Columns[3].Width = 120;
            Dgv_tickets.Columns[3].ReadOnly = true;
            Dgv_tickets.Columns[3].HeaderText = "FECHA EMISIÓN";
            Dgv_tickets.Columns[4].Width = 120;
            Dgv_tickets.Columns[4].ReadOnly = true;
            Dgv_tickets.Columns[4].HeaderText = "TOTAL S/.";
            Dgv_tickets.Columns[5].Visible = false;
            Dgv_tickets.Columns[6].Visible = false;
        }

        private void Mostrar_Tickets_Mesa()
        {
            try
            {
                Dgv_tickets.DataSource = N_MesaAbierta.Mostrar_Tickets_Mesa(Convert.ToInt32(Lbl_codigo_me.Text));
                this.Formato_tickets();
                Lbl_total_tickets.Text = "Total Nro. Tickets x mesa: " +Convert.ToString(Dgv_tickets.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        #endregion

        #region "Mostrar el detalle del ticket seleccionado"
        private void Formato_detalle_ticket()
        {
            Dgv_detalle_ticket.Columns[0].Width = 280;
            Dgv_detalle_ticket.Columns[0].HeaderText = "PRODUCTO";
            Dgv_detalle_ticket.Columns[1].Width = 75;
            Dgv_detalle_ticket.Columns[1].HeaderText = "P.UNIT.";
            Dgv_detalle_ticket.Columns[2].Width = 75;
            Dgv_detalle_ticket.Columns[2].HeaderText = "CANTIDAD";
            Dgv_detalle_ticket.Columns[3].Width = 75;
            Dgv_detalle_ticket.Columns[3].HeaderText = "TOTAL";
            Dgv_detalle_ticket.Columns[4].Width = 40;
            Dgv_detalle_ticket.Columns[4].HeaderText = "Obs.";
            Dgv_detalle_ticket.Columns[5].Visible = false;
            Dgv_detalle_ticket.Columns[6].Visible = false;
            Dgv_detalle_ticket.Columns[7].Visible = false;
        }

        private void Selecciona_detalle_ticket()
        {
            if (string.IsNullOrEmpty(Convert.ToString(Dgv_tickets.CurrentRow.Cells["codigo_ti"].Value)))
            {
                MessageBox.Show("Seleccione un registro",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else
            {
                Pnl_detalles_tickets.Visible = true;
                int xCodigo_ti = Convert.ToInt32(Dgv_tickets.CurrentRow.Cells["codigo_ti"].Value);
                Txt_cliente_detalle_ticket.Text = Convert.ToString(Dgv_tickets.CurrentRow.Cells["Cliente"].Value);
                Txt_nrodocumento_cliente_detalle.Text = Convert.ToString(Dgv_tickets.CurrentRow.Cells["nrodocumento_cl"].Value);
                Txt_tickets_seleccionados.Text = Convert.ToString(Dgv_tickets.CurrentRow.Cells["codigo_ti"].Value);
                Lbl_total_detalles_tickets.Text = Convert.ToString(Dgv_tickets.CurrentRow.Cells["total_ti"].Value);
                Dgv_detalle_ticket.DataSource = N_MesaAbierta.Mostrar_ticket(xCodigo_ti);
                this.Formato_detalle_ticket();
            }
        }
        #endregion
        public Frm_Mesa_Abierta()
        {
            InitializeComponent();
        }

        private void Dgv_listado_sf_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.LlenarListadoProductos(Flp_listadoproductos);
        }

        private void Btn_salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_Mesa_Abierta_Load(object sender, EventArgs e)
        {
            Tbc_principal.Controls["tabPage1"].Enabled = false;
            Tbc_principal.Controls["tabPage2"].Enabled = false;
            this.Crear_TablaDetalle();
        }

        private void Btn_nuevopedido_Click(object sender, EventArgs e)
        {
            Tbc_principal.Controls["tabPage1"].Enabled = true;
            Tbc_principal.Controls["tabPage2"].Enabled = false;
            Tbc_principal.SelectedIndex = 0;
            timer1.Enabled = true;
        }

        private void Btn_visualizarpedido_Click(object sender, EventArgs e)
        {
            this.Mostrar_Tickets_Mesa();
            Tbc_principal.Controls["tabPage1"].Enabled = false;
            Tbc_principal.Controls["tabPage2"].Enabled = true;
            Tbc_principal.SelectedIndex = 1;
        }

        private void Btn_1_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "1";
        }

        private void Btn_2_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "2";
        }

        private void Btn_3_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "3";
        }

        private void Btn_4_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "4";
        }

        private void Btn_5_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "5";
        }

        private void Btn_6_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "6";
        }

        private void Btn_7_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "7";
        }

        private void Btn_8_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "8";
        }

        private void Btn_9_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "9";
        }

        private void Btn_0_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = Lbl_cantidad.Text.Trim() + "0";
        }

        private void Btn_c_Click(object sender, EventArgs e)
        {
            Lbl_cantidad.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (File.Exists(@"C:\Users\Public\Documents\"+Lbl_archivo_txt.Text.Trim()+".txt") ==true)
            {
                string xDescripcion_pr;
                string xPreciounitario_pr;
                string xCodigo_pr;
                string xImpresora;
                StreamReader Leer = new StreamReader(@"C:\Users\Public\Documents\" + Lbl_archivo_txt.Text.Trim() + ".txt");

                xDescripcion_pr = Leer.ReadLine();
                xPreciounitario_pr = Leer.ReadLine();
                xCodigo_pr = Leer.ReadLine();
                xImpresora = Leer.ReadLine();
                Leer.Close();
                File.Delete(@"C:\Users\Public\Documents\" + Lbl_archivo_txt.Text.Trim() + ".txt");
                this.Agregar_item(xDescripcion_pr.Substring(15,xDescripcion_pr.Length-15),
                                  xPreciounitario_pr.Substring(18,xPreciounitario_pr.Length-18),
                                  "1.00",
                                  xPreciounitario_pr.Substring(18, xPreciounitario_pr.Length - 18),
                                  "",
                                  Convert.ToInt32(xCodigo_pr.Substring(10,xCodigo_pr.Length-10)),
                                  xImpresora.Substring(10,xImpresora.Length-10));
                TablaDetalle.AcceptChanges();

                const int nColumna = 3;
                decimal nSuma = 0;
                foreach (DataGridViewRow nRow in Dgv_detalle.Rows)
                {
                    nSuma += Convert.ToDecimal(nRow.Cells[nColumna].Value);
                }
                Lbl_total.Text =Convert.ToString(nSuma);
            }
        }

        private void Btn_actualizar_cantidad_Click(object sender, EventArgs e)
        {
            if (Dgv_detalle.SelectedRows.Count>0 && Lbl_cantidad.Text.Length>0)
            {
                DataGridViewRow nFila = Dgv_detalle.CurrentRow;
                if (nFila==null)
                {
                    return;
                }
                nFila.Cells["Cantidad"].Value = " " + Lbl_cantidad.Text + ".00";
                nFila.Cells["Total"].Value =Convert.ToString(Convert.ToDecimal(nFila.Cells["Preciounitario_pr"].Value) *
                                             Convert.ToDecimal(Lbl_cantidad.Text));
                Lbl_cantidad.Text = "";
                TablaDetalle.AcceptChanges();

                const int nColumna = 3;
                decimal nSuma = 0;
                foreach (DataGridViewRow nRow in Dgv_detalle.Rows)
                {
                    nSuma += Convert.ToDecimal(nRow.Cells[nColumna].Value);
                }
                Lbl_total.Text = Convert.ToString(nSuma);
            }
        }

        private void Btn_quitarproducto_Click(object sender, EventArgs e)
        {
            if (Dgv_detalle.SelectedRows.Count>0)
            {
                Dgv_detalle.Rows.Remove(Dgv_detalle.CurrentRow);
                TablaDetalle.AcceptChanges();

                const int nColumna = 3;
                decimal nSuma = 0;
                foreach (DataGridViewRow nRow in Dgv_detalle.Rows)
                {
                    nSuma += Convert.ToDecimal(nRow.Cells[nColumna].Value);
                }
                Lbl_total.Text = Convert.ToString(nSuma);

            }
        }

        private void Dgv_detalle_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Dgv_detalle.SelectedRows.Count>0)
            {
                DataGridViewRow nFila2 = Dgv_detalle.CurrentRow;
                if (nFila2 == null)
                {
                    return;
                }
                Txt_observacion.Text =Convert.ToString(nFila2.Cells["Obs"].Value);
                Dgv_detalle.Enabled = false;
                Pnl_observacion.Visible = true;
                Txt_observacion.Focus();
            }
        }

        private void Btn_retornar_obs_Click(object sender, EventArgs e)
        {
            if (Dgv_detalle.SelectedRows.Count>0)
            {
                DataGridViewRow nFila2 = Dgv_detalle.CurrentRow;
                if (nFila2==null)
                {
                    return;
                }
                nFila2.Cells["Obs"].Value = Txt_observacion.Text.Trim();
                TablaDetalle.AcceptChanges();
                Pnl_observacion.Visible = false;
                Dgv_detalle.Enabled = true;
            }
        }

        private void Btn_busquedarapida_Click(object sender, EventArgs e)
        {
            Pnl_busqueda_pr.Visible = true;
        }

        private void Btn_retornar_pr_Click(object sender, EventArgs e)
        {
            Pnl_busqueda_pr.Visible = false;
        }

        private void Btn_buscar_pr_Click(object sender, EventArgs e)
        {
            this.Busquedarapida_pr(Txt_buscar_pr.Text.Trim());
        }

        private void Dgv_1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // pasar el producto seleccionado al detalle principal
            this.Selecciona_dgv_busqueda_pr();
            Pnl_busqueda_pr.Visible = false;
        }

        private void Btn_lupa_1_Click(object sender, EventArgs e)
        {
            Pnl_busqueda_cl.Location = Chk_manual.Location;
            Pnl_busqueda_cl.Visible = true;
        }

        private void Btn_retornar_cl_Click(object sender, EventArgs e)
        {
            Pnl_busqueda_cl.Visible = false;
        }

        private void Btn_buscar_cl_Click(object sender, EventArgs e)
        {
            this.Busqueda_cl(Txt_buscar_cl.Text.Trim());
        }

        private void Dgv_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_dgv_busqueda_cl();
            Pnl_busqueda_cl.Visible = false;
        }

        private void Chk_manual_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_manual.Checked== true )
            {
                Txt_cliente.ReadOnly = false;
                Txt_nrodocumento.ReadOnly = false;
                Txt_cliente.Focus();
            }
            else
            {
                nCodigo_cl = 0;
                Txt_cliente.Text = "";
                Txt_nrodocumento.Text = "";
                Txt_cliente.ReadOnly = true;
                Txt_nrodocumento.ReadOnly = true;
            }
            
        }

        private void Btn_generarcomanda_Click(object sender, EventArgs e)
        {
            try
            {
                if (Txt_cliente.Text.Trim() == string.Empty || Lbl_total.Text.Trim() == String.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    // pasariamos a desarrollar la comanda
                    DataTable TablaImpresora = new DataTable();
                    E_RegistroPedido oErp = new E_RegistroPedido();
                    oErp.Fecha_emision = Lbl_fecha_trabajo.Text.Trim();
                    oErp.Codigo_cl = this.nCodigo_cl;
                    oErp.Nrodocumento_cl = Txt_nrodocumento.Text.Trim();
                    oErp.Cliente = Txt_cliente.Text.Trim();
                    oErp.Codigo_me = Convert.ToInt32(Lbl_codigo_me.Text);
                    oErp.Total_ti = Convert.ToDecimal(Lbl_total.Text.Trim());
                    oErp.Codigo_tu = Convert.ToInt32(Lbl_codigo_tu.Text);
                    oErp.Codigo_us = 1;

                    TablaDetalle.AcceptChanges();

                    TablaImpresora = N_MesaAbierta.Guardar_RP(oErp, TablaDetalle); 

                    if (TablaImpresora.Rows.Count>0)
                    {
                        #region "Impresión de Comandas"
                        //En esta posición lanzamos la impresión de comandas a Ticketeras
                        for (int nFila = 0; nFila <= TablaImpresora.Rows.Count-1; nFila++)
                        {
                            X1Impresora =Convert.ToString(TablaImpresora.Rows[nFila][0]);
                            x1Codigo_ti= Convert.ToInt32(TablaImpresora.Rows[nFila][1]);
                            x1Descripcion_pv= Convert.ToString(TablaImpresora.Rows[nFila][2]);
                            x1Fecha_emision= Convert.ToString(TablaImpresora.Rows[nFila][3]);
                            x1Descripcion_tu= Convert.ToString(TablaImpresora.Rows[nFila][4]);
                            X1Nombre_us= Convert.ToString(TablaImpresora.Rows[nFila][5]);
                            X1Descripcion_ca= Convert.ToString(TablaImpresora.Rows[nFila][6]);
                            X1Descripcion_me= Convert.ToString(TablaImpresora.Rows[nFila][7]);
                            x1Cliente= Convert.ToString(TablaImpresora.Rows[nFila][8]);
                            x1Nrodocumento_cl= Convert.ToString(TablaImpresora.Rows[nFila][9]);

                            //Creación del printdocument para la comanda
                            printDocument1 = new PrintDocument();
                            printDocument1.PrinterSettings.PrinterName = X1Impresora.Trim();
                            printDocument1.PrintPage += Imprimir;
                            printDocument1.Print();
                        }
                        //Fin de la impresión de comanda
                        #endregion
                        MessageBox.Show("Pedido generado correctamente",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        Txt_cliente.Text = "";
                        Txt_nrodocumento.Text = "";
                        Chk_manual.Checked = false;
                        Lbl_cantidad.Text = "";
                        Lbl_total.Text = "";
                        TablaDetalle.Clear();
                        TablaDetalle.AcceptChanges();
                        this.timer1.Enabled = false;
                        Tbc_principal.Controls["TabPage1"].Enabled = false;
                        Tbc_principal.Controls["TabPage2"].Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("Comanda no generada, verifique el detalle del pedido",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Dgv_tickets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Selecciona_detalle_ticket();
        }

        private void Btn_reimprimir_comanda_Click(object sender, EventArgs e)
        {
            try
            {
                //Se valida si tiene permisos administrador para realizar dicha tarea
                int xCodigo_us = 1;
                int xResp = 0;
                DataTable TablaTemp_admin = new DataTable();
                TablaTemp_admin = N_MesaAbierta.Usuario_Admin(xCodigo_us);
                xResp = Convert.ToInt32(TablaTemp_admin.Rows[0][0]);

                if (xResp==0)
                {
                    MessageBox.Show("Usuario no tiene permiso para este proceso",
                                    "Aviso del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                }
                else
                {
                    DataTable TablaImpresora = new DataTable();
                    TablaImpresora = N_MesaAbierta.ReImprimir_comanda(Convert.ToInt32(Txt_tickets_seleccionados.Text));
                    if (TablaImpresora.Rows.Count>0)
                    {
                        //En esta posición lanzamos la impresión de comandas a las ticketeras
                        for (int nFila = 0; nFila<=TablaImpresora.Rows.Count-1; nFila++)
                        {
                            x1Impresora =Convert.ToString(TablaImpresora.Rows[nFila][0]);
                            x1Codigo_ti= Convert.ToInt32(TablaImpresora.Rows[nFila][1]);
                            x1Descripcion_pv= Convert.ToString(TablaImpresora.Rows[nFila][2]);
                            x1Fecha_emision= Convert.ToString(TablaImpresora.Rows[nFila][3]);
                            x1Descripcion_tu= Convert.ToString(TablaImpresora.Rows[nFila][4]);
                            X1Nombre_us= Convert.ToString(TablaImpresora.Rows[nFila][5]);
                            x1Descripcion_ca= Convert.ToString(TablaImpresora.Rows[nFila][6]);
                            x1Descripcion_me= Convert.ToString(TablaImpresora.Rows[nFila][7]);
                            X1Cliente = Convert.ToString(TablaImpresora.Rows[nFila][8]);
                            x1Nrodocumento_cl= Convert.ToString(TablaImpresora.Rows[nFila][9]);

                            //Creación del printdocument para la comanda
                            printDocument1 = new PrintDocument();
                            printDocument1.PrinterSettings.PrinterName = x1Impresora.Trim();
                            printDocument1.PrintPage+= Reimprimir;
                            printDocument1.Print();
                        }
                        //fin de la reimpresión
                        MessageBox.Show("Reimpresión de comanda generada correctamente",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Btn_anularpedido_Click(object sender, EventArgs e)
        {

            //Se valida si tiene permisos administrador para realizar dicha tarea
            int aCodigo_us = 1;
            int aResp = 0;
            DataTable TablaTemp_admin = new DataTable();
            TablaTemp_admin = N_MesaAbierta.Usuario_Admin(aCodigo_us);
            aResp = Convert.ToInt32(TablaTemp_admin.Rows[0][0]);

            if (aResp == 0)
            {
                MessageBox.Show("Usuario no tiene permiso para este proceso",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else //Proceder ya que es usuario Administrador
            {
                int aCodigo_ti = Convert.ToInt32(Dgv_tickets.CurrentRow.Cells["codigo_ti"].Value);
                Lbl_titulo_osbanulado_ti.Text = "Observación de ticket anulado # " + aCodigo_ti;
                Btn_reimprimir_comanda.Enabled = false;
                Dgv_tickets.Enabled = false;

                Btn_anularpedido.Enabled = false;
                Btn_emitirdocumento.Enabled = false;
                Btn_dividir_precuenta.Enabled = false;
                Btn_boleta.Enabled = false;
                Btn_factura.Enabled = false;

                Pnl_observacion_anulado.Visible = true;
               
                
            }            
        }

        private void Btn_cancelar_anulado_Click(object sender, EventArgs e)
        {
            Pnl_observacion_anulado.Visible = false;
            Btn_reimprimir_comanda.Enabled = true;
            Dgv_tickets.Enabled = true;

            Btn_anularpedido.Enabled = true;
            Btn_emitirdocumento.Enabled = true;
            Btn_dividir_precuenta.Enabled = true;
            Btn_boleta.Enabled = true;
            Btn_factura.Enabled = true;
        }

        private void Btn_confirmar_anulado_Click(object sender, EventArgs e)
        {
            if (Txt_obsanulado_ti.Text==string.Empty)
            {
                MessageBox.Show("Es necesario ingresar el motivo de anulacíón del ticket",
                                "Aviso del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
            }
            else //Procedemos a enviar los datos para anular el ticket seleccionado
            {
                string cRpta = "";
                int aCodigo_ti = Convert.ToInt32(Dgv_tickets.CurrentRow.Cells["codigo_ti"].Value);
                int aCodigo_me =Convert.ToInt32(Lbl_codigo_me.Text);
                string cFechayHora = "  ::Fecha/Hora: "+ DateTime.Now;
                string cObs = Txt_obsanulado_ti.Text.Trim()+ cFechayHora;
                cRpta = N_MesaAbierta.Eliminar_ti(aCodigo_ti, aCodigo_me, cObs);
                if (cRpta.Equals("OK"))
                {
                    //Iniciamos la previa para la impresión de la cuenta anulada
                    DataTable TablaImpresora = new DataTable();
                    TablaImpresora = N_MesaAbierta.ReImprimir_comanda(aCodigo_ti);
                    if (TablaImpresora.Rows.Count>0)
                    {
                        //En esta posición enviamos la reimpresión de comandas
                        for (int nFila = 0; nFila <= TablaImpresora.Rows.Count-1; nFila++)
                        {
                            X1Impresora =Convert.ToString(TablaImpresora.Rows[nFila][0]);
                            x1Codigo_ti = Convert.ToInt32(TablaImpresora.Rows[nFila][1]);
                            x1Descripcion_pv = Convert.ToString(TablaImpresora.Rows[nFila][2]);
                            x1Fecha_emision= Convert.ToString(TablaImpresora.Rows[nFila][3]);
                            x1Descripcion_tu= Convert.ToString(TablaImpresora.Rows[nFila][4]);
                            X1Nombre_us= Convert.ToString(TablaImpresora.Rows[nFila][5]);
                            X1Descripcion_ca= Convert.ToString(TablaImpresora.Rows[nFila][6]);
                            x1Descripcion_me= Convert.ToString(TablaImpresora.Rows[nFila][7]);
                            x1Cliente= Convert.ToString(TablaImpresora.Rows[nFila][8]);
                            x1Nrodocumento_cl= Convert.ToString(TablaImpresora.Rows[nFila][9]);
                            x1obsanulado_ti= cObs;

                            //Creación de printdocument para la comanda
                            printDocument1 = new PrintDocument();
                            _ = printDocument1.PrinterSettings.IsDefaultPrinter;
                            printDocument1.PrintPage += Reimprimir_anulado;
                            printDocument1.Print();
                            // Fin de comandas anulada 
                        }

                        this.Mostrar_Tickets_Mesa();
                        Pnl_detalles_tickets.Visible = false;
                        Pnl_observacion_anulado.Visible = false;
                        Btn_reimprimir_comanda.Enabled = true;
                        Dgv_tickets.Enabled = true;

                        Btn_anularpedido.Enabled = true;
                        Btn_emitirdocumento.Enabled = true;
                        Btn_dividir_precuenta.Enabled = true;
                        Btn_boleta.Enabled = true;
                        Btn_factura.Enabled = true;

                        MessageBox.Show("Ticket anulado",
                                        "Aviso del Sistema",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                    }
                }

            }
        }
    }
}
