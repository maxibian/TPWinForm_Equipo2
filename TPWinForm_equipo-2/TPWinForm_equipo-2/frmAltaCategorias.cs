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
    public partial class frmAltaCategorias : Form
    {
        public frmAltaCategorias()
        {
            InitializeComponent();
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptarCategoria_Click(object sender, EventArgs e)
        {
            Categoria cat = new Categoria();
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            try
            {
                cat.Descripcion = txtNombreCategoria.Text;
                catNegocio.agregar(cat);
                MessageBox.Show("Agregado exitosamente");
                Close();
            } 
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
