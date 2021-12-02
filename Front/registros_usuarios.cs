using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atividade_DS.Conn;
using Atividade_DS.Classes;
using MySql.Data.MySqlClient;

namespace Atividade_DS.front_end
{
    public partial class registros_usuarios : Form {
        int contador, contar = 1;
        public registros_usuarios() {
            InitializeComponent();
        }
        private void registros_usuarios_Load(object sender, EventArgs e) {
            usuarios users = new usuarios();
            String query = "Select *from usarios";

            if (users.dados(query).Rows.Count > 0) {
                try {
                    contador = 0;
                    contar = 1;
                    edCodigo.Text = users.dados(query).Rows[contador]["usuarios_id"].ToString();
                    edNome.Text = users.dados(query).Rows[contador]["usuarios_nome"].ToString();
                    edLogin.Text = users.dados(query).Rows[contador]["usuarios_login"].ToString();
                    edRegistro.Text = contar.ToString() + " de " + users.dados(query).Rows.Count;
                }
                catch (MySqlException ex) {
                    throw ex;
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e) {
            usuarios users = new usuarios();
            String query = "Select *from usuarios";

            if (contador <= users.dados(query).Rows.Count - 1 && contador > 0) {
                try {
                    contador--;
                    contar--;
                    edCodigo.Text = users.dados(query).Rows[contador]["usuarios_id"].ToString();
                    edNome.Text = users.dados(query).Rows[contador]["usuarios_nome"].ToString();
                    edLogin.Text = users.dados(query).Rows[contador]["usuarios_login"].ToString();
                    edRegistro.Text = contar.ToString() + " de " + users.dados(query).Rows.Count;
                }
                catch (MySqlException ex) {
                    throw ex;
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e) {
            try {
                usuarios users = new usuarios();
                users.usuarios_id = Convert.ToInt32(edCodigo.Text);
                users.usuarios_nome = edNome.Text;
                users.usuarios_login = edLogin.Text;

                DialogResult resultado = MessageBox.Show("Confirma alteração deste Usuário ?", "Confirma Exclusão",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes) {
                    usuarios.alterarUsuarios(users);
                    MessageBox.Show(users.usuarios_nome + " Alterado com Sucesso");
                }
                else {
                    MessageBox.Show("Usuario Não Alterado");
                }


            }
            catch (MySqlException ex) {
                throw ex;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            try {
                usuarios users = new usuarios();
                users.usuarios_id = Convert.ToInt32(edCodigo.Text);
                users.usuarios_nome = edNome.Text;

                DialogResult resultado = MessageBox.Show("Confirma exclusão deste Funcionário ?", "Confirma Exclusão",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes) {
                    usuarios.excluirUsuarios(users);
                    MessageBox.Show(users.usuarios_nome + " Excluído com Sucesso");
                }
                else {
                    MessageBox.Show("Usuario Não Excluido");
                }
            }
            catch (MySqlException ex) {
                throw ex;
            }
        }

        private void btnProximo_Click(object sender, EventArgs e) {
            usuarios users = new usuarios();
            String query = "Select *from usuarios";
            if (contador < users.dados(query).Rows.Count - 1)
            {
                try
                {
                    contador++;
                    contar++;
                    edCodigo.Text = users.dados(query).Rows[contador]["usuarios_id"].ToString();
                    edNome.Text = users.dados(query).Rows[contador]["usuarios nome"].ToString();
                    edLogin.Text = users.dados(query).Rows[contador]["usuarios_login"].ToString();
                    edRegistro.Text = contar.ToString() + " de " + users.dados(query).Rows.Count;
                }
                catch (MySqlException ex)
                {
                    throw ex;
                }
            }
        }
    }
}
