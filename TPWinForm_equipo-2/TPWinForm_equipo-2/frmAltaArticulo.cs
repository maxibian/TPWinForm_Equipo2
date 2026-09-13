using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;
using dominio;

namespace TPWinForm_equipo_2
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo art = null;
        public frmAltaArticulo()
        {
            InitializeComponent();
        }
        public frmAltaArticulo(Articulo art)
        {
            InitializeComponent();
            this.art = art; 
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Articulo art = new Articulo();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                art.Nombre = txtNombre.Text;
                art.Descripcion = txtDescripcion.Text;
                //art.Imagen = txtImagen.Text;
                art.Precio = decimal.Parse(txtPrecio.Text);
                //art.Marca;
                //art.Categoria;
                articuloNegocio.agregar(art);
                MessageBox.Show("Articulo agregado exitosamente");
                Close();
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            //cboMarca
            //cboCategoria
            if(art != null)
            {
                txtNombre.Text = art.Nombre.ToString();
                txtDescripcion.Text = art.Descripcion.ToString();
                txtPrecio.Text = art.Precio.ToString();
            }
        }
    }
}
