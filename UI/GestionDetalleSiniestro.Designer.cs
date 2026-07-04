
namespace UI
{
    partial class GestionDetalleSiniestro
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
            this.tabDetalleSiniestro = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtNombreRazonSocial = new System.Windows.Forms.TextBox();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.txtCBU = new System.Windows.Forms.TextBox();
            this.txtObservacionesPersona = new System.Windows.Forms.TextBox();
            this.btnCrearPersona = new System.Windows.Forms.Button();
            this.dgvPersonas = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTipoParte = new System.Windows.Forms.ComboBox();
            this.txtObservacionesParte = new System.Windows.Forms.TextBox();
            this.btnCrearParte = new System.Windows.Forms.Button();
            this.dgvPartes = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbPersona = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.txtPlazoPago = new System.Windows.Forms.TextBox();
            this.chkEsPrincipal = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtObservacionesIntegrante = new System.Windows.Forms.TextBox();
            this.dgvIntegrantes = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnAgregarIntegrante = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvVehiculos = new System.Windows.Forms.DataGridView();
            this.btnCrearVehiculo = new System.Windows.Forms.Button();
            this.txtObservacionesVehiculo = new System.Windows.Forms.TextBox();
            this.txtDominio = new System.Windows.Forms.TextBox();
            this.txtModelo = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabDetalleSiniestro.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegrantes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDetalleSiniestro
            // 
            this.tabDetalleSiniestro.AccessibleName = "";
            this.tabDetalleSiniestro.Controls.Add(this.tabPage2);
            this.tabDetalleSiniestro.Controls.Add(this.tabPage1);
            this.tabDetalleSiniestro.Controls.Add(this.tabPage3);
            this.tabDetalleSiniestro.Location = new System.Drawing.Point(0, 0);
            this.tabDetalleSiniestro.Name = "tabDetalleSiniestro";
            this.tabDetalleSiniestro.SelectedIndex = 0;
            this.tabDetalleSiniestro.Size = new System.Drawing.Size(1239, 544);
            this.tabDetalleSiniestro.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label17);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dgvPersonas);
            this.tabPage1.Controls.Add(this.btnCrearPersona);
            this.tabPage1.Controls.Add(this.txtObservacionesPersona);
            this.tabPage1.Controls.Add(this.txtCBU);
            this.tabPage1.Controls.Add(this.txtCUIT);
            this.tabPage1.Controls.Add(this.txtNombreRazonSocial);
            this.tabPage1.Location = new System.Drawing.Point(8, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1223, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Personas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Controls.Add(this.dgvVehiculos);
            this.tabPage3.Controls.Add(this.btnCrearVehiculo);
            this.tabPage3.Controls.Add(this.txtObservacionesVehiculo);
            this.tabPage3.Controls.Add(this.txtDominio);
            this.tabPage3.Controls.Add(this.txtModelo);
            this.tabPage3.Controls.Add(this.txtMarca);
            this.tabPage3.Location = new System.Drawing.Point(8, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1223, 506);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Vehículos";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtNombreRazonSocial
            // 
            this.txtNombreRazonSocial.Location = new System.Drawing.Point(1035, 45);
            this.txtNombreRazonSocial.Name = "txtNombreRazonSocial";
            this.txtNombreRazonSocial.Size = new System.Drawing.Size(152, 22);
            this.txtNombreRazonSocial.TabIndex = 0;
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(1035, 78);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(152, 22);
            this.txtCUIT.TabIndex = 1;
            // 
            // txtCBU
            // 
            this.txtCBU.Location = new System.Drawing.Point(1035, 114);
            this.txtCBU.Name = "txtCBU";
            this.txtCBU.Size = new System.Drawing.Size(152, 22);
            this.txtCBU.TabIndex = 2;
            // 
            // txtObservacionesPersona
            // 
            this.txtObservacionesPersona.Location = new System.Drawing.Point(1035, 154);
            this.txtObservacionesPersona.Name = "txtObservacionesPersona";
            this.txtObservacionesPersona.Size = new System.Drawing.Size(152, 22);
            this.txtObservacionesPersona.TabIndex = 3;
            // 
            // btnCrearPersona
            // 
            this.btnCrearPersona.Location = new System.Drawing.Point(1067, 202);
            this.btnCrearPersona.Name = "btnCrearPersona";
            this.btnCrearPersona.Size = new System.Drawing.Size(120, 42);
            this.btnCrearPersona.TabIndex = 4;
            this.btnCrearPersona.Text = "Crear Persona";
            this.btnCrearPersona.UseVisualStyleBackColor = true;
            this.btnCrearPersona.Click += new System.EventHandler(this.btnCrearPersona_Click);
            // 
            // dgvPersonas
            // 
            this.dgvPersonas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonas.Location = new System.Drawing.Point(25, 34);
            this.dgvPersonas.Name = "dgvPersonas";
            this.dgvPersonas.RowHeadersWidth = 82;
            this.dgvPersonas.RowTemplate.Height = 24;
            this.dgvPersonas.Size = new System.Drawing.Size(809, 425);
            this.dgvPersonas.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(881, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre Razon Social:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(881, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "CUIT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(881, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "CBU:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(881, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Observaciones:";
            // 
            // cmbTipoParte
            // 
            this.cmbTipoParte.FormattingEnabled = true;
            this.cmbTipoParte.Location = new System.Drawing.Point(569, 38);
            this.cmbTipoParte.Name = "cmbTipoParte";
            this.cmbTipoParte.Size = new System.Drawing.Size(186, 24);
            this.cmbTipoParte.TabIndex = 0;
            // 
            // txtObservacionesParte
            // 
            this.txtObservacionesParte.Location = new System.Drawing.Point(569, 81);
            this.txtObservacionesParte.Name = "txtObservacionesParte";
            this.txtObservacionesParte.Size = new System.Drawing.Size(186, 22);
            this.txtObservacionesParte.TabIndex = 1;
            // 
            // btnCrearParte
            // 
            this.btnCrearParte.Location = new System.Drawing.Point(652, 120);
            this.btnCrearParte.Name = "btnCrearParte";
            this.btnCrearParte.Size = new System.Drawing.Size(103, 41);
            this.btnCrearParte.TabIndex = 2;
            this.btnCrearParte.Text = "Crear Parte";
            this.btnCrearParte.UseVisualStyleBackColor = true;
            this.btnCrearParte.Click += new System.EventHandler(this.btnCrearParte_Click);
            // 
            // dgvPartes
            // 
            this.dgvPartes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPartes.Location = new System.Drawing.Point(27, 38);
            this.dgvPartes.Name = "dgvPartes";
            this.dgvPartes.RowHeadersWidth = 82;
            this.dgvPartes.RowTemplate.Height = 24;
            this.dgvPartes.Size = new System.Drawing.Size(416, 198);
            this.dgvPartes.TabIndex = 3;
            this.dgvPartes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPartes_CellClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(460, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tipo Parte:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(460, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Observaciones:";
            // 
            // cmbPersona
            // 
            this.cmbPersona.FormattingEnabled = true;
            this.cmbPersona.Location = new System.Drawing.Point(992, 38);
            this.cmbPersona.Name = "cmbPersona";
            this.cmbPersona.Size = new System.Drawing.Size(186, 24);
            this.cmbPersona.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(883, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "Persona:";
            // 
            // txtMonto
            // 
            this.txtMonto.Location = new System.Drawing.Point(992, 76);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(186, 22);
            this.txtMonto.TabIndex = 8;
            // 
            // txtPlazoPago
            // 
            this.txtPlazoPago.Location = new System.Drawing.Point(992, 116);
            this.txtPlazoPago.Name = "txtPlazoPago";
            this.txtPlazoPago.Size = new System.Drawing.Size(186, 22);
            this.txtPlazoPago.TabIndex = 9;
            // 
            // chkEsPrincipal
            // 
            this.chkEsPrincipal.AutoSize = true;
            this.chkEsPrincipal.Location = new System.Drawing.Point(886, 197);
            this.chkEsPrincipal.Name = "chkEsPrincipal";
            this.chkEsPrincipal.Size = new System.Drawing.Size(111, 27);
            this.chkEsPrincipal.TabIndex = 10;
            this.chkEsPrincipal.Text = "Es Principal";
            this.chkEsPrincipal.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAgregarIntegrante);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.dgvIntegrantes);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.txtObservacionesIntegrante);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.chkEsPrincipal);
            this.tabPage2.Controls.Add(this.txtPlazoPago);
            this.tabPage2.Controls.Add(this.txtMonto);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.cmbPersona);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.dgvPartes);
            this.tabPage2.Controls.Add(this.btnCrearParte);
            this.tabPage2.Controls.Add(this.txtObservacionesParte);
            this.tabPage2.Controls.Add(this.cmbTipoParte);
            this.tabPage2.Location = new System.Drawing.Point(8, 30);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1223, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Partes e integrantes";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(883, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 11;
            this.label8.Text = "Monto:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(883, 116);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 16);
            this.label9.TabIndex = 12;
            this.label9.Text = "Plazo Pago:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(883, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "Observaciones:";
            // 
            // txtObservacionesIntegrante
            // 
            this.txtObservacionesIntegrante.Location = new System.Drawing.Point(992, 151);
            this.txtObservacionesIntegrante.Name = "txtObservacionesIntegrante";
            this.txtObservacionesIntegrante.Size = new System.Drawing.Size(186, 22);
            this.txtObservacionesIntegrante.TabIndex = 13;
            // 
            // dgvIntegrantes
            // 
            this.dgvIntegrantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIntegrantes.Location = new System.Drawing.Point(27, 281);
            this.dgvIntegrantes.Name = "dgvIntegrantes";
            this.dgvIntegrantes.RowHeadersWidth = 82;
            this.dgvIntegrantes.RowTemplate.Height = 24;
            this.dgvIntegrantes.Size = new System.Drawing.Size(1151, 186);
            this.dgvIntegrantes.TabIndex = 15;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 16);
            this.label11.TabIndex = 16;
            this.label11.Text = "Partes";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 16);
            this.label12.TabIndex = 17;
            this.label12.Text = "Integrantes";
            // 
            // btnAgregarIntegrante
            // 
            this.btnAgregarIntegrante.Location = new System.Drawing.Point(1038, 197);
            this.btnAgregarIntegrante.Name = "btnAgregarIntegrante";
            this.btnAgregarIntegrante.Size = new System.Drawing.Size(140, 39);
            this.btnAgregarIntegrante.TabIndex = 18;
            this.btnAgregarIntegrante.Text = "Agregar Integrante";
            this.btnAgregarIntegrante.UseVisualStyleBackColor = true;
            this.btnAgregarIntegrante.Click += new System.EventHandler(this.btnAgregarIntegrante_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(870, 140);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "Observaciones:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(870, 103);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(61, 16);
            this.label14.TabIndex = 18;
            this.label14.Text = "Dominio:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(870, 70);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 16);
            this.label15.TabIndex = 17;
            this.label15.Text = "Modelo:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(870, 34);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(49, 16);
            this.label16.TabIndex = 16;
            this.label16.Text = "Marca:";
            // 
            // dgvVehiculos
            // 
            this.dgvVehiculos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVehiculos.Location = new System.Drawing.Point(21, 25);
            this.dgvVehiculos.Name = "dgvVehiculos";
            this.dgvVehiculos.RowHeadersWidth = 82;
            this.dgvVehiculos.RowTemplate.Height = 24;
            this.dgvVehiculos.Size = new System.Drawing.Size(819, 424);
            this.dgvVehiculos.TabIndex = 15;
            // 
            // btnCrearVehiculo
            // 
            this.btnCrearVehiculo.Location = new System.Drawing.Point(1058, 188);
            this.btnCrearVehiculo.Name = "btnCrearVehiculo";
            this.btnCrearVehiculo.Size = new System.Drawing.Size(118, 42);
            this.btnCrearVehiculo.TabIndex = 14;
            this.btnCrearVehiculo.Text = "Crear Vehiculo";
            this.btnCrearVehiculo.UseVisualStyleBackColor = true;
            this.btnCrearVehiculo.Click += new System.EventHandler(this.btnCrearVehiculo_Click);
            // 
            // txtObservacionesVehiculo
            // 
            this.txtObservacionesVehiculo.Location = new System.Drawing.Point(1024, 140);
            this.txtObservacionesVehiculo.Name = "txtObservacionesVehiculo";
            this.txtObservacionesVehiculo.Size = new System.Drawing.Size(152, 22);
            this.txtObservacionesVehiculo.TabIndex = 13;
            // 
            // txtDominio
            // 
            this.txtDominio.Location = new System.Drawing.Point(1024, 100);
            this.txtDominio.Name = "txtDominio";
            this.txtDominio.Size = new System.Drawing.Size(152, 22);
            this.txtDominio.TabIndex = 12;
            // 
            // txtModelo
            // 
            this.txtModelo.Location = new System.Drawing.Point(1024, 64);
            this.txtModelo.Name = "txtModelo";
            this.txtModelo.Size = new System.Drawing.Size(152, 22);
            this.txtModelo.TabIndex = 11;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(1024, 31);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.Size = new System.Drawing.Size(152, 22);
            this.txtMarca.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(22, 6);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 16);
            this.label17.TabIndex = 17;
            this.label17.Text = "Personas";
            // 
            // GestionDetalleSiniestro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 561);
            this.Controls.Add(this.tabDetalleSiniestro);
            this.Name = "GestionDetalleSiniestro";
            this.Text = "GestionDetalleSiniestro";
            this.Load += new System.EventHandler(this.GestionDetalleSiniestro_Load);
            this.tabDetalleSiniestro.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPartes)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIntegrantes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVehiculos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDetalleSiniestro;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPersonas;
        private System.Windows.Forms.Button btnCrearPersona;
        private System.Windows.Forms.TextBox txtObservacionesPersona;
        private System.Windows.Forms.TextBox txtCBU;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.TextBox txtNombreRazonSocial;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAgregarIntegrante;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgvIntegrantes;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtObservacionesIntegrante;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkEsPrincipal;
        private System.Windows.Forms.TextBox txtPlazoPago;
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbPersona;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvPartes;
        private System.Windows.Forms.Button btnCrearParte;
        private System.Windows.Forms.TextBox txtObservacionesParte;
        private System.Windows.Forms.ComboBox cmbTipoParte;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvVehiculos;
        private System.Windows.Forms.Button btnCrearVehiculo;
        private System.Windows.Forms.TextBox txtObservacionesVehiculo;
        private System.Windows.Forms.TextBox txtDominio;
        private System.Windows.Forms.TextBox txtModelo;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Label label17;
    }
}