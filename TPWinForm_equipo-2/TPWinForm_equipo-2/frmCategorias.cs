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
using dominio;

namespace TPWinForm_equipo_2
{
    public partial class frmCategorias : Form
    {
        List<Categoria> listaCategorias;
        public frmCategorias()
        {
            InitializeComponent();
        }

        private void cargar()
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                listaCategorias = categoriaNegocio.listarCategorias();
                dgvCategorias.DataSource = listaCategorias;
                dgvCategorias.Columns["Id"].Visible = false;
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmCategorias_Load(object sender, EventArgs e)
        {
            cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaCategorias altaCategoria = new frmAltaCategorias();
            altaCategoria.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Categoria seleccionada;
            seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            frmAltaCategorias modificarCategoria = new frmAltaCategorias(seleccionada);
            modificarCategoria.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            Categoria seleccionada = new Categoria();
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Estas seguro de que queres eliminarlo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
                    seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
                    catNegocio.eliminar(seleccionada.Id);
                    cargar();
                }
                
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
