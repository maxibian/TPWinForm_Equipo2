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
        private Categoria categoria = null;
        public frmAltaCategorias()
        {
            InitializeComponent();
        }

        public frmAltaCategorias(Categoria cat)
        {
            InitializeComponent();
            categoria = cat;
            Text = "Modificar Categoria";
        }

        private void btnCancelarCategoria_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio catNegocio = new CategoriaNegocio();
            try
            {
                if (categoria == null) categoria = new Categoria();

                categoria.Descripcion = txtNombreCategoria.Text;

                if(categoria.Id != 0)
                {
                    catNegocio.modificar(categoria);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    catNegocio.agregar(categoria);
                    MessageBox.Show("Agregado exitosamente");
                }
                
                Close();
            } 
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void frmAltaCategorias_Load(object sender, EventArgs e)
        {
            try
            {
                if(categoria != null)
                {
                    txtNombreCategoria.Text = categoria.Descripcion;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
