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

namespace UI //[NBL005]
{
    public partial class GestionDetalleSiniestro : Form
    {
        private int idSiniestro;
        private string numeroSiniestro;
        private int idParteSeleccionada = 0;

        private BLLPersona bllPersona = new BLLPersona();
        private BLLTipoParte bllTipoParte = new BLLTipoParte();
        private BLLParte bllParte = new BLLParte();
        private BLLIntegranteParte bllIntegranteParte = new BLLIntegranteParte();
        private BLLVehiculo bllVehiculo = new BLLVehiculo();

        public GestionDetalleSiniestro(int idSiniestro, string numeroSiniestro)
        {
            InitializeComponent();

            this.idSiniestro = idSiniestro;
            this.numeroSiniestro = numeroSiniestro;
        }

        private void GestionDetalleSiniestro_Load(object sender, EventArgs e)
        {
            this.Text = "Detalle del siniestro " + numeroSiniestro;

            CargarCombos();
            CargarPersonas();
            CargarPartes();
            CargarVehiculos();
        }

        private void CargarCombos()
        {
            cmbTipoParte.DataSource = null;
            cmbTipoParte.DataSource = bllTipoParte.Listar();
            cmbTipoParte.DisplayMember = "Nombre";
            cmbTipoParte.ValueMember = "IDTipoParte";

            cmbPersona.DataSource = null;
            cmbPersona.DataSource = bllPersona.ListarActivas();
            cmbPersona.DisplayMember = "NombreRazonSocial";
            cmbPersona.ValueMember = "IDPersona";
        }

        private void CargarPersonas()
        {
            dgvPersonas.DataSource = null;
            dgvPersonas.DataSource = bllPersona.Listar();

            if (dgvPersonas.Columns["IDPersona"] != null)
                dgvPersonas.Columns["IDPersona"].Visible = false;
        }

        private void CargarPartes()
        {
            dgvPartes.DataSource = null;
            dgvPartes.DataSource = bllParte.ListarPorSiniestro(idSiniestro);

            if (dgvPartes.Columns["IDParte"] != null)
                dgvPartes.Columns["IDParte"].Visible = false;

            if (dgvPartes.Columns["IDSiniestro"] != null)
                dgvPartes.Columns["IDSiniestro"].Visible = false;

            if (dgvPartes.Columns["IDTipoParte"] != null)
                dgvPartes.Columns["IDTipoParte"].Visible = false;
        }

        private void CargarIntegrantes()
        {
            if (idParteSeleccionada == 0)
                return;

            dgvIntegrantes.DataSource = null;
            dgvIntegrantes.DataSource = bllIntegranteParte.ListarPorParte(idParteSeleccionada);

            if (dgvIntegrantes.Columns["IDIntegranteParte"] != null)
                dgvIntegrantes.Columns["IDIntegranteParte"].Visible = false;

            if (dgvIntegrantes.Columns["IDParte"] != null)
                dgvIntegrantes.Columns["IDParte"].Visible = false;

            if (dgvIntegrantes.Columns["IDPersona"] != null)
                dgvIntegrantes.Columns["IDPersona"].Visible = false;
        }

        private void CargarVehiculos()
        {
            dgvVehiculos.DataSource = null;
            dgvVehiculos.DataSource = bllVehiculo.ListarPorSiniestro(idSiniestro);

            if (dgvVehiculos.Columns["IDVehiculo"] != null)
                dgvVehiculos.Columns["IDVehiculo"].Visible = false;

            if (dgvVehiculos.Columns["IDSiniestro"] != null)
                dgvVehiculos.Columns["IDSiniestro"].Visible = false;
        }

        private void btnCrearPersona_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreRazonSocial.Text))
            {
                MessageBox.Show("Debe ingresar el nombre o razón social.");
                return;
            }

            EEPersona persona = new EEPersona();

            persona.NombreRazonSocial = txtNombreRazonSocial.Text.Trim();
            persona.CUIT = txtCUIT.Text.Trim();
            persona.CBU = txtCBU.Text.Trim();
            persona.Observaciones = txtObservacionesPersona.Text.Trim();
            persona.Activo = true;

            bool resultado = bllPersona.Crear(persona);

            if (resultado)
            {
                MessageBox.Show("Persona creada correctamente.");

                LimpiarPersona();
                CargarPersonas();
                CargarCombos();
            }
            else
            {
                MessageBox.Show("No se pudo crear la persona.");
            }
        }

        private void btnCrearParte_Click(object sender, EventArgs e)
        {
            if (cmbTipoParte.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de parte.");
                return;
            }

            EEParte parte = new EEParte();

            parte.IDSiniestro = idSiniestro;
            parte.IDTipoParte = Convert.ToInt32(cmbTipoParte.SelectedValue);
            parte.Observaciones = txtObservacionesParte.Text.Trim();

            bool resultado = bllParte.Crear(parte);

            if (resultado)
            {
                MessageBox.Show("Parte creada correctamente.");

                txtObservacionesParte.Clear();
                CargarPartes();
            }
            else
            {
                MessageBox.Show("No se pudo crear la parte. Puede que ya exista ese tipo de parte para este siniestro.");
            }
        }

        private void dgvPartes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            idParteSeleccionada = Convert.ToInt32(
                dgvPartes.Rows[e.RowIndex].Cells["IDParte"].Value
            );

            CargarIntegrantes();
        }

        private void btnAgregarIntegrante_Click(object sender, EventArgs e)
        {
            if (idParteSeleccionada == 0)
            {
                MessageBox.Show("Debe seleccionar una parte.");
                return;
            }

            if (cmbPersona.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar una persona.");
                return;
            }

            decimal monto;
            decimal? montoFinal = null;

            if (!string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                if (!decimal.TryParse(txtMonto.Text.Trim(), out monto))
                {
                    MessageBox.Show("El monto ingresado no es válido.");
                    return;
                }

                montoFinal = monto;
            }

            EEIntegranteParte integrante = new EEIntegranteParte();

            integrante.IDParte = idParteSeleccionada;
            integrante.IDPersona = Convert.ToInt32(cmbPersona.SelectedValue);
            integrante.Monto = montoFinal;
            integrante.PlazoPago = txtPlazoPago.Text.Trim();
            integrante.EsPrincipal = chkEsPrincipal.Checked;
            integrante.Observaciones = txtObservacionesIntegrante.Text.Trim();

            bool resultado = bllIntegranteParte.Crear(integrante);

            if (resultado)
            {
                MessageBox.Show("Integrante agregado correctamente.");

                LimpiarIntegrante();
                CargarIntegrantes();
            }
            else
            {
                MessageBox.Show("No se pudo agregar el integrante. Puede que esa persona ya esté cargada en esta parte.");
            }
        }

        private void btnCrearVehiculo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMarca.Text))
            {
                MessageBox.Show("Debe ingresar la marca.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDominio.Text))
            {
                MessageBox.Show("Debe ingresar el dominio.");
                return;
            }

            EEVehiculo vehiculo = new EEVehiculo();

            vehiculo.IDSiniestro = idSiniestro;
            vehiculo.Marca = txtMarca.Text.Trim();
            vehiculo.Modelo = txtModelo.Text.Trim();
            vehiculo.Dominio = txtDominio.Text.Trim();
            vehiculo.Observaciones = txtObservacionesVehiculo.Text.Trim();

            bool resultado = bllVehiculo.Crear(vehiculo);

            if (resultado)
            {
                MessageBox.Show("Vehículo creado correctamente.");

                LimpiarVehiculo();
                CargarVehiculos();
            }
            else
            {
                MessageBox.Show("No se pudo crear el vehículo. Puede que el dominio ya exista para este siniestro.");
            }
        }

        private void LimpiarPersona()
        {
            txtNombreRazonSocial.Clear();
            txtCUIT.Clear();
            txtCBU.Clear();
            txtObservacionesPersona.Clear();
        }

        private void LimpiarIntegrante()
        {
            txtMonto.Clear();
            txtPlazoPago.Clear();
            chkEsPrincipal.Checked = false;
            txtObservacionesIntegrante.Clear();
        }

        private void LimpiarVehiculo()
        {
            txtMarca.Clear();
            txtModelo.Clear();
            txtDominio.Clear();
            txtObservacionesVehiculo.Clear();
        }
    }
}