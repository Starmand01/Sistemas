namespace Sol_PuntoVenta.Presentacion.Procesos
{
    partial class Frm_Cierres_Turnos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Pnl_titulo_form = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.Dgv_1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Btn_cerrarturno = new System.Windows.Forms.Button();
            this.Btn_abrirturno = new System.Windows.Forms.Button();
            this.Txt_estado = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_turno = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Txt_fecha_trabajo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_puntoventa = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.Pnl_titulo_form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pnl_titulo_form
            // 
            this.Pnl_titulo_form.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(145)))), ((int)(((byte)(194)))));
            this.Pnl_titulo_form.Controls.Add(this.label3);
            this.Pnl_titulo_form.Dock = System.Windows.Forms.DockStyle.Top;
            this.Pnl_titulo_form.Location = new System.Drawing.Point(0, 0);
            this.Pnl_titulo_form.Name = "Pnl_titulo_form";
            this.Pnl_titulo_form.Size = new System.Drawing.Size(800, 40);
            this.Pnl_titulo_form.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Location = new System.Drawing.Point(28, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 14);
            this.label3.TabIndex = 0;
            this.label3.Text = "GESTIÓN DE TURNOS";
            // 
            // Dgv_1
            // 
            this.Dgv_1.AllowUserToAddRows = false;
            this.Dgv_1.AllowUserToDeleteRows = false;
            this.Dgv_1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.Dgv_1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.Dgv_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dgv_1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(145)))), ((int)(((byte)(194)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.Dgv_1.ColumnHeadersHeight = 35;
            this.Dgv_1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_1.EnableHeadersVisualStyles = false;
            this.Dgv_1.Location = new System.Drawing.Point(31, 46);
            this.Dgv_1.Name = "Dgv_1";
            this.Dgv_1.ReadOnly = true;
            this.Dgv_1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Dgv_1.Size = new System.Drawing.Size(420, 180);
            this.Dgv_1.TabIndex = 13;
            this.Dgv_1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_1_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.Btn_cerrarturno);
            this.panel1.Controls.Add(this.Btn_abrirturno);
            this.panel1.Controls.Add(this.Txt_estado);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Txt_turno);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Txt_fecha_trabajo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Txt_puntoventa);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(31, 245);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(420, 272);
            this.panel1.TabIndex = 14;
            // 
            // Btn_cerrarturno
            // 
            this.Btn_cerrarturno.BackColor = System.Drawing.Color.DimGray;
            this.Btn_cerrarturno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_cerrarturno.Enabled = false;
            this.Btn_cerrarturno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_cerrarturno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_cerrarturno.ForeColor = System.Drawing.Color.White;
            this.Btn_cerrarturno.Location = new System.Drawing.Point(211, 214);
            this.Btn_cerrarturno.Name = "Btn_cerrarturno";
            this.Btn_cerrarturno.Size = new System.Drawing.Size(145, 44);
            this.Btn_cerrarturno.TabIndex = 25;
            this.Btn_cerrarturno.Text = "Cerrar turno";
            this.Btn_cerrarturno.UseVisualStyleBackColor = false;
            this.Btn_cerrarturno.Click += new System.EventHandler(this.Btn_cerrarturno_Click);
            // 
            // Btn_abrirturno
            // 
            this.Btn_abrirturno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(105)))), ((int)(((byte)(141)))));
            this.Btn_abrirturno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_abrirturno.Enabled = false;
            this.Btn_abrirturno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_abrirturno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_abrirturno.ForeColor = System.Drawing.Color.White;
            this.Btn_abrirturno.Location = new System.Drawing.Point(60, 214);
            this.Btn_abrirturno.Name = "Btn_abrirturno";
            this.Btn_abrirturno.Size = new System.Drawing.Size(145, 44);
            this.Btn_abrirturno.TabIndex = 24;
            this.Btn_abrirturno.Text = "Abrir siguiente turno";
            this.Btn_abrirturno.UseVisualStyleBackColor = false;
            this.Btn_abrirturno.Click += new System.EventHandler(this.Btn_abrirturno_Click);
            // 
            // Txt_estado
            // 
            this.Txt_estado.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_estado.ForeColor = System.Drawing.Color.DarkGray;
            this.Txt_estado.Location = new System.Drawing.Point(135, 173);
            this.Txt_estado.Name = "Txt_estado";
            this.Txt_estado.ReadOnly = true;
            this.Txt_estado.Size = new System.Drawing.Size(264, 22);
            this.Txt_estado.TabIndex = 23;
            this.Txt_estado.Text = "Estado X";
            this.Txt_estado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(29, 176);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 14);
            this.label6.TabIndex = 22;
            this.label6.Text = "Estado actual:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_turno
            // 
            this.Txt_turno.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_turno.ForeColor = System.Drawing.Color.DarkGray;
            this.Txt_turno.Location = new System.Drawing.Point(135, 135);
            this.Txt_turno.Name = "Txt_turno";
            this.Txt_turno.ReadOnly = true;
            this.Txt_turno.Size = new System.Drawing.Size(264, 22);
            this.Txt_turno.TabIndex = 21;
            this.Txt_turno.Text = "Turno X";
            this.Txt_turno.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label5.Location = new System.Drawing.Point(79, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 14);
            this.label5.TabIndex = 20;
            this.label5.Text = "Turno:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_fecha_trabajo
            // 
            this.Txt_fecha_trabajo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_fecha_trabajo.ForeColor = System.Drawing.Color.DarkGray;
            this.Txt_fecha_trabajo.Location = new System.Drawing.Point(135, 98);
            this.Txt_fecha_trabajo.Name = "Txt_fecha_trabajo";
            this.Txt_fecha_trabajo.ReadOnly = true;
            this.Txt_fecha_trabajo.Size = new System.Drawing.Size(264, 22);
            this.Txt_fecha_trabajo.TabIndex = 19;
            this.Txt_fecha_trabajo.Text = "Fecha trabajo X";
            this.Txt_fecha_trabajo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(3, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(126, 14);
            this.label4.TabIndex = 18;
            this.label4.Text = "Fecha de Trabajo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Txt_puntoventa
            // 
            this.Txt_puntoventa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_puntoventa.ForeColor = System.Drawing.Color.DarkGray;
            this.Txt_puntoventa.Location = new System.Drawing.Point(135, 58);
            this.Txt_puntoventa.Name = "Txt_puntoventa";
            this.Txt_puntoventa.ReadOnly = true;
            this.Txt_puntoventa.Size = new System.Drawing.Size(264, 22);
            this.Txt_puntoventa.TabIndex = 17;
            this.Txt_puntoventa.Text = "Punto de Venta X";
            this.Txt_puntoventa.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(17, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 14);
            this.label2.TabIndex = 16;
            this.label2.Text = "Punto de Venta:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(193)))), ((int)(((byte)(211)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(420, 40);
            this.panel2.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(105, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATOS ACTUALES DEL TURNO";
            // 
            // Frm_Cierres_Turnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Dgv_1);
            this.Controls.Add(this.Pnl_titulo_form);
            this.Name = "Frm_Cierres_Turnos";
            this.Text = "Frm_Cierres_Turnos";
            this.Load += new System.EventHandler(this.Frm_Cierres_Turnos_Load);
            this.Pnl_titulo_form.ResumeLayout(false);
            this.Pnl_titulo_form.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Pnl_titulo_form;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Dgv_1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_estado;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Txt_turno;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Txt_fecha_trabajo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_puntoventa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_abrirturno;
        private System.Windows.Forms.Button Btn_cerrarturno;
    }
}