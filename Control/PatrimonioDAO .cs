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
    public class PatrimonioDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Patrimonio> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM patrimonio";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Patrimonio");

                        List<Model.Patrimonio> lstRetorno = ds.Tables["Patrimonio"].AsEnumerable().Select(x => new Model.Patrimonio
                        {
                            Id = x.Field<int>("id"),
                            Descricao = x.Field<string>("descricao"),
                            EmManutecao = x.Field<bool>("emManutencao"),
                            Local = x.Field<string>("local"),
                            Tipo = x.Field<string>("tipo"),
                            TorreId = x.Field<int>("idTorre")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Patrimonio patrimonio)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (patrimonio.Id == 0)
                        cmd.CommandText = @"INSERT INTO patrimonio
                                                (descricao, emManutencao, local, tipo, idTorre)
                                            VALUES
                                                (?descricao, ?emManutencao, ?local, ?tipo, ?idTorre);";
                    else
                        cmd.CommandText = @"UPDATE patrimonio 
                                                SET descricao = ?descricao,
                                                    emManutencao = ?emManutencao,
                                                    local = ?local,
                                                    tipo = ?tipo,
                                                    idTorre = ?idTorre,
                                                    status = ?status,
                                                    idCondominio = ?idCondominio
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?descricao", patrimonio.Descricao);
                    cmd.Parameters.AddWithValue("?emManutencao", patrimonio.EmManutecao);
                    cmd.Parameters.AddWithValue("?local", patrimonio.Local);
                    cmd.Parameters.AddWithValue("?tipo", patrimonio.Tipo);
                    cmd.Parameters.AddWithValue("?idTorre", patrimonio.TorreId);
                    cmd.Parameters.AddWithValue("?id", patrimonio.Id);

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
                    cmd.CommandText = @"DELETE FROM patrimonio WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Patrimonio BuscarPorId(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM patrimonio WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", clienteId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Patrimonio retorno = new Model.Patrimonio();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Descricao = (string)reader["descricao"];
                        retorno.Tipo = (string)reader["tipo"];
                        retorno.EmManutecao = (bool)reader["emManutencao"];
                        retorno.TorreId = (int)reader["idTorre"];
                        retorno.Local = (string)reader["local"];
                    }

                    return retorno;
                }
            }
        }
    }
}
