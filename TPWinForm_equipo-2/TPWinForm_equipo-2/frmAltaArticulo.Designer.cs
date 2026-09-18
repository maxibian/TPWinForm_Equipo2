namespace TPWinForm_equipo_2
{
    partial class frmAltaArticulo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pboAltaArticulos = new System.Windows.Forms.PictureBox();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAgregarImagen = new System.Windows.Forms.Button();
            this.btnEliminarImagen = new System.Windows.Forms.Button();
            this.lblIndex = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNombreInvalido = new System.Windows.Forms.Label();
            this.lblDescripcionInvalida = new System.Windows.Forms.Label();
            this.lblPrecioInvalido = new System.Windows.Forms.Label();
            this.lblCodigoInvalido = new System.Windows.Forms.Label();
            this.lblValorInvalido2 = new System.Windows.Forms.Label();
            this.lblValorInvalido1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pboAltaArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(161, 337);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(80, 30);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(247, 337);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(134, 38);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(193, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(134, 66);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(193, 22);
            this.txtDescripcion.TabIndex = 3;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(134, 94);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(193, 22);
            this.txtPrecio.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Descripción:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(80, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Precio:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Código:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(134, 122);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(193, 22);
            this.txtCodigo.TabIndex = 10;
            // 
            // cboMarca
            // 
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(134, 150);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(193, 24);
            this.cboMarca.TabIndex = 12;
            // 
            // cboCategoria
            // 
            this.cboCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(134, 180);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(193, 24);
            this.cboCategoria.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(80, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Marca:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Categoría:";
            // 
            // pboAltaArticulos
            // 
            this.pboAltaArticulos.Location = new System.Drawing.Point(374, 38);
            this.pboAltaArticulos.Name = "pboAltaArticulos";
            this.pboAltaArticulos.Size = new System.Drawing.Size(300, 300);
            this.pboAltaArticulos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboAltaArticulos.TabIndex = 16;
            this.pboAltaArticulos.TabStop = false;
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(374, 345);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(47, 23);
            this.btnAnterior.TabIndex = 17;
            this.btnAnterior.Text = "<-";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(427, 345);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(47, 23);
            this.btnSiguiente.TabIndex = 18;
            this.btnSiguiente.Text = "->";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAgregarImagen
            // 
            this.btnAgregarImagen.Location = new System.Drawing.Point(590, 345);
            this.btnAgregarImagen.Name = "btnAgregarImagen";
            this.btnAgregarImagen.Size = new System.Drawing.Size(39, 23);
            this.btnAgregarImagen.TabIndex = 19;
            this.btnAgregarImagen.Text = "+";
            this.btnAgregarImagen.UseVisualStyleBackColor = true;
            this.btnAgregarImagen.Click += new System.EventHandler(this.btnAgregarImagen_Click);
            // 
            // btnEliminarImagen
            // 
            this.btnEliminarImagen.Location = new System.Drawing.Point(635, 344);
            this.btnEliminarImagen.Name = "btnEliminarImagen";
            this.btnEliminarImagen.Size = new System.Drawing.Size(39, 23);
            this.btnEliminarImagen.TabIndex = 20;
            this.btnEliminarImagen.Text = "-";
            this.btnEliminarImagen.UseVisualStyleBackColor = true;
            this.btnEliminarImagen.Click += new System.EventHandler(this.btnEliminarImagen_Click);
            // 
            // lblIndex
            // 
            this.lblIndex.AutoSize = true;
            this.lblIndex.Location = new System.Drawing.Point(555, 351);
            this.lblIndex.Name = "lblIndex";
            this.lblIndex.Size = new System.Drawing.Size(0, 16);
            this.lblIndex.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(481, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Imágen n°:";
            // 
            // lblNombreInvalido
            // 
            this.lblNombreInvalido.AutoSize = true;
            this.lblNombreInvalido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreInvalido.ForeColor = System.Drawing.Color.Red;
            this.lblNombreInvalido.Location = new System.Drawing.Point(333, 41);
            this.lblNombreInvalido.Name = "lblNombreInvalido";
            this.lblNombreInvalido.Size = new System.Drawing.Size(16, 20);
            this.lblNombreInvalido.TabIndex = 23;
            this.lblNombreInvalido.Text = "*";
            this.lblNombreInvalido.Visible = false;
            // 
            // lblDescripcionInvalida
            // 
            this.lblDescripcionInvalida.AutoSize = true;
            this.lblDescripcionInvalida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblDescripcionInvalida.ForeColor = System.Drawing.Color.Red;
            this.lblDescripcionInvalida.Location = new System.Drawing.Point(333, 69);
            this.lblDescripcionInvalida.Name = "lblDescripcionInvalida";
            this.lblDescripcionInvalida.Size = new System.Drawing.Size(16, 20);
            this.lblDescripcionInvalida.TabIndex = 24;
            this.lblDescripcionInvalida.Text = "*";
            this.lblDescripcionInvalida.Visible = false;
            // 
            // lblPrecioInvalido
            // 
            this.lblPrecioInvalido.AutoSize = true;
            this.lblPrecioInvalido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblPrecioInvalido.ForeColor = System.Drawing.Color.Red;
            this.lblPrecioInvalido.Location = new System.Drawing.Point(333, 97);
            this.lblPrecioInvalido.Name = "lblPrecioInvalido";
            this.lblPrecioInvalido.Size = new System.Drawing.Size(16, 20);
            this.lblPrecioInvalido.TabIndex = 25;
            this.lblPrecioInvalido.Text = "*";
            this.lblPrecioInvalido.Visible = false;
            // 
            // lblCodigoInvalido
            // 
            this.lblCodigoInvalido.AutoSize = true;
            this.lblCodigoInvalido.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblCodigoInvalido.ForeColor = System.Drawing.Color.Red;
            this.lblCodigoInvalido.Location = new System.Drawing.Point(333, 125);
            this.lblCodigoInvalido.Name = "lblCodigoInvalido";
            this.lblCodigoInvalido.Size = new System.Drawing.Size(16, 20);
            this.lblCodigoInvalido.TabIndex = 26;
            this.lblCodigoInvalido.Text = "*";
            this.lblCodigoInvalido.Visible = false;
            // 
            // lblValorInvalido2
            // 
            this.lblValorInvalido2.AutoSize = true;
            this.lblValorInvalido2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValorInvalido2.ForeColor = System.Drawing.Color.Red;
            this.lblValorInvalido2.Location = new System.Drawing.Point(224, 282);
            this.lblValorInvalido2.Name = "lblValorInvalido2";
            this.lblValorInvalido2.Size = new System.Drawing.Size(103, 16);
            this.lblValorInvalido2.TabIndex = 27;
            this.lblValorInvalido2.Text = "Valor Inválido";
            this.lblValorInvalido2.Visible = false;
            // 
            // lblValorInvalido1
            // 
            this.lblValorInvalido1.AutoSize = true;
            this.lblValorInvalido1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblValorInvalido1.ForeColor = System.Drawing.Color.Red;
            this.lblValorInvalido1.Location = new System.Drawing.Point(211, 278);
            this.lblValorInvalido1.Name = "lblValorInvalido1";
            this.lblValorInvalido1.Size = new System.Drawing.Size(16, 20);
            this.lblValorInvalido1.TabIndex = 28;
            this.lblValorInvalido1.Text = "*";
            this.lblValorInvalido1.Visible = false;
            // 
            // frmAltaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 398);
            this.Controls.Add(this.lblValorInvalido1);
            this.Controls.Add(this.lblValorInvalido2);
            this.Controls.Add(this.lblCodigoInvalido);
            this.Controls.Add(this.lblPrecioInvalido);
            this.Controls.Add(this.lblDescripcionInvalida);
            this.Controls.Add(this.lblNombreInvalido);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblIndex);
            this.Controls.Add(this.btnEliminarImagen);
            this.Controls.Add(this.btnAgregarImagen);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.btnAnterior);
            this.Controls.Add(this.pboAltaArticulos);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(740, 445);
            this.MinimumSize = new System.Drawing.Size(740, 445);
            this.Name = "frmAltaArticulo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nuevo Artículo";
            this.Load += new System.EventHandler(this.frmAltaArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboAltaArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pboAltaArticulos;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Button btnAgregarImagen;
        private System.Windows.Forms.Button btnEliminarImagen;
        private System.Windows.Forms.Label lblIndex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNombreInvalido;
        private System.Windows.Forms.Label lblDescripcionInvalida;
        private System.Windows.Forms.Label lblPrecioInvalido;
        private System.Windows.Forms.Label lblCodigoInvalido;
        private System.Windows.Forms.Label lblValorInvalido2;
        private System.Windows.Forms.Label lblValorInvalido1;
    }
}