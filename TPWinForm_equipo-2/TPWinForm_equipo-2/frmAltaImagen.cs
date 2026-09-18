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
    public partial class frmAltaImagen : Form
    {
        private int idArt;
        public frmAltaImagen(int id)
        {
            
            InitializeComponent();
            idArt = id;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Imagen imagen = new Imagen();
            ImagenNegocio imagenNegocio = new ImagenNegocio();
            imagen.ImagenUrl = txtImagen.Text.ToString();
            imagen.IdArticulo = idArt;
            imagenNegocio.agregar(imagen);
            Close();
        }
    }
}
