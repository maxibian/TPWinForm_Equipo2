using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TPWinForm_equipo_2
{
    public partial class frmAltaArticulo : Form
    {
        private Articulo art = null;
        private string ruta = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName, "placeholder.jpg");
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
                    int id = art.Id;
                    ImagenNegocio imagenNegocio = new ImagenNegocio();
                    List<Imagen> listaImagenes = new List<Imagen>();
                    List<Imagen> imagenesArticulo = new List<Imagen>();
                    listaImagenes = imagenNegocio.listarImagenes();
                    foreach (Imagen img in listaImagenes)
                    {
                        if(id == img.Id)
                        {
                            imagenesArticulo.Add(img);
                        }
                    }

                    txtNombre.Text = art.Nombre.ToString();
                    txtDescripcion.Text = art.Descripcion.ToString();
                    txtPrecio.Text = art.Precio.ToString();
                    txtCodigo.Text = art.Codigo.ToString();
                    cboMarca.SelectedValue = art.Marca.Id;
                    cboCategoria.SelectedValue = art.Categoria.Id;

                    //Imagen
                    if (imagenesArticulo.Count > 0)
                        pboAltaArticulos.Load(imagenesArticulo[0].ImagenUrl);
                    else
                        pboAltaArticulos.Load(ruta);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            frmAltaImagen frmAltaImagen = new frmAltaImagen();
            frmAltaImagen.ShowDialog();
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {

        }
    }
}
