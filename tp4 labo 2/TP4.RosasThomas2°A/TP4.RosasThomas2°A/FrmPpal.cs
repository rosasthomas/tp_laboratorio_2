using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace TP4.RosasThomas2_A
{
    public partial class FrmPpal : Form
    {
        Correo correo = new Correo();
        public FrmPpal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creará y añadirá un nuevo paquete al correp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);
            paquete.InformaEstado += new Paquete.DelegadoEstado(this.paq_InformaEstado);
            try
            {
                correo += paquete;
            }
            catch (TrackingIdRepetidoException tr)
            {
                    MessageBox.Show(tr.Message);
                
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                this.ActualizarEstados();
            }

            
        }

        /// <summary>
        /// Actualizara el estado de los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }

        /// <summary>
        /// Agregara los paquetes a las listas según corresponda
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();

            foreach (Paquete paquete in correo.Paquetes)
            {
                if (paquete.Estado == Paquete.EEstado.Ingresado)
                {
                    lstEstadoIngresado.Items.Add(paquete);
                }
                else if (paquete.Estado == Paquete.EEstado.EnViaje)
                {
                    lstEstadoEnViaje.Items.Add(paquete);
                }
                else if (paquete.Estado == Paquete.EEstado.Entregado)
                {
                    lstEstadoEntregado.Items.Add(paquete); 
                }
            }
        }

        /// <summary>
        /// Cuando se cierre el programa cerrará todos los hilos activos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                correo.FinEntregas();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            
        }

        /// <summary>
        /// Mostrará todos los paquetes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Guarda los datos en un documento de texto y los mostrará en pantalla
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                GuardaString.Guardar(rtbMostrar.Text, "salida.txt");
            }
        }

        /// <summary>
        /// Mostrará el item seleccionado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

    }
}
