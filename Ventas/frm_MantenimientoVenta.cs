using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_PA.Ventas
{
    public partial class frm_MantenimientoVenta : Form
    {
        public frm_MantenimientoVenta()
        {
            InitializeComponent();
        }

        ConnectionDataContext db = new ConnectionDataContext();

        private void listar()
        {
            dgvVentas.DataSource = db.Venta.Select(
                x => new
                {
                    x.ID,
                    x.Fecha,
                    x.ClienteID,
                    x.VendedorID,
                    x.EstadoID,
                    x.AutoID
                }
                ).ToList();
        }

        private void frm_MantenimientoVenta_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void filtrarID(object sender, EventArgs e)
        {
            dgvVentas.DataSource = db.Venta.Where(x => x.ID.ToString().Equals(txtBusquedaID.Text.ToString())).Select(
                x => new
                {
                    x.ID,
                    x.Fecha,
                    x.ClienteID,
                    x.VendedorID,
                    x.EstadoID,
                    x.AutoID
                }
                ).ToList();
        }
        //Intente hacer un buscador con fecha pero supe muy bien como hacerlo
        //private void filtrarFecha(object sender, EventArgs e)
        //{
        //    dgvVentas.DataSource = db.Venta.Where(x => x.Fecha.Equals(txtBuscadorFecha.Text.ToString())).Select(
        //        x => new
        //        {
        //            x.ID,
        //            x.Fecha,
        //            x.ClienteID,
        //            x.VendedorID,
        //            x.EstadoID,
        //            x.AutoID
        //        }
        //        ).ToList();
        //}

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            frm_PopUpVenta obj_PopUpVenta = new frm_PopUpVenta();
            obj_PopUpVenta.accion = "Nuevo";
            obj_PopUpVenta.ShowDialog();
            if (obj_PopUpVenta.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }

        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            frm_PopUpVenta obj_PopUpVenta = new frm_PopUpVenta();
            obj_PopUpVenta.accion = "Editar";
            obj_PopUpVenta.id = dgvVentas.CurrentRow.Cells[0].Value.ToString();
            obj_PopUpVenta.ShowDialog();
            if (obj_PopUpVenta.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvVentas.CurrentRow.Cells[0].Value.ToString());

            // Preguntar antes de eliminar
            if (MessageBox.Show(
                   "Quieres eliminar el registro?\n",
                   "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                // Eliminar la venta en cuestión
                db.Venta.DeleteOnSubmit(
                db.Venta.Where(p => p.ID == id).FirstOrDefault()
            );

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Eliminacion correcta");
                    listar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la eliminacion " + ex);
                }
            }
        }
    }
}
