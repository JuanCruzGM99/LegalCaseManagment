namespace UI
{
	partial class CrearUser
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.gbAgregarUser = new System.Windows.Forms.GroupBox();
			this.labelID = new System.Windows.Forms.Label();
			this.txtID = new System.Windows.Forms.TextBox();
			this.dgvUsuarios = new System.Windows.Forms.DataGridView();
			this.txtContraseña = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.btnAgregarUsuario = new System.Windows.Forms.Button();
			this.labelPass = new System.Windows.Forms.Label();
			this.labelUser = new System.Windows.Forms.Label();
			this.gbAgregarUser.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
			this.SuspendLayout();
			// 
			// gbAgregarUser
			// 
			this.gbAgregarUser.Controls.Add(this.labelID);
			this.gbAgregarUser.Controls.Add(this.txtID);
			this.gbAgregarUser.Controls.Add(this.dgvUsuarios);
			this.gbAgregarUser.Controls.Add(this.txtContraseña);
			this.gbAgregarUser.Controls.Add(this.txtUser);
			this.gbAgregarUser.Controls.Add(this.btnAgregarUsuario);
			this.gbAgregarUser.Controls.Add(this.labelPass);
			this.gbAgregarUser.Controls.Add(this.labelUser);
			this.gbAgregarUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbAgregarUser.ForeColor = System.Drawing.Color.Black;
			this.gbAgregarUser.Location = new System.Drawing.Point(21, 12);
			this.gbAgregarUser.Name = "gbAgregarUser";
			this.gbAgregarUser.Size = new System.Drawing.Size(683, 305);
			this.gbAgregarUser.TabIndex = 2;
			this.gbAgregarUser.TabStop = false;
			this.gbAgregarUser.Text = "Agregar/Eliminar usuario";
			// 
			// labelID
			// 
			this.labelID.AutoSize = true;
			this.labelID.Location = new System.Drawing.Point(54, 41);
			this.labelID.Name = "labelID";
			this.labelID.Size = new System.Drawing.Size(26, 20);
			this.labelID.TabIndex = 11;
			this.labelID.Text = "ID";
			// 
			// txtID
			// 
			this.txtID.Enabled = false;
			this.txtID.Location = new System.Drawing.Point(110, 41);
			this.txtID.Name = "txtID";
			this.txtID.Size = new System.Drawing.Size(170, 26);
			this.txtID.TabIndex = 10;
			// 
			// dgvUsuarios
			// 
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
			this.dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvUsuarios.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.dgvUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvUsuarios.Location = new System.Drawing.Point(341, 25);
			this.dgvUsuarios.Name = "dgvUsuarios";
			this.dgvUsuarios.Size = new System.Drawing.Size(327, 204);
			this.dgvUsuarios.TabIndex = 6;
			this.dgvUsuarios.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvUsuarios_CellMouseClick);
			// 
			// txtContraseña
			// 
			this.txtContraseña.Location = new System.Drawing.Point(110, 112);
			this.txtContraseña.Name = "txtContraseña";
			this.txtContraseña.PasswordChar = '*';
			this.txtContraseña.Size = new System.Drawing.Size(170, 26);
			this.txtContraseña.TabIndex = 5;
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(110, 76);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(170, 26);
			this.txtUser.TabIndex = 4;
			// 
			// btnAgregarUsuario
			// 
			this.btnAgregarUsuario.ForeColor = System.Drawing.Color.DimGray;
			this.btnAgregarUsuario.Location = new System.Drawing.Point(98, 166);
			this.btnAgregarUsuario.Name = "btnAgregarUsuario";
			this.btnAgregarUsuario.Size = new System.Drawing.Size(125, 81);
			this.btnAgregarUsuario.TabIndex = 2;
			this.btnAgregarUsuario.Text = "Agregar Usuario";
			this.btnAgregarUsuario.UseVisualStyleBackColor = true;
			this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
			// 
			// labelPass
			// 
			this.labelPass.AutoSize = true;
			this.labelPass.Location = new System.Drawing.Point(12, 115);
			this.labelPass.Name = "labelPass";
			this.labelPass.Size = new System.Drawing.Size(92, 20);
			this.labelPass.TabIndex = 1;
			this.labelPass.Text = "Contraseña";
			// 
			// labelUser
			// 
			this.labelUser.AutoSize = true;
			this.labelUser.Location = new System.Drawing.Point(36, 79);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new System.Drawing.Size(64, 20);
			this.labelUser.TabIndex = 0;
			this.labelUser.Text = "Usuario";
			// 
			// CrearUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(745, 329);
			this.Controls.Add(this.gbAgregarUser);
			this.Name = "CrearUser";
			this.Text = "CrearUser";
			this.Load += new System.EventHandler(this.CrearUser_Load);
			this.gbAgregarUser.ResumeLayout(false);
			this.gbAgregarUser.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox gbAgregarUser;
		private System.Windows.Forms.Label labelID;
		private System.Windows.Forms.TextBox txtID;
		private System.Windows.Forms.DataGridView dgvUsuarios;
		private System.Windows.Forms.TextBox txtContraseña;
		private System.Windows.Forms.TextBox txtUser;
		private System.Windows.Forms.Button btnAgregarUsuario;
		private System.Windows.Forms.Label labelPass;
		private System.Windows.Forms.Label labelUser;
	}
}