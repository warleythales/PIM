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
    public class ReuniaoDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Reuniao> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM reuniao";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Reuniao");

                        List<Model.Reuniao> lstRetorno = ds.Tables["Reuniao"].AsEnumerable().Select(x => new Model.Reuniao
                        {
                            Id = x.Field<int>("id"),
                            Assunto = x.Field<string>("assunto"),
                            DataHora = x.Field<DateTime>("dataHora"),
                            CondominioId = x.Field<int>("idCondominio"),
                            Local = x.Field<string>("local"),
                            Situacao = (SituacaoReuniao)x.Field<int>("situacao")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Reuniao reuniao)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (reuniao.Id == 0)
                        cmd.CommandText = @"INSERT INTO reuniao
                                                (assunto, dataHora, local, situacao, idCondominio)
                                            VALUES
                                                (?assunto, ?dataHora, ?local, ?situacao, ?idCondominio);";
                    else
                        cmd.CommandText = @"UPDATE reuniao 
                                                SET assunto = ?assunto,
                                                    dataHora = ?dataHora,
                                                    local = ?local,
                                                    situacao = ?situacao,
                                                    idCondominio = ?idCondominio
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?assunto", reuniao.Assunto);
                    cmd.Parameters.AddWithValue("?dataHora", reuniao.DataHora);
                    cmd.Parameters.AddWithValue("?local", reuniao.Local);
                    cmd.Parameters.AddWithValue("?situacao", (int)reuniao.Situacao);
                    cmd.Parameters.AddWithValue("?idCondominio", reuniao.CondominioId);
                    cmd.Parameters.AddWithValue("?id", reuniao.Id);

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
                    cmd.CommandText = @"DELETE FROM reuniao WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Reuniao BuscarPorId(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM reuniao WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", clienteId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Reuniao retorno = new Model.Reuniao();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Assunto = (string)reader["assunto"];
                        retorno.Situacao = (SituacaoReuniao)reader["situacao"];
                        retorno.CondominioId = (int)reader["idCondominio"];
                        retorno.DataHora = (DateTime)reader["dataHora"];
                        retorno.Local = (string)reader["local"];
                    }

                    return retorno;
                }
            }
        }
    }
}
