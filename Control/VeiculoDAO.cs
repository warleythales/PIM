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
    public class VeiculoDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Veiculo> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM veiculo";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Veiculo");

                        List<Model.Veiculo> lstRetorno = ds.Tables["Veiculo"].AsEnumerable().Select(x => new Model.Veiculo
                        {
                            Id = x.Field<int>("id"),
                            Ano = x.Field<string>("ano"),
                            Marca = x.Field<string>("marca"),
                            CondominoId = x.Field<int>("idCondomino"),
                            VisitanteId = x.Field<int>("idVisitante"),
                            Modelo = x.Field<string>("modelo"),
                            Placa = x.Field<string>("placa")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Veiculo veiculo)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (veiculo.Id == 0)
                        cmd.CommandText = @"INSERT INTO veiculo
                                                (ano, marca, idVisitante, modelo, placa, idCondomino)
                                            VALUES
                                                (?ano, ?marca, ?idVisitante, ?modelo, ?placa, ?idCondomino);";
                    else
                        cmd.CommandText = @"UPDATE veiculo 
                                                SET ano = ?ano,
                                                    marca = ?marca,
                                                    idVisitante = ?idVisitante,
                                                    modelo = ?modelo,
                                                    placa = ?placa,
                                                    idCondomino = ?idCondomino
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?ano", veiculo.Ano);
                    cmd.Parameters.AddWithValue("?marca", veiculo.Marca);
                    cmd.Parameters.AddWithValue("?idVisitante", veiculo.VisitanteId);
                    cmd.Parameters.AddWithValue("?modelo", veiculo.Modelo);
                    cmd.Parameters.AddWithValue("?placa", veiculo.Placa);
                    cmd.Parameters.AddWithValue("?idCondomino", veiculo.CondominoId);
                    cmd.Parameters.AddWithValue("?id", veiculo.Id);

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
                    cmd.CommandText = @"DELETE FROM veiculo WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Veiculo BuscarPorId(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM veiculo WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", clienteId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Veiculo retorno = new Model.Veiculo();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Ano = (string)reader["ano"];
                        retorno.VisitanteId = (int)reader["idVisitante"];
                        retorno.CondominoId = (int)reader["idCondomino"];
                        retorno.Marca = (string)reader["marca"];
                        retorno.Modelo = (string)reader["modelo"];
                        retorno.Placa = (string)reader["placa"];
                    }

                    return retorno;
                }
            }
        }
    }
}
