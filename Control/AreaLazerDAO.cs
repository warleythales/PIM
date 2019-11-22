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
    public class AreaLazerDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.AreaLazer> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM areaLazer";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "AreaLazer");

                        List<Model.AreaLazer> lstRetorno = ds.Tables["AreaLazer"].AsEnumerable().Select(x => new Model.AreaLazer
                        {
                            Id = x.Field<int>("id"),
                            Descricao = x.Field<string>("descricao"),
                            CapacidadePessoas = x.Field<int>("capacidadePessoas"),
                            Visitante = x.Field<bool>("visitante"),
                            Aluguel = x.Field<bool>("aluguel"),
                            Status = x.Field<string>("status"),
                            IdTorre = x.Field<int>("idTorre")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.AreaLazer areaLazer)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (areaLazer.Id == 0)
                        cmd.CommandText = @"INSERT INTO areaLazer
                                                (descricao, capacidadePessoas, visitante, aluguel, status, idTorre)
                                            VALUES
                                                (?descricao, ?capacidadePessoas, ?visitante, ?aluguel, ?status, ?idTorre);";
                    else
                        cmd.CommandText = @"UPDATE areaLazer 
                                                SET descricao = ?descricao,
                                                    capacidadePessoas = ?capacidadePessoas,
                                                    visitante = ?visitante,
                                                    aluguel = ?aluguel,
                                                    status = ?status,
                                                    idTorre = ?idTorre
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?descricao", areaLazer.Descricao);
                    cmd.Parameters.AddWithValue("?capacidadePessoas", areaLazer.CapacidadePessoas);
                    cmd.Parameters.AddWithValue("?visitante", areaLazer.Visitante);
                    cmd.Parameters.AddWithValue("?aluguel", areaLazer.Aluguel);
                    cmd.Parameters.AddWithValue("?status", areaLazer.Status);
                    cmd.Parameters.AddWithValue("?idTorre", areaLazer.IdTorre);
                    cmd.Parameters.AddWithValue("?id", areaLazer.Id);

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
                    cmd.CommandText = @"DELETE FROM areaLazer WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.AreaLazer BuscarPorId(int areaLazerId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM areaLazer WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", areaLazerId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.AreaLazer retorno = new Model.AreaLazer();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Descricao = (string)reader["descricao"];
                        retorno.CapacidadePessoas = (int)reader["capacidadePessoas"];
                        retorno.Visitante = (bool)reader["visitante"];
                        retorno.Aluguel = (bool)reader["aluguel"];
                        retorno.Status = (string)reader["status"];
                        retorno.IdTorre = (int)reader["idTorre"];
                    }

                    return retorno;
                }
            }
        }
    }
}
