﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grupoB_TP
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }


        private void btnContinuar_Click(object sender, EventArgs e)
        {
            if (rboSolicitarServicio.Checked)
            {
                new SolicitudDeServicioNacional().ShowDialog();
            }
            if (rboConsultarEstadoDeServicio.Checked)
            {
                new EstadoDeServicio().ShowDialog();
            }
            if (rboConsultarEstadoDeCuenta.Checked)
            {
                new EstadoDeCuenta().ShowDialog();
            }

        }
    }
}
