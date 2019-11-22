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
    public class CondominioDAO
    {
        private static string strConection = ConfigurationManager.AppSettings["connection"].ToString();

        public static List<Model.Condominio> Listar()
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM condominio";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Condominio");

                        List<Model.Condominio> lstRetorno = ds.Tables["Condominio"].AsEnumerable().Select(x => new Model.Condominio
                        {
                            Id = x.Field<int>("id"),
                            Nome = x.Field<string>("nome"),
                            CNPJ = x.Field<string>("cnpj"),
                            Endereco = x.Field<string>("endereco")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }

        public static void Salvar(Model.Condominio condominio)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;

                    if (condominio.Id == 0)
                        cmd.CommandText = @"INSERT INTO condominio
                                                (nome, cnpj, endereco)
                                            VALUES
                                                (?nome, ?cnpj, ?endereco);";
                    else
                        cmd.CommandText = @"UPDATE condominio 
                                                SET nome = ?nome,
                                                    cnpj = ?cnpj,
                                                    endereco = ?endereco
                                            WHERE id = ?id;";

                    cmd.Parameters.AddWithValue("?nome", condominio.Nome);
                    cmd.Parameters.AddWithValue("?cnpj", condominio.CNPJ);
                    cmd.Parameters.AddWithValue("?endereco", condominio.Endereco);                    
                    cmd.Parameters.AddWithValue("?id", condominio.Id);

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
                    cmd.CommandText = @"DELETE FROM condominio WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static Model.Condominio BuscarPorId(int condominioId)
        {
            using (MySqlConnection conn = new MySqlConnection(strConection))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = @"SELECT * FROM condominio WHERE id = ?id";
                    cmd.Parameters.AddWithValue("?id", condominioId);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    Model.Condominio retorno = new Model.Condominio();

                    while (reader.Read())
                    {
                        retorno.Id = (int)reader["Id"];
                        retorno.Nome = (string)reader["nome"];
                        retorno.CNPJ = (string)reader["cnpj"];
                        retorno.Endereco = (string)reader["endereco"];                        
                    }

                    return retorno;
                }
            }
        }
    }
}
