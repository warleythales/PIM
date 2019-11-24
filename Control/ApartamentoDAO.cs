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
    public class ApartamentoDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Apartamento> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM apartamento";

                    MySqlDataReader reader = cmd.ExecuteReader();

                    List<Model.Apartamento> listRetorno = new List<Model.Apartamento>();

                    while (reader.Read())
                    {
                        Model.Apartamento apartamento = new Model.Apartamento();

                        apartamento.Id = (int)reader["Id"];
                        apartamento.Numero = (int)reader["numero"];
                        apartamento.QtdQuartos = (int)reader["qtdQuartos"];
                        apartamento.QtdMoradores = (int)reader["qtdMoradores"];
                        apartamento.Disponivel = reader.GetByte("disponivel") >= 1 ? true : false;
                        apartamento.Tipo = (string)reader["tipo"];
                        apartamento.IdTorre = (int)reader["idTorre"];

                        listRetorno.Add(apartamento);
                    }

                    return listRetorno;
                }
            }
        }

        public static void Salvar(Model.Apartamento apartamento)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (apartamento.Id == 0)
                        cmd.CommandText = @"INSERT INTO apartamento
                                                (numero, qtdQuartos, qtdMoradores, disponivel, tipo, idTorre)
                                            VALUES
                                                (?numero, ?qtdQuartos, ?qtdMoradores, ?disponivel, ?tipo, ?idTorre);";
                    else
                        cmd.CommandText = @"UPDATE apartamento 
                                                SET numero = ?numero,
                                                    qtdQuartos = ?qtdQuartos,
                                                    qtdMoradores = ?qtdMoradores,
                                                    disponivel = ?disponivel,
                                                    tipo = ?tipo,
                                                    idTorre = ?idTorre
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?numero", apartamento.Numero);
                    cmd.Parameters.AddWithValue("?qtdQuartos", apartamento.QtdQuartos);
                    cmd.Parameters.AddWithValue("?qtdMoradores", apartamento.QtdMoradores);
                    cmd.Parameters.AddWithValue("?disponivel", apartamento.Disponivel);
                    cmd.Parameters.AddWithValue("?tipo", string.IsNullOrEmpty(apartamento.Tipo) ? "Tipo" : apartamento.Tipo);
                    cmd.Parameters.AddWithValue("?idTorre", apartamento.IdTorre);
                    cmd.Parameters.AddWithValue("?id", apartamento.Id);

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
                    cmd.CommandText = @"DELETE FROM apartamento WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Apartamento BuscarPorId(int apartamentoId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM apartamento WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", apartamentoId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Apartamento retorno = new Model.Apartamento();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Numero = (int)reader["numero"];
                        retorno.QtdQuartos = (int)reader["qtdQuartos"];
                        retorno.QtdMoradores = (int)reader["qtdMoradores"];
                        retorno.Disponivel = reader.GetByte("disponivel") >= 1 ? true : false;
                        retorno.Tipo = (string)reader["tipo"];
                        retorno.IdTorre = (int)reader["idTorre"];                        
                    }

                    return retorno;
                }
            }
        }
    }
}
