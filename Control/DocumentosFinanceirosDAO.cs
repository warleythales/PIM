using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enumerados;

namespace Control
{
    public class DocumentosFinanceirosDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.DocumentosFinanceiros> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM documentosFinanceiros";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "DocumentosFinanceiros");

                        List<Model.DocumentosFinanceiros> lstRetorno = ds.Tables["DocumentosFinanceiros"].AsEnumerable().Select(x => new Model.DocumentosFinanceiros
                        {
                            Id = x.Field<int>("id"),
                            Nome = x.Field<string>("nome"),
                            Valor = x.Field<double>("valor"),
                            Tipo = (TipoDocumento)x.Field<int>("tipo"),
                            DataEmissao = x.Field<DateTime>("dataEmissao"),
                            DataVencimento = x.Field<DateTime>("dataVencimento"),
                            ContaBancaria = x.Field<string>("contaBancaria"),
                            IdCondominio = x.Field<int>("idCondominio")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.DocumentosFinanceiros documentosFinanceiros)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (documentosFinanceiros.Id == 0)
                        cmd.CommandText = @"INSERT INTO documentosFinanceiros
                                                (nome, valor, tipo, dataEmissao, dataVencimento, contaBancaria, idCondominio)
                                            VALUES
                                                (?nome, ?valor, ?tipo ?dataEmissao, ?dataVencimento, ?contaBancaria, ?idCondominio);";
                    else
                        cmd.CommandText = @"UPDATE documentosFinanceiros 
                                                SET nome = ?nome,
                                                    valor = ?valor,
                                                    tipo = ?tipo,
                                                    dataEmissao = ?dataEmissao,
                                                    dataVencimento = ?dataVencimento,
                                                    contaBancaria = ?contaBancaria,
                                                    idCondominio = ?idCondominio
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?nome", documentosFinanceiros.Nome);
                    cmd.Parameters.AddWithValue("?valor", documentosFinanceiros.Valor);
                    cmd.Parameters.AddWithValue("?tipo", documentosFinanceiros.Tipo);
                    cmd.Parameters.AddWithValue("?dataEmissao", documentosFinanceiros.DataEmissao);
                    cmd.Parameters.AddWithValue("?dataVencimento", documentosFinanceiros.DataVencimento);
                    cmd.Parameters.AddWithValue("?contaBancaria", documentosFinanceiros.ContaBancaria);
                    cmd.Parameters.AddWithValue("?idCondominio", documentosFinanceiros.IdCondominio);
                    cmd.Parameters.AddWithValue("?id", documentosFinanceiros.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Excluir(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"DELETE FROM documentosFinanceiros WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.DocumentosFinanceiros BuscarPorId(int documentosFinanceirosId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM documentosFinanceiros WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", documentosFinanceirosId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.DocumentosFinanceiros retorno = new Model.DocumentosFinanceiros();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Nome = (string)reader["nome"];
                        retorno.Valor = (double)reader["valor"];
                        retorno.Tipo = (TipoDocumento)reader["tipo"];
                        retorno.DataEmissao = (DateTime)reader["dataEmissao"];
                        retorno.DataVencimento = (DateTime)reader["dataVencimento"];
                        retorno.ContaBancaria = (string)reader["contaBancaria"];
                        retorno.IdCondominio = (int)reader["idCondominio"];
                    }

                    return retorno;
                }
            }
        }
    }
}
