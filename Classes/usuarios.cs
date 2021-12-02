using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Atividade_DS.Conn;
using MySql.Data.MySqlClient;

namespace Atividade_DS.Classes {
    class usuarios {
        public int usuarios_id;
        public string usuarios_nome;
        public string usuarios_login;
        public string usuarios_senha;
        public DataTable dados(string query) {
            MySqlConnection conn = conexao.obterConexao();

            //string query - "Select *from funcionarios";
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try {
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable dtList = new DataTable();
                adp.Fill(dtList);

                //fecha a conexão
                conexao.fecharConexao();

                return dtList;
            }
            catch (Exception e) {
                throw e;
            }
        }

        public static void inserirUsuario(usuarios usuario)
        {
            try
            {
                MySqlConnection conn = conexao.obterConexao();
                String query = "INSERT INTO usuarios VALUES (null, @NOME, @LOGIN, @SENHA)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@NOME", usuario.usuarios_nome);
                cmd.Parameters.AddWithValue("@LOGIN", usuario.usuarios_login);
                cmd.Parameters.AddWithValue("@SENHA", usuario.usuarios_senha);

                cmd.ExecuteNonQuery();

                //fecha a conexão
                conexao.fecharConexao();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

        }

        public static void excluirUsuarios(usuarios usuario)
        {
            try
            {
                MySqlConnection conn = conexao.obterConexao();
                String query = "DELETE FROM usuarios WHERE usuarios_id = @ID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", usuario.usuarios_id);

                cmd.ExecuteNonQuery();

                //fecha a conexão
                conexao.fecharConexao();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        public static void alterarUsuarios(usuarios usuario)
        {
            try
            {
                MySqlConnection conn = conexao.obterConexao();
                String query = "UPDATE usuarios SET usuarios_nome = @NOME, usuarios_login = @LOGIN WHERE usuarios_id = @ID";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", usuario.usuarios_id);
                cmd.Parameters.AddWithValue("@NOME", usuario.usuarios_nome);
                cmd.Parameters.AddWithValue("@LOGIN", usuario.usuarios_login);

                cmd.ExecuteNonQuery();

                //fecha a conexão
                conexao.fecharConexao();
            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
    }
}
