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
    public class VisitaDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Visita> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM visita";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Visita");

                        List<Model.Visita> lstRetorno = ds.Tables["Visita"].AsEnumerable().Select(x => new Model.Visita
                        {
                            Id = x.Field<int>("id"),
                            CondominoId = x.Field<int>("idCondomino"),
                            VisitanteId = x.Field<int>("idVisitante"),
                            DataVisita = x.Field<DateTime>("datavisita"),
                            HoraEntrada = x.Field<TimeSpan>("horaEntrada"),
                            HoraSaida = x.Field<TimeSpan>("horaSaida")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Visita visita)
        {
            DateTime dt = DateTime.Now;

            visita.DataVisita = dt;
            visita.HoraEntrada = new TimeSpan(dt.Hour, dt.Minute, dt.Second);

            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (visita.Id == 0)
                        cmd.CommandText = @"INSERT INTO visita (idCondomino, idVisitante, datavisita, horaEntrada, horaSaida) VALUES (?idCondomino, ?idVisitante, ?datavisita, ?horaEntrada, ?horaSaida);";
                    else
                        cmd.CommandText = @"UPDATE visita 
                                                SET idCondomino = ?idCondomino,
                                                    idVisitante = ?idVisitante,
                                                    datavisita = ?datavisita,
                                                    horaEntrada = ?horaEntrada,
                                                    horaSaida = ?horaSaida
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?idCondomino", visita.CondominoId);
                    cmd.Parameters.AddWithValue("?idVisitante", visita.VisitanteId);
                    cmd.Parameters.AddWithValue("?datavisita", visita.DataVisita);
                    cmd.Parameters.AddWithValue("?horaEntrada", visita.HoraEntrada);
                    cmd.Parameters.AddWithValue("?horaSaida", visita.HoraSaida);
                    cmd.Parameters.AddWithValue("?id", visita.Id);

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
                    cmd.CommandText = @"DELETE FROM visita WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Visita BuscarPorId(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM visita WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", clienteId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Visita retorno = new Model.Visita();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.CondominoId = (int)reader["idCondomino"];
                        retorno.VisitanteId = (int)reader["idVisitante"];
                        retorno.DataVisita = (DateTime)reader["datavisita"];
                        retorno.HoraEntrada = (TimeSpan)reader["horaEntrada"];
                        retorno.HoraSaida = (TimeSpan)reader["horaSaida"];
                    }

                    return retorno;
                }
            }
        }
    }
}
