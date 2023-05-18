using Proyecto_Final_PA.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_PA
{
    public partial class frm_MantenimientoAuto : Form
    {
        public frm_MantenimientoAuto()
        {
            InitializeComponent();
        }

        ConnectionDataContext db = new ConnectionDataContext();

        Global global = new Global();

        private int currID { get; set; } = 0;

        private void listar()
        {
            dgvAutos.DataSource = db.Auto.Select(
                x => new
                {
                    x.ID,
                    x.Nombre,
                    x.Precio,
                    x.Manual,
                    x.ProveedorID,
                    x.MarcaID,
                    x.CarroceriaID
                }
                ).ToList();
        }

        private void frm_MantenimientoAuto_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void filtrar(object sender, EventArgs e)
        {
            dgvAutos.DataSource = db.Auto.Where(x => x.Nombre.Contains(txtBusqueda.Text)).Select(
                x => new
                {
                    x.ID,
                    x.Nombre,
                    x.Precio,
                    x.Manual,
                    x.ProveedorID,
                    x.MarcaID,
                    x.CarroceriaID
                }
                ).ToList();
        }

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            frm_PopUpAuto obj_PopUpAuto = new frm_PopUpAuto();
            obj_PopUpAuto.accion = "Nuevo";
            obj_PopUpAuto.ShowDialog();
            if (obj_PopUpAuto.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }

        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            frm_PopUpAuto obj_PopUpAuto = new frm_PopUpAuto();
            obj_PopUpAuto.accion = "Editar";
            obj_PopUpAuto.id = dgvAutos.CurrentRow.Cells[0].Value.ToString();
            obj_PopUpAuto.ShowDialog();
            if (obj_PopUpAuto.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvAutos.CurrentRow.Cells[0].Value.ToString());

            // Preguntar antes de eliminar
            if (MessageBox.Show(
                   "Quieres eliminar el registro?\n" +
                   "Se eliminarán también todos los registros co-dependientes:\n",
                   "AVISO", MessageBoxButtons.YesNo ) == DialogResult.Yes)
            {

               global.Eliminar_Puesto(currID, true);

                // Eliminar al auto en cuestión
                db.Auto.DeleteOnSubmit(
                db.Auto.Where(p => p.ID == id).FirstOrDefault()
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

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
