
namespace UI
{
    partial class VerBitacora
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
            this.dgvBitacora = new System.Windows.Forms.DataGridView();
            this.cmbActividad = new System.Windows.Forms.ComboBox();
            this.chkHoraDesde = new System.Windows.Forms.CheckBox();
            this.chkFechaDesde = new System.Windows.Forms.CheckBox();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.chkFechaHasta = new System.Windows.Forms.CheckBox();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.chkHoraHasta = new System.Windows.Forms.CheckBox();
            this.dtpHoraDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraHasta = new System.Windows.Forms.DateTimePicker();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVer = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBitacora
            // 
            this.dgvBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBitacora.Location = new System.Drawing.Point(43, 41);
            this.dgvBitacora.Name = "dgvBitacora";
            this.dgvBitacora.RowHeadersWidth = 82;
            this.dgvBitacora.RowTemplate.Height = 24;
            this.dgvBitacora.Size = new System.Drawing.Size(801, 354);
            this.dgvBitacora.TabIndex = 1;
            // 
            // cmbActividad
            // 
            this.cmbActividad.FormattingEnabled = true;
            this.cmbActividad.Location = new System.Drawing.Point(995, 253);
            this.cmbActividad.Name = "cmbActividad";
            this.cmbActividad.Size = new System.Drawing.Size(220, 24);
            this.cmbActividad.TabIndex = 3;
            // 
            // chkHoraDesde
            // 
            this.chkHoraDesde.AutoSize = true;
            this.chkHoraDesde.Location = new System.Drawing.Point(885, 147);
            this.chkHoraDesde.Name = "chkHoraDesde";
            this.chkHoraDesde.Size = new System.Drawing.Size(115, 27);
            this.chkHoraDesde.TabIndex = 7;
            this.chkHoraDesde.Text = "Hora desde:";
            this.chkHoraDesde.UseVisualStyleBackColor = true;
            // 
            // chkFechaDesde
            // 
            this.chkFechaDesde.AutoSize = true;
            this.chkFechaDesde.Location = new System.Drawing.Point(885, 45);
            this.chkFechaDesde.Name = "chkFechaDesde";
            this.chkFechaDesde.Size = new System.Drawing.Size(123, 27);
            this.chkFechaDesde.TabIndex = 2;
            this.chkFechaDesde.Text = "Fecha desde:";
            this.chkFechaDesde.UseVisualStyleBackColor = true;
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(1015, 44);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaDesde.TabIndex = 4;
            // 
            // chkFechaHasta
            // 
            this.chkFechaHasta.AutoSize = true;
            this.chkFechaHasta.Location = new System.Drawing.Point(885, 94);
            this.chkFechaHasta.Name = "chkFechaHasta";
            this.chkFechaHasta.Size = new System.Drawing.Size(117, 27);
            this.chkFechaHasta.TabIndex = 5;
            this.chkFechaHasta.Text = "Fecha hasta:";
            this.chkFechaHasta.UseVisualStyleBackColor = true;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(1015, 99);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(200, 22);
            this.dtpFechaHasta.TabIndex = 6;
            // 
            // chkHoraHasta
            // 
            this.chkHoraHasta.AutoSize = true;
            this.chkHoraHasta.Location = new System.Drawing.Point(885, 198);
            this.chkHoraHasta.Name = "chkHoraHasta";
            this.chkHoraHasta.Size = new System.Drawing.Size(109, 27);
            this.chkHoraHasta.TabIndex = 8;
            this.chkHoraHasta.Text = "Hora hasta:";
            this.chkHoraHasta.UseVisualStyleBackColor = true;
            // 
            // dtpHoraDesde
            // 
            this.dtpHoraDesde.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraDesde.Location = new System.Drawing.Point(1015, 152);
            this.dtpHoraDesde.Name = "dtpHoraDesde";
            this.dtpHoraDesde.ShowUpDown = true;
            this.dtpHoraDesde.Size = new System.Drawing.Size(200, 22);
            this.dtpHoraDesde.TabIndex = 9;
            // 
            // dtpHoraHasta
            // 
            this.dtpHoraHasta.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraHasta.Location = new System.Drawing.Point(1015, 198);
            this.dtpHoraHasta.Name = "dtpHoraHasta";
            this.dtpHoraHasta.ShowUpDown = true;
            this.dtpHoraHasta.Size = new System.Drawing.Size(200, 22);
            this.dtpHoraHasta.TabIndex = 10;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(995, 301);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(220, 22);
            this.txtUsuario.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(885, 256);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Actividad:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(885, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Usuario:";
            // 
            // btnVer
            // 
            this.btnVer.Location = new System.Drawing.Point(1118, 362);
            this.btnVer.Name = "btnVer";
            this.btnVer.Size = new System.Drawing.Size(96, 33);
            this.btnVer.TabIndex = 14;
            this.btnVer.Text = "Aplicar Filtro";
            this.btnVer.UseVisualStyleBackColor = true;
            this.btnVer.Click += new System.EventHandler(this.btnVer_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(1004, 364);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(96, 31);
            this.btnLimpiar.TabIndex = 15;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // VerBitacora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 426);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnVer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.dtpHoraHasta);
            this.Controls.Add(this.dtpHoraDesde);
            this.Controls.Add(this.chkHoraHasta);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.chkFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.chkHoraDesde);
            this.Controls.Add(this.chkFechaDesde);
            this.Controls.Add(this.cmbActividad);
            this.Controls.Add(this.dgvBitacora);
            this.Name = "VerBitacora";
            this.Text = "VerBitacora";
            this.Load += new System.EventHandler(this.VerBitacora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBitacora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBitacora;
        private System.Windows.Forms.ComboBox cmbActividad;
        private System.Windows.Forms.CheckBox chkHoraDesde;
        private System.Windows.Forms.CheckBox chkFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.CheckBox chkFechaHasta;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
        private System.Windows.Forms.CheckBox chkHoraHasta;
        private System.Windows.Forms.DateTimePicker dtpHoraDesde;
        private System.Windows.Forms.DateTimePicker dtpHoraHasta;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVer;
        private System.Windows.Forms.Button btnLimpiar;
    }
}