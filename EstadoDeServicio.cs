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
    public partial class EstadoDeServicio : Form
    {
        public EstadoDeServicio()
        {
            InitializeComponent();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string mensaje = "";
            int[] numerosdeTrackeo = { 123, 456, 789};
            string numeroTrack = txtTrackeo.Text;
            Console.WriteLine($"Código de trackeo: {numeroTrack}");
            mensaje += Usuario.PedirVacio("El número de Tracking", numeroTrack);
            mensaje += Usuario.PedirEntero("tracking", 0 ,9999, numeroTrack);

            if (mensaje != "")
            {
                MessageBox.Show(mensaje, "Errores");
            }
            
            else
            {
               
                string estado = "";
                foreach (int i in numerosdeTrackeo)
                {
                    if (numerosdeTrackeo.Contains(int.Parse(numeroTrack)))
                    {
                        if (int.Parse(numeroTrack) == 123)
                        {
                            estado = "Recibida";
                        }
                        else if (int.Parse(numeroTrack) == 456)
                        {
                            estado = "En Tránsito";
                        }
                        else if(int.Parse(numeroTrack) == 789)
                        {
                            estado = "Cerrada";
                        }      
                    }
                }
                if(estado != "")
                {
                    MessageBox.Show(estado, "Estado de servicio");
                }
                else
                {
                    MessageBox.Show("No existe un servicio con el número de trackeo ingresado.", "Estado de servicio");
                }
                
            }  
        }

        private void EstadoDeServicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void EstadoDeServicio_Load(object sender, EventArgs e)
        {

        }
    }
}
