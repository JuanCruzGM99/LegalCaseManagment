
namespace UI
{
    partial class GestionSiniestros
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
            this.txtNumeroSiniestro = new System.Windows.Forms.TextBox();
            this.txtCaratula = new System.Windows.Forms.TextBox();
            this.txtAnalistaInterno = new System.Windows.Forms.TextBox();
            this.dtpFechaSiniestro = new System.Windows.Forms.DateTimePicker();
            this.txtLugarSiniestro = new System.Windows.Forms.TextBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnVerCambios = new System.Windows.Forms.Button();
            this.btnRestaurar = new System.Windows.Forms.Button();
            this.dgvSiniestros = new System.Windows.Forms.DataGridView();
            this.dgvCambios = new System.Windows.Forms.DataGridView();
            this.dgvHistorial = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btnGestionarDetalle = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiniestros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNumeroSiniestro
            // 
            this.txtNumeroSiniestro.Location = new System.Drawing.Point(1184, 49);
            this.txtNumeroSiniestro.Name = "txtNumeroSiniestro";
            this.txtNumeroSiniestro.Size = new System.Drawing.Size(200, 22);
            this.txtNumeroSiniestro.TabIndex = 0;
            this.txtNumeroSiniestro.Text = " ";
            // 
            // txtCaratula
            // 
            this.txtCaratula.Location = new System.Drawing.Point(1184, 90);
            this.txtCaratula.Name = "txtCaratula";
            this.txtCaratula.Size = new System.Drawing.Size(200, 22);
            this.txtCaratula.TabIndex = 1;
            this.txtCaratula.Text = " ";
            // 
            // txtAnalistaInterno
            // 
            this.txtAnalistaInterno.Location = new System.Drawing.Point(1184, 136);
            this.txtAnalistaInterno.Name = "txtAnalistaInterno";
            this.txtAnalistaInterno.Size = new System.Drawing.Size(200, 22);
            this.txtAnalistaInterno.TabIndex = 2;
            this.txtAnalistaInterno.Text = " ";
            // 
            // dtpFechaSiniestro
            // 
            this.dtpFechaSiniestro.Location = new System.Drawing.Point(1184, 183);
            this.dtpFechaSiniestro.Name = "dtpFechaSiniestro";
            this.dtpFechaSiniestro.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaSiniestro.TabIndex = 3;
            // 
            // txtLugarSiniestro
            // 
            this.txtLugarSiniestro.Location = new System.Drawing.Point(1184, 234);
            this.txtLugarSiniestro.Name = "txtLugarSiniestro";
            this.txtLugarSiniestro.Size = new System.Drawing.Size(200, 22);
            this.txtLugarSiniestro.TabIndex = 4;
            this.txtLugarSiniestro.Text = " ";
            // 
            // cmbEstado
            // 
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(1184, 285);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(200, 24);
            this.cmbEstado.TabIndex = 5;
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Location = new System.Drawing.Point(1184, 340);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(200, 22);
            this.txtObservaciones.TabIndex = 6;
            this.txtObservaciones.Text = " ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1054, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Numero Siniestro:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1054, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Caratula";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1054, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Analista Interno:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1054, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Estado:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1054, 237);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Lugar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1054, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 16);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1054, 340);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Observaciones:";
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(1279, 393);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(105, 37);
            this.btnAgregar.TabIndex = 14;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(1168, 393);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(105, 37);
            this.btnModificar.TabIndex = 15;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1051, 393);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(105, 37);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnVerCambios
            // 
            this.btnVerCambios.Location = new System.Drawing.Point(1279, 856);
            this.btnVerCambios.Name = "btnVerCambios";
            this.btnVerCambios.Size = new System.Drawing.Size(105, 62);
            this.btnVerCambios.TabIndex = 17;
            this.btnVerCambios.Text = "Ver todos los cambios";
            this.btnVerCambios.UseVisualStyleBackColor = true;
            this.btnVerCambios.Click += new System.EventHandler(this.btnVerCambios_Click);
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(1279, 634);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(105, 37);
            this.btnRestaurar.TabIndex = 19;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseVisualStyleBackColor = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // dgvSiniestros
            // 
            this.dgvSiniestros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSiniestros.Location = new System.Drawing.Point(26, 49);
            this.dgvSiniestros.Name = "dgvSiniestros";
            this.dgvSiniestros.RowHeadersWidth = 82;
            this.dgvSiniestros.RowTemplate.Height = 24;
            this.dgvSiniestros.Size = new System.Drawing.Size(969, 381);
            this.dgvSiniestros.TabIndex = 20;
            this.dgvSiniestros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSiniestros_CellClick);
            // 
            // dgvCambios
            // 
            this.dgvCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCambios.Location = new System.Drawing.Point(26, 763);
            this.dgvCambios.Name = "dgvCambios";
            this.dgvCambios.RowHeadersWidth = 82;
            this.dgvCambios.RowTemplate.Height = 24;
            this.dgvCambios.Size = new System.Drawing.Size(1206, 155);
            this.dgvCambios.TabIndex = 21;
            // 
            // dgvHistorial
            // 
            this.dgvHistorial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Location = new System.Drawing.Point(26, 548);
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.RowHeadersWidth = 82;
            this.dgvHistorial.RowTemplate.Height = 24;
            this.dgvHistorial.Size = new System.Drawing.Size(1206, 123);
            this.dgvHistorial.TabIndex = 22;
            this.dgvHistorial.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHistorial_CellClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 16);
            this.label8.TabIndex = 23;
            this.label8.Text = "Siniestros actuales";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 736);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(130, 16);
            this.label9.TabIndex = 24;
            this.label9.Text = "Cambios por campo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 515);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 16);
            this.label10.TabIndex = 25;
            this.label10.Text = "Historial de Cambios";
            // 
            // btnGestionarDetalle
            // 
            this.btnGestionarDetalle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnGestionarDetalle.Location = new System.Drawing.Point(829, 449);
            this.btnGestionarDetalle.Name = "btnGestionarDetalle";
            this.btnGestionarDetalle.Size = new System.Drawing.Size(166, 37);
            this.btnGestionarDetalle.TabIndex = 26;
            this.btnGestionarDetalle.Text = "Partes y vehículos";
            this.btnGestionarDetalle.UseVisualStyleBackColor = false;
            this.btnGestionarDetalle.Click += new System.EventHandler(this.btnGestionarDetalle_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Info;
            this.button1.Location = new System.Drawing.Point(637, 449);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 37);
            this.button1.TabIndex = 27;
            this.button1.Text = "Generar documento";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnGenerarDocumento_Click);
            // 
            // GestionSiniestros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 1019);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnGestionarDetalle);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvHistorial);
            this.Controls.Add(this.dgvCambios);
            this.Controls.Add(this.dgvSiniestros);
            this.Controls.Add(this.btnRestaurar);
            this.Controls.Add(this.btnVerCambios);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.txtLugarSiniestro);
            this.Controls.Add(this.dtpFechaSiniestro);
            this.Controls.Add(this.txtAnalistaInterno);
            this.Controls.Add(this.txtCaratula);
            this.Controls.Add(this.txtNumeroSiniestro);
            this.Name = "GestionSiniestros";
            this.Text = "GestionSiniestros";
            this.Load += new System.EventHandler(this.GestionSiniestros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSiniestros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCambios)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNumeroSiniestro;
        private System.Windows.Forms.TextBox txtCaratula;
        private System.Windows.Forms.TextBox txtAnalistaInterno;
        private System.Windows.Forms.DateTimePicker dtpFechaSiniestro;
        private System.Windows.Forms.TextBox txtLugarSiniestro;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnVerCambios;
        private System.Windows.Forms.Button btnRestaurar;
        private System.Windows.Forms.DataGridView dgvSiniestros;
        private System.Windows.Forms.DataGridView dgvCambios;
        private System.Windows.Forms.DataGridView dgvHistorial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnGestionarDetalle;
        private System.Windows.Forms.Button button1;
    }
}