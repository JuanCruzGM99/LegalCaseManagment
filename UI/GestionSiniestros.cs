using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Services;

namespace UI //[NBL004] Se crea formulario GestionSiniestros
{
    public partial class GestionSiniestros : Form
    {
        BLLSiniestro bllSiniestro = new BLLSiniestro();

        private int idSiniestroSeleccionado = 0;

        public GestionSiniestros()
        {
            InitializeComponent();
        }

        private void GestionSiniestros_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            CargarSiniestros();
        }

        private void ConfigurarFormulario()
        {
            cmbEstado.Items.Clear();
            cmbEstado.Items.Add("En curso");
            cmbEstado.Items.Add("Terminado");
            cmbEstado.Items.Add("Pagado");
            cmbEstado.SelectedIndex = 0;

            dgvSiniestros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSiniestros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSiniestros.ReadOnly = true;
            dgvSiniestros.AllowUserToAddRows = false;

            dgvCambios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCambios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCambios.ReadOnly = true;
            dgvCambios.AllowUserToAddRows = false;

            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;
        }

        private void CargarSiniestros()
        {
            dgvSiniestros.DataSource = null;
            dgvSiniestros.DataSource = bllSiniestro.Listar();

            if (dgvSiniestros.Columns["IDSiniestro"] != null)
                dgvSiniestros.Columns["IDSiniestro"].Visible = false;
        }

        private EESiniestro ObtenerSiniestroDesdePantalla()
        {
            EESiniestro siniestro = new EESiniestro();

            siniestro.IDSiniestro = idSiniestroSeleccionado;
            siniestro.NumeroSiniestro = txtNumeroSiniestro.Text.Trim();
            siniestro.Caratula = txtCaratula.Text.Trim();
            siniestro.AnalistaInterno = txtAnalistaInterno.Text.Trim();
            siniestro.FechaSiniestro = dtpFechaSiniestro.Value.Date;
            siniestro.LugarSiniestro = txtLugarSiniestro.Text.Trim();
            siniestro.Estado = cmbEstado.SelectedItem.ToString();
            siniestro.Observaciones = txtObservaciones.Text.Trim();

            return siniestro;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNumeroSiniestro.Text))
            {
                MessageBox.Show("Debe ingresar el número de siniestro.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtCaratula.Text))
            {
                MessageBox.Show("Debe ingresar la carátula.");
                return false;
            }

            if (cmbEstado.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un estado.");
                return false;
            }

            return true;
        }

        private void LimpiarCampos()
        {
            idSiniestroSeleccionado = 0;

            txtNumeroSiniestro.Text = "";
            txtCaratula.Text = "";
            txtAnalistaInterno.Text = "";
            dtpFechaSiniestro.Value = DateTime.Today;
            txtLugarSiniestro.Text = "";
            cmbEstado.SelectedIndex = 0;
            txtObservaciones.Text = "";

            dgvCambios.DataSource = null;
            dgvHistorial.DataSource = null;
        }

        private int ObtenerIdUsuarioActual()
        {
            return SessionManager.GetInstance.Usuario.ID;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidarCampos())
                    return;

                EESiniestro siniestro = ObtenerSiniestroDesdePantalla();

                bllSiniestro.Crear(siniestro);

                MessageBox.Show("Siniestro agregado correctamente.");

                LimpiarCampos();
                CargarSiniestros();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar siniestro: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idSiniestroSeleccionado == 0)
                {
                    MessageBox.Show("Debe seleccionar un siniestro.");
                    return;
                }

                if (!ValidarCampos())
                    return;

                EESiniestro siniestro = ObtenerSiniestroDesdePantalla();

                int idUsuario = ObtenerIdUsuarioActual();

                bllSiniestro.Modificar(siniestro, idUsuario);

                MessageBox.Show("Siniestro modificado correctamente.");

                CargarSiniestros();
                CargarCambios();
                CargarHistorial();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar siniestro: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvSiniestros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow fila = dgvSiniestros.Rows[e.RowIndex];

            idSiniestroSeleccionado = Convert.ToInt32(fila.Cells["IDSiniestro"].Value);

            txtNumeroSiniestro.Text = fila.Cells["NumeroSiniestro"].Value.ToString();
            txtCaratula.Text = fila.Cells["Caratula"].Value.ToString();
            txtAnalistaInterno.Text = fila.Cells["AnalistaInterno"].Value.ToString();

            if (fila.Cells["FechaSiniestro"].Value != null && fila.Cells["FechaSiniestro"].Value != DBNull.Value)
                dtpFechaSiniestro.Value = Convert.ToDateTime(fila.Cells["FechaSiniestro"].Value);

            txtLugarSiniestro.Text = fila.Cells["LugarSiniestro"].Value.ToString();
            cmbEstado.SelectedItem = fila.Cells["Estado"].Value.ToString();
            txtObservaciones.Text = fila.Cells["Observaciones"].Value.ToString();

            CargarCambios();
            CargarHistorial();
        }

        private void CargarCambios()
        {
            if (idSiniestroSeleccionado == 0)
                return;

            dgvCambios.DataSource = null;
            dgvCambios.DataSource = bllSiniestro.ListarCambiosPorSiniestro(idSiniestroSeleccionado);

            OcultarColumnasCambios();
        }

        private void CargarHistorial()
        {
            if (idSiniestroSeleccionado == 0)
                return;

            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = bllSiniestro.ListarHistorialPorSiniestro(idSiniestroSeleccionado);

            if (dgvHistorial.Columns["IDHistorialSiniestro"] != null)
                dgvHistorial.Columns["IDHistorialSiniestro"].Visible = false;

            if (dgvHistorial.Columns["IDSiniestro"] != null)
                dgvHistorial.Columns["IDSiniestro"].Visible = false;
        }

        private void btnVerCambios_Click(object sender, EventArgs e)
        {
            CargarCambios();
        }

        

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvHistorial.CurrentRow == null)
                {
                    MessageBox.Show("Debe seleccionar un registro del historial.");
                    return;
                }

                int idHistorial = Convert.ToInt32(dgvHistorial.CurrentRow.Cells["IDHistorialSiniestro"].Value);
                int idUsuario = ObtenerIdUsuarioActual();

                DialogResult respuesta = MessageBox.Show(
                    "¿Desea restaurar el siniestro al estado seleccionado?",
                    "Restaurar siniestro",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (respuesta == DialogResult.Yes)
                {
                    bllSiniestro.RestaurarDesdeHistorial(idHistorial, idUsuario);

                    MessageBox.Show("Siniestro restaurado correctamente.");

                    CargarSiniestros();
                    CargarCambios();
                    CargarHistorial();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al restaurar siniestro: " + ex.Message);
            }
        }


        private void CargarCambiosPorHistorial(int idHistorialSiniestro)
        {
            if (idSiniestroSeleccionado == 0)
                return;

            var cambiosFiltrados = bllSiniestro
                .ListarCambiosPorSiniestro(idSiniestroSeleccionado)
                .Where(c => c.IDHistorialSiniestro == idHistorialSiniestro)
                .ToList();

            dgvCambios.DataSource = null;
            dgvCambios.DataSource = cambiosFiltrados;

            OcultarColumnasCambios();
        }

        private void OcultarColumnasCambios()
        {
            if (dgvCambios.Columns["IDControlCambio"] != null)
                dgvCambios.Columns["IDControlCambio"].Visible = false;

            if (dgvCambios.Columns["IDSiniestro"] != null)
                dgvCambios.Columns["IDSiniestro"].Visible = false;

            if (dgvCambios.Columns["IDHistorialSiniestro"] != null)
                dgvCambios.Columns["IDHistorialSiniestro"].Visible = false;
        }

        private void dgvHistorial_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            int idHistorialSiniestro = Convert.ToInt32(
                dgvHistorial.Rows[e.RowIndex].Cells["IDHistorialSiniestro"].Value
            );

            CargarCambiosPorHistorial(idHistorialSiniestro);
        }

    }
}
