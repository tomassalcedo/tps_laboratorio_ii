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
            this.cmbOperador.Items.Add("");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");
        }

        private void btnCerrar_OnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        //Inicia la aplicacion limpiando pantalla
        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            this.lblResultado.Text = String.Empty;
            this.txtNumero1.Text = String.Empty;
            this.txtNumero2.Text = String.Empty;
            this.cmbOperador.SelectedIndex = 0;
        }

        //Al presionar el boton limpiar , Este llama al metodo Limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }


        //Llamo al metodo Operar de la clase calculadora para realizar la operacion
        private static double Operar(string num1,string num2,string operador)
        {
            char auxOperador;
            Operando op1 = new Operando(num1);
            Operando op2 = new Operando(num2);
            char.TryParse(operador, out auxOperador);

            return Calculadora.Operar(op1, op2, auxOperador);
        }

        //Se llama al metodo operar pasando los numeros ingresados en los txtNumeros y el operador del comboBox
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string cadena = String.Empty;  
            string operador = this.cmbOperador.Text;
            if(this.cmbOperador.Text == "")
            {
                operador = "+";
            }
            double total = Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cmbOperador.Text);
            this.lstOperaciones.Items.Add(cadena);
            

            this.lblResultado.Text = Convert.ToString(total);
        }


        //Al intentar salir del programa, manda una alerta para confirmar salida
        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Seguro que quiere salir?","Salida",MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        //Convertir a binario,llama al metodo de la clase operando para dicha operacion
        private void btnConvertirBinario_Click(object sender, EventArgs e)
        {
            Operando operador = new Operando();
            string cadena = operador.DecimalBinario(this.lblResultado.Text);
            this.lblResultado.Text = cadena;
            this.lstOperaciones.Items.Add(cadena);
        }

        private void btnConvertirDecimal_Click(object sender, EventArgs e)
        {
            Operando operador = new Operando();
            string cadena = operador.BinarioDecimal(this.lblResultado.Text);
            this.lblResultado.Text = cadena;
            this.lstOperaciones.Items.Add(cadena);
        }
        

        //No permite ingresar ni letras,simbolos o espacios en blanco
        private void txtNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(char.IsLetter(e.KeyChar) || char.IsSymbol(e.KeyChar) || char.IsWhiteSpace(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solamente numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
