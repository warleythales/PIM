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
    public class CondominoDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Condomino> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM condomino";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Condomino");

                        List<Model.Condomino> lstRetorno = ds.Tables["Condomino"].AsEnumerable().Select(x => new Model.Condomino
                        {
                            Id = x.Field<int>("id"),
                            Nome = x.Field<string>("nome"),
                            CPF = x.Field<string>("cpf"),
                            RG = x.Field<string>("rg"),
                            Telefone = x.Field<string>("telefone"),
                            Email = x.Field<string>("email"),
                            IdApartamento = x.Field<int>("idApartamento")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Condomino condomino)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (condomino.Id == 0)
                        cmd.CommandText = @"INSERT INTO condomino
                                                (nome, cpf, rg, telefone, email, idApartamento)
                                            VALUES
                                                (?nome, ?cpf, ?rg, ?telefone, ?email, ?idApartamento);";
                    else
                        cmd.CommandText = @"UPDATE condomino 
                                                SET nome = ?nome,
                                                    cpf = ?cpf,
                                                    rg = ?rg,
                                                    telefone = ?telefone,
                                                    email = ?email,
                                                    idApartamento = ?idApartamento
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?nome", condomino.Nome);
                    cmd.Parameters.AddWithValue("?cpf", condomino.CPF);
                    cmd.Parameters.AddWithValue("?rg", condomino.RG);
                    cmd.Parameters.AddWithValue("?telefone", condomino.Telefone);
                    cmd.Parameters.AddWithValue("?email", condomino.Email);
                    cmd.Parameters.AddWithValue("?idApartamento", condomino.IdApartamento);
                    cmd.Parameters.AddWithValue("?id", condomino.Id);

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
                    cmd.CommandText = @"DELETE FROM condomino WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Condomino BuscarPorId(int condominoId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM condomino WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", condominoId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Condomino retorno = new Model.Condomino();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Nome = (string)reader["nome"];
                        retorno.CPF = (string)reader["cpf"];
                        retorno.RG = (string)reader["rg"];
                        retorno.Telefone = (string)reader["telefone"];
                        retorno.Email = (string)reader["email"];
                        retorno.IdApartamento = (int)reader["idApartamento"];
                    }

                    return retorno;
                }
            }
        }
    }
}
