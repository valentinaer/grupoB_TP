﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grupoB_TP
{
    public partial class SolicitudDeServicio : Form
    {
        public SolicitudDeServicio()
        {
            InitializeComponent();
        }
        public void cotizar(string origen, string destino)
        {
            txtDirrecionNacional.Text = origen;
            // -------------- Escondemos elementos -----------------//

            btnCotizar.Visible = false;
            grpCotizacion.Visible = true;
            lblMenuPrincipal.Visible = true;
            grpCaracteristicaServicio.Visible = false;
            grpTipoEnvio.Visible = false;
            grpTipoRecepcion.Visible = false;
            grpNacional.Visible = false;
            grpInternacional.Visible = false;
            grpCotizacion.Visible = true;

            // -------------- Centramos el elemento de cotizacion -----------------//
            //centra el elemento de cotizacion hoirzontalmente y verticalmente
            grpCotizacion.Location = new Point(
                this.ClientSize.Width / 2 - grpCotizacion.Size.Width / 2,
                this.ClientSize.Height / 2 - grpCotizacion.Size.Height / 2);

            // centra el titulo horizontalmente
            lblMenuPrincipal.Location = new Point(
                this.ClientSize.Width / 2 - lblMenuPrincipal.Size.Width / 2,
                lblMenuPrincipal.Location.Y);

            // centra el boton cotizar horizontalmente
            btnCotizar.Location = new Point(
                this.ClientSize.Width / 2 - btnCotizar.Size.Width / 2,
                btnCotizar.Location.Y);


            // Si el checkbox de urgente esta marcado seteamos la variable a Urgente para utilizar como texto 
            string urgente = "";
            if (chkUrgente.Checked)
            {
                urgente = "Urgente";
            }
            else
            {
                urgente = "No Urgente";
            }

            // Calculamos el precio y multiplicamos por 4 para obtener el precio final de envio internacional
            double price = 0;
            if (rboNacional.Checked)
            {
                price = calculatePrecio();
            }
            else
            {
                price = calculatePrecio() * 4;
            }

            // Seteamos el texto de la cotizacion
            lblCotizacion.Text = "$" + price;
            lblOrigen.Text = origen;
            lblDestino.Text = destino;
            lblUrgente.Text = urgente;
            lblCuitI.Text = "30-" + Usuario.DNI + "-9";
        }
        private double calculatePrecio()
        {
            double precio = 0;
            double precioUrgente = 0;
            double precioFinal = 0;

            // -------------- Sobres Hasta 500g -----------------//
            if (cmbCantidadBultosN.SelectedIndex == 0)
            {

                // ----------------- Local -----------------//
                if (cmbProvinciaDestino.SelectedIndex == 0)
                {
                    precio = 20;
                }

                // ----------------- Provincial -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 1)
                {
                    precio = 60;
                }
                // ----------------- Regional -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 2 || cmbProvinciaDestino.SelectedIndex == 3 || cmbProvinciaDestino.SelectedIndex == 4)
                {
                    precio = 100;
                }
                // ----------------- Nacional -----------------//
                else
                {
                    precio = 140;
                }
            }

            // ----------------- Segun la cantidad de bultos -----------------//
            else if (cmbCantidadBultosN.SelectedIndex == 1)
            {
                // ----------------- Local -----------------//
                if (cmbProvinciaDestino.SelectedIndex == 0)
                {
                    precio = 30;
                }
                // ----------------- Provincial -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 1)
                {
                    precio = 70;
                }
                // ----------------- Regional -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 2 || cmbProvinciaDestino.SelectedIndex == 3 || cmbProvinciaDestino.SelectedIndex == 4)
                {
                    precio = 110;
                }
                // ----------------- Nacional -----------------//
                else
                {
                    precio = 150;
                }
            }

            // ------------- Bultos hasta 20Kg --------//
            else if (cmbCantidadBultosN.SelectedIndex == 2)
            {
                // ----------------- Local -----------------//
                if (cmbProvinciaDestino.SelectedIndex == 0)
                {
                    precio = 40;
                }
                // ----------------- Provincial -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 1)
                {
                    precio = 80;
                }
                // ----------------- Regional -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 2 || cmbProvinciaDestino.SelectedIndex == 3 || cmbProvinciaDestino.SelectedIndex == 4)
                {
                    precio = 120;
                }
                // ----------------- Nacional -----------------//
                else
                {
                    precio = 160;
                }
            }

            // ------------- Bultos hasta 30Kg --------//
            else if (cmbCantidadBultosN.SelectedIndex == 3)
            {
                // ----------------- Local -----------------//
                if (cmbProvinciaDestino.SelectedIndex == 0)
                {
                    precio = 50;
                }
                // ----------------- Provincial -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 1)
                {
                    precio = 90;
                }
                // ----------------- Regional -----------------//
                else if (cmbProvinciaDestino.SelectedIndex == 2 || cmbProvinciaDestino.SelectedIndex == 3 || cmbProvinciaDestino.SelectedIndex == 4)
                {
                    precio = 130;
                }
                // ----------------- Nacional -----------------//
                else
                {
                    precio = 170;
                }
            }

            // si es urgente sumamos 20% al precio
            if (chkUrgente.Checked)
            {
                precioUrgente = precio * 0.2;
            }

            // tope maximo de urgencia es 50, por eso si es mas alto sobre escribimos 50
            if (precioUrgente > 50)
            {
                precioUrgente = 50;
            }

            // retiro fijo es 30 y destino fijo 40
            precioFinal = precio + precioUrgente + 30 + 40;

            return precioFinal;
        }
        private void cmbCiudad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbRangoPeso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmbSucursales_SelectedIndexChanged(object sender, EventArgs e)
        {
          

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }


        private void lblMenuPrincipal_Click(object sender, EventArgs e)
        {

        }
        private void rboRecibeSucursal_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grpCotizacion_Enter(object sender, EventArgs e)
        {

        }
        private void SolicitudDeServicioNacional_Load(object sender, EventArgs e)
        {

        }
        //Boton CONFIRMACION
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            int tracking = Autonumerar();
            MessageBox.Show($"La solicitud de servicio se registro de forma exitosa." +
                $" {"\n"}Su numero de trackeo es: {tracking}", "Exito");
        }
        private int Autonumerar()
        {
            Random r = new Random();
            return r.Next(0001, 9999);
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {

            //----------------- Logica Extra para Cotizar -----------------//            
            string origen = "";

            // if sucursal show in a string the sucursal selected from dropdown, if envio a domicilio show in a string the provincia and ciudad selected from dropdown
            if (rboRecibeSucursal.Checked && !rboRetiroDomicilio.Checked)
            {
                origen = cmbSucursalOrigen.Text;
            }

            if (rboRetiroDomicilio.Checked && !rboRecibeSucursal.Checked)
            {
                origen = cmbProvinciaOrigen.Text + " - " + cmbCiudadOrigen.Text;
            }

            //----------------- Validaciones -----------------//


            // Validar que sea Nacional o Internacional
            if (!rboInternacional.Checked && !rboNacional.Checked)
            {
                MessageBox.Show("Debe seleccionar un tipo de envio", "Errores");
                return;
            }

            // Condiciones generales para todos los envios
            if (cmbRangoPeso.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un rango de peso", "Errores");
                return;
            }
            if (cmbCantidadBultosN.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar la cantidad de Bultos", "Errores");
                return;
            }

            //valida que se haya seleccionado un tipo de envio con los radio buttons Sucursal y Domicilio
            if (!rboRecibeSucursal.Checked && !rboRetiroDomicilio.Checked)
            {
                MessageBox.Show("Debe seleccionar un tipo de recepcion", "Errores");
                return;
            }

            // Condiciones para el Origen
            // Si es RETIRO a domicilio
            if (rboRetiroDomicilio.Checked && !rboRecibeSucursal.Checked)
            {
                // Validacion de Provincia en el Origen
                string mensaje = "";
                if (cmbProvinciaOrigen.SelectedIndex == -1)
                {
                    mensaje += "Debe seleccionar una provincia de ORIGEN" + "\n";
                }
                if (cmbCiudadOrigen.SelectedIndex == -1)
                {
                    mensaje += "Debe seleccionar una Ciudad de ORIGEN" + "\n";
                }
                if (string.IsNullOrEmpty(txtDirrecionOrigen.Text))
                {
                    mensaje += "El domicilio de Retiro a Domicilio no puede estar VACIO" + "\n";
                }
                if (string.IsNullOrEmpty(txtAlturaOrigen.Text))
                {
                    mensaje += "La altura de Retiro no puede estar VACIO" + "\n";
                }
                else
                {
                    mensaje += Usuario.PedirEntero("Altura de Retiro", 0, 99999, txtAlturaOrigen.Text);
                }

                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, "Errores");
                    return;
                }
            }

            // Si es sucursal
            if (rboRecibeSucursal.Checked && !rboRetiroDomicilio.Checked)
            {
                if (cmbSucursalOrigen.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una Sucursal de ORIGEN", "Errores");
                    return;
                }
            }

            // Validaciones para Envios Nacionales
            if (rboNacional.Checked && !rboInternacional.Checked)
            {

                if (!rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
                {
                    MessageBox.Show("Debe seleccionar el tipo de entrega", "Errores");
                    return;
                }

                // Condiciones para el Origen de Retirmo a Domicilio
                if (rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
                {
                    //Checkear que se haya seleccionado una Provincia de origen
                    if (cmbProvinciaDestino.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar una provincia de DESTINO", "Errores");
                        return;
                    }
                    //Checkear que se haya seleccionado una Ciudad de origen
                    else if (cmbCiudadDestino.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar una ciudad de DESTINO", "Errores");
                        return;
                    }

                    string mensaje = "";
                    if (string.IsNullOrEmpty(txtDirrecionNacional.Text))
                    {
                        mensaje += "El domicilio de Entrega no puede estar Vacio" + "\n";
                    }
                    if (string.IsNullOrEmpty(txtAlturaNacional.Text))
                    {
                        mensaje += "La altura de Entrega no puede estar Vacio" + "\n";
                    }
                    else
                    {
                        mensaje += Usuario.PedirEntero("Altura de Entrega", 0, 99999, txtAlturaNacional.Text);
                    }

                    if (mensaje != "")
                    {
                        MessageBox.Show(mensaje, "Errores");
                        return;
                    }
                }

                // Condiciones para el Destino, si es envio a sucursal 
                if (rboSucursalDestino.Checked && !rboEntregaDomicilio.Checked)
                {
                    //Checkear que se haya seleccionado una sucursal de destino
                    if (cmbSucursalesDestino.SelectedIndex == -1)
                    {
                        MessageBox.Show("Debe seleccionar una sucursal de destino", "Errores");
                        return;
                    }
                }

                string destino = "";

                // Mostrar informacion de cotizacion de Destino
                if (rboSucursalDestino.Checked && !rboEntregaDomicilio.Checked)
                {
                    destino = cmbSucursalesDestino.Text;
                }
                else if (rboEntregaDomicilio.Checked && !rboSucursalDestino.Checked)
                {
                    destino = cmbCiudadDestino.Text + " - " + cmbProvinciaDestino.Text;
                }

                cotizar(origen, destino);
            }


            // Validaciones para Envios Internacionales
            if (rboInternacional.Checked && !rboNacional.Checked)
            {
                // Condiciones para el Origen
                if (cmbRegionI.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una Region de DESTINO", "Errores");
                    return;
                }

                if (cmbPaisCiudadDestino.SelectedIndex == -1)
                {
                    MessageBox.Show("Debe seleccionar una País y Ciudad de DESTINO", "Errores");
                    return;
                }

                string mensaje = "";
                if (string.IsNullOrEmpty(txtDireccionI.Text))
                {
                    mensaje += "El domicilio de Entrega a Domicilio Internacional no puede estar VACIO" + "\n";
                }
                if (string.IsNullOrEmpty(txtAlturaI.Text))
                {
                    mensaje += "La altura de Entrega Internacional no puede estar VACIO" + "\n";
                }
                else
                {
                    mensaje += Usuario.PedirEntero("Altura de Entrega Internacional ", 0, 99999, txtAlturaI.Text);
                }

                if (mensaje != "")
                {
                    MessageBox.Show(mensaje, "Errores");
                    return;
                }
                cotizar(origen, cmbPaisCiudadDestino.Text + " - " + cmbRegionI.Text);
            }
        }
        private void mostrarOcultar(object sender, EventArgs e)
        {
            // Si radio button Nacional esta checkeda, mostrar el grupo Nacional
            if (rboNacional.Checked)
            {
                grpNacional.Visible = true;
                grpInternacional.Visible = false;
            }
            // Si radio button Internacional esta checkeda, mostrar el grupo Internacional
            else if (rboInternacional.Checked)
            {
                grpInternacional.Visible = true;
                grpNacional.Visible = false;
            }
        }

        //BOTON MODIFICAR
        private void btnModificar_Click(object sender, EventArgs e)
        {
            // -------------- Escondemos elementos -----------------//
            grpCotizacion.Visible = false;
            
            lblMenuPrincipal.Visible = false;
            grpCaracteristicaServicio.Visible = true;
            grpTipoEnvio.Visible = true;
            grpTipoRecepcion.Visible = true;
            grpNacional.Visible = true;
            grpInternacional.Visible = false;
            btnCotizar.Visible = true;
        }

        //Mostrar Provincia Origen
        private void cmbProvinciaOrigen_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvinciaOrigen.Text == "BUENOS AIRES")
            {
                cmbCiudadOrigen.Items.Clear();
                cmbCiudadOrigen.Items.Add("Mar del Plata");
                cmbCiudadOrigen.Items.Add("Quilmes");
                cmbCiudadOrigen.Items.Add("Bahia Blanca");
                cmbCiudadOrigen.Items.Add("Salto");
            }
            else if (cmbProvinciaOrigen.Text != "BUENOS AIRES")
            {
                cmbCiudadOrigen.Items.Clear();
                cmbCiudadOrigen.Items.Add("NO IMPLEMENTADO");
            }
        }
        //Mostrar Provincia Destino
        private void cmbProvinciaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvinciaDestino.Text == "BUENOS AIRES")
            {
                cmbCiudadDestino.Items.Clear();
                cmbCiudadDestino.Items.Add("Mar del Plata");
                cmbCiudadDestino.Items.Add("Quilmes");
                cmbCiudadDestino.Items.Add("Bahia Blanca");
                cmbCiudadDestino.Items.Add("Salto");
            }
            else if (cmbProvinciaDestino.Text != "BUENOS AIRES")
            {
                cmbCiudadDestino.Items.Clear();
                cmbCiudadDestino.Items.Add("NO IMPLEMENTADO");
            }
        }
        //Mostrar Internacional Destino
        private void cmbRegionI_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRegionI.Text == "Europa")
            {
                cmbPaisCiudadDestino.Items.Clear();
                cmbPaisCiudadDestino.Items.Add("Madrid España");
                cmbPaisCiudadDestino.Items.Add("Paris, Francia");
                cmbPaisCiudadDestino.Items.Add("Roma, Italia");
                cmbPaisCiudadDestino.Items.Add("Berlin, Alemania");
            }
            else if (cmbProvinciaDestino.Text != "Europa")
            {
                cmbPaisCiudadDestino.Items.Clear();
                cmbPaisCiudadDestino.Items.Add("NO IMPLEMENTADO");
            }
        }
      
    }
}
