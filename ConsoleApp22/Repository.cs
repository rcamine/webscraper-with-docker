using System;
using System.Data.SqlClient;
using Dapper;

namespace ConsoleApp22
{
    public class Repository : IRepository
    {
        public string ConnectionString { get; set; }

        public Repository()
        {
            ConnectionString = @"yourconnstring";
        }

        public void EscreverTeste(string mensagem)
        {
            using var sqlConn = new SqlConnection(ConnectionString);
            sqlConn.Query("insert into DockerTests (data, mensagem, id) values (@data, @mensagem, @id)", 
                new
                {
                    data = DateTime.Now,
                    mensagem = mensagem,
                    id = Guid.NewGuid()
                });
        }
    }
}