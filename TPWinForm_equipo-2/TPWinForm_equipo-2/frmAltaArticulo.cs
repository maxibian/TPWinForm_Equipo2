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
        private ImagenNegocio imagenNegocio = new ImagenNegocio();
        private List<Imagen> listaImagenes = new List<Imagen>();
        private List<Imagen> imagenesArticulo = new List<Imagen>();
        int indice;
        int idArt;

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
                btnSiguiente.Enabled = false;
                btnAnterior.Enabled = false;
                indice = 0;
                lblIndex.Text = (indice + 1).ToString();
                cboMarca.DataSource = marcaNegocio.listarMarcas();
                cboMarca.ValueMember = "Id";
                cboMarca.DisplayMember = "Descripcion";
                cboCategoria.DataSource = categoriaNegocio.listarCategorias();
                cboCategoria.ValueMember = "Id";
                cboCategoria.DisplayMember = "Descripcion";
                if (art != null)
                {
                    idArt = art.Id;
                    listaImagenes = imagenNegocio.listarImagenes();
                    imagenesArticulo.Clear();
                    foreach (Imagen img in listaImagenes)
                    {
                        if (idArt == img.IdArticulo)
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

                    if (imagenesArticulo.Count == 0)
                        pboAltaArticulos.Load(ruta);
                    //Imagen
                    if (imagenesArticulo.Count > 0)
                    {
                        try
                        {
                            pboAltaArticulos.Load(imagenesArticulo[0].ImagenUrl);
                            btnSiguiente.Enabled = true;
                            btnAnterior.Enabled = true;
                        }
                        catch (Exception)
                        {

                            pboAltaArticulos.Load(ruta);
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            frmAltaImagen frmAltaImagen = new frmAltaImagen(idArt);

            frmAltaImagen.ShowDialog();
        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Imagen seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Realmente quiere eliminar el Artículo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Imagen)imagenesArticulo[indice];
                    imagenNegocio.eliminar(seleccionado.Id);
                    //cargar();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (imagenesArticulo.Count == 0)
                    return;
                indice++;
                lblIndex.Text = (indice + 1).ToString();
                if (indice >= imagenesArticulo.Count)
                {
                    indice = 0;
                    lblIndex.Text = (indice + 1).ToString();
                }
                pboAltaArticulos.Load(imagenesArticulo[indice].ImagenUrl);
                //MessageBox.Show("id foto "+imagenesArticulo[indice].Id.ToString());
            }
            catch (Exception)
            {
                pboAltaArticulos.Load(ruta);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (imagenesArticulo.Count == 0)
                    return;
                indice--;
                if (indice < 0)
                {
                    indice = imagenesArticulo.Count - 1;
                    lblIndex.Text = (indice).ToString();
                }
                lblIndex.Text = (indice + 1).ToString();
                pboAltaArticulos.Load(imagenesArticulo[indice].ImagenUrl);
            }
            catch (Exception)
            {
                pboAltaArticulos.Load(ruta);
            }
        }
    }
}
