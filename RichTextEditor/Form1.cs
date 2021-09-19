using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RichTextEditor
{
    public partial class Form1 : Form
    {
        StringReader leitura = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void editarToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void arquivoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        
        // Funções do arquivo (Criar/Salvar/Abrir)
        private void novoArquivo()
        {
            richTextBox1.Clear();
            richTextBox1.Focus();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            novoArquivo();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            novoArquivo();
        }

        private void salvarArquivo()
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    FileStream arquivo = new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                    StreamWriter cfb_streamWriter = new StreamWriter(arquivo);
                    cfb_streamWriter.Flush();
                    cfb_streamWriter.BaseStream.Seek(0, SeekOrigin.Begin);
                    cfb_streamWriter.Write(this.richTextBox1.Text);
                    cfb_streamWriter.Flush();
                    cfb_streamWriter.Close();
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Erro na gravação do arquivo: " + ex.Message,"Erro ao gravar",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            salvarArquivo();
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            salvarArquivo();
        }
        
        private void abrirArquivo()
        {
            this.openFileDialog1.Title = "Abrir arquivo";
            openFileDialog1.InitialDirectory = @"E:\Projetos com C#\C-sharp-editor";
            openFileDialog1.Filter = "Todos os Arquivos(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try 
                {
                    FileStream arquivo = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                    StreamReader cfb_streamReader = new StreamReader(arquivo);
                    cfb_streamReader.BaseStream.Seek(0, SeekOrigin.Begin);
                    this.richTextBox1.Text = "";
                    string linha = cfb_streamReader.ReadLine();
                    
                    while(linha != null)
                    {
                        this.richTextBox1.Text += linha + "\n";
                        linha = cfb_streamReader.ReadLine();
                    }
                    cfb_streamReader.Close();

                } catch (Exception ex)
                {
                    MessageBox.Show("Erro ade leitura: " + ex.Message, "Erro ao ler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            abrirArquivo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            abrirArquivo();
        }
        //Funções de edição (Copiar/Colar/Recortar)
        private void Copiar()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Copy();
            }
        }
        
        private void Colar()
        {
            if(richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Paste();
            }
        }
        private void Recortar()
        {
            if (richTextBox1.SelectionLength > 0)
            {
                richTextBox1.Cut();
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void btnColar_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Colar();
        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Recortar();
        }

        private void btnRecortar_Click(object sender, EventArgs e)
        {
            Recortar();
        }
        //Editar texto (Negrito/Italico/Sublinhado)
        private void Negrito()
        {
            string nomeDaFonte = null;
            float tamanhoDaFonte = 0;
            bool n, i, s = false;

            nomeDaFonte = richTextBox1.Font.Name;
            tamanhoDaFonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Regular);
            if (n == false)
            {
              if(i == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Italic | FontStyle.Underline);
                }
              else if(i == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Underline);
                }
              else if(i == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Italic);
                }
              else if(i == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold);
                } 
            } 
            else
            {
                if (i == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (i == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline);
                }
                else if (i == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic);
                }
            }
        }
        private void Italico()
        {
            string nomeDaFonte = null;
            float tamanhoDaFonte = 0;
            bool n, i, s = false;

            nomeDaFonte = richTextBox1.Font.Name;
            tamanhoDaFonte = richTextBox1.Font.Size;
            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Regular);
            if (i == false)
            {
                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic | FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic | FontStyle.Underline);
                }
                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic | FontStyle.Bold);
                }
                else if (n == false & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic);
                }
            }
            else
            {
                if (n == true & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Underline);
                }
                else if (n == false & s == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline);
                }
                else if (n == true & s == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold);
                }
            }
        }
        private void Sublinhado()
        {
            string nomeDaFonte = null;
            float tamanhoDaFonte = 0;
            bool n, i, s = false;

            nomeDaFonte = richTextBox1.Font.Name;
            tamanhoDaFonte = richTextBox1.Font.Size;

            n = richTextBox1.SelectionFont.Bold;
            i = richTextBox1.SelectionFont.Italic;
            s = richTextBox1.SelectionFont.Underline;

            richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Regular);
            if (s == false)
            {
                if(n==true & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline | FontStyle.Bold | FontStyle.Italic);
                }
                else if (n == false & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline | FontStyle.Italic);
                }
                else if (n == true & i == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline | FontStyle.Bold);
                }
                else if (n == false & i == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Underline);
                }
                
            } 
            else
            {
                if(n == true & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold | FontStyle.Italic);
                }
                else if (n == false & i == true)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Italic);
                }
                else if (n == true & i == false)
                {
                    richTextBox1.SelectionFont = new Font(nomeDaFonte, tamanhoDaFonte, FontStyle.Bold);
                }
            }

        }
        private void btnNegrito_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void negritoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Negrito();
        }

        private void italicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btnItalico_Click(object sender, EventArgs e)
        {
            Italico();
        }

        private void btnSublinhado_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        private void sublinharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sublinhado();
        }

        //Alinhamento do texto
        private void alinharEsquerda()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }
        private void alinharDireita()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }
        private void alinharAoCentro()
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void btnEsquerda_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void esquerdaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharEsquerda();
        }

        private void btnDireita_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void direitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharDireita();
        }

        private void centralizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alinharAoCentro();
        }

        private void btnCentralizar_Click(object sender, EventArgs e)
        {
            alinharAoCentro();
        }
        //Impressão do arquivo
        private void imprimir() 
        {
            printDialog1.Document = printDocument1;
            string texto = this.richTextBox1.Text;
            leitura = new StringReader(texto);

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            imprimir();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            float linhasPagina = 0;
            float posY = 0;
            int count = 0;
            float margemEsquerda = e.MarginBounds.Left - 50;
            float margemSuperior = e.MarginBounds.Top - 50;
            
            if(margemEsquerda < 5)
            {
                margemEsquerda = 20;
            }

            if (margemSuperior < 5)
            {
                margemSuperior = 20;
            }

            string linha = null;
            Font fonte = this.richTextBox1.Font;
            SolidBrush pincel = new SolidBrush(Color.Black);
            linhasPagina = e.MarginBounds.Height / fonte.GetHeight(e.Graphics);
            linha = leitura.ReadLine();

            while (count < linhasPagina)
            {
                posY = (margemSuperior + (count * fonte.GetHeight(e.Graphics)));
                e.Graphics.DrawString(linha, fonte, pincel, margemEsquerda, posY, new StringFormat());
                count += 1;
                linha = leitura.ReadLine();
            }
            if (linha != null)
            {
                e.HasMorePages = true;
            } 
            else
            {
                e.HasMorePages = false;
            }
            pincel.Dispose();
        }
    }
}
