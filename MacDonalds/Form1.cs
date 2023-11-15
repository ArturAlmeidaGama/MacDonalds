using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MacDonalds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CarregarDadosBanco();
        }

        private void CarregarDadosBanco()
        {
            string conexao = "server=localhost;database=dbMacDonalds;uid=root;pwd=etec";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter("select * from tbPedidoItem", conexaoMYSQL);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dgvList.DataSource = dt;

        }

        private void btnAlterarPedido_Click(object sender, EventArgs e)
        {
            string conexao = "server=localhost;database=dbMacDonalds;uid=root;pwd=etec";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();
            MySqlCommand comando = new MySqlCommand("update tbPedidoItem set vlProdutoItem=" + txtValor.Text + ", qtde=" + txtQuantidade.Text + " where idPedidoItem=" + txtId.Text, conexaoMYSQL);
            comando.ExecuteNonQuery();
            MessageBox.Show("Pedido alterado!!!");
            txtValor.Text = "";
            txtQuantidade.Text = "";
            txtId.Text = "";
            groupBox1.Visible = false;
            CarregarDadosBanco();
        }

        private void btnExcluirPedido_Click(object sender, EventArgs e)
        {
            DialogResult caixaMensagem = MessageBox.Show("Deseja exluir esse pedido?", "Alerta", MessageBoxButtons.YesNo);

            if (caixaMensagem == DialogResult.Yes)
            {
                string conexao = "server=localhost;database=dbMacDonalds;uid=root;pwd=etec";
                MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
                conexaoMYSQL.Open();
                MySqlCommand comando = new MySqlCommand("delete from tbPedidoItem where idPedidoItem=" + txtId.Text + ";", conexaoMYSQL);
                comando.ExecuteNonQuery();
                MessageBox.Show("Pedido excluído com sucesso!");
                txtValor.Text = "";
                txtQuantidade.Text = "";
                txtId.Text = "";
                groupBox1.Visible = false;
                CarregarDadosBanco();
            }
        }

        private void dgvList_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            txtId.Text = dgvList.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtValor.Text = dgvList.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtQuantidade.Text = dgvList.Rows[e.RowIndex].Cells[2].Value.ToString();
            groupBox1.Visible = true;
        }

        private void btnNovoPedido_Click(object sender, EventArgs e)
        {
            string conexao = "server=localhost;database=dbMacDonalds;uid=root;pwd=etec";
            MySqlConnection conexaoMYSQL = new MySqlConnection(conexao);
            conexaoMYSQL.Open();
            MySqlCommand comando = new MySqlCommand("insert into tbPedidoItem (vlProdutoItem,qtde) values (" + txtValor.Text + "," + txtQuantidade.Text + ");", conexaoMYSQL);
            comando.ExecuteNonQuery();
            MessageBox.Show("Novo pedido realizado com sucesso!!!");
            txtValor.Text = "";
            txtQuantidade.Text = "";
            txtId.Text = "";
            groupBox1.Visible = false;
            CarregarDadosBanco();
        }
    }
}
