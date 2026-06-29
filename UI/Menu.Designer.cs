namespace UI
{
	partial class Menu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.agregarUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGestorUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGestorPermisos = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verBitacoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.agregarUsuarioToolStripMenuItem,
            this.gestoresToolStripMenuItem,
            this.bitacoraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1067, 42);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // agregarUsuarioToolStripMenuItem
            // 
            this.agregarUsuarioToolStripMenuItem.Name = "agregarUsuarioToolStripMenuItem";
            this.agregarUsuarioToolStripMenuItem.Size = new System.Drawing.Size(206, 38);
            this.agregarUsuarioToolStripMenuItem.Text = "Agregar Usuario";
            this.agregarUsuarioToolStripMenuItem.Click += new System.EventHandler(this.agregarUsuarioToolStripMenuItem_Click);
            // 
            // gestoresToolStripMenuItem
            // 
            this.gestoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGestorUsuarios,
            this.mnuGestorPermisos});
            this.gestoresToolStripMenuItem.Name = "gestoresToolStripMenuItem";
            this.gestoresToolStripMenuItem.Size = new System.Drawing.Size(127, 38);
            this.gestoresToolStripMenuItem.Text = "Gestores";
            // 
            // mnuGestorUsuarios
            // 
            this.mnuGestorUsuarios.Name = "mnuGestorUsuarios";
            this.mnuGestorUsuarios.Size = new System.Drawing.Size(367, 44);
            this.mnuGestorUsuarios.Text = "Gestion de usarios";
            this.mnuGestorUsuarios.Click += new System.EventHandler(this.gestionDeToolStripMenuItem_Click);
            // 
            // mnuGestorPermisos
            // 
            this.mnuGestorPermisos.Name = "mnuGestorPermisos";
            this.mnuGestorPermisos.Size = new System.Drawing.Size(367, 44);
            this.mnuGestorPermisos.Text = "Gestion de permisos";
            this.mnuGestorPermisos.Click += new System.EventHandler(this.gestionDePermisosToolStripMenuItem_Click);
            // 
            // bitacoraToolStripMenuItem
            // 
            this.bitacoraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verBitacoraToolStripMenuItem});
            this.bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            this.bitacoraToolStripMenuItem.Size = new System.Drawing.Size(120, 38);
            this.bitacoraToolStripMenuItem.Text = "Bitacora";
            // 
            // verBitacoraToolStripMenuItem
            // 
            this.verBitacoraToolStripMenuItem.Name = "verBitacoraToolStripMenuItem";
            this.verBitacoraToolStripMenuItem.Size = new System.Drawing.Size(359, 44);
            this.verBitacoraToolStripMenuItem.Text = "Ver";
            this.verBitacoraToolStripMenuItem.Click += new System.EventHandler(this.verBitacoraToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Menu";
            this.Text = "Menú";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_FormClosed);
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem agregarUsuarioToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem gestoresToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem mnuGestorUsuarios;
		private System.Windows.Forms.ToolStripMenuItem mnuGestorPermisos;
        private System.Windows.Forms.ToolStripMenuItem bitacoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verBitacoraToolStripMenuItem;
    }
}