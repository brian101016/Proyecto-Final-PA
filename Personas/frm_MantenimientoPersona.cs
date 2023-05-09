using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            if (MessageBox.Show("Realmente quieres eliminar el registro?", "!!!AVISO!!!", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
            {
                string id = dgvPersonas.CurrentRow.Cells[0].Value.ToString();
                Persona persona = db.Persona.Where(x => x.ID.Equals(id)).FirstOrDefault();
                db.Persona.DeleteOnSubmit(persona);

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("El elemento fue eliminado correctamente :)");
                    listar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio un error mientras se eliminaba el registro: " + ex);
                }
            }
            else
            {
                return;
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
