using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculadoraExperience
{
    public partial class Form1 : Form
    {
        Buttons botoes = new Buttons();
        int escolaOperation = 0;
        double valor1, valor2;
        public Form1()
        {
            InitializeComponent();
            textBoxValor.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnZero_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(0);
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(1);
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(2);
        }

        private void btnThre_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(3);
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(4);
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(5);
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(6);
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(7);
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(8);
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += botoes.NumeroEscolhido(9);
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (textBoxValor.Text.Length > 0)
            {
                // Remove o último caractere
                textBoxValor.Text = textBoxValor.Text.Substring(0, textBoxValor.Text.Length - 1);
                //Usa o método Substring() para pegar uma parte da string do TextBox até o penúltimo
                //caractere, efetivamente apagando o último caractere.
            }
        }

        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números e o ponto decimal
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            // Permite apenas um ponto decimal
            else if (e.KeyChar == ',' && textBoxValor.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            double resultado;
            if(escolaOperation == 1)
            {
                double.TryParse(textBoxValor.Text, out valor2);
                resultado = valor1 + valor2;
                labelValor1.Text += textBoxValor.Text;
                textBoxValor.Text = resultado.ToString();
                escolaOperation = 0;
            }
        }

        private void textBoxValor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                escolaOperation = 1;
                labelValor1.Text = textBoxValor.Text + " +";
                double.TryParse(textBoxValor.Text, out valor1);
                textBoxValor.Text = null;
            }
            if (e.KeyCode == Keys.Enter)
            {
                double resultado;
                if (escolaOperation == 1)
                {
                    double.TryParse(textBoxValor.Text, out valor2);
                    resultado = valor1 + valor2;
                    labelValor1.Text += textBoxValor.Text;
                    textBoxValor.Text = resultado.ToString();
                    escolaOperation = 0;
                }
            }
        }

        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            escolaOperation = 1;
            labelValor1.Text = textBoxValor.Text + " +";
            double.TryParse(textBoxValor.Text, out valor1);
            textBoxValor.Text = null;
        }

    }
}
