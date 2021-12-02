using Atividade_DS.Conn;
using Atividade_DS.front_end;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atividade_DS {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e) {
            cad_usuarios newForm = new cad_usuarios();
            newForm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e) {
            registros_usuarios newForm = new registros_usuarios();
            newForm.Show();
        }
    }
}
