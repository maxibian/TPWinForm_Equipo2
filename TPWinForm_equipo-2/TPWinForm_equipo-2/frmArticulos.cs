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
using System.IO;
using System.Net;
using System.Threading;

namespace TPWinForm_equipo_2
{
    public partial class frmArticulos : Form
    {
        private List<Articulo> listaArticulos;
        private List<Imagen> imagenArticulos;
        private List<Imagen> listaImagenesSeleccionado = new List<Imagen>();
        private int indiceImagen = 0;
        private string ruta = Path.Combine(Directory.GetParent(Application.StartupPath).Parent.Parent.FullName, "placeholder.jpg");
        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Marca");
            cboCampo.Items.Add("Categoria");
            cboCampo.Items.Add("Precio");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAltaArticulo alta = new frmAltaArticulo();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
            frmAltaArticulo modificar = new frmAltaArticulo(seleccionado);
            modificar.Text = "Modificar Artículo";
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("¿Realmente quiere eliminar el Artículo?", "Eliminando", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;
                    articuloNegocio.eliminar(seleccionado.Id);
                    cargar();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void cargar()
        {
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            try
            {
                listaArticulos = articuloNegocio.listarArticulos();
                imagenArticulos = imagenNegocio.listarImagenes();                
                dgvListaArticulos.DataSource = listaArticulos;
                dgvListaArticulos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        
        private void btnAdminCategorias_Click(object sender, EventArgs e)
        {
            frmCategorias categorias = new frmCategorias();
            categorias.ShowDialog();
        }

        private void btnAdministrarMarcas_Click(object sender, EventArgs e)
        {
            frmMarcas marcas = new frmMarcas();
            marcas.ShowDialog();
        }

        private void btnFiltro_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvListaArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void txtBoxFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Articulo> listaFiltro;
            string filtro = txtBoxFiltro.Text;


            if (filtro != "")
            {
                listaFiltro = listaArticulos.FindAll(articulo => articulo.Nombre.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltro = listaArticulos;
            }

            dgvListaArticulos.DataSource = null;
            dgvListaArticulos.DataSource = listaFiltro;
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();

                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();

                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }

        private void dgvListaArticulos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvListaArticulos.CurrentRow == null)
                    return;

                if (dgvListaArticulos.CurrentRow.DataBoundItem == null)
                    return;

                Articulo seleccionado = (Articulo)dgvListaArticulos.CurrentRow.DataBoundItem;

                indiceImagen = 0;
                listaImagenesSeleccionado.Clear();
                foreach (Imagen imagen in imagenArticulos)
                {
                    if (seleccionado.Id == imagen.IdArticulo)
                    {
                        listaImagenesSeleccionado.Add(imagen);
                    }
                }
                if (listaImagenesSeleccionado.Count > 0)
                {
                    pboArticulo.Load(listaImagenesSeleccionado[indiceImagen].ImagenUrl);
                }
                else
                {
                    pboArticulo.Load(ruta);
                }
            }
            catch (Exception ex)
            {
                pboArticulo.Load(ruta);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaImagenesSeleccionado.Count == 0)
                    return;

                indiceImagen--;

                if (indiceImagen < 0)
                    indiceImagen = listaImagenesSeleccionado.Count - 1;

                pboArticulo.Load(listaImagenesSeleccionado[indiceImagen].ImagenUrl);
            }
            catch (Exception ex)
            {
                pboArticulo.Load(ruta);
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            try
            {
                if (listaImagenesSeleccionado.Count == 0)
                    return;
                indiceImagen++;
                if (indiceImagen >= listaImagenesSeleccionado.Count)
                    indiceImagen = 0;
                pboArticulo.Load(listaImagenesSeleccionado[indiceImagen].ImagenUrl);
            }
            catch (Exception ex)
            {
                pboArticulo.Load(ruta);
            }
        }
    }
}
