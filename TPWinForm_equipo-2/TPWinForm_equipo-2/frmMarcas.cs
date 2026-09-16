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
        private List<Marca> listaMarca;
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            cargar();
        }
        private void cargar()
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            dgvMarca.DataSource = marcaNegocio.listarMarcas();
            dgvMarca.Columns["Descripcion"].HeaderText = "MARCAS";
            dgvMarca.Columns["Id"].Visible = false;
        }
        private void dgvMarca_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaMarca alta = new frmAltaMarca();
            alta.ShowDialog();
        }
    }
}
