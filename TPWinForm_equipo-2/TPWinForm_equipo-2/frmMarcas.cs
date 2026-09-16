using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm_equipo_2
{
    public partial class frmMarcas : Form
    {
        List<Marca> listaMarca;
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            try
            {
                listaMarca = marcaNegocio.listarMarcas();
                dgvMarca.DataSource = listaMarca;
                dgvMarca.Columns["Descripcion"].HeaderText = "MARCAS";
                dgvMarca.Columns["Id"].Visible = false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaMarca alta = new frmAltaMarca();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Marca seleccionado;
            seleccionado = (Marca)dgvMarca.CurrentRow.DataBoundItem;
            frmAltaMarca modificar = new frmAltaMarca(seleccionado);
            modificar.ShowDialog();
            cargar();
        }
    }
}
