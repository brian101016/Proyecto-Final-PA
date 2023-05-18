using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Proyecto_Final_PA.Personas
{
    public partial class frm_MantenimientoPersona : Form
    {
        public frm_MantenimientoPersona()
        {
            InitializeComponent();
        }

        //Intanciamos el objeto que contendra a la base de datos
        ConnectionDataContext db = new ConnectionDataContext();
        Global global = new Global();

        private void frm_MantenimientoPersona_Load(object sender, EventArgs e)
        {
            listar();
        }

        private void listar()
        {
            dgvPersonas.DataSource = db.Persona.Select(
                x=> new
                {
                    x.ID,
                    x.Nombre,
                    x.Apellido,
                    x.Email,
                    x.Telefono,
                    x.Direccion,
                    x.PuestoID,
                }
            ).ToList();
        }

        private void filtrar(object sender, EventArgs e)
        {
            dgvPersonas.DataSource = db.Persona.Where(x => x.Nombre.Contains(txtBusqueda.Text)).Select(
                x => new
                {
                    x.ID,
                    x.Nombre,
                    x.Apellido,
                    x.Email,
                    x.Telefono,
                    x.Direccion,
                    x.PuestoID,
                }
            ).ToList();
        }

        private void toolStripNuevo_Click(object sender, EventArgs e)
        {
            frm_PopUpPersona obj_PopUpPersona = new frm_PopUpPersona();
            obj_PopUpPersona.accion = "Nuevo";
            obj_PopUpPersona.ShowDialog();
            if (obj_PopUpPersona.DialogResult == DialogResult.OK) listar();
        }

        private void toolStripEditar_Click(object sender, EventArgs e)
        {
            if (dgvPersonas.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningun campo");
                return;
            }

            frm_PopUpPersona obj_PopUpPersona = new frm_PopUpPersona();
            obj_PopUpPersona.accion = "Editar";
            obj_PopUpPersona.id = dgvPersonas.CurrentRow.Cells[0].Value.ToString();
            obj_PopUpPersona.ShowDialog();
            if (obj_PopUpPersona.DialogResult == DialogResult.OK) listar();
        }

        private void toolStripEliminar_Click(object sender, EventArgs e)
        {
            if(dgvPersonas.CurrentRow == null)
            {
                MessageBox.Show("No se ha seleccionado ningun campo");
                return;
            }

            // Preguntar antes de eliminar
            if (MessageBox.Show(
                    "Quieres eliminar el registro?\n" +
                    "Se eliminarán también todos los registros co-dependientes!",
                    "AVISO", MessageBoxButtons.YesNo
            ) == DialogResult.Yes)
            {
                int id = (int)dgvPersonas.CurrentRow.Cells[0].Value;

                // Eliminar persona
                global.Eliminar_Persona(id, true);
                listar();
            }
        }

        private void toolStripSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
