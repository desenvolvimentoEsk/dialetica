using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dialetica.Classes
{
    class Geral
    {
        //encontra palavra dentro de uma string
        public bool EncontraPalavra(string texto, string palavra)
        {
            bool resultado = texto.Contains(palavra);
            return resultado;
        }
        public bool validaArquivoCopiou(string Caminho)
        {
            try
            {
                if (File.Exists(Caminho))
                    using (File.OpenRead(Caminho))
                    {
                        return true;
                    }
                else
                    return false;
            }
            catch (Exception)
            {
                Thread.Sleep(100);
                return validaArquivoCopiou(Caminho);
            }

        }

        public void LogErroSalvaTxt(string texto)
        {
            string caminhoParaSalvar = @"C:\B2B";

            if (!File.Exists(caminhoParaSalvar + @"\LogErroDialetica.txt"))
            {
                File.Create(caminhoParaSalvar + @"\LogErroDialetica.txt").Close();
            }
            TextWriter arquivo = File.AppendText(caminhoParaSalvar + @"\LogErroDialetica.txt");
            arquivo.WriteLine(DateTime.Now.ToString("dd/MM/yyyy H:mm") + " - - " + texto);
            arquivo.Close();
        }


        public bool MoveparaImpressora(string pastaImpo, string pastaImpressora)
        {
            bool retorno = false;
            //verifica se pasta de destino esta vazia
            if (!Directory.GetFiles(pastaImpo).Length.Equals(0) || !Directory.GetDirectories(pastaImpo).Length.Equals(0))
            {

                //monta a pasta processado
                string pasta = "processado" + DateTime.Now.ToString("ddMMyyyy");
                if (!Directory.Exists(pastaImpo + @"\" + pasta))
                {
                    Directory.CreateDirectory(pastaImpo + @"\" + pasta);
                }

                //move para pasta da imposicao
                DirectoryInfo Dir = new DirectoryInfo(pastaImpo);
                // Busca automaticamente todos os arquivos em todos os subdiretórios
                FileInfo[] Files = Dir.GetFiles("*");
                foreach (FileInfo Filer in Files)
                {
                    string caminhodoarquivocomarquivo = Filer.FullName;
                    string nomePdf = Filer.Name;
                    try
                    {
                        File.Copy(caminhodoarquivocomarquivo, pastaImpo + @"\" + pasta + @"\" + nomePdf, true);
                        File.Move(caminhodoarquivocomarquivo, pastaImpressora + @"\" + nomePdf);
                        retorno = true;
                    }
                    catch (Exception)
                    {
                        retorno = false;
                        throw;
                    }

                }


            }
            else
            {
                retorno = false;
            }
            return retorno;
        }


        public string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }
    }

    

}
