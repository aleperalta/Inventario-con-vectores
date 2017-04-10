using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ape_inventario
{
    public partial class frmPrincipal : Form
    {
        Inventario inventario = new Inventario();

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtPrecio.Text == "" || txtCantidad.Text == "")
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                if (inventario._posicionActual < inventario.v.Length)
                {
                    int vCodigo = Convert.ToInt16(txtCodigo.Text);
                    string vNombre = txtNombre.Text;
                    double vPrecio = Convert.ToDouble(txtPrecio.Text);
                    int vCantidad = Convert.ToInt16(txtCantidad.Text);

                    inventario.agregar(new Producto(vCodigo, vNombre, vPrecio, vCantidad));
                }
                else
                    MessageBox.Show("¡Inventario lleno!");

                limpiarCajas();
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            if (inventario.mostrar() == "")
                MessageBox.Show("Inventario vacío.");
            else
                txtReporte.Text = inventario.mostrar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del producto a buscar. Gracias.");
            else
                if (inventario.buscar(Convert.ToInt16(txtCodigo.Text)) == null)
                    MessageBox.Show("El producto no existe.");
                else
                    txtReporte.Text = inventario.buscar(Convert.ToInt16(txtCodigo.Text)).ToString();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "" || txtNombre.Text == "" || txtPrecio.Text == "" || txtCantidad.Text == "" || txtInsertar.Text == "")
                MessageBox.Show("Favor de llenar los campos incompletos. Gracias.");
            else
            {
                if (inventario._posicionActual < inventario.v.Length)
                {
                    int vCodigo = Convert.ToInt16(txtCodigo.Text);
                    string vNombre = txtNombre.Text;
                    double vPrecio = Convert.ToDouble(txtPrecio.Text);
                    int vCantidad = Convert.ToInt16(txtCantidad.Text);

                    inventario.insertar(new Producto(vCodigo, vNombre, vPrecio, vCantidad), Convert.ToInt16(txtInsertar.Text));
                }
                else
                    MessageBox.Show("¡Inventario lleno!");

                limpiarCajas();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
                MessageBox.Show("Favor de escribir el código del producto a eliminar. Gracias.");
            else
            {
                if (inventario.buscar(Convert.ToInt16(txtCodigo.Text)) == null)
                    MessageBox.Show("El producto no existe.");
                else
                {
                    inventario.eliminar();
                    MessageBox.Show("El producto se ha eliminado.");
                    txtReporte.Text = inventario.mostrar();
                }
            }
        }

        private void limpiarCajas()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCantidad.Text = "";
            txtInsertar.Text = "";
        }
    }
}
