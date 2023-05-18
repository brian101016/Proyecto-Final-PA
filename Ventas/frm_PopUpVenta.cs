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
    public partial class frm_PopUpVenta : Form
    {
        public frm_PopUpVenta()
        {
            InitializeComponent();
        }

        ConnectionDataContext db = new ConnectionDataContext();

        public string id { get; set; }
        public string accion { get; set; }

        private void frm_PopUpVenta_Load(object sender, EventArgs e)
        {
            //Combobox
            cboClienteID.DataSource = db.Persona.Where(p => p.PuestoID == 1).ToList();
            cboClienteID.DisplayMember = "Nombre";
            cboClienteID.ValueMember = "ID";
            // cboClienteID.SelectedIndex = 0;

            cboVendedorID.DataSource = db.Persona.Where(p => p.PuestoID == 2).ToList();
            cboVendedorID.DisplayMember = "Nombre";
            cboVendedorID.ValueMember = "ID";
            // cboVendedorID.SelectedIndex = 0;

            cboEstadoID.DataSource = db.Estado.ToList();
            cboEstadoID.DisplayMember = "Nombre";
            cboEstadoID.ValueMember = "ID";
            // cboEstadoID.SelectedIndex = 0;

            cboAutoID.DataSource = db.Auto.ToList();
            cboAutoID.DisplayMember = "Nombre";
            cboAutoID.ValueMember = "ID";
            // cboAutoID.SelectedIndex = 0;

            if (accion.Equals("Editar"))
            {
                this.Text = "Editar un registro";

                Venta obj_venta = db.Venta.Where(x => x.ID.Equals(id)).FirstOrDefault();
                txtIdVenta.Text = obj_venta.ID.ToString();
                txtFecha.Value = obj_venta.Fecha;
                cboClienteID.SelectedValue = obj_venta.ClienteID;
                cboVendedorID.SelectedValue = obj_venta.VendedorID;
                cboEstadoID.SelectedValue = obj_venta.EstadoID;
                cboAutoID.SelectedValue = obj_venta.AutoID;
            }
            else this.Text = "Agregar un registro";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            // -------------------------------------- VALIDAR DATOS
            var arr = new List<ComboBox>{
                cboClienteID,
                cboVendedorID,
                cboEstadoID,
                cboAutoID,
            };

            foreach (var item in arr)
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

            DateTime fecha = txtFecha.Value;
            int cliente = int.Parse(cboClienteID.SelectedValue.ToString());
            int vendedor = int.Parse(cboVendedorID.SelectedValue.ToString());
            int estado = int.Parse(cboEstadoID.SelectedValue.ToString());
            int auto = int.Parse(cboAutoID.SelectedValue.ToString());

            if (accion.Equals("Nuevo"))
            {
                Venta obj_venta = new Venta
                {
                    Fecha = fecha,
                    ClienteID = cliente,
                    VendedorID = vendedor,
                    EstadoID = estado,
                    AutoID = auto
                };

                db.Venta.InsertOnSubmit(obj_venta);

                try
                {
                    db.SubmitChanges();
                    MessageBox.Show("Se ha agregado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
            }
            else
            {
                Venta venta = db.Venta.Where(x => x.ID.Equals(id)).FirstOrDefault();
                venta.Fecha = fecha;
                venta.ClienteID = cliente;
                venta.VendedorID = vendedor;
                venta.EstadoID = estado;
                venta.AutoID = auto;

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
