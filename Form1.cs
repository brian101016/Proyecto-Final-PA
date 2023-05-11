using Proyecto_Final_PA.Personas;
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
    }
}
