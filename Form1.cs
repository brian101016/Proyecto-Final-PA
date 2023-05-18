<<<<<<< HEAD
﻿using Proyecto_Final_PA.Buscar;
using Proyecto_Final_PA.Personas;
=======
﻿using Proyecto_Final_PA.Personas;
using Proyecto_Final_PA.Ventas;
>>>>>>> 11ef769170af6ebe33d14b1c072e0c11e06b616e
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

        private void autosToolStripMenuItem_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Buscar obj_frm_Buscar = new frm_Buscar();
            obj_frm_Buscar.ShowDialog();
=======
            frm_MantenimientoAuto obj_MantenimientoAuto = new frm_MantenimientoAuto();
            obj_MantenimientoAuto.ShowDialog();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_MantenimientoVenta frm_MantenimientoVenta = new frm_MantenimientoVenta();
            frm_MantenimientoVenta.ShowDialog();
>>>>>>> 11ef769170af6ebe33d14b1c072e0c11e06b616e
        }
    }
}
