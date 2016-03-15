using revures.model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace revures.conf
{
    class DB
    {
        // a instância da conexão
        private SQLiteConnection conn;

        // string statica com o nome da base de dados
        private static string DB_NAME = "revures.sqlite";

        // construtor
        public DB(){}
        
        // função para abrir a conexão
        public void openConnection()
        {
            try
            {
                conn = new SQLiteConnection("Data Source=" + DB_NAME + ";Version=3;");
                conn.Open();
            }
            catch (Exception e)
            {
                Console.Write("Erro ao conectar à base de dados\n");
                Console.Write(e.Message);
            }         
        }
        
        //  função para executar um comando sql
        public void executeQuery(string sql)
        {   
            SQLiteCommand command = new SQLiteCommand(sql, this.conn);
            command.ExecuteNonQuery();
        }
        
        // funcao para fechar a conexao
        public void closeConnection()
        {
            this.conn.Close();
        }

        public void testeSELECT()
        {
            string sql = "select * from users";
            SQLiteCommand command = new SQLiteCommand(sql, this.conn);
            SQLiteDataReader reader = command.ExecuteReader();

            List<User> users = new List<User>();

            while (reader.Read()){
                Console.WriteLine("username: " + reader["username"] + "\tpassword: " + reader["password"]);
            }
        }
       
    }
}
