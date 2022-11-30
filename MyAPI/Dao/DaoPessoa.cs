using Microsoft.Data.SqlClient;
using MyAPI.Model;
using System.Collections.Generic;
using System.Data;

namespace MyAPI.Dao
{
    public class DaoPessoa
    {
        string conexao = @"Data Source=WINAPRKSPTBC7JC\RODRIGO;Initial Catalog=MY_API;Integrated Security=True";

        public List<Pessoa> GetPessoas()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("GetPessoas", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if(reader != null)
                        {
                            while (reader.Read())
                            {
                                var pessoa = new Pessoa();
                                pessoa.Nome = reader["NOME"].ToString();
                                pessoa.Email = reader["EMAIL"].ToString();
                                pessoas.Add(pessoa);
                            }
                        }
                    }
                }
            }
           return pessoas;
        }

        public void InserirPessoa(Pessoa pessoa)
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            using (SqlConnection conn = new SqlConnection(conexao))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PostPessoa", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOME", pessoa.Nome);
                    cmd.Parameters.AddWithValue("@EMAIL", pessoa.Email);
                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}
