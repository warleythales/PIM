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
    public class FuncionarioDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Funcionario> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM funcionario";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Funcionario");

                        List<Model.Funcionario> lstRetorno = ds.Tables["Funcionario"].AsEnumerable().Select(x => new Model.Funcionario
                        {
                            Id = x.Field<int>("id"),
                            Nome = x.Field<string>("nome"),
                            CPF = x.Field<string>("cpf"),
                            RG = x.Field<string>("rg"),
                            Telefone = x.Field<string>("telefone"),
                            Email = x.Field<string>("email"),
                            Tipo = x.Field<string>("tipo"),
                            Conta = x.Field<string>("conta"),
                            PIS = x.Field<int>("pis"),
                            IdCondominio = x.Field<int>("IdCondominio")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Funcionario funcionario)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (funcionario.Id == 0)
                        cmd.CommandText = @"INSERT INTO funcionario
                                                (nome, cpf, rg, telefone, email, tipo, conta, pis, IdCondominio)
                                            VALUES
                                                (?nome, ?cpf, ?rg, ?telefone, ?email, ?tipo, ?conta, ?pis, ?IdCondominio);";
                    else
                        cmd.CommandText = @"UPDATE funcionario 
                                                SET nome = ?nome,
                                                    cpf = ?cpf,
                                                    rg = ?rg,
                                                    telefone = ?telefone,
                                                    email = ?email,
                                                    tipo = ?tipo,
                                                    conta = ?conta,
                                                    pis = ?pis,
                                                    IdCondominio = ?IdCondominio
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?nome", funcionario.Nome);
                    cmd.Parameters.AddWithValue("?cpf", funcionario.CPF);
                    cmd.Parameters.AddWithValue("?rg", funcionario.RG);
                    cmd.Parameters.AddWithValue("?telefone", funcionario.Telefone);
                    cmd.Parameters.AddWithValue("?email", funcionario.Email);
                    cmd.Parameters.AddWithValue("?tipo", funcionario.Tipo);
                    cmd.Parameters.AddWithValue("?conta", funcionario.Conta);
                    cmd.Parameters.AddWithValue("?pis", funcionario.PIS);
                    cmd.Parameters.AddWithValue("?IdCondominio", funcionario.IdCondominio);
                    cmd.Parameters.AddWithValue("?id", funcionario.Id);

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
                    cmd.CommandText = @"DELETE FROM funcionario WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Funcionario BuscarPorId(int funcionarioId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM funcionario WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", funcionarioId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Funcionario retorno = new Model.Funcionario();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Nome = (string)reader["nome"];
                        retorno.CPF = (string)reader["cpf"];
                        retorno.RG = (string)reader["rg"];
                        retorno.Telefone = (string)reader["telefone"];
                        retorno.Email = (string)reader["email"];
                        retorno.Tipo = (string)reader["tipo"];
                        retorno.Conta = (string)reader["conta"];
                        retorno.PIS = (int)reader["pis"];
                        retorno.IdCondominio = (int)reader["idCondominio"];
                    }

                    return retorno;
                }
            }
        }
    }
}
