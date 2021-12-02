using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Atividade_DS.Classes;

namespace Atividade_DS.front_end
{
    public partial class cad_usuarios : Form
    {
        public cad_usuarios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            usuarios usu = new usuarios();

            usu.usuarios_nome = edNome.Text;
            usu.usuarios_login = edLogin.Text;
            usu.usuarios_senha = edSenha.Text;

            usuarios.inserirUsuario(usu);

            MessageBox.Show("Usuário Cadastrado com sucesso");

            edNome.Text = "";
            edLogin.Text = "";
            edSenha.Text = "";
        }
    }
}
