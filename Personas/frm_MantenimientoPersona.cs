using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Final_PA.Personas
{
    public partial class frm_MantenimientoPersona : Form
    {

        //Intanciamos el objeto que contendra a la base de datos
        ConnectionDataContext db = new ConnectionDataContext();

        private void listar()
        {
            dgvPersonas.DataSource = db.Persona.Select(
                x=> new
                {
                    x.ID,
                    x.Nombre,
                    x.Telefono,
                    x.Email
                }
                ).ToList();
        }

        public frm_MantenimientoPersona()
        {
            InitializeComponent();
        }

        private void filtrar(object sender, EventArgs e)
        {
            dgvPersonas.DataSource = db.Persona.Where(x=>x.Nombre.Contains(txtBusqueda.Text)).Select(
                x => new
                {
                    x.ID,
                    x.Nombre,
                    x.Telefono,
                    x.Email
                }
                ).ToList();
        }

        private void frm_MantenimientoPersona_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvPersonas.CurrentRow.Cells[0].Value.ToString());

            // select id from Auto where ProveedorID = 29
            var query_autos = db.Auto.Where(auto => auto.ProveedorID == id);

            // select id from Venta where ClienteID = 29 or VendedorID = 29 or AutoID in (select id from Auto where ProveedorID = 29 )
            var query_ventas = db.Venta.Where(
                venta => venta.ClienteID == id
                || venta.VendedorID == id
                || query_autos.Select(i => i.ID).Contains(venta.AutoID));

            string autosIDs = "";
            foreach (var item in query_autos) autosIDs += item.ID + "  ";
                
            string ventasIDs = "";
            foreach (var item in query_ventas) ventasIDs += item.ID + "  ";

            // Preguntar antes de eliminar
            if (MessageBox.Show(
                    "Quieres eliminar el registro?\n" +
                    "Se eliminarán también todos los registros co-dependientes:\n" +
                    $"IDs Autos:  \t{(autosIDs != "" ? autosIDs : "Ninguno")}\n" +
                    $"IDs Ventas: \t{(ventasIDs != "" ? ventasIDs : "Ninguno")}\n",
                    "AVISO", MessageBoxButtons.YesNo
            ) == DialogResult.Yes) {

                // Eliminar las ventas
                foreach (Venta item in query_ventas)
                    db.Venta.DeleteOnSubmit(item);

                // Eliminar los autos
                foreach (Auto item in query_autos)
                    db.Auto.DeleteOnSubmit(item);

                // Eliminar a la persona en cuestión
                db.Persona.DeleteOnSubmit(
                    db.Persona.Where(p => p.ID == id).FirstOrDefault()
                );

                try {
                    db.SubmitChanges();
                    MessageBox.Show("Eliminacion correcta");
                    listar();
                } catch (Exception ex) {
                    MessageBox.Show("Error en la eliminacion " + ex);
                }
            }
        }

        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            frm_PopUpPersona obj_PopUpPersona = new frm_PopUpPersona();
            obj_PopUpPersona.accion = "Editar";
            obj_PopUpPersona.id =dgvPersonas.CurrentRow.Cells[0].Value.ToString();
            obj_PopUpPersona.ShowDialog();
            if (obj_PopUpPersona.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            frm_PopUpPersona obj_PopUpPersona = new frm_PopUpPersona();
            obj_PopUpPersona.accion = "Nuevo";
            obj_PopUpPersona.ShowDialog();
            if (obj_PopUpPersona.DialogResult.Equals(DialogResult.OK))
            {
                listar();
            }
        }
    }
}
