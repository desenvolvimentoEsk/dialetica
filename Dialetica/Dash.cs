using Dialetica.Apps;
using Dialetica.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialetica
{
    public partial class Dash : Form
    {
        public Dash()
        {
            InitializeComponent();
            
        }

        private void sincronizadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sincronizador abre = new Sincronizador();
            abre.Show();
        }

        private void nomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string texto = "9786580096299_CAPA.pdf";
            string palavra = "_CAPA";
            bool resultado = texto.Contains(palavra);
            Console.WriteLine(resultado);
        }

        private void montalotecapaTesteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string caminhoraiz = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21\";
            string caminhoHotFolder = @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21\";
            //manda tudo hotfolder
            DirectoryInfo DirLote = new DirectoryInfo(caminhoraiz + @"\Lote\");
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] FilesLote = DirLote.GetFiles("*");
            foreach (FileInfo Filelote in FilesLote)
            {
                string caminhodoarquivocomarquivoLote = Filelote.FullName;
                if (Filelote.Extension == ".pdf")
                {
                    File.Move(caminhodoarquivocomarquivoLote, caminhoHotFolder + @"\" + Filelote.Name);
                }
            }
        }

        private void cedetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cedet cedet = new Cedet();
            cedet.Show();
        }

        private void removeVirgulaDeNomeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Geral geral = new Geral();
            DirectoryInfo Dir = new DirectoryInfo(@"\\192.168.0.28\cedet\");
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);
            foreach (FileInfo File in Files)
            {

                Console.WriteLine(File.FullName);
                Console.WriteLine(File.Name);
                if (File.Extension == ".pdf")
                {
                    try
                    {
                        string nomearquivo = geral.RemoveAccents(File.Name);
                        System.IO.File.Move(File.FullName, File.DirectoryName + @"\" + nomearquivo.Replace(",", ""));
                    }
                    catch (Exception erro)
                    {
                        MessageBox.Show(erro.ToString());
                    }
                                  
                }
            }
            MessageBox.Show("Finalizado");
        }
    }
}
