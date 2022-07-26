using ConectandoBanco.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConectandoBanco
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                int escolha;
                do
                {

                    Console.WriteLine("\r\nDigite o numero da função que deseja executar:\r\n1- Inserir dados na tabela\r\n2- Atualizar os dados da tabela\r\n3- Deletar os dados da tabela\r\n4- Mostrar Tabela\r\n5- Encerrar programa");
                     escolha = int.Parse(Console.ReadLine());

                    if (escolha == 1)
                    {
                        Console.WriteLine("Digite o nome da pessoa a ser inserida");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Digite a idade");
                        int idade = int.Parse(Console.ReadLine());

                        Conexao.InserirDados(nome, idade);

                    }
                    else if (escolha == 2)
                    {
                        Console.WriteLine("digite o ID do usuario a ser alterado");
                        int id = int.Parse(Console.ReadLine());

                        Console.WriteLine("Digite o novo Nome");
                        string nome = Console.ReadLine();

                        Console.WriteLine("Digite a nova idade");
                        int idade = int.Parse(Console.ReadLine());

                        Conexao.AtualizarDados(id, nome, idade);

                    }
                    else if (escolha == 3)
                    {
                        Console.WriteLine("Digite o ID do usuario que deseja excluir");
                        int id = int.Parse(Console.ReadLine());

                        Conexao.DeletarDados(id);

                    }
                    else if (escolha == 4)
                    {
                        SqlConnection ponte = new SqlConnection();
                        ponte.ConnectionString = @"Data Source=DESKTOP-6D9A4A3\SQLEXPRESS;" +
                            "Initial Catalog=DB_DIEGO;" +
                            "Integrated Security=SSPI";
                        ponte.Open();

                        string sqlselect = "select*from pessoa";

                        SqlCommand cmd = new SqlCommand(sqlselect, ponte);

                        SqlDataReader ler = cmd.ExecuteReader();

                        
                     

                        while (ler.Read())
                        {
                            cliente dadosbanco = new cliente();
                            dadosbanco.id = Convert.ToInt32(ler["id"]);
                            dadosbanco.nome = Convert.ToString(ler["nome"]);
                            dadosbanco.idade = Convert.ToInt32(ler["idade"]);


                            Console.WriteLine("ID do usuario " + dadosbanco.id + "\r\nNome: " + dadosbanco.nome + "\r\nIdade: " + dadosbanco.idade + "\r\n");
                        }
                    }else if (escolha == 6)
                    {


                    }
                } while (escolha != 5);














                //try
                //{

                //    SqlConnection conexao = new SqlConnection();
                //    conexao.ConnectionString =
                //        @"Data Source=DESKTOP-D4OOTSF\SQLEXPRESS;" +
                //        "Initial Catalog=mercado;" +
                //        "Integrated Security=SSPI";
                //    conexao.Open();
                //    string sqlselect = "select*from treinador";
                //    SqlCommand cmd = new SqlCommand(sqlselect, conexao);

                //    SqlDataReader reader = cmd.ExecuteReader();
                //    while (reader.Read())
                //    {
                //        Treinador puxar = new Treinador();
                //        puxar.id = Convert.ToInt32(reader["id"]);
                //        puxar.treinador = reader["nome"].ToString(); // <-- tudo que vem do SQLServer vem como Object. então você deve convertelo ao receber.
                //        puxar.pokemon = Convert.ToInt32(reader["pokemon"]);

                //        Console.WriteLine("Usuario" + puxar.id + "," + puxar.treinador + "," + puxar.pokemon);
                //    }

                //    //                      Adicionando Dados no Banco de Dados

                //  string sqlinsert = "insert into treinador(nome) values (@nome)";
                //  SqlCommand cmd = new SqlCommand(sqlinsert, conexao);
                //  cmd.Parameters.AddWithValue("@nome", "teixeirinha");
                //  cmd.ExecuteNonQuery();

                //    //                                fim

                //    //                       Dando Update nos Dados da Base de dados

                //    //string sqlupdate = "update treinador set pokemon=3 where id=9";
                //    //SqlCommand cmd = new SqlCommand(sqlupdate, conexao);
                //    //cmd.ExecuteNonQuery();
                //    //                                fim

                //    //                    Deletando dados da tabela de dados

                //    //string sqldelete = "delete from treinador where id =9";
                //    //SqlCommand cmd = new SqlCommand(sqldelete, conexao);
                //    //cmd.ExecuteNonQuery();

                //    //                               fim

                //}
                //catch (Exception teste)
                //{
                //    Console.WriteLine("A conexão falhou, erro" + teste.Message);
                //}

                //                                     --X--



                //SqlConnection ponte = new SqlConnection();
                //ponte.ConnectionString = @"Data Source=DESKTOP-6D9A4A3\SQLEXPRESS;" +
                //    "Initial Catalog=DB_DIEGO;" +
                //    "Integrated Security=SSPI";
                //ponte.Open();

                //string sqlselect = "select*from pessoa";

                //SqlCommand cmd = new SqlCommand(sqlselect, ponte);

                //SqlDataReader ler = cmd.ExecuteReader();

                //while (ler.Read())
                //{
                //    cliente dadosbanco = new cliente();
                //    dadosbanco.id = Convert.ToInt32(ler["id"]);
                //    dadosbanco.nome = Convert.ToString(ler["nome"]);
                //    dadosbanco.cidade = Convert.ToInt32(ler["cidade"]);

                //    Console.WriteLine("ID do usuario " + dadosbanco.id + "\r\nNome: " + dadosbanco.nome + "\r\nCidade: " + dadosbanco.cidade);
                //}

                //                                 Inserindo Dados

                //string sqlinsert = "insert into pessoa (nome,idade) values (@nome,@idade)";
                //SqlCommand cmd = new SqlCommand(sqlinsert, ponte);
                //cmd.Parameters.AddWithValue("@nome", "Vanessa");
                //cmd.Parameters.AddWithValue("@idade", 98);
                //cmd.ExecuteNonQuery();



                //                                         Fim

                //                               Dando update no banco

                //string sqlupdate = "update pessoa set idade=10 where idade=98";
                //SqlCommand cmd = new SqlCommand(sqlupdate, ponte);
                //cmd.ExecuteNonQuery();

                //                                         Fim

            }
            catch (Exception erro)
            {
                Console.WriteLine("erro na conexão " + erro.Message);
            }
        }


    }
}
