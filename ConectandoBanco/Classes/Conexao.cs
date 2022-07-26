using ConectandoBanco.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectandoBanco
{
    public  class Conexao
    {


        public static void InserirDados(string nome,int idade)
        {
            SqlConnection ponte = new SqlConnection();
            ponte.ConnectionString = @"Data Source=DESKTOP-6D9A4A3\SQLEXPRESS;" +
                "Initial Catalog=DB_DIEGO;" +
                "Integrated Security=SSPI";
            ponte.Open();


            string sqlinsert = "insert into pessoa (nome,idade) values (@nome,@idade)"; // <-- Podemos adicionar também usando a concatenação das variaveis dentro desse texto em vez de "@nome,@idade"
            SqlCommand cmd = new SqlCommand(sqlinsert, ponte);
            cmd.Parameters.AddWithValue("@nome",nome);
            cmd.Parameters.AddWithValue("@idade",idade);
            cmd.ExecuteNonQuery();
            ponte.Close();
        }

        public static void AtualizarDados(int id, string nome, int idade)
        {
            SqlConnection ponte = new SqlConnection();
            ponte.ConnectionString = @"Data Source=DESKTOP-6D9A4A3\SQLEXPRESS;" +
                "Initial Catalog=DB_DIEGO;" +
                "Integrated Security=SSPI";
            ponte.Open();

            string sqlupdate="update pessoa set nome="+nome+" and idade="+idade+" where id="+id;
            SqlCommand cmd = new SqlCommand(sqlupdate, ponte);
            cmd.ExecuteNonQuery();
            ponte.Close();
           

        }

        public static void DeletarDados(int id)
        {
            SqlConnection ponte = new SqlConnection();
            ponte.ConnectionString = @"Data Source=DESKTOP-6D9A4A3\SQLEXPRESS;" +
                "Initial Catalog=DB_DIEGO;" +
                "Integrated Security=SSPI";
            ponte.Open();

            string sqldelet = "delete from pessoa where id=" + id;
            SqlCommand cmd = new SqlCommand(sqldelet, ponte);
            cmd.ExecuteNonQuery();
            ponte.Close();

        }

        public List<cliente> Listar() // <-- diferente de "Void" você colocou que esse metodo ira retornar uma lista. Por esse motivo o metodo ira aparecer em erro porque você obrigatoriamente tem que retornar uma lista de objetos.
        {
            SqlConnection ponte = new SqlConnection();
            ponte.ConnectionString = @"Data Source=DESKTOP-6D9A4A3\SQLEXPRESS;" +
                "Initial Catalog=DB_DIEGO;" +
                "Integrated Security=SSPI";
            ponte.Open();

            string sqlselect = "select pessoa.id, pessoa.nome, pessoa.idade, cidades.nome from pessoa left join cidades on pessoa.cidade=cidades.id";

            SqlCommand cmd = new SqlCommand(sqlselect, ponte);

            SqlDataReader leitura = cmd.ExecuteReader();

            List<cliente> clientes = new List<cliente>();

            while (leitura.Read())
            {
                cliente clientetemporario = new cliente();

                clientetemporario.id = Convert.ToInt32(leitura["id"]);
                clientetemporario.nome = Convert.ToString(leitura["nome"]);
                clientetemporario.idade = Convert.ToInt32(leitura["idade"]);
                //clientetemporario.cidade = Convert.ToString(leitura["cidade"]);

                clientes.Add(clientetemporario);
            }
            return clientes;
        }


    }
}
