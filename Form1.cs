using Proyecto_Final_PA.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proyecto_Final_PA.frmMantenimientoVariosCampos;

namespace Proyecto_Final_PA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void personasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_MantenimientoPersona obj_MantenimientoPersona = new frm_MantenimientoPersona();
            obj_MantenimientoPersona.ShowDialog();
        }

        private void toolCamposEspeciales_Click(object sender, EventArgs e)
        {
            frmMantenimientoVariosCampos obj_VariosCampos = new frmMantenimientoVariosCampos();
            obj_VariosCampos.ShowDialog();
        }

        private void reiniciarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreBaseDeDatos = "ProyectoPA";
            string rutaArchivoBackup = @"C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\Backup\ProyectoPA.bak";

            string connectionString = Properties.Settings.Default.ProyectoPAConnectionString;
            string restoreCommand = $"USE master; ALTER DATABASE {nombreBaseDeDatos} SET SINGLE_USER WITH ROLLBACK IMMEDIATE; RESTORE DATABASE {nombreBaseDeDatos} FROM DISK='{rutaArchivoBackup}' WITH REPLACE;";

            if (MessageBox.Show("¿Deseas reiniciar la base de datos?", "AVISO", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                {
                    if (File.Exists(rutaArchivoBackup))
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            using (SqlCommand command = new SqlCommand(restoreCommand, connection))
                            {
                                try
                                {
                                    connection.Open();
                                    command.ExecuteNonQuery();
                                    MessageBox.Show("Restauración completada correctamente.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error al realizar la restauración: {ex.Message}");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el archivo 'ProyectoPA.bak' en la ruta especificada.");
                    }
                }
            }
        }
    }
}

