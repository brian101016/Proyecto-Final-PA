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
    public partial class frm_PopUpPersona : Form
    {
        ConnectionDataContext db = new ConnectionDataContext();

        public string id { get; set; }
        public string accion { get; set; }    

        public frm_PopUpPersona()
        {
            InitializeComponent();
        }

        private void frm_PopUpPersona_Load(object sender, EventArgs e)
        {
            //Combobox
            cboPuesto.DataSource = db.Puesto.ToList();
            cboPuesto.DisplayMember = "Nombre";
            cboPuesto.ValueMember = "ID";
            // cboPuesto.SelectedIndex = 0;

            if (accion.Equals("Editar"))
            {
                this.Text = "Editar un registro";

                Persona obj_persona = db.Persona.Where(x => x.ID.Equals(id)).FirstOrDefault();
                txtIdPersona.Text = obj_persona.ID.ToString();
                txtNombre.Text = obj_persona.Nombre;
                txtApellido.Text = obj_persona.Apellido;
                txtDireccion.Text = obj_persona.Direccion;
                txtEmail.Text = obj_persona.Email;
                txtTelefono.Text = obj_persona.Telefono;
                cboPuesto.SelectedValue = obj_persona.PuestoID;
            }
            else
            {
                this.Text = "Agregar un registro";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // -------------------------------------- VALIDAR DATOS
            var arr = new List<TextBox>{
                txtNombre,
                txtApellido,
                txtEmail,
                txtTelefono,
                txtDireccion,
            };

            foreach (var item in arr)
            {
                // Validar vacios
                if (item.Text.Equals(""))
                {
                    errorProvider.SetError(item, "El campo no puede estar vacío");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else errorProvider.SetError(item, "");
            }

            if (cboPuesto.SelectedIndex == -1)
            {
                errorProvider.SetError(cboPuesto, "Valor invalido");
                this.DialogResult = DialogResult.None;
                return;
            }

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string direccion = txtDireccion.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;
            int puesto = int.Parse(cboPuesto.SelectedValue.ToString());

            if (accion.Equals("Nuevo"))
            {
                Persona obj_persona = new Persona
                {
                    Nombre = nombre,
                    Apellido = apellido,
                    Direccion = direccion,
                    Email = email,
                    Telefono = telefono,
                    PuestoID = puesto
                };

                db.Persona.InsertOnSubmit(obj_persona);

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Se ha insertado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                Persona persona = db.Persona.Where(x => x.ID.Equals(id)).FirstOrDefault();
                persona.Nombre = nombre;
                persona.Apellido = apellido;
                persona.Direccion = direccion;
                persona.Email = email;
                persona.Telefono = telefono;
                persona.PuestoID = puesto;

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Se ha modificado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }

        }
    }
}
