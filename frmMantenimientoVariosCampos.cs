using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Final_PA
{
    public partial class frmMantenimientoVariosCampos : Form
    {
        public frmMantenimientoVariosCampos()
        {
            InitializeComponent();
        }

        ConnectionDataContext db = new ConnectionDataContext();

        // Variables para no estar leyendo a cada rato de los inputs
        private string currTable { get; set; } = "Puesto";
        private int currID { get; set; } = 0;
        private string currSearch { get; set; } = "";

        // Clase generica que representa el modelo de las tablas (dinámico)
        public class Generic { public dynamic ID; public dynamic Nombre; }

        private void frmMantenimientoVariosCampos_Load(object sender, EventArgs e)
        {
            // Obtener todas las tablas que existen en la DB
            var tables = db.Mapping.GetTables().ToList();
            foreach (var item in tables)
            {
                // Los nombres comienzan con "dbo." y lo recortamos
                string name = item.TableName.Substring(4);
                // Guardamos en un cbo todas las tablas que no sean...
                if (!"Persona Venta Auto".Contains(name))
                    cboCampoEspecial.Items.Add( name );
            }

            // Seleccionamos la primera opción como default
            cboCampoEspecial.SelectedIndex = 0;
        }

        private void listar()
        {
            // Ejecutamos queries para que sea dinámico

            // Query de búsqueda (solo si hay algo que buscar)
            string fq = "";
            if (currSearch != "")
                fq = $"WHERE Nombre LIKE '%{currSearch}%'" +
                    $"OR ID LIKE '%{currSearch}%'";

            // Query para seleccionar y mostrar en el dgv
            var result = db.ExecuteQuery<Generic>
                ($"SELECT * FROM {currTable} {fq}");

            dgvDatos.DataSource = result.Select(
                x => new {
                    x.ID, x.Nombre
                })
                .OrderBy(x => x.ID).ToList();
        }

        // Se ejecuta cada vez que se modifica el cbo o txtBuscar
        private void handleChange(object sender, EventArgs e)
        {
            currTable = cboCampoEspecial.SelectedItem.ToString();
            currSearch = txtBuscar.Text;
            listar();
        }

        // Se ejecuta cada vez que se hace selecciona una fila del dgv
        private void handleRow(object sender, DataGridViewCellEventArgs e)
        {
            var temp = dgvDatos.Rows[e.RowIndex]?.Cells;
            if (temp != null) // Si el dgv no está vacío
            {
                currID = (int)temp[0].Value;
                txtNombre.Text = temp[1].Value.ToString();
            }
        }

        // Click en los botones
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try {
                _ = db.ExecuteQuery<Generic>(
                    $"INSERT {currTable}(Nombre) " +
                    $"VALUES ('{txtNombre.Text}')");

                listar();
            } catch (Exception) {
                MessageBox.Show(
                    $"Ya existe un registro con el nombre '{txtNombre.Text}'",
                    "ERROR");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try {
                _ = db.ExecuteQuery<Generic>(
                    $"UPDATE {currTable} SET " +
                    $"Nombre = '{txtNombre.Text}' " +
                    $"WHERE ID = {currID}");

                listar();
            } catch (Exception) {
                MessageBox.Show(
                    $"Ya existe un registro con el nombre '{txtNombre.Text}'",
                    "ERROR");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PENDIENTE POR HACER");
        }
    }
}
