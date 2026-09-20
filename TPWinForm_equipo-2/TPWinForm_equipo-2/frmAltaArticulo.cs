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
using System.Threading;
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
        public frmAltaArticulo(Articulo art, bool detalle)
        {
            InitializeComponent();
            this.art = art;
            Text = "Detalles Artículo";
            txtCodigo.Enabled = false;
            txtNombre.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            cboCategoria.Enabled = false;
            cboMarca.Enabled = false;
            btnAgregarImagen.Enabled = false;
            btnEliminarImagen.Enabled = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void lblInvalido(bool value)
        {
            lblValorInvalido1.Visible = value;
            lblValorInvalido2.Visible = value;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                if (art == null)
                    art = new Articulo();
                //MessageBox.Show("articulo " + art.Id);
                if (!string.IsNullOrWhiteSpace(txtNombre.Text) &&
    txtNombre.Text.All(c => char.IsLetter(c) || c == ' '))
                {
                    art.Nombre = txtNombre.Text;
                    lblNombreInvalido.Visible = false;
                    lblInvalido(false);
                }
                else
                {
                    lblNombreInvalido.Visible = true;
                    lblInvalido(true);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txtDescripcion.Text) &&
    txtDescripcion.Text.All(c => char.IsLetter(c) || c == ' '))
                {
                    art.Descripcion = txtDescripcion.Text;
                    lblDescripcionInvalida.Visible = false;
                    lblInvalido(false);
                }
                else
                {
                    lblDescripcionInvalida.Visible = true;
                    lblInvalido(true);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txtPrecio.Text) &&
    decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    art.Precio = decimal.Parse(txtPrecio.Text);
                    lblPrecioInvalido.Visible = false;
                    lblInvalido(false);
                }
                else
                {
                    lblPrecioInvalido.Visible = true;
                    lblInvalido(true);
                    return;
                }
                if (!string.IsNullOrWhiteSpace(txtCodigo.Text) &&
    txtCodigo.Text.All(char.IsLetterOrDigit))
                {
                    art.Codigo = txtCodigo.Text;
                    lblCodigoInvalido.Visible = false;
                    lblInvalido(false);
                }
                else
                {
                    lblCodigoInvalido.Visible = true;
                    lblInvalido(true);
                    return;
                }
                art.Marca = (Marca)cboMarca.SelectedItem;
                art.Categoria = (Categoria)cboCategoria.SelectedItem;
                if (art.Id != 0)
                {
                    articuloNegocio.modificar(art);

                    foreach (Imagen imagen in imagenesArticulo)
                    {
                        if (imagen.Id == 0)
                        {
                            imagen.IdArticulo = art.Id;
                            imagenNegocio.agregar(imagen);
                        }
                    }

                    MessageBox.Show("Modificado exitosamente");
                }
                else
                {
                    int idNuevo = articuloNegocio.agregar(art);

                    foreach (Imagen imagen in imagenesArticulo)
                    {

                        imagen.IdArticulo = idNuevo;
                        imagenNegocio.agregar(imagen);

                    }




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
                if (art == null)
                {
                    pboAltaArticulos.Load(ruta);
                    lblIndex.Text = "0";
                    btnEliminarImagen.Enabled = false;

                }

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
                    {
                        pboAltaArticulos.Load(ruta);
                        lblIndex.Text = "0";
                        btnEliminarImagen.Enabled = false;
                    }
                    //Imagen
                    if (imagenesArticulo.Count > 0)
                    {

                        try
                        {
                            pboAltaArticulos.Load(imagenesArticulo[0].ImagenUrl);

                        }
                        catch (Exception)
                        {
                            pboAltaArticulos.Load(ruta);
                        }
                        btnSiguiente.Enabled = true;
                        btnAnterior.Enabled = true;
                        btnEliminarImagen.Enabled = true;
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
            try
            {
                frmAltaImagen frmAltaImagen = new frmAltaImagen(idArt);
                frmAltaImagen.ShowDialog();
                if (frmAltaImagen.imagenCreada != null)
                {
                    
                        imagenesArticulo.Add(frmAltaImagen.imagenCreada);
                    //-----------
                    
                    //-----------
                    btnEliminarImagen.Enabled = true;
                    indice = imagenesArticulo.Count - 1;
                    try
                    {
                        pboAltaArticulos.Load(imagenesArticulo[indice].ImagenUrl);

                    }
                    catch (Exception)
                    {
                        pboAltaArticulos.Load(ruta);
                    }

                    lblIndex.Text = (imagenesArticulo.Count).ToString();
                    if (imagenesArticulo.Count > 1)
                    {
                        btnSiguiente.Enabled = true;
                        btnAnterior.Enabled = true;
                    }
                }


            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            Imagen seleccionado;
            try
            {
                //MessageBox.Show("antes count " + listaImagenes.Count);
                MessageBox.Show("antes imagenarticulo " + imagenesArticulo.Count);
                DialogResult respuesta = MessageBox.Show("¿Realmente quiere eliminar el Artículo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {

                    if (imagenesArticulo.Count > 0)
                    {
                        seleccionado = (Imagen)imagenesArticulo[indice];
                        imagenNegocio.eliminar(seleccionado.Id);
                        //si el indice es menor o igual al count poner siguiente n| lbl y siguiente pic
                        //sino, restar 1 lbl y 1 pic anterior mostrar
                        //sino mostrar placeholder y lbl 0
                        listaImagenes = imagenNegocio.listarImagenes();
                        imagenesArticulo.Clear();
                        foreach (Imagen img in listaImagenes)
                        {
                            if (idArt == img.IdArticulo)
                            {
                                imagenesArticulo.Add(img);
                            }
                        }
                        try
                        {
                            pboAltaArticulos.Load(imagenesArticulo[0].ImagenUrl);
                            
                        }
                        catch (Exception)
                        {
                            pboAltaArticulos.Load(ruta);
                            
                        }
                        lblIndex.Text = "1";
                        indice = 0;

                    }
                    else
                    {
                        pboAltaArticulos.Load(ruta);
                        MessageBox.Show("El artículo no tiene imágenes");
                        lblIndex.Text = "0";
                        indice = 0;
                    }
                    MessageBox.Show("dps 2 imagenarticulo " + imagenesArticulo.Count);
                    //cargar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
