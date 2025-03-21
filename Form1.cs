using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CalculadoraExperience
{
    public partial class Form1 : Form
    {
        List<double> numeros = new List<double>();
        Operations operations = new Operations();
        //Controla até então a escolha das 4 operações:
        //0 = "neutro"
        //1 = +
        //2 = -
        //3 = /
        //4 = *
        int escolhaOperation = 0;

        //Variáveis para salvar o primeiro valor "escolhido" e poder fazer o calculo com o próximo
        double numero1, numero2;
        
        private bool dragging = false;
        private int offsetX;
        private int offsetY;

        double soma = 0;
        double valorTemporario = 0;

        private int clickTema = 0;
        private int clickBtnAdiciona = 0;
        //Adicionar um painel no topo como área de movimentação
        Panel titleBar = new Panel
        {
            Dock = DockStyle.Top,
            Height = 30,
            BackColor = System.Drawing.Color.White
        };

        public Form1()
        {

            InitializeComponent();

            //Mantém a área de entrada ativa para o teclado
            textBoxValor.Select();

            //Definir as bordas arredondadas do Forms
            //Defina o valor para o raio de arredondamento que você deseja
            int raioCurvatura = 30;

            //Criar um caminho gráfico com bordas arredondadas
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, raioCurvatura, raioCurvatura, 180, 90); // Canto superior esquerdo
            path.AddArc(this.Width - raioCurvatura - 1, 0, raioCurvatura, raioCurvatura, 270, 90); // Canto superior direito
            path.AddArc(this.Width - raioCurvatura - 1, this.Height - raioCurvatura - 1, raioCurvatura, raioCurvatura, 0, 90); // Canto inferior direito
            path.AddArc(0, this.Height - raioCurvatura - 1, raioCurvatura, raioCurvatura, 90, 90); // Canto inferior esquerdo
            path.CloseAllFigures();

            //Definir a região do formulário com o caminho gráfico
            this.Region = new Region(path);

            //Adicionar o painel ao formulário
            this.Controls.Add(titleBar);

            //Permitir arrastar o formulário com o painel
            titleBar.MouseDown += new MouseEventHandler(TitleBar_MouseDown);
            titleBar.MouseMove += new MouseEventHandler(TitleBar_MouseMove);
            titleBar.MouseUp += new MouseEventHandler(TitleBar_MouseUp);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Procura todos os botões do formulário e adiciona o evento de clique
            foreach (Control controle in this.Controls)
            {
                if (controle is System.Windows.Forms.Button)
                {
                    controle.Click += (s, args) =>
                    {
                        textBoxValor.Focus();
                        textBoxValor.SelectionStart = textBoxValor.Text.Length;  // Coloca o cursor no final do texto
                        textBoxValor.SelectionLength = 0;  // Remove qualquer seleção de texto
                    };
                }
            }
        }
        //Método criado para mudar o tema de claro para escuro
        private void mudarTema(int clickTema)
        {
            if (clickTema % 2 == 0)
            {
                btnTema.Text = "☾";
                btnTema.ForeColor = Color.MediumSeaGreen;
                BackColor = Color.White;
                titleBar.BackColor = Color.White;
                panelValores.BackColor = Color.FromArgb(192, 255, 192);
                textBoxValor.BackColor = Color.FromArgb(192, 255, 192);

                btnPorcentagem.BackColor = Color.FromArgb(192, 255, 255);
                btnCancelEntry.BackColor = Color.FromArgb(192, 255, 255);
                btnClear.BackColor = Color.FromArgb(192, 255, 255);
                btnApagar.BackColor = Color.FromArgb(192, 255, 255);
                btnDivide.BackColor = Color.FromArgb(192, 255, 255);
                btnMultiplica.BackColor = Color.FromArgb(192, 255, 255);
                btnSubtrai.BackColor = Color.FromArgb(192, 255, 255);
                btnAdiciona.BackColor = Color.FromArgb(192, 255, 255);

            }
            else
            {
                btnTema.Text = "☼";
                btnTema.ForeColor = Color.Yellow;
                BackColor = Color.FromArgb(33, 28, 28);
                titleBar.BackColor = Color.FromArgb(33, 28, 28);
                panelValores.BackColor = Color.FromArgb(236, 251, 236);
                textBoxValor.BackColor = Color.FromArgb(236, 251, 236);

                btnPorcentagem.BackColor = Color.FromArgb(51, 43, 43);
                btnCancelEntry.BackColor = Color.FromArgb(51, 43, 43);
                btnClear.BackColor = Color.FromArgb(51, 43, 43);
                btnApagar.BackColor = Color.FromArgb(51, 43, 43);
                btnDivide.BackColor = Color.FromArgb(51, 43, 43);
                btnMultiplica.BackColor = Color.FromArgb(51, 43, 43);
                btnSubtrai.BackColor = Color.FromArgb(51, 43, 43);
                btnAdiciona.BackColor = Color.FromArgb(51, 43, 43);
            }
        }
        //Inicia o processo de arrastar
        private void TitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            //Verifica se o botão do mouse pressionado é o botão esquerdo
            if (e.Button == MouseButtons.Left)
            {
                //Define a variável 'dragging' como verdadeira, indicando que o arraste foi iniciado
                dragging = true;
                offsetX = e.X;
                offsetY = e.Y;
            }
        }

        //Move o formulário enquanto o mouse está sendo arrastado
        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            //Verifica se o panel foi arrastado
            if (dragging)
            {
                this.Left = e.X + this.Left - offsetX;
                this.Top = e.Y + this.Top - offsetY;
            }
        }

        //Para o movimento quando o botão do mouse for solto
        private void TitleBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }


        //Essa série de eventos reconhece o click do mouse nas "teclas" da calculadora
        private void btnZero_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 0;
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 1;
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 2;
        }

        private void btnThre_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 3;
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 4;
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 5;
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 6;
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 7;
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 8;
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            textBoxValor.Text += 9;
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            if (textBoxValor.Text.Length > 0)
            {
                //Remove o último caractere
                textBoxValor.Text = textBoxValor.Text.Substring(0, textBoxValor.Text.Length - 1);
                //Usa o método Substring() para pegar uma parte da string do TextBox até o penúltimo
                //caractere, efetivamente apagando o último caractere.
            }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            //Converte o segundo valor setado no "textBoxValor" e insere na variável "numero1"
            double.TryParse(textBoxValor.Text, out numero1);
            numeros.Add(numero1);
            soma = operations.Somar(numeros);
            labelValor1.Text += numero1 + " = " + soma;
            textBoxValor.Text = null;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnTema_Click(object sender, EventArgs e)
        {
            clickTema++;
            mudarTema(clickTema);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Zera a calculadora
            numero1 = 0;
            numero2 = 0;
            labelValor1.Text = "0";
            textBoxValor.Text = null;
        }

        private void btnCancelEntry_Click(object sender, EventArgs e)
        {
            //Limpa todo o valor "digitado" no momento
            //Se "escolhaOperation" for igual a 0, estamos no primeiro número
            if (escolhaOperation == 0)
            {
                numero1 = 0;
                textBoxValor.Text = null;
            }
            else
            {
                numero2 = 0;
                textBoxValor.Text = null;
            }
        }

        //Botões para operações
        private void btnAdiciona_Click(object sender, EventArgs e)
        {
            //Atualiza o valor do label responsável para mostrar o calculo que esta sendo feito
            labelValor1.Text += textBoxValor.Text + " + ";

            //Converte o segundo valor setado no "textBoxValor" e insere na variável "numero1"
            double.TryParse(textBoxValor.Text, out numero1);
            numeros.Add(numero1);

            //Atualiza o valor no textBoxValor ser setado um novo valor
            textBoxValor.Text = null;
        }


        //Interações com o TextBox
        private void textBoxValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Permite números e o ponto decimal
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != ',')
            {
                e.Handled = true;
            }
            //Permite apenas um ponto decimal
            else if (e.KeyChar == ',' && textBoxValor.Text.Contains(","))
            {
                e.Handled = true;
            }
        }

        private void textBoxValor_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Add)
            {
                btnAdiciona_Click((object)sender, e);
            }
            
            if (e.KeyCode == Keys.Return && e.KeyCode == Keys.Enter)
            {
                btnEnter_Click((object)sender, e);
            }
        }

        

    }
}
