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
    public partial class frm_PopUpAuto : Form
    {
        ConnectionDataContext db = new ConnectionDataContext();

        public string id { get; set; }
        public string accion { get; set; }

        public frm_PopUpAuto()
        {
            InitializeComponent();
        }

        private void frm_PopUpAuto_Load(object sender, EventArgs e)
        {
            //Combobox
            cboProveedorID.DataSource = db.Persona.Where(p => p.PuestoID == 3).ToList();
            cboProveedorID.DisplayMember = "Nombre";
            cboProveedorID.ValueMember = "ID";
            // cboProveedorID.SelectedIndex = 0;

            cboMarcaID.DataSource = db.Marca.ToList();
            cboMarcaID.DisplayMember = "Nombre";
            cboMarcaID.ValueMember = "ID";
            // cboMarcaID.SelectedIndex = 0;

            cboCarroceriaID.DataSource = db.Carroceria.ToList();
            cboCarroceriaID.DisplayMember = "Nombre";
            cboCarroceriaID.ValueMember = "ID";
            // cboCarroceriaID.SelectedIndex = 0;

            if (accion.Equals("Editar"))
            {
                this.Text = "Editar un registro";

                Auto obj_auto = db.Auto.Where(x => x.ID.Equals(id)).FirstOrDefault();
                txtIdAuto.Text = obj_auto.ID.ToString();
                txtNombre.Text = obj_auto.Nombre;
                txtPrecio.Text = obj_auto.Precio.ToString();
                chkManual.Checked = obj_auto.Manual;
                cboProveedorID.SelectedValue = obj_auto.ProveedorID;
                cboMarcaID.SelectedValue = obj_auto.MarcaID;
                cboCarroceriaID.SelectedValue = obj_auto.CarroceriaID;
            }
            else
            {
                this.Text = "Agregar un registro";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // -------------------------------------- VALIDAR DATOS
            if (txtNombre.Text == "")
            {
                errorProvider.SetError(txtNombre, "El campo no puede estar vacío");
                this.DialogResult = DialogResult.None;
                return;
            }
            else errorProvider.SetError(txtNombre, "");

            if (txtPrecio.Value <= 0)
            {
                errorProvider.SetError(txtPrecio, "El precio debe ser mayor a 0");
                this.DialogResult = DialogResult.None;
                return;
            }
            else errorProvider.SetError(txtPrecio, "");

            var arr2 = new List<ComboBox>{
                cboProveedorID,
                cboMarcaID,
                cboCarroceriaID,
            };

            foreach (var item in arr2)
            {
                // Validar vacios
                if (item.SelectedIndex == -1)
                {
                    errorProvider.SetError(item, "Valor invalido");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                else errorProvider.SetError(item, "");
            }

            string nombre = txtNombre.Text;
            int precio = (int)txtPrecio.Value;
            bool manual = chkManual.Checked;
            int proveedor = int.Parse(cboProveedorID.SelectedValue.ToString());
            int marca = int.Parse(cboMarcaID.SelectedValue.ToString());
            int carroceria = int.Parse(cboCarroceriaID.SelectedValue.ToString());

            if (accion.Equals("Nuevo"))
            {
                Auto obj_auto = new Auto
                {
                    Nombre = nombre,
                    Precio = precio,
                    Manual = manual,
                    ProveedorID = proveedor,
                    MarcaID = marca,
                    CarroceriaID = carroceria
                };

                db.Auto.InsertOnSubmit(obj_auto);

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Agregado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                Auto auto = db.Auto.Where(x => x.ID.Equals(id)).FirstOrDefault();
                auto.Nombre = nombre;
                auto.Precio = precio;
                auto.Manual = manual;
                auto.ProveedorID = proveedor;
                auto.MarcaID = marca;
                auto.CarroceriaID = carroceria;

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Modificado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
        }
    }
}
