namespace UI
{
	partial class LogIn
	{
		/// <summary>
		/// Variable del diseñador necesaria.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpiar los recursos que se estén usando.
		/// </summary>
		/// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código generado por el Diseñador de Windows Forms

		/// <summary>
		/// Método necesario para admitir el Diseñador. No se puede modificar
		/// el contenido de este método con el editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnSesion = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.txtContraseña = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtUsuario = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnSesion
			// 
			this.btnSesion.Location = new System.Drawing.Point(12, 111);
			this.btnSesion.Name = "btnSesion";
			this.btnSesion.Size = new System.Drawing.Size(115, 23);
			this.btnSesion.TabIndex = 9;
			this.btnSesion.Text = "Iniciar Sesión";
			this.btnSesion.UseVisualStyleBackColor = true;
			this.btnSesion.Click += new System.EventHandler(this.btnSesion_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 53);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(61, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "Contraseña";
			// 
			// txtContraseña
			// 
			this.txtContraseña.Location = new System.Drawing.Point(12, 72);
			this.txtContraseña.Name = "txtContraseña";
			this.txtContraseña.PasswordChar = '*';
			this.txtContraseña.Size = new System.Drawing.Size(115, 20);
			this.txtContraseña.TabIndex = 7;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Usuario";
			// 
			// txtUsuario
			// 
			this.txtUsuario.Location = new System.Drawing.Point(12, 28);
			this.txtUsuario.Name = "txtUsuario";
			this.txtUsuario.Size = new System.Drawing.Size(115, 20);
			this.txtUsuario.TabIndex = 5;
			// 
			// LogIn
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(153, 171);
			this.Controls.Add(this.btnSesion);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtContraseña);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtUsuario);
			this.Name = "LogIn";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LogIn_FormClosed);
			this.Load += new System.EventHandler(this.LogIn_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSesion;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtContraseña;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtUsuario;
	}
}

