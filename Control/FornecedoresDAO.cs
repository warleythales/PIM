using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Model.Enumerados;

namespace Control
{
    public class FornecedoresDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Fornecedores> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM fornecedores";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Fornecedores");

                        List<Model.Fornecedores> lstRetorno = ds.Tables["Fornecedores"].AsEnumerable().Select(x => new Model.Fornecedores
                        {
                            Id = x.Field<int>("id"),
                            Atividade = x.Field<string>("atividade"),
                            Telefone = x.Field<string>("telefone"),
                            CNPJ = x.Field<string>("cnpj"),
                            Nome = x.Field<string>("nome"),
                            IdCondominio = (int)x.Field<int>("idCondominio")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Fornecedores fornecedores)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (fornecedores.Id == 0)
                        cmd.CommandText = @"INSERT INTO fornecedores
                                                (atividade, telefone, cnpj, nome, idCondominio)
                                            VALUES
                                                (?atividade, ?telefone, ?cnpj, ?nome, ?idCondominio);";
                    else
                        cmd.CommandText = @"UPDATE fornecedores 
                                                SET atividade = ?atividade,
                                                    telefone = ?telefone,
                                                    cnpj = ?cnpj,
                                                    nome = ?nome,
                                                    idCondominio = ?idCondominio
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?atividade", fornecedores.Atividade);
                    cmd.Parameters.AddWithValue("?telefone", fornecedores.Telefone);
                    cmd.Parameters.AddWithValue("?cnpj", fornecedores.CNPJ);
                    cmd.Parameters.AddWithValue("?nome", fornecedores.Nome);
                    cmd.Parameters.AddWithValue("?idCondominio", fornecedores.IdCondominio);
                    cmd.Parameters.AddWithValue("?id", fornecedores.Id);

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
                    cmd.CommandText = @"DELETE FROM fornecedores WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Fornecedores BuscarPorId(int clienteId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM fornecedores WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", clienteId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Fornecedores retorno = new Model.Fornecedores();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["id"];
                        retorno.Atividade = (string)reader["atividade"];
                        retorno.Telefone = (string)reader["telefone"];
                        retorno.CNPJ = (string)reader["cnpj"];
                        retorno.Nome = (string)reader["nome"];
                        retorno.IdCondominio = (int)reader["idCondominio"];
                    }

                    return retorno;
                }
            }
        }
    }
}
