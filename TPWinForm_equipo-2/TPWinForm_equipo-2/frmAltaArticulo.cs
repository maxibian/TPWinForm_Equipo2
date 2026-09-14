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
            Text = "Modificar Artículo";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                if (art == null)
                    art = new Articulo();
                art.Nombre = txtNombre.Text;
                art.Descripcion = txtDescripcion.Text;
                art.Codigo = txtCodigo.Text;
                //art.Imagen = txtImagen.Text;
                art.Precio = decimal.Parse(txtPrecio.Text);
                art.Marca = (Marca)cboMarca.SelectedItem;
                art.Categoria = (Categoria)cboCategoria.SelectedItem;
                if (art.Id != 0)
                {
                    articuloNegocio.modificar(art);
                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    articuloNegocio.agregar(art);
                    MessageBox.Show("Articulo agregado exitosamente");
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void frmAltaArticulo_Load(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            try
            {
                cboMarca.DataSource = marcaNegocio.listarMarcas();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.listarCategorias();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                if (art != null)
                {
                    txtNombre.Text = art.Nombre.ToString();
                    txtDescripcion.Text = art.Descripcion.ToString();
                    txtPrecio.Text = art.Precio.ToString();
                    txtCodigo.Text = art.Codigo.ToString();
                    cboMarca.SelectedValue = art.Marca.Id;
                    cboCategoria.SelectedValue = art.Categoria.Id;

                    //Imagen
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
    }
}
