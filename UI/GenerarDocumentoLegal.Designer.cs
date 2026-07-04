
namespace UI
{
    partial class GenerarDocumentoLegal
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
            this.cmbTipoDocumento = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.txtVistaPrevia = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbTipoDocumento
            // 
            this.cmbTipoDocumento.FormattingEnabled = true;
            this.cmbTipoDocumento.Location = new System.Drawing.Point(59, 59);
            this.cmbTipoDocumento.Name = "cmbTipoDocumento";
            this.cmbTipoDocumento.Size = new System.Drawing.Size(159, 24);
            this.cmbTipoDocumento.TabIndex = 0;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(122, 104);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(96, 62);
            this.btnGenerar.TabIndex = 1;
            this.btnGenerar.Text = "Generar Vista Previa";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // txtVistaPrevia
            // 
            this.txtVistaPrevia.Location = new System.Drawing.Point(50, 192);
            this.txtVistaPrevia.Multiline = true;
            this.txtVistaPrevia.Name = "txtVistaPrevia";
            this.txtVistaPrevia.ReadOnly = true;
            this.txtVistaPrevia.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVistaPrevia.Size = new System.Drawing.Size(755, 660);
            this.txtVistaPrevia.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(693, 878);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 54);
            this.button1.TabIndex = 3;
            this.button1.Text = "Descargar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // GenerarDocumentoLegal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 964);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtVistaPrevia);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.cmbTipoDocumento);
            this.Name = "GenerarDocumentoLegal";
            this.Text = "GenerarDocumentoLegal";
            this.Load += new System.EventHandler(this.GenerarDocumentoLegal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTipoDocumento;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox txtVistaPrevia;
        private System.Windows.Forms.Button button1;
    }
}