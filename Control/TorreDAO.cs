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
    public class TorreDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Torre> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM torre";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Torre");

                        List<Model.Torre> lstRetorno = ds.Tables["Torre"].AsEnumerable().Select(x => new Model.Torre
                        {
                            Id = x.Field<int>("id"),
                            Descricao = x.Field<string>("descricao"),
                            Academia = x.Field<bool>("academia"),
                            CondominioId = x.Field<int>("idCondominio"),
                            Pavimentos = x.Field<int>("pavimentos"),
                            SalaoFesta = x.Field<bool>("SalaoDeFesta"),
                            Vagas = x.Field<int>("vagas"),
                            Status = x.Field<bool>("status")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Torre torre)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (torre.Id == 0)
                        cmd.CommandText = @"INSERT INTO torre
                                                (descricao, pavimentos, vagas, academia, SalaoDeFesta, status, idCondominio)
                                            VALUES
                                                (?descricao, ?pavimentos, ?vagas, ?academia, ?SalaoDeFesta, ?status, ?idCondominio);";
                    else
                        cmd.CommandText = @"UPDATE torre 
                                                SET descricao = ?descricao,
                                                    pavimentos = ?pavimentos,
                                                    vagas = ?vagas,
                                                    academia = ?academia,
                                                    SalaoDeFesta = ?SalaoDeFesta,
                                                    status = ?status,
                                                    idCondominio = ?idCondominio
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?descricao", torre.Descricao);
                    cmd.Parameters.AddWithValue("?pavimentos", torre.Pavimentos);
                    cmd.Parameters.AddWithValue("?vagas", torre.Vagas);
                    cmd.Parameters.AddWithValue("?academia", torre.Academia);
                    cmd.Parameters.AddWithValue("?SalaoDeFesta", torre.SalaoFesta);
                    cmd.Parameters.AddWithValue("?status", torre.Status);
                    cmd.Parameters.AddWithValue("?idCondominio", torre.CondominioId);
                    cmd.Parameters.AddWithValue("?id", torre.Id);

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
                    cmd.CommandText = @"DELETE FROM torre WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Torre BuscarPorId(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM torre WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", clienteId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Torre retorno = new Model.Torre();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Descricao = (string)reader["descricao"];
                        retorno.Academia = (bool)reader["academia"];
                        retorno.CondominioId = (int)reader["idCondominio"];
                        retorno.Pavimentos = (int)reader["pavimentos"];
                        retorno.SalaoFesta = (bool)reader["SalaoDeFesta"];
                        retorno.Vagas = (int)reader["vagas"];
                        retorno.Status = (bool)reader["status"];
                    }

                    return retorno;
                }
            }
        }
    }
}
