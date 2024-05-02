using ChataPDV.BO;
using ChataPDV.Services;
using System;
using System.Windows.Forms;

namespace ChataPDV
{
    public partial class FAddProducto : Form
    {
        private GlobalServices _servicio = new GlobalServices();
        private int? productoId = null;
        private Producto productoEditar = null;
        public FAddProducto(int? productoId = null)
        {
            InitializeComponent();
            this.productoId = productoId;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            //Logica para guardar. . . 
            if (productoEditar != null)
            {
                //productoEditar.ProductoId = productoId;
                productoEditar.Descripcion = txtDescripcion.Text;
                productoEditar.PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text);
                _servicio.GuardarProducto(productoEditar);
            }
            else
            {
                var newProduct = new Producto()
                {
                    Descripcion = txtDescripcion.Text,
                    PrecioUnitario = Convert.ToDecimal(txtPrecioUnitario.Text)
                };
                _servicio.GuardarProducto(newProduct);
            }



            this.DialogResult = DialogResult.OK;
        }

        private void FAddProducto_Load(object sender, EventArgs e)
        {
            if (productoId != null)
            {
                productoEditar = _servicio.ObtenerProductoPorId(productoId.Value);
                lblId.Text = productoEditar.ProductoId.ToString();
                txtDescripcion.Text = productoEditar.Descripcion;
                txtPrecioUnitario.Text = productoEditar.PrecioUnitario.ToString();
            }
        }
    }
}
