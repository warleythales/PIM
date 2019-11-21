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
    public class TipoOcorrenciaDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.TipoOcorrencia> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM tipoOcorrencia";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "TipoOcorrencia");

                        List<Model.TipoOcorrencia> lstRetorno = ds.Tables["TipoOcorrencia"].AsEnumerable().Select(x => new Model.TipoOcorrencia
                        {
                            Id = x.Field<int>("id"),
                            Descricao = x.Field<string>("descricao")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.TipoOcorrencia tipoOcorrencia)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (tipoOcorrencia.Id == 0)
                        cmd.CommandText = @"INSERT INTO tipoOcorrencia
                                                (descricao)
                                            VALUES
                                                (?descricao);";
                    else
                        cmd.CommandText = @"UPDATE tipoOcorrencia 
                                                SET descricao = ?descricao
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?descricao", tipoOcorrencia.Descricao);
                    cmd.Parameters.AddWithValue("?id", tipoOcorrencia.Id);

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
                    cmd.CommandText = @"DELETE FROM tipoOcorrencia WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.TipoOcorrencia BuscarPorId(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM tipoOcorrencia WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", clienteId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.TipoOcorrencia retorno = new Model.TipoOcorrencia();

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
