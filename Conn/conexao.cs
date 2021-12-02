using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_DS.Conn
{
    class conexao {
        // representa a conexão com o banco
        private static MySqlConnection conn = null;

        // método que permite obter a conexão
        public static MySqlConnection obterConexao() {
            conn = new MySqlConnection("Server=localhost;Database=cadastro_mysql2;Uid=root;Pwd=;");
            try {
                // abre a conexão e a devolve ao chamador do método
                conn.Open();
            }
            catch (MySqlException e) {
                conn = null;
                MessageBox.Show("Não foi possível estabelecer conexão");
            }
            return conn;
        }
        public static void fecharConexao()
        {
            if (conn != null) 
            {
                conn.Close();
            }
        }
    }
}
