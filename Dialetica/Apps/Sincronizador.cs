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
    public partial class Sincronizador : Form
    {
        public Sincronizador()
        {
            InitializeComponent();
        }

        private void btn_iniciar_Click(object sender, EventArgs e)
        {
            pictureBox1.Show();
            btn_iniciar.Enabled = false;
            backgroundWorker_iniciaProcesso.RunWorkerAsync();
            backgroundWorker_MontaloteCapa.RunWorkerAsync();
            backgroundWorker_MontaloteMiolo.RunWorkerAsync();
            backgroundWorker_enviaImpressora.RunWorkerAsync();
        }

        //faz download
        private void backgroundWorker_iniciaProcesso_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                Banco banco = new Banco();
                Pastas pastas = new Pastas();
                Geral geral = new Geral();

                ArrayList dados = banco.PegaDadosApi();
                foreach (string item in dados)
                {
                    string[] corta = item.Split('|');
                    string nomedialetica = corta[0];
                    string codproduto = corta[1];
                    string tipodeproduto = corta[2];
                    string numpedido = corta[3];
                    string numitem = corta[4];
                    string isbn = corta[5];
                    string titulodolivro = corta[6];
                    string subtitulo = corta[7];
                    string editoraSelo = corta[8];
                    string tiragem = corta[9];
                    string papelcapa = corta[10];
                    string gramaturacapa = corta[11];
                    string corescapa = corta[12];
                    string formatoabertocapa = corta[13];
                    string formatodalombada = corta[14];
                    string medidadaorelha = corta[15];
                    string acabamentocapa = corta[16];
                    string papelmiolo = corta[17];
                    string gramaturamiolo = corta[18];
                    string coresmiolo = corta[19];
                    string formatomiolo = corta[20];
                    string paginasmiolototal = corta[21];
                    string paginasmiolopb = corta[22];
                    string paginasmiolocor = corta[23];
                    string acabamentolivro = corta[24];
                    string embalagemdolivro = corta[25];
                    string precounitdolivro = corta[26];
                    string tiragemmarcador = corta[27];
                    string datapedido = corta[28];
                    string data = corta[29];
                    string status = corta[30];
                    string id = corta[31];




                    if (geral.EncontraPalavra(acabamentocapa.ToUpper(), "FOSCA"))
                    {
                        acabamentocapa = "FOSCO";
                    }
                    else if (geral.EncontraPalavra(acabamentocapa.ToUpper(), "brilho"))
                    {
                        acabamentocapa = "BRILHO";
                    }
                    else
                    {
                        acabamentocapa = acabamentocapa;
                    }




                    //valida e pega pasta da capa
                    string caminhoCapa = pastas.PegaPastaCapa(gramaturacapa, acabamentocapa, formatomiolo);



                    //valida e pega pasta miolo
                    string caminhoMiolo = pastas.PegaPastaMiolo(coresmiolo, papelmiolo, gramaturamiolo, formatomiolo);


                    //valida e pega pasta da capa
                    string caminholOTECapa = pastas.PegaPastaLoteCapa(gramaturacapa, acabamentocapa, formatomiolo);



                    //valida e pega pasta miolo
                    string caminholOTEMiolo = pastas.PegaPastaLoteMiolo(coresmiolo, papelmiolo, gramaturamiolo, formatomiolo);


                    //localiza os arquivos no ftp
                    ArrayList arquivos = pastas.EncontraArquivo(@"\\192.168.0.28\Dialetica\LIVROS PUBLICADOS - DIALÉTICA", isbn);
                    //encontra os arquivos no ftp
                    string arquivoFtpCapa = "";
                    string arquivoFtpMiolo = "";

                    if (arquivos.Count > 0)
                    {
                        Console.WriteLine(arquivos);
                        foreach (string achou in arquivos)
                        {
                            string[] cortaArquivo = achou.Split(',');
                            Console.WriteLine(cortaArquivo[1]);
                            if (geral.EncontraPalavra(cortaArquivo[1], "_CAPA"))
                            {
                                Console.WriteLine(cortaArquivo[0]);
                                arquivoFtpCapa = cortaArquivo[0];
                            }
                            else if (geral.EncontraPalavra(cortaArquivo[1], "_MIOLO"))
                            {
                                Console.WriteLine(cortaArquivo[0]);
                                arquivoFtpMiolo = cortaArquivo[0];
                            }


                        }
                    }


                    try
                    {
                        if (Int16.Parse(tiragem) > 1)
                        {

                            if (Int16.Parse(tiragem) <= 19)
                            {
                                for (int i = 0; i < Int16.Parse(tiragem); i++)
                                {

                                    File.Copy(arquivoFtpCapa, caminholOTECapa + "/" + id + "_Capa_Isbn_" + isbn + "_tiragem_" + tiragem + "_N_" + i + "_.pdf");
                                    bool valida = geral.validaArquivoCopiou(caminholOTECapa + "/" + id + "_Capa_Isbn_" + isbn + "_tiragem_" + tiragem + "_N_" + i + "_.pdf");
                                    if (valida)
                                    {
                                        banco.atualizaStatus(id);
                                    }
                                }
                            }
                            else
                            {
                                string caminhoBaixa = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\BAIXA_TIRAGEM\CAPA";
                                //\\192.168.24.181\c\B2B\EDITORA DIALETICA\MONTALOTE\BAIXA_TIRAGEM\CAPA
                                //envia capa pra pasta
                                File.Copy(arquivoFtpCapa, caminhoBaixa + "/" + id + "_Capa_Isbn_" + isbn + "_tiragem_" + tiragem + ".pdf");
                                //valida se copiou
                                bool valida = geral.validaArquivoCopiou(caminhoBaixa + "/" + id + "_Capa_Isbn_" + isbn + "_tiragem_" + tiragem + ".pdf");
                                if (valida)
                                {
                                    banco.atualizaStatus(id);
                                }
                            }





                        }
                        else
                        {
                            //envia capa pra pasta
                            File.Copy(arquivoFtpCapa, caminholOTECapa + "/" + id + "_Capa_Isbn_" + isbn + "_tiragem_" + tiragem + ".pdf");
                            //valida se copiou
                            bool valida = geral.validaArquivoCopiou(caminholOTECapa + "/" + id + "_Capa_Isbn_" + isbn + "_tiragem_" + tiragem + ".pdf");
                            if (valida)
                            {
                                banco.atualizaStatus(id);
                            }
                        }

                    }
                    catch (Exception erro)
                    {
                        geral.LogErroSalvaTxt("Capa isbn:" + isbn + "-" + erro.ToString());
                    }


                    try
                    {

                        if (Int16.Parse(tiragem) > 1)
                        {
                            if (Int16.Parse(tiragem) <= 19)
                            {
                                for (int i = 0; i < Int16.Parse(tiragem); i++)
                                {
                                    File.Copy(arquivoFtpMiolo, caminholOTEMiolo + "/" + id + "_Miolo_Isbn_" + isbn + "_paginas_" + paginasmiolototal + "_tiragem_" + tiragem + "_N_" + i + "_.pdf");
                                    bool valida = geral.validaArquivoCopiou(caminholOTEMiolo + "/" + id + "_Miolo_Isbn_" + isbn + "_paginas_" + paginasmiolototal + "_tiragem_" + "_tiragem_" + tiragem + "_N_" + i + "_.pdf");
                                    if (valida)
                                    {
                                        banco.atualizaStatus(id);
                                    }

                                }
                            }
                            else
                            {
                                //\\192.168.24.181\c\B2B\EDITORA DIALETICA\MONTALOTE\BAIXA_TIRAGEM\MIOLO
                                string caminhoBaixa = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\BAIXA_TIRAGEM\MIOLO";
                                File.Copy(arquivoFtpMiolo, caminhoBaixa + "/" + id + "_Miolo_Isbn_" + isbn + "_paginas_" + paginasmiolototal + "_tiragem_" + tiragem + "_.pdf");
                                bool valida = geral.validaArquivoCopiou(caminhoBaixa + "/" + id + "_Miolo_Isbn_" + isbn + "_paginas_" + paginasmiolototal + "_tiragem_" + tiragem + "_.pdf");
                                if (valida)
                                {
                                    banco.atualizaStatus(id);
                                }
                            }


                        }
                        else
                        {
                            //envia miolo pra pasta
                            File.Copy(arquivoFtpMiolo, caminholOTEMiolo + "/" + id + "_Miolo_Isbn_" + isbn + "_paginas_" + paginasmiolototal + "_tiragem_" + tiragem + ".pdf");
                            // valida se copiou
                            bool valida = geral.validaArquivoCopiou(caminholOTEMiolo + "/" + id + "_Miolo_Isbn_" + isbn + "_paginas_" + paginasmiolototal + "_tiragem_" + tiragem + ".pdf");
                            if (valida)
                            {
                                banco.atualizaStatus(id);
                            }

                        }




                    }
                    catch (Exception erro)
                    {
                        geral.LogErroSalvaTxt("Miolo isbn:" + isbn + "-" + erro.ToString());
                    }





                }

            }
        }


        //monta lote capa
        private void backgroundWorker_MontaloteCapa_DoWork(object sender, DoWorkEventArgs e)
        {
            Pastas pastas = new Pastas();
            //11x18 total de folhas 800
            //14x21 total de folhas 600
            while (true)
            {
                var date = DateTime.Now;
                if (date.Hour == 10 && date.Minute >= 1 && date.Minute <= 3)
                {
                    //envia tudo
                    pastas.EnviatudoLote_Capa(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21", 600);
                    pastas.EnviatudoLote_Capa(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 11X18", @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 11X18", 800);
                }

                else if (date.Hour == 15 && date.Minute >= 41 && date.Minute <= 43)
                {
                    //envia tudo
                    pastas.EnviatudoLote_Capa(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21", 600);
                    pastas.EnviatudoLote_Capa(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 11X18", @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 11X18", 800);

                }
                else
                {
                    pastas.MontaloteCapa(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21", 600);
                    pastas.MontaloteCapa(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 11X18", @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 11X18", 800);
                }

                    
            }

        }

        //monta lote miolo
        private void backgroundWorker_MontaloteMiolo_DoWork(object sender, DoWorkEventArgs e)
        {

            while (true)
            {
                Pastas pastas = new Pastas();
                var date = DateTime.Now;
                if (date.Hour == 10 && date.Minute >= 1 && date.Minute <= 3)
                {
                    //envia tudo
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\COUCHE FOSCO 150\MIOLO_COUCHE FOSCO_150_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\COUCHE FOSCO 150\MIOLO_COUCHE FOSCO_150_14X21\", 7200);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO_OFFSET75_11X18", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO_OFFSET75_11X18\", 10800);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO-OFFSET75_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO-OFFSET75_14X21\", 7200);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 90\MIOLO_OFFSET90_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 90\MIOLO_OFFSET90_14X21\", 7200);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 120\MIOLO_OFFSET_120_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 120\MIOLO_OFFSET_120_14X21\", 7200);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_11X18", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_11X18\", 10800);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14\", 7200);

                }

                else if (date.Hour == 15 && date.Minute >= 41 && date.Minute <= 43)
                {
                    //envia tudo
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\COUCHE FOSCO 150\MIOLO_COUCHE FOSCO_150_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\COUCHE FOSCO 150\MIOLO_COUCHE FOSCO_150_14X21\", 7200);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO_OFFSET75_11X18", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO_OFFSET75_11X18\", 10800);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO-OFFSET75_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO-OFFSET75_14X21\", 7200);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 90\MIOLO_OFFSET90_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 90\MIOLO_OFFSET90_14X21\", 7200);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 120\MIOLO_OFFSET_120_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 120\MIOLO_OFFSET_120_14X21\", 7200);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_11X18", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_11X18\", 10800);
                    pastas.EnviatudoLote_Miolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14\", 7200);

                }
                else
                {
                    //Formatos; 21,0 x 14,0 e 15,5 x 23,0 - 7.200 páginas por batch
                    //Formatos; 11,5 x 18,0 e 11,0 x 18,0 - 10.800  páginas por batch
                    //Formato; 20,0 x 20,0 - 3.600 páginas por batch
                    //monta lote
                    pastas.MontaLoteMiolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\COUCHE FOSCO 150\MIOLO_COUCHE FOSCO_150_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\COUCHE FOSCO 150\MIOLO_COUCHE FOSCO_150_14X21\", 7200);
                    pastas.MontaLoteMiolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO_OFFSET75_11X18", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO_OFFSET75_11X18\", 10800);
                    pastas.MontaLoteMiolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO-OFFSET75_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO-OFFSET75_14X21\", 7200);
                    pastas.MontaLoteMiolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 90\MIOLO_OFFSET90_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 90\MIOLO_OFFSET90_14X21\", 7200);
                    pastas.MontaLoteMiolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 120\MIOLO_OFFSET_120_14X21", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 120\MIOLO_OFFSET_120_14X21\", 7200);
                    pastas.MontaLoteMiolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_11X18", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_11X18\", 10800);
                    pastas.MontaLoteMiolo(@"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14", @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14\", 7200);

                    
                }
            }

        }

        //envia para as impressoras
        private void backgroundWorker_enviaImpressora_DoWork(object sender, DoWorkEventArgs e)
        {
            Geral geral = new Geral();
            while (true)
            {
                geral.MoveparaImpressora(@"C:\B2B\EDITORA DIALETICA\OUTPUT\CAPAS\CAPAS 300 FOSCO", @"\\DFE12000\Jobs\CAPAS B2B 300");
            }
        }

        private void Sincronizador_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
        }
    }
        
}
