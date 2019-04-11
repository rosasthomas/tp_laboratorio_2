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

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {

        
        public FormCalculadora()
        {
            InitializeComponent();
            cmbOperador.Items.Add("+");
            cmbOperador.Items.Add("-");
            cmbOperador.Items.Add("*");
            cmbOperador.Items.Add("/");

        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {

        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();           
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = Operar(txtNumeroUno.Text, txtNumeroDos.Text, cmbOperador.Text).ToString();
        }

        private void Limpiar()
        {
            foreach (var txt in Controls)
            {
                if (txt is TextBox)
                {
                    ((TextBox)txt).Clear();
                }
                else if (txt is ComboBox)
                {
                    ((ComboBox)txt).SelectedIndex = -1;
                }
                else if (txt is Label)
                {
                    ((Label)txt).Text = "";
                }
            }
        }
        private static double Operar(string numeroUno, string numeroDos, string operador)
        {
            Numero auxNumeroUno = new Numero(numeroUno);
            Numero auxNumeroDos = new Numero(numeroDos);
            
            return Calculadora.Operar(auxNumeroUno, auxNumeroDos, operador);
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnConvertirABinario_Click(object sender, EventArgs e)
        {
            Numero auxNumero = new Numero();
            lblResultado.Text = auxNumero.DecimalBinario(lblResultado.Text);
        }
        private void BtnConvertirADecimal_Click(object sender, EventArgs e)
        {
            Numero auxNumero = new Numero();
            lblResultado.Text = auxNumero.BinarioDecimal(lblResultado.Text);
        }
    }
}
