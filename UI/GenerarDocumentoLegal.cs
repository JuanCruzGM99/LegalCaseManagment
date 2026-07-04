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
    public partial class GenerarDocumentoLegal : Form //[NBL006]
    {
        private int idSiniestro;
        private string numeroSiniestro;

        private BLLDocumentoLegal bllDocumentoLegal = new BLLDocumentoLegal();

        public GenerarDocumentoLegal(int idSiniestro, string numeroSiniestro)
        {
            InitializeComponent();

            this.idSiniestro = idSiniestro;
            this.numeroSiniestro = numeroSiniestro;
        }

        private void GenerarDocumentoLegal_Load(object sender, EventArgs e)
        {
            this.Text = "Generar documento - Siniestro " + numeroSiniestro;

            cmbTipoDocumento.Items.Clear();
            cmbTipoDocumento.Items.Add(TiposDocumentoLegal.AcuerdoLegal);
            cmbTipoDocumento.Items.Add(TiposDocumentoLegal.FormularioPago);
            cmbTipoDocumento.SelectedIndex = 0;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbTipoDocumento.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de documento.");
                return;
            }

            string tipoDocumento = cmbTipoDocumento.SelectedItem.ToString();

            string vistaPrevia = bllDocumentoLegal.GenerarDocumento(
                idSiniestro,
                tipoDocumento
            );

            txtVistaPrevia.Text = vistaPrevia;
        }
    }
}
