using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Control
{
    class ApartamentoController
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
                    cmd.CommandText = @"SELECT * FROM classificacao";

                    using (MySqlDataAdapter da = new MySqlDataAdapter())
                    {
                        da.SelectCommand = cmd;

                        DataSet ds = new DataSet();
                        da.Fill(ds, "Apartamento");

                        List<Model.Apartamento> lstRetorno = ds.Tables["Apartamento"].AsEnumerable().Select(x => new Model.Apartamento
                        {
                            Id = x.Field<int>("id"),
                            Numero = x.Field<int>("numero")
                        }).ToList();

                        return lstRetorno;
                    }
                }
            }
        }
    }
}
