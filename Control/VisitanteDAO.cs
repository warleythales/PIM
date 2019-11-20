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
    public class VisitanteDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Visitante> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM visitante";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Visitante");

                        List<Model.Visitante> lstRetorno = ds.Tables["Visitante"].AsEnumerable().Select(x => new Model.Visitante
                        {
                            Id = x.Field<int>("id"),
                            CPF = x.Field<string>("cpf"),
                            Email = x.Field<string>("email"),
                            Nome = x.Field<string>("nome"),
                            RG = x.Field<string>("rg"),
                            Telefone = x.Field<string>("telefone")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Visitante visitante)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (visitante.Id == 0)
                        cmd.CommandText = @"INSERT INTO visitante (cpf, email, nome, rg, telefone) VALUES (?cpf, ?email, ?nome, ?rg, ?telefone);";
                    else
                        cmd.CommandText = @"UPDATE visitante 
                                                SET cpf = ?cpf,
                                                    email = ?email,
                                                    nome = ?nome,
                                                    rg = ?rg,
                                                    telefone = ?telefone
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?cpf", visitante.CPF);
                    cmd.Parameters.AddWithValue("?email", visitante.Email);
                    cmd.Parameters.AddWithValue("?nome", visitante.Nome);
                    cmd.Parameters.AddWithValue("?rg", visitante.RG);
                    cmd.Parameters.AddWithValue("?telefone", visitante.Telefone);
                    cmd.Parameters.AddWithValue("?id", visitante.Id);

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
                    cmd.CommandText = @"DELETE FROM visitante WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Visitante BuscarPorId(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM visitante WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", clienteId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Visitante retorno = new Model.Visitante();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.CPF = (string)reader["cpf"];
                        retorno.Email = (string)reader["email"];
                        retorno.Nome = (string)reader["nome"];
                        retorno.RG = (string)reader["rg"];
                        retorno.Telefone = (string)reader["telefone"];
                    }

                    return retorno;
                }
            }
        }
    }
}
