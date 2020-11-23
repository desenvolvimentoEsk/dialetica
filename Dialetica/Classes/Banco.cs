using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dialetica.Classes
{
    class Banco
    {
        public ArrayList PegaDadosApi()
        {
            ArrayList lista = new ArrayList();
            //Aqui você substitui pelos seus dados
            var connString = "Server=sistema.graficaeskenazi.com.br;Database=sis3;Uid=waldir;Pwd=w1b2n310";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM `DadosApi` WHERE status = 'Pedido Recebido'";
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                   
                    lista.Add(
                        reader.GetString("nomedialetica") + "|" + 
                        reader.GetString("codproduto") + "|" + 
                        reader.GetString("tipodeproduto") + "|" + 
                        reader.GetString("numpedido") + "|" +
                        reader.GetString("numitem") + "|" +
                        reader.GetString("isbn") + "|" +
                        reader.GetString("titulodolivro") + "|" +
                        reader.GetString("subtitulo") + "|" +
                        reader.GetString("editoraSelo") + "|" +
                        reader.GetString("tiragem") + "|" +
                        reader.GetString("papelcapa") + "|" +
                        reader.GetString("gramaturacapa") + "|" +
                        reader.GetString("corescapa") + "|" +
                        reader.GetString("formatoabertocapa") + "|" +
                        reader.GetString("formatodalombada") + "|" +
                        reader.GetString("medidadaorelha") + "|" +
                        reader.GetString("acabamentocapa") + "|" +
                        reader.GetString("papelmiolo") + "|" +
                        reader.GetString("gramaturamiolo") + "|" +
                        reader.GetString("coresmiolo") + "|" + 
                        reader.GetString("formatomiolo") + "|" +
                        reader.GetString("paginasmiolototal") + "|" +
                        reader.GetString("paginasmiolopb") + "|" +
                        reader.GetString("paginasmiolocor") + "|" +
                        reader.GetString("acabamentolivro") + "|" +
                        reader.GetString("embalagemdolivro") + "|" +
                        reader.GetString("precounitdolivro") + "|" +
                        reader.GetString("tiragemmarcador") + "|" +
                        reader.GetString("datapedido") + "|" +
                        reader.GetString("data") + "|" +
                        reader.GetString("status") + "|" +
                        reader.GetString("id")
                    );
                }



            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();

                }


            }
            return lista;
        }

        public bool atualizaStatus(string id)
        {
            bool retorno = false;

            //Aqui você substitui pelos seus dados
            var connString = "Server=sistema.graficaeskenazi.com.br;Database=sis3;Uid=waldir;Pwd=w1b2n310";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            try
            {
                connection.Open();
                command.CommandText = "UPDATE DadosApi SET status = 'Pedido enviado para impressao' WHERE id = "+ id + "";
                command.ExecuteNonQuery();
                retorno = true;

            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();

                }


            }

            return retorno;
        }

        public ArrayList PegaDadosCedet()
        {
            //
            ArrayList lista = new ArrayList();
            //Aqui você substitui pelos seus dados
            var connString = "Server=sistema.graficaeskenazi.com.br;Database=sis3;Uid=waldir;Pwd=w1b2n310";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            try
            {
                connection.Open();
                command.CommandText = "SELECT * FROM `Importaxls` WHERE nome_cliente = 'CEDET' AND downaload = 'nao' ORDER BY id DESC";
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString("nome_cliente"));
                    lista.Add(
                        reader.GetString("nome_cliente") + "|" +
                        reader.GetString("nome_do_trabalho") + "|" +
                        "codigo_cliente" + "|" +
                        reader.GetString("codigo_isbn") + "|" +
                        reader.GetString("valor_unitario") + "|" +
                        reader.GetString("quantidade") + "|" +
                        reader.GetString("formato_final_fechado_do_miolo") + "|" +
                        reader.GetString("papel_capa") + "|" +
                        reader.GetString("cores_capa") + "|" +
                        reader.GetString("orelha_da_capa") + "|" +
                        reader.GetString("acabamento_capa") + "|" +
                        reader.GetString("papel_miolo") + "|" +
                        reader.GetString("cores_miolo") + "|" +
                        reader.GetString("miolo_sangrado") + "|" +
                        reader.GetString("quantidade_paginas_miolo") + "|" +
                        reader.GetString("acabamento_miolo") + "|" +
                        reader.GetString("acabamento_livro") + "|" +
                        reader.GetString("shrink") + "|" +
                        reader.GetString("papel_fornecido") + "|" +
                        reader.GetString("vendedor") + "|" +
                        reader.GetString("data") + "|" +
                        reader.GetString("usuario") + "|" +
                        reader.GetString("feito") + "|" +
                        reader.GetString("cliente") + "|" +
                        reader.GetString("prazo") + "|" +
                        reader.GetString("downaload") + "|" +
                        reader.GetString("id")
                    );
                }



            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();

                }


            }
            return lista;
        }

        public bool atualizaDownloadCedet(string id,string status)
        {
            bool retorno = false;

            //Aqui você substitui pelos seus dados
            var connString = "Server=sistema.graficaeskenazi.com.br;Database=sis3;Uid=waldir;Pwd=w1b2n310";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            try
            {
                connection.Open();
                command.CommandText = "UPDATE Importaxls SET downaload = '" + status + "' WHERE id = " + id + "";
                command.ExecuteNonQuery();
                retorno = true;

            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();

                }


            }

            return retorno;
        }
    }
}
