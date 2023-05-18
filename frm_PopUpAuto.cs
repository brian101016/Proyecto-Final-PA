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
            cboManual.DataSource = db.Auto.ToList();
            cboManual.DisplayMember = "NOMBRE";
            cboManual.ValueMember = "ID";

            cboProveedorID.DataSource = db.Auto.ToList();
            cboProveedorID.DisplayMember = "NOMBRE";
            cboProveedorID.ValueMember = "ID";

            cboMarcaID.DataSource = db.Marca.ToList();
            cboMarcaID.DisplayMember = "NOMBRE";
            cboMarcaID.ValueMember = "ID";

            cboCarroceriaID.DataSource = db.Carroceria.ToList();
            cboCarroceriaID.DisplayMember = "NOMBRE";
            cboCarroceriaID.ValueMember = "ID";

            if (accion.Equals("Editar"))
            {
                this.Text = "Editar un registro";

                Auto obj_auto = db.Auto.Where(x => x.ID.Equals(id)).FirstOrDefault();
                txtIdAuto.Text = obj_auto.ID.ToString();
                txtNombre.Text = obj_auto.Nombre;
                txtPrecio.Text = obj_auto.Precio.ToString();
                cboManual.SelectedValue = obj_auto.Manual;
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
            string nombre = txtNombre.Text;
            int precio = int.Parse(txtPrecio.Text);
            bool manual = bool.Parse(cboManual.SelectedValue.ToString());
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
                    MessageBox.Show(":)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trono :( --> " + ex);
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
                    MessageBox.Show(":)");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Trono :( --> " + ex);
                }
            }
        }
    }
}
