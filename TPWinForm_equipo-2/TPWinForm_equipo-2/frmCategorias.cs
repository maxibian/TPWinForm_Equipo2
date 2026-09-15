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
    }
}
