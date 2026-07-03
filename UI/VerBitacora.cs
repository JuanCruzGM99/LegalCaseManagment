using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class VerBitacora : Form
    {
        BLLBitacora bllBitacora = new BLLBitacora();

        public VerBitacora()
        {
            InitializeComponent();
        }

        private void VerBitacora_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            CargarBitacora();
        }

        private void ConfigurarFormulario()
        {
            cmbActividad.Items.Clear();
            cmbActividad.Items.Add("Todas");
            cmbActividad.Items.Add("Login exitoso");
            cmbActividad.Items.Add("Login fallido - usuario inexistente");
            cmbActividad.Items.Add("Login fallido - contraseña incorrecta");
            cmbActividad.Items.Add("Logout exitoso"); //[NBL003]
            cmbActividad.Items.Add("Restauracion de siniestro"); //[NBL004]
            cmbActividad.SelectedIndex = 0;

            dtpHoraDesde.Format = DateTimePickerFormat.Time;
            dtpHoraDesde.ShowUpDown = true;

            dtpHoraHasta.Format = DateTimePickerFormat.Time;
            dtpHoraHasta.ShowUpDown = true;

            dgvBitacora.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBitacora.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBitacora.ReadOnly = true;
            dgvBitacora.AllowUserToAddRows = false;
        }

        private void CargarBitacora()
        {
            DateTime? fechaDesde = null;
            DateTime? fechaHasta = null;
            TimeSpan? horaDesde = null;
            TimeSpan? horaHasta = null;
            string actividad = null;
            string usuario = null;

            if (chkFechaDesde.Checked)
                fechaDesde = dtpFechaDesde.Value.Date;

            if (chkFechaHasta.Checked)
                fechaHasta = dtpFechaHasta.Value.Date;

            if (chkHoraDesde.Checked)
                horaDesde = dtpHoraDesde.Value.TimeOfDay;

            if (chkHoraHasta.Checked)
                horaHasta = dtpHoraHasta.Value.TimeOfDay;

            if (cmbActividad.SelectedItem != null && cmbActividad.SelectedItem.ToString() != "Todas")
                actividad = cmbActividad.SelectedItem.ToString();

            if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
                usuario = txtUsuario.Text.Trim();

            dgvBitacora.DataSource = null;
            dgvBitacora.DataSource = bllBitacora.Listar(fechaDesde, fechaHasta, horaDesde, horaHasta, actividad, usuario);

            if (dgvBitacora.Columns["IDBitacora"] != null)
                dgvBitacora.Columns["IDBitacora"].Visible = false;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            CargarBitacora();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            chkFechaDesde.Checked = false;
            chkFechaHasta.Checked = false;
            chkHoraDesde.Checked = false;
            chkHoraHasta.Checked = false;
            cmbActividad.SelectedIndex = 0;
            txtUsuario.Text = "";

            CargarBitacora();
        }

    }
}
