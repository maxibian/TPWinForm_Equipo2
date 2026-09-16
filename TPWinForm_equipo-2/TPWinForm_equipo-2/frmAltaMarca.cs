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
    public partial class frmAltaMarca : Form
    {
        Marca marca = null;
        public frmAltaMarca()
        {
            InitializeComponent();
        }
        public frmAltaMarca(Marca marc)
        {
            InitializeComponent();
            this.marca = marc;
            Text = "Modificar Marca";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            MarcaNegocio negocio = new MarcaNegocio();

            try
            {
                if(marca == null)
                {
                    marca = new Marca();
                }

                marca.Descripcion = txtMarca.Text;

                if(marca.Id != 0)
                {
                    negocio.modificar(marca);
                    MessageBox.Show("Modificado correctamente");
                }
                else 
                {
                    negocio.agregar(marca);
                    MessageBox.Show("Agregado correctamente");
                }


                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmAltaMarca_Load(object sender, EventArgs e)
        {
            try
            {
                if (marca != null)
                {
                    txtMarca.Text = marca.Descripcion;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}
