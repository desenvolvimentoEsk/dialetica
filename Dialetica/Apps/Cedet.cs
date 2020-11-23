using Dialetica.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dialetica.Apps
{
    public partial class Cedet : Form
    {
        public Cedet()
        {
            InitializeComponent();
            pictureBox1.Hide();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            backgroundWorker_inicia.RunWorkerAsync();
            pictureBox1.Show();
        }

        private void backgroundWorker_inicia_DoWork(object sender, DoWorkEventArgs e)
        {
            Banco banco = new Banco();
            Pastas pastas = new Pastas();
            Geral geral = new Geral();

            while (true)
            {
                ArrayList dados = banco.PegaDadosCedet();
                foreach (string item in dados)
                {
                    string[] corta = item.Split('|');

                    string nome_cliente = corta[0];
                    string nome_do_trabalho = corta[1];
                    string codigo_cliente = corta[2];
                    string codigo_isbn = corta[3];
                    string valor_unitario = corta[4];
                    string quantidade = corta[5];
                    string formato_final_fechado_do_miolo = corta[6];
                    string papel_capa = corta[7];
                    string cores_capa = corta[8];
                    string orelha_da_capa = corta[9];
                    string acabamento_capa = corta[10];
                    string papel_miolo = corta[11];
                    string cores_miolo = corta[12];
                    string miolo_sangrado = corta[13];
                    string quantidade_paginas_miolo = corta[14];
                    string acabamento_miolo = corta[15];
                    string acabamento_livro = corta[16];
                    string shrink = corta[17];
                    string papel_fornecido = corta[18];
                    string vendedor = corta[19];
                    string data = corta[20];
                    string usuario = corta[21];
                    string feito = corta[22];
                    string cliente = corta[23];
                    string prazo = corta[24];
                    string downaload = corta[25];
                    string id = corta[26];



                    if (geral.EncontraPalavra(acabamento_capa.ToUpper(), "FOSCA"))
                    {
                        acabamento_capa = "FOSCO";
                    }
                    else if (geral.EncontraPalavra(acabamento_capa.ToUpper(), "brilho"))
                    {
                        acabamento_capa = "BRILHO";
                    }
                    else
                    {
                        acabamento_capa = acabamento_capa;
                    }


                    if (geral.EncontraPalavra(papel_capa, "250"))
                    {
                        papel_capa = "250";
                    }
                    else if (geral.EncontraPalavra(papel_capa.ToUpper(), "300"))
                    {
                        papel_capa = "300";
                    }
                    //MessageBox.Show(papel_capa);


                    //valida e pega pasta da capa
                    string caminhoCapa = pastas.PegaPastaCapaCEDET(papel_capa, acabamento_capa, formato_final_fechado_do_miolo, cores_capa);



                    //valida e pega pasta miolo
                    string caminhoMiolo = pastas.PegaPastaMioloCEDET(cores_miolo, formato_final_fechado_do_miolo);





                    //localiza os arquivos no ftp
                    ArrayList arquivos = pastas.EncontraArquivo(@"\\192.168.0.28\cedet\", codigo_isbn.Trim());
                    //encontra os arquivos no ftp
                    string arquivoFtpCapa = "";
                    string arquivoFtpMiolo = "";

                    if (arquivos.Count > 0)
                    {
                        foreach (string achou in arquivos)
                        {
                            string[] cortaArquivo = achou.Split('|');
                            if (geral.EncontraPalavra(cortaArquivo[1], "CAPA"))
                            {
                             
                                arquivoFtpCapa = cortaArquivo[0];
                            }
                            else if (geral.EncontraPalavra(cortaArquivo[1], "MIOLO"))
                            {
                             
                                arquivoFtpMiolo = cortaArquivo[0];
                            }


                        }

                        bool validaMiolo = false;
                        bool validaCapa = false;
                        //transfere capa
                        try
                        {
                            //envia miolo pra pasta
                            File.Copy(arquivoFtpCapa, caminhoCapa + "/" + id + "_Capa_Isbn_" + codigo_isbn + "_paginas_" + quantidade_paginas_miolo + "_tiragem_" + quantidade  + ".pdf");
                            // valida se copiou
                            validaCapa = geral.validaArquivoCopiou(caminhoCapa + "/" + id + "_Capa_Isbn_" + codigo_isbn + "_paginas_" + quantidade_paginas_miolo + "_tiragem_" + quantidade  + ".pdf");
                        }
                        catch (Exception erro)
                        {
                            geral.LogErroSalvaTxt("Miolo isbn:" + codigo_isbn + "-" + erro.ToString());
                        }

                        //transfere miolo
                        try
                        {
                            //envia miolo pra pasta
                            File.Copy(arquivoFtpMiolo, caminhoMiolo + "/" + id + "_Miolo_Isbn_" + codigo_isbn + "_paginas_" + quantidade_paginas_miolo + "_tiragem_" + quantidade + ".pdf");
                            // valida se copiou
                            validaMiolo = geral.validaArquivoCopiou(caminhoMiolo + "/" + id + "_Miolo_Isbn_" + codigo_isbn + "_paginas_" + quantidade_paginas_miolo + "_tiragem_" + quantidade + ".pdf");
                            
                        }
                        catch (Exception erro)
                        {
                            geral.LogErroSalvaTxt("Miolo isbn:" + codigo_isbn + "-" + erro.ToString());
                        }


                        //mudar status
                        
                        if (validaCapa == true && validaMiolo == true)
                        {
                            banco.atualizaDownloadCedet(id, "sim");
                        }else if (validaCapa == false && validaMiolo == true)
                        {
                            banco.atualizaDownloadCedet(id, "erro capa");
                        }else if(validaCapa == true && validaMiolo == false)
                        {
                            banco.atualizaDownloadCedet(id, "erro miolo");
                        }
                        else
                        {
                            banco.atualizaDownloadCedet(id, "erro capa e miolo");
                        }

                        //wait 30 seg
                        System.Threading.Thread.Sleep(20000);
                    }




                }
            }

            
        }
    }
}
