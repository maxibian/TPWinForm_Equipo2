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
            if (dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una categoria");
                return;
            }
            seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;
            frmAltaCategorias modificarCategoria = new frmAltaCategorias(seleccionada);
            modificarCategoria.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            if(dgvCategorias.CurrentRow == null)
            {
                MessageBox.Show("Debe seleccionar una categoria");
                return;
            } 

            Categoria seleccionada = (Categoria)dgvCategorias.CurrentRow.DataBoundItem;

            if (catNegocio.estaEnUso(seleccionada.Id))
            {
                MessageBox.Show("No se puede eliminar la categoria porque está siendo utilizada por uno o mas artículos");
                return;
            }

            try
            {
                DialogResult respuesta = MessageBox.Show("¿Estas seguro de que queres eliminar la categoria?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(respuesta == DialogResult.Yes)
                {
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
