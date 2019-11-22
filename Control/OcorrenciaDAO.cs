using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control
{
    public class OcorrenciaDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Ocorrencia> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM ocorrencia";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Ocorrencia");

                        List<Model.Ocorrencia> lstRetorno = ds.Tables["Ocorrencia"].AsEnumerable().Select(x => new Model.Ocorrencia
                        {
                            Id = x.Field<int>("id"),
                            Descricao = x.Field<string>("descricao"),
                            TipoOcorrenciaId = x.Field<int>("idTipoOcorrencia")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Ocorrencia ocorrencia)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (ocorrencia.Id == 0)
                        cmd.CommandText = @"INSERT INTO ocorrencia
                                                (descricao)
                                            VALUES
                                                (?descricao);";
                    else
                        cmd.CommandText = @"UPDATE ocorrencia 
                                                SET descricao = ?descricao
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?descricao", ocorrencia.Descricao);
                    cmd.Parameters.AddWithValue("?id", ocorrencia.Id);

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
                    cmd.CommandText = @"DELETE FROM ocorrencia WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Ocorrencia BuscarPorId(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM ocorrencia WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", clienteId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Ocorrencia retorno = new Model.Ocorrencia();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Descricao = (string)reader["descricao"];
                    }

                    return retorno;
                }
            }
        }
    }
}
