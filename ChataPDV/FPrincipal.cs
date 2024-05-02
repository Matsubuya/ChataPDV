using ChataPDV.BO;
using ChataPDV.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChataPDV
{
    public partial class FPrincipal : Form
    {
        private GlobalServices _service = new GlobalServices();
        public FPrincipal()
        {
            InitializeComponent();
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            RefrescarListadoProductos();

        }

        private void btnAddProducto_Click(object sender, EventArgs e)
        {
            var fAddProduct = new FAddProducto();
            var result = fAddProduct.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Puedo refresar el listado por ejemplo
                RefrescarListadoProductos();
            }
            else
            {
                MessageBox.Show("No se refresca el listado");
            }

        }
        private void RefrescarListadoProductos()
        {
            var productos = _service.ObtenerProductos();

            gridProductos.DataSource = productos;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void gridProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int productoId = Convert.ToInt32(gridProductos.Rows[e.RowIndex].Cells[0].Value.ToString());

            var fAddProduct = new FAddProducto(productoId);
            var result = fAddProduct.ShowDialog();

            if (result == DialogResult.OK)
            {
                //Puedo refresar el listado por ejemplo
                RefrescarListadoProductos();
            }
        }
    }
}
