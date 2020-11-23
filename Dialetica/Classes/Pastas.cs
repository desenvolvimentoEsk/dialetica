using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialetica.Classes
{
    class Pastas
    {
            
        public string PegaPastaCapa(string gramatura, string tipo, string formato)
        {
            //-Capas entrada:
            //C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21
            //C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 11X18
            //(demais em execução)

            //-Capas saída: 
            //C:\B2B\EDITORA DIALETICA\OUTPUT\CAPAS\CAPAS 300 FOSCO
            //C:\B2B\EDITORA DIALETICA\OUTPUT\CAPAS\CAPAS 300 BRILHO
            //C:\B2B\EDITORA DIALETICA\OUTPUT\CAPAS\CAPAS 250 FOSCO
            //C:\B2B\EDITORA DIALETICA\OUTPUT\CAPAS\CAPAS 250 BRILHO
            formato = formato.ToUpper();
            tipo = tipo.ToUpper();
            gramatura = gramatura.ToUpper();

            string final = "";
            switch (formato)
            {
                case "14X21":
                    if (tipo == "FOSCO")
                    {
                        if (gramatura == "300")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21";
                        }
                        else if (gramatura == "250")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 250 FOSCO\CAPA 250 FOSCO 14X21";
                        }
                    }
                    else if (tipo == "BRILHO")
                    {
                        if (gramatura == "300")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 BRILHO\CAPA 300 BRILHO 14X21";
                        }
                        else if (gramatura == "250")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 250 BRILHO\CAPA 250 BRILHO 14X21";
                        }
                    }

                    break;
                case "11X18":
                    if (tipo == "FOSCO")
                    {
                        if (gramatura == "300")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 11X18";
                        }
                        else if (gramatura == "250")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 250 FOSCO\CAPA 250 FOSCO 11X18";
                        }
                    }
                    else if (tipo == "BRILHO")
                    {
                        if (gramatura == "300")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 300 BRILHO\CAPA 300 BRILHO 11X18";
                        }
                        else if (gramatura == "250")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\INPUT\CAPAS\CAPA 250 BRILHO\CAPA 250 BRILHO 11X18";
                        }
                    }

                    break;
                default:
                    break;
            }


            return final;
        }

        public string PegaPastaMiolo(string coresMiolo,string papelMiolo, string gramaturaMiolo, string formatoMiolo)
        {

            //-Miolos entrada:
            //C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_11X18
            //C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14
            //
            //
            //
            //

            //Miolos saída:
            //C:\B2B\EDITORA DIALETICA\OUTPUT\MIOLOS\MIOLO 1X1\POLEN_80_21X14
            //C:\B2B\EDITORA DIALETICA\OUTPUT\MIOLOS\MIOLO 1X1\POLEN_80_11X18
            //C:\B2B\EDITORA DIALETICA\OUTPUT\MIOLOS\MIOLO 1X1\OFFSET_120_14X21
            //C:\B2B\EDITORA DIALETICA\OUTPUT\MIOLOS\MIOLO 1X1\OFFSET_90_14X21
            //C:\B2B\EDITORA DIALETICA\OUTPUT\MIOLOS\MIOLO 1X1\OFFSET_75_14X21
            //C:\B2B\EDITORA DIALETICA\OUTPUT\MIOLOS\MIOLO 1X1\COUCHE_FOSCO_150_14X21
            formatoMiolo = formatoMiolo.ToUpper();
            coresMiolo = coresMiolo.ToUpper();
            papelMiolo = papelMiolo.ToUpper();
            gramaturaMiolo = gramaturaMiolo.ToUpper();
            formatoMiolo = formatoMiolo.ToUpper();
            string final = "";

            if (coresMiolo == "1X1")
            {
                switch (papelMiolo)
                {
                    case "POLEN":
                        if(gramaturaMiolo == "80")
                        {
                            if (formatoMiolo == "11X18")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_11X18";
                            }
                            else if (formatoMiolo == "21X14")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14";
                            }
                        }
                        break;
                    case "OFFSET":
                        if (gramaturaMiolo == "75")
                        {
                            if (formatoMiolo == "14X21")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO-OFFSET75_14X21";
                            }
                        }
                        else if (gramaturaMiolo == "90")
                        {
                            if (formatoMiolo == "14X21")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 90\MIOLO_OFFSET90_14X21";
                            }
                        }
                        else if (gramaturaMiolo == "120")
                        {
                            if (formatoMiolo == "14X21")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\OFFSET 120\MIOLO_OFFSET_120_14X21";
                            }
                        }
                        break;
                    case "COUCHE FOSCO":
                        if (gramaturaMiolo == "150")
                        {
                            if(formatoMiolo == "14X21")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\INPUT\MIOLOS\MIOLO 1X1\COUCHE FOSCO 150\MIOLO_COUCHE FOSCO_150_14X21";
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (coresMiolo == "4X4")
            {
                switch (papelMiolo)
                {
                    case "14X21":
                        break;
                    case "11X18":
                        break;
                    default:
                        break;
                }
            }



            
            


            return final;
        }



        public string PegaPastaLoteCapa(string gramatura, string tipo, string formato)
        {
            formato = formato.ToUpper();
            tipo = tipo.ToUpper();
            gramatura = gramatura.ToUpper();

            string final = "";
            switch (formato)
            {
                case "14X21":
                    if (tipo == "FOSCO")
                    {
                        if (gramatura == "300")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 14X21";
                        }
                        else if (gramatura == "250")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 250 FOSCO\CAPA 250 FOSCO 14X21";
                        }
                    }
                    else if (tipo == "BRILHO")
                    {
                        if (gramatura == "300")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 BRILHO\CAPA 300 BRILHO 14X21";
                        }
                        else if (gramatura == "250")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 250 BRILHO\CAPA 250 BRILHO 14X21";
                        }
                    }

                    break;
                case "11X18":
                    if (tipo == "FOSCO")
                    {
                        if (gramatura == "300")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 FOSCO\CAPA 300 FOSCO 11X18";
                        }
                        else if (gramatura == "250")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 250 FOSCO\CAPA 250 FOSCO 11X18";
                        }
                    }
                    else if (tipo == "BRILHO")
                    {
                        if (gramatura == "300")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 300 BRILHO\CAPA 300 BRILHO 11X18";
                        }
                        else if (gramatura == "250")
                        {
                            final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\CAPAS\CAPA 250 BRILHO\CAPA 250 BRILHO 11X18";
                        }
                    }

                    break;
                default:
                    break;
            }


            return final;
        }

        public string PegaPastaLoteMiolo(string coresMiolo, string papelMiolo, string gramaturaMiolo, string formatoMiolo)
        {
            formatoMiolo = formatoMiolo.ToUpper();
            coresMiolo = coresMiolo.ToUpper();
            papelMiolo = papelMiolo.ToUpper();
            gramaturaMiolo = gramaturaMiolo.ToUpper();
            formatoMiolo = formatoMiolo.ToUpper();
            string final = "";

            if (coresMiolo == "1X1")
            {
                switch (papelMiolo)
                {
                    case "POLEN":
                        if (gramaturaMiolo == "80")
                        {
                            if (formatoMiolo == "11X18")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_11X18";
                            }
                            else if (formatoMiolo == "21X14")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14";
                            }
                            else if (formatoMiolo == "14X21")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\POLEN 80\MIOLO_POLEN_80_21X14";
                            }
                        }
                        break;
                    case "OFFSET":
                        if (gramaturaMiolo == "75")
                        {
                            if (formatoMiolo == "14X21")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 75\MIOLO-OFFSET75_14X21";
                            }
                        }
                        else if (gramaturaMiolo == "90")
                        {
                            if (formatoMiolo == "14X21")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 90\MIOLO_OFFSET90_14X21";
                            }
                        }
                        else if (gramaturaMiolo == "120")
                        {
                            if (formatoMiolo == "14X21")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\OFFSET 120\MIOLO_OFFSET_120_14X21";
                            }
                        }
                        break;
                    case "COUCHE FOSCO":
                        if (gramaturaMiolo == "150")
                        {
                            if (formatoMiolo == "14X21")
                            {
                                final = @"C:\B2B\EDITORA DIALETICA\MONTALOTE\MIOLOS\MIOLO 1X1\COUCHE FOSCO 150\MIOLO_COUCHE FOSCO_150_14X21";
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            else if (coresMiolo == "4X4")
            {
                switch (papelMiolo)
                {
                    case "14X21":
                        break;
                    case "11X18":
                        break;
                    default:
                        break;
                }
            }

            return final;
        }

        public ArrayList EncontraArquivo(string caminho, string nomeparcial)
        {
            ArrayList array = new ArrayList();

            string partialName = nomeparcial;

            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(caminho);
            FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*", SearchOption.AllDirectories);

            foreach (FileInfo foundFile in filesInDir)
            {
                if (foundFile.Extension == ".pdf")
                {
                    string fullName = foundFile.FullName;
                    string fileName = foundFile.Name;
                    array.Add(fullName + "|" + fileName);
                    //Console.WriteLine(fullName + "," + fileName);
                }

            }
            return array;
        }


        public void MontaloteCapa(string caminhoraiz, string caminhoHotFolder, int totalLote)
        {

            Geral geral = new Geral();
            //cria pasta lote
            if (!Directory.Exists(caminhoraiz + @"\Lote"))
            {
                Directory.CreateDirectory(caminhoraiz + @"\Lote");
            }

            int totalCapa = Directory.GetFiles(caminhoraiz + @"\Lote", "*.pdf", SearchOption.AllDirectories).Length;

            DirectoryInfo Dir = new DirectoryInfo(caminhoraiz);
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*");
            foreach (FileInfo File in Files)
            {
                string caminhodoarquivocomarquivo = File.FullName;
                string nomePdf = File.Name;
                if (File.Extension == ".pdf")
                {


                    if (totalCapa <= totalLote)
                    {
                        //value e o nome do arquivo, move o arquivo 
                        bool valida = geral.validaArquivoCopiou(caminhodoarquivocomarquivo);
                        if (valida)
                        {
                            System.IO.File.Move(caminhodoarquivocomarquivo, caminhoraiz + @"\Lote\" + nomePdf);
                            totalCapa++;
                        }
                        
                    }
                    else
                    {
                        //manda tudo hotfolder
                        DirectoryInfo DirLote = new DirectoryInfo(caminhoraiz + @"\Lote\");
                        // Busca automaticamente todos os arquivos em todos os subdiretórios
                        FileInfo[] FilesLote = DirLote.GetFiles("*");
                        foreach (FileInfo Filelote in FilesLote)
                        {
                            string caminhodoarquivocomarquivoLote = Filelote.FullName;
                            if (Filelote.Extension == ".pdf")
                            {
                                bool valida = geral.validaArquivoCopiou(caminhodoarquivocomarquivo);
                                if (valida)
                                {
                                    System.IO.File.Move(caminhodoarquivocomarquivoLote, caminhoHotFolder + @"\" + Filelote.Name);
                                }
                                    
                            }
                        }
                        //para o foreach
                        break;

                    }
                    

                }
            }
        }

        public void EnviatudoLote_Capa(string caminhoraiz, string caminhoHotFolder, int totalLote)
        {
            Geral geral = new Geral();
            //cria pasta lote
            if (!Directory.Exists(caminhoraiz + @"\Lote"))
            {
                Directory.CreateDirectory(caminhoraiz + @"\Lote");
            }

           
            //manda tudo hotfolder
            DirectoryInfo DirLoteTudo = new DirectoryInfo(caminhoraiz + @"\Lote\");
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] FilesLoteTudo = DirLoteTudo.GetFiles("*");
            foreach (FileInfo FileloteTudo in FilesLoteTudo)
            {
                string caminhodoarquivocomarquivoLote = FileloteTudo.FullName;
                if (FileloteTudo.Extension == ".pdf")
                {
                    bool valida = geral.validaArquivoCopiou(caminhodoarquivocomarquivoLote);
                    if (valida)
                    {
                        System.IO.File.Move(caminhodoarquivocomarquivoLote, caminhoHotFolder + @"\" + FileloteTudo.Name);
                    }
                                    
                }
            }
                        
        }



        public void MontaLoteMiolo(string caminhoraiz, string caminhoHotFolder, int totalLote)
        {
            Geral geral = new Geral();
            //cria pasta lote
            if (!Directory.Exists(caminhoraiz + @"\Lote"))
            {
                Directory.CreateDirectory(caminhoraiz + @"\Lote");
            }

           

            DirectoryInfo Dir = new DirectoryInfo(caminhoraiz);
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] Files = Dir.GetFiles("*");
            foreach (FileInfo File in Files)
            {
                string caminhodoarquivocomarquivo = File.FullName;
                string nomePdf = File.Name;
                if (File.Extension == ".pdf")
                {

                    int totalMiolo = 0;
                    string[] corta = nomePdf.Split('_', '.');
                    string isbn = corta[3];
                    string paginas = corta[5];
                    string tiragem = corta[7];

                    if (totalMiolo <= totalLote)
                    {
                        //value e o nome do arquivo, move o arquivo 
                        bool valida = geral.validaArquivoCopiou(caminhodoarquivocomarquivo);
                        if (valida)
                        {
                            System.IO.File.Move(caminhodoarquivocomarquivo, caminhoraiz + @"\Lote\" + nomePdf);
                            totalMiolo = totalMiolo + Int16.Parse(paginas);
                        }
                        
                    }
                    else
                    {
                        //manda tudo hotfolder
                        DirectoryInfo DirLote = new DirectoryInfo(caminhoraiz + @"\Lote\");
                        // Busca automaticamente todos os arquivos em todos os subdiretórios
                        FileInfo[] FilesLote = DirLote.GetFiles("*");
                        foreach (FileInfo Filelote in FilesLote)
                        {
                            string caminhodoarquivocomarquivoLote = Filelote.FullName;
                            if (Filelote.Extension == ".pdf")
                            {
                                bool valida = geral.validaArquivoCopiou(caminhodoarquivocomarquivo);
                                if (valida)
                                {
                                    System.IO.File.Move(caminhodoarquivocomarquivoLote, caminhoHotFolder + @"\" + Filelote.Name);
                                }
                                    
                            }
                        }
                        //para o foreach
                        break;

                    }


                }
            }
        }

        public void EnviatudoLote_Miolo(string caminhoraiz, string caminhoHotFolder, int totalLote)
        {
            Geral geral = new Geral();
            //cria pasta lote
            if (!Directory.Exists(caminhoraiz + @"\Lote"))
            {
                Directory.CreateDirectory(caminhoraiz + @"\Lote");
            }

  
            //manda tudo hotfolder
            DirectoryInfo DirLote = new DirectoryInfo(caminhoraiz + @"\Lote\");
            // Busca automaticamente todos os arquivos em todos os subdiretórios
            FileInfo[] FilesLote = DirLote.GetFiles("*");
            foreach (FileInfo Filelote in FilesLote)
            {
                string caminhodoarquivocomarquivoLote = Filelote.FullName;
                if (Filelote.Extension == ".pdf")
                {
                    bool valida = geral.validaArquivoCopiou(caminhodoarquivocomarquivoLote);
                    if (valida)
                    {
                        System.IO.File.Move(caminhodoarquivocomarquivoLote, caminhoHotFolder + @"\" + Filelote.Name);
                    }
                    
                }
            }
            //para o foreach
                    


                
        }




        //CEDET


        public string PegaPastaCapaCEDET(string gramatura, string tipo, string formato, string cores)
        {

            formato = formato.ToUpper().Trim();
            tipo = tipo.ToUpper().Trim();
            gramatura = gramatura.ToUpper().Trim();


            string final = "";
            //brilho
            if (tipo == "BRILHO")
            {
                if(gramatura == "250")
                {
                    switch (formato)
                    {
                        case "155X230":
                            if(cores.ToUpper().Trim() == "4X0")
                            {
                                final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\250GRS\CAPA_155X230_BRILHO250";
                            }
                            else
                            {
                                final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\250GRS\CAPA_155X230_BRILHO250_4X4";
                            }
                            break;
                        case "105X148":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\250GRS\CAPA_155X230_BRILHO250";
                            break;
                        case "110X180":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\250GRS\CAPA_155X230_BRILHO250";
                            break;
                        case "115X175":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\250GRS\CAPA_155X230_BRILHO250";
                            break;
                        case "137X210":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\250GRS\CAPA_155X230_BRILHO250";
                            break;
                        case "140X210":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\250GRS\CAPA_155X230_BRILHO250";
                            break;
                        case "170X240":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\250GRS\CAPA_170X240_BRILHO250";
                            break;

                        case "190X230":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\250GRS\CAPA_190X230_BRILHO250";
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    switch (formato)
                    {
                        case "155X230":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\300GRS\CAPA_155X230X230_BRILHO300";
                            break;
                        case "105X148":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\300GRS\CAPA_155X230X230_BRILHO300";
                            break;
                        case "110X180":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\300GRS\CAPA_155X230X230_BRILHO300";
                            break;
                        case "115X175":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\300GRS\CAPA_155X230X230_BRILHO300";
                            break;
                        case "137X210":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\300GRS\CAPA_155X230X230_BRILHO300";
                            break;
                        case "140X210":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\300GRS\CAPA_155X230X230_BRILHO300";
                            break;

                        case "170X240":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\300GRS\CAPA_170X240_BRILHO300";
                            break;

                        case "190X230":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS BRILHO\300GRS\CAPA_190X230_BRILHO300";
                            break;

                        default:
                            break;
                    }
                }
            }
            //fosco
            else
            {
                if (gramatura == "250")
                {
                    switch (formato)
                    {
                        case "155X230":
                            if (cores.ToUpper().Trim() == "4X0")
                            {
                                final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\250GRS\CAPA_155X230_FOSCO250";
                            }
                            else
                            {
                                final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\250GRS\CAPA_155X230_FOSCO250_4X4";
                            }
                            break;
                        case "105X148":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\250GRS\CAPA_155X230_FOSCO250";
                            break;
                        case "110X180":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\250GRS\CAPA_155X230_FOSCO250";
                            break;
                        case "115X175":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\250GRS\CAPA_155X230_FOSCO250";
                            break;
                        case "137X210":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\250GRS\CAPA_155X230_FOSCO250";
                            break;
                        case "140X210":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\250GRS\CAPA_155X230_FOSCO250";
                            break;

                        case "170X240":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\250GRS\CAPA_170X240_FOSCO250";
                            break;

                        case "190X230":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\250GRS\CAPA_190X230_FOSCO250";
                            break;

                        default:
                            break;
                    }
                }
                else
                {
                    switch (formato)
                    {
                        case "155X230":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\300GRS\CAPA_155X230_FOSCO";
                            break;
                        case "105X148":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\300GRS\CAPA_155X230_FOSCO";
                            break;
                        case "110X180":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\300GRS\CAPA_155X230_FOSCO";
                            break;
                        case "115X175":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\300GRS\CAPA_155X230_FOSCO";
                            break;
                        case "137X210":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\300GRS\CAPA_155X230_FOSCO";
                            break;
                        case "140X210":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\300GRS\CAPA_155X230_FOSCO";
                            break;

                        case "170X240":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\300GRS\CAPA_170X240_FOSCO300";
                            break;

                        case "190X230":
                            final = @"C:\B2B\B2B INTERNO\CAPAS\CAPAS FOSCO\300GRS\CAPA_190X230_FOSCO300";
                            break;

                        default:
                            break;
                    }
                }
            }


            return final;
        }

        public string PegaPastaMioloCEDET(string coresMiolo, string formatoMiolo)
        {


            formatoMiolo = formatoMiolo.ToUpper().Trim();
            coresMiolo = coresMiolo.ToUpper().Trim();
            formatoMiolo = formatoMiolo.ToUpper().Trim();


            string final = "";

            if (coresMiolo == "1X1")
            {
                switch (formatoMiolo)
                {
                    case "105X148":
                        final = @"C:\B2B\B2B INTERNO\MIOLOS\MIOLO 1 COR\MIOLO_1_COR_105X148";
                        break;

                    case "110X180":
                        final = @"C:\B2B\B2B INTERNO\MIOLOS\MIOLO 1 COR\MIOLO_1_COR_110X180";
                        break;

                    case "115X175":
                        final = @"C:\B2B\B2B INTERNO\MIOLOS\MIOLO 1 COR\MIOLO_1_COR_115X175";
                        break;
                    case "137X210":
                        final = @"C:\B2B\B2B INTERNO\MIOLOS\MIOLO 1 COR\MIOLO_1_COR_137X210";
                        break;
                    case "140X210":
                        final = @"C:\B2B\B2B INTERNO\MIOLOS\MIOLO 1 COR\MIOLO_1_COR_140X210";
                        break;
                    case "155X230":
                        final = @"C:\B2B\B2B INTERNO\MIOLOS\MIOLO 1 COR\MIOLO_1_COR_155X230";
                        break;
                    case "170X240":
                        final = @"C:\B2B\B2B INTERNO\MIOLOS\MIOLO 1 COR\MIOLO_1_COR_170X240";
                        break;
                    case "190X230":
                        final = @"C:\B2B\B2B INTERNO\MIOLOS\MIOLO 1 COR\MIOLO_1_COR_190X230";
                        break;

                    default:
                        break;
                }
            }
            else if (coresMiolo == "4X4")
            {
               
            }







            return final;
        }





    }
}
