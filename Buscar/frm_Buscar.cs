using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_PA.Buscar
{
    public partial class frm_Buscar : Form
    {
        ConnectionDataContext db = new ConnectionDataContext();

        public frm_Buscar()
        {
            InitializeComponent();
        }

        private void frm_Buscar_Load(object sender, EventArgs e)
        {
            string[] tablas = new string[] { "Persona", "Venta", "Estado", "Puesto", "Auto", "Marca", "Carroceria" };
           
            cboTabla.DataSource = tablas.ToList();
            
        }
        
        private void txtreadOnly()
        {
            txtFiltrar.ReadOnly = false;
            txtNombre.ReadOnly = false;
        }

        private void txtMedioOnly()
        {
            txtFiltrar.ReadOnly = true;
            txtNombre.ReadOnly = false;
        }

        //Para filtrar con otros campos
        private void filtrar(object sender, EventArgs e)
        {
            //PERSONA
            if (cboCampoEspecifico.SelectedItem.ToString().Equals("Apellido"))
            {
                dgvTabla.DataSource = db.Persona.Where(x => x.Apellido.Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();
            } else if (cboCampoEspecifico.SelectedItem.ToString().Equals("Email"))
            {
                dgvTabla.DataSource = db.Persona.Where(x => x.Email.Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();
            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("Telefono"))
            {
                dgvTabla.DataSource = db.Persona.Where(x => x.Telefono.Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("Dirección"))
            {
                dgvTabla.DataSource = db.Persona.Where(x => x.Direccion.Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("Puesto"))
            {
                dgvTabla.DataSource = db.Persona.Where(x => x.PuestoID.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            //VENTA
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("ClienteID"))
            {
                dgvTabla.DataSource = db.Venta.Where(x => x.ClienteID.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("VendedorID"))
            {
                dgvTabla.DataSource = db.Venta.Where(x => x.VendedorID.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("EstadoID"))
            {
                dgvTabla.DataSource = db.Venta.Where(x => x.EstadoID.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("AutoID"))
            {
                dgvTabla.DataSource = db.Venta.Where(x => x.AutoID.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            //AUTO
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("Precio"))
            {
                dgvTabla.DataSource = db.Auto.Where(x => x.Precio.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("ProveedorID"))
            {
                dgvTabla.DataSource = db.Auto.Where(x => x.ProveedorID.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("MarcaID"))
            {
                dgvTabla.DataSource = db.Auto.Where(x => x.MarcaID.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("CarroceriaID"))
            {
                dgvTabla.DataSource = db.Auto.Where(x => x.CarroceriaID.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboCampoEspecifico.SelectedItem.ToString().Equals("Manual"))
            {
                dgvTabla.DataSource = db.Auto.Where(x => x.Manual.ToString().Contains(txtFiltrar.Text)).OrderBy(x => x.ID).ToList();

            }
        }

        //Para ir cambiando las tablas
        private void cambiar(object sender, EventArgs e)
        {
            //Muestra las opciones en el combobox de campo especifico
            string[] personas = new string[] { "Apellido", "Email", "Telefono", "Dirección", "PuestoID" };
            string[] ventas = new string[] { "ClienteID", "VendedorID", "EstadoID", "AutoID" };
            string[] autos = new string[] { "Precio", "ProveedorID", "MarcaID", "CarroceriaID", "Manual" };

            //Cada uno de estos es un listar
            if (cboTabla.SelectedItem.ToString().Equals("Persona"))
            {
                cboCampoEspecifico.DataSource = personas.ToList();
                txtreadOnly();
                dgvTabla.DataSource = db.Persona.OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Venta"))
            {
                cboCampoEspecifico.DataSource = ventas.ToList();
                dgvTabla.DataSource = db.Venta.OrderBy(x => x.ID).ToList();
                txtNombre.ReadOnly = true;

            }
            else if (cboTabla.SelectedItem.ToString().Equals("Auto"))
            {
                cboCampoEspecifico.DataSource = autos.ToList();
                txtreadOnly();
                dgvTabla.DataSource = db.Auto.OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Puesto"))
            {
                cboCampoEspecifico.DataSource = null;
                txtMedioOnly();
                dgvTabla.DataSource = db.Puesto.OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Estado"))
            {
                cboCampoEspecifico.DataSource = null;
                txtFiltrar.ReadOnly = true;
                txtNombre.ReadOnly = false;
                dgvTabla.DataSource = db.Estado.OrderBy(x => x.ID).ToList();

            }
            else if (cboTabla.SelectedItem.ToString().Equals("Marca"))
            {
                cboCampoEspecifico.DataSource = null;
                txtMedioOnly();
                dgvTabla.DataSource = db.Marca.OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Carroceria"))
            {
                cboCampoEspecifico.DataSource = null;
                txtMedioOnly();
                dgvTabla.DataSource = db.Carroceria.OrderBy(x => x.ID).ToList();
            }
        }

        //Para filtrar por ID
        private void filtrarID(object sender, EventArgs e)
        {
            if (cboTabla.SelectedItem.ToString().Equals("Persona"))
            {
                dgvTabla.DataSource = db.Persona.Where(x => x.ID.ToString().Contains(txtId.Text.ToString())).OrderBy(x => x.ID).ToList(); 
                
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Auto"))
            {
                dgvTabla.DataSource = db.Auto.Where(x => x.ID.ToString().Contains(txtId.Text.ToString())).OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Venta"))
            {
                dgvTabla.DataSource = db.Venta.Where(x => x.ID.ToString().Contains(txtId.Text.ToString())).OrderBy(x => x.ID).ToList();
                txtNombre.ReadOnly = true;

            }
            else if (cboTabla.SelectedItem.ToString().Equals("Puesto"))
            {
                dgvTabla.DataSource = db.Puesto.Where(x => x.ID.ToString().Contains(txtId.Text.ToString())).OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Estado"))
            {
                dgvTabla.DataSource = db.Estado.Where(x => x.ID.ToString().Contains(txtId.Text.ToString())).OrderBy(x => x.ID).ToList();

            }
            else if (cboTabla.SelectedItem.ToString().Equals("Marca"))
            {
                dgvTabla.DataSource = db.Marca.Where(x => x.ID.ToString().Contains(txtId.Text.ToString())).OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Carroceria"))
            {
                dgvTabla.DataSource = db.Carroceria.Where(x => x.ID.ToString().Contains(txtId.Text.ToString())).OrderBy(x => x.ID).ToList();
            }
        }

        //Para filtrar por nombre
        private void listarNombre(object sender, EventArgs e)
        {
            if (cboTabla.SelectedItem.ToString().Equals("Persona"))
            {
                dgvTabla.DataSource = db.Persona.Where(x => x.Nombre.Contains(txtNombre.Text)).OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Auto"))
            {
                dgvTabla.DataSource = db.Auto.Where(x => x.Nombre.Contains(txtNombre.Text)).OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Puesto"))
            {
                dgvTabla.DataSource = db.Puesto.Where(x => x.Nombre.Contains(txtNombre.Text)).OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Estado"))
            {
                dgvTabla.DataSource = db.Estado.Where(x => x.Nombre.Contains(txtNombre.Text)).OrderBy(x => x.ID).ToList();

            }
            else if (cboTabla.SelectedItem.ToString().Equals("Marca"))
            {
                dgvTabla.DataSource = db.Marca.Where(x => x.Nombre.Contains(txtNombre.Text)).OrderBy(x => x.ID).ToList();
            }
            else if (cboTabla.SelectedItem.ToString().Equals("Carroceria"))
            {
                dgvTabla.DataSource = db.Carroceria.Where(x => x.Nombre.Contains(txtNombre.Text)).OrderBy(x => x.ID).ToList();
            }
        }

        private void campoCambiar(object sender, EventArgs e)
        {
            // filtrar(null, null);
        }
    }
}
