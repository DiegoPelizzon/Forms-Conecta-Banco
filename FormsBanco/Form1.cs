using ConectandoBanco;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsBanco
{
    public partial class Form1 : Form
    {
      

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            Conexao conecta = new Conexao();
            var datagrid=conecta.Listar();

            this.dataGridView1.DataSource = datagrid; // <-- Podemos também atribuir para receber diretamente "conecta.Listar()"
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text =="" || textBox2.Text =="")
            {
                MessageBox.Show("Favor preencher todos os campos");
            }
            else
            {

                string nome = Convert.ToString(textBox1.Text);

                int idade = Convert.ToInt32(textBox2.Text);

                Conexao.InserirDados(nome, idade);

                Conexao conecta = new Conexao();
                var datagrid = conecta.Listar();            // <-- Criei isso no final para que atualize a tabela após clicar no botão
                this.dataGridView1.DataSource = datagrid;

                MessageBox.Show("Cliente Cadastrado");
            }
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos");
            }
            else
            {
                int id = Convert.ToInt32(textBox3.Text);

                Conexao.DeletarDados(id);

                Conexao conecta = new Conexao();
                var datagrid = conecta.Listar();            // <-- Criei isso no final para que atualize a tabela após clicar no botão
                this.dataGridView1.DataSource = datagrid;

                MessageBox.Show("Cliente Deletado");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox4.Text =="" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Favor preencher todos os campos");
            }
            else
            {

                int id = Convert.ToInt32(textBox4.Text);

                string nome = Convert.ToString(textBox5.Text);

                int idade = Convert.ToInt32(textBox6.Text);

                Conexao.AtualizarDados(id, nome, idade);

                Conexao conecta = new Conexao();
                var datagrid = conecta.Listar();            // <-- Criei isso no final para que atualize a tabela após clicar no botão
                this.dataGridView1.DataSource = datagrid;

                MessageBox.Show("Cliente Atualizado");
            }
            
        }
    }
}
