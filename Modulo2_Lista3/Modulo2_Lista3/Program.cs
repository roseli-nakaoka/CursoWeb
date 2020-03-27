using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using Dados;
using Interface;
using Negocio;


namespace Modulo2_Lista3

{   
    public class ProgramaPrincipal
    {
        // Declaração das variáveis globais

        public static List<ILivro> livros = new List<ILivro>();
        public static List<IPessoa> pessoas = new List<IPessoa>();
        public static List<IEmprestimo> emprestimos = new List<IEmprestimo>();

        // Program Principal

        static void Main()
        {
            try
            {
                MenuPrincipal();
            }

            catch (Exception e)
            {
                Console.WriteLine("\nErro encontrado!\nMESSAGE: " + e.Message + "\nTASK: " + e.StackTrace);

            }
        }


        // Mostra o Menu Principal

        static void MenuPrincipal()
        {
            StringBuilder menu = new StringBuilder();
            menu.Append("\nAUTENTICAÇÃO\n");
            menu.Append("\nLivro");
            menu.Append("\n     11 - Cadastrar Livro");
            menu.Append("\n     12 - Pesquisar Livro");
            menu.Append("\n     13 - Excluir Livro");
            menu.Append("\nPessoa");
            menu.Append("\n     21 - Cadastrar Pessoa");
            menu.Append("\n     22 - Pesquisar Pessoa");
            menu.Append("\n     23 - Excluir Pessoa");
            menu.Append("\n3 - Alugar Livro");
            menu.Append("\n4 - Devolver Livro");
            menu.Append("\n5 - Sair");
            int opt = -1;

            while (opt != 5)
            {
                Console.WriteLine(menu);
                Console.Write("Digite a opção desejada: ");
                opt = Int32.Parse(Console.ReadLine());
                
                switch (opt)
                {
                    case 11:
                        CadastraLivro();
                        break;
                    case 12:
                        PesquisaLivro();
                        break;
                    case 13:
                        ExcluiLivro();
                        break;
                    case 21:
                        CadastraUsuario();
                        break;
                    case 22:
                        PesquisaUsuario();
                        break;
                    case 23:
                        ExcluiUsuario();
                        break;
                    case 3:
                        EmprestaLivros();
                        break;
                    case 4:
                        DevolveLivros();
                        break;
                    case 5:
                        Console.WriteLine("Sistema Encerrado");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida! Digite Novamente");
                        continue;
                }

            }

        }

        // Método para Cadastrar o Livro
        private static void CadastraLivro()
        {
            string titulo, autor;
            string prompt1a = "Entre com o título do livro: ";
            Console.Write(prompt1a);
            var titulo_inp = Console.ReadLine();
            titulo = ValidaInputStr(titulo_inp, prompt1a, "Titulo inválido. Tente Novamente.");

            string prompt1b = "Entre com o autor do livro: ";
            Console.Write(prompt1b);
            var autor_inp = Console.ReadLine();
            autor = ValidaInputStr(autor_inp, prompt1b, "Autor inválido. Tente Novamente.");

            Biblioteca.ValidarLivro(titulo, autor, livros, out bool res1);
       
            if (res1)
            {
                Guid tombo = Guid.NewGuid();
                ILivro livro = new Livro(tombo.ToString(), titulo, autor);
                livros.Add(livro);
                Console.WriteLine("Cadastro Realizado com Sucesso!");
                Console.WriteLine($"{livro.GetTombo()} { livro.GetTitulo()} {livro.GetAutor()}");

            }
            else
                Console.WriteLine("Cadastro Inválido. Tente novamente.");

        }

        // Metodo para Pesquisar Livro
        private static ILivro PesquisaLivro()
        {
            
            string prompt3b = "Tombo do Livro: ";
            Console.Write(prompt3b);
            var id_inp = Console.ReadLine();
            string id = ValidaInputStr(id_inp, prompt3b, "Tombo inválido. Tente Novamente.");
            ILivro livro = null;

            if (livros != null)
            {
                livro = Biblioteca.ProcurarLivro(id, livros);

                if (livro != null)
                {
                    Console.WriteLine("Livro Encontrado: ");
                    Console.WriteLine($"Tombo: {livro.GetTombo()} Titulo: {livro.GetTitulo()} " +
                                        $"Autor: {livro.GetAutor()}");
                }
                else
                    Console.WriteLine("Livro não cadastrado!");

            }
            else
                Console.WriteLine("Livro não está cadastrado!");

            return livro;

        }

        // Metodo para Remover Livro
        private static void ExcluiLivro()
        {
            ILivro livro = PesquisaLivro();

            if (livro != null)
            {
                IEmprestimo emprestimo = Biblioteca.ProcurarEmprestimoLivro(livro.GetTombo(), emprestimos);

                if (emprestimo == null)
                {
                    livro.DeletarLivro(livro, livros);
                    Console.WriteLine("Livro removido com sucesso");
                }
                else
                    Console.WriteLine("Livro não pode ser removido. Está pendente na lista de empréstimos");
            }

        }

        // Método para Cadastrar o Usuario
        private static void CadastraUsuario()
        {
            int cpf;
            string nome, email;

            string prompt2a = "CPF do usuário: ";
            Console.Write(prompt2a);
            var cpf_inp = Console.ReadLine();
            cpf = ValidaInputInt(cpf_inp, prompt2a, "CPF inválido. Tente Novamente.");

            string prompt2b = "Nome do usuário: ";
            Console.Write(prompt2b);
            var nome_inp = Console.ReadLine();
            nome = ValidaInputStr(nome_inp, prompt2b, "Nome inválido. Tente Novamente.");

            string prompt2c = "E-mail do usuário: ";
            Console.Write(prompt2c);
            var email_inp = Console.ReadLine();
            email = ValidaInputStr(email_inp, prompt2c, "Email inválido. Tente Novamente.");

            Biblioteca.ValidarPessoa(cpf, pessoas, out bool res2);
            Console.WriteLine(res2);
            if (res2)
            {
                IPessoa pessoa = new Pessoa(cpf, nome, email);
                pessoas.Add(pessoa);
                Console.WriteLine("Cadastro Realizado com Sucesso!");
                Console.WriteLine($"{pessoa.GetCpf()} { pessoa.GetNome()} {pessoa.GetEmail()}");
            }
            else
                Console.WriteLine("Cadastro Inválido. Favor tentar novamente.");

        }

        // Metodo para Pesquisar Usuario
        private static IPessoa PesquisaUsuario()
        {
            int cpf;
            IPessoa user_emp = null;

            string prompt3a = "CPF do usuário: ";
            Console.Write(prompt3a);
            var cpf_inp3 = Console.ReadLine();
            cpf = ValidaInputInt(cpf_inp3, prompt3a, "CPF inválido. Tente Novamente.");
            
            if (pessoas != null)
            {
                user_emp = Biblioteca.ProcurarPessoa(cpf, pessoas);

                if (user_emp != null)
                {
                    Console.WriteLine("Usuário Encontrado: ");
                    Console.WriteLine($"CPF: {user_emp.GetCpf()} Nome: {user_emp.GetNome()} " +
                                      $"Email: {user_emp.GetEmail()}");
                }
                    
                else
                    Console.WriteLine("Usuário não cadastrado!");
                
            }
            else         
                Console.WriteLine("Usuário não cadastrado!");

            return user_emp;
        
        }

        // Metodo para Remover Usuario
        private static void ExcluiUsuario()
        {
            IPessoa usuario = PesquisaUsuario();

            if (usuario != null)
            {
                IEmprestimo emprestimo = Biblioteca.ProcurarEmprestimoUsuario(usuario.GetCpf(), emprestimos);

                if (emprestimo == null)
                {
                    usuario.DeletarPessoa(usuario, pessoas);
                    Console.WriteLine("Usuário removido com sucesso.");
                }
                else
                    Console.WriteLine("Usuário não pode ser removido, tem pendências de emprestimo.");
                
            }    
               
        }

        // Metodo para Emprestar Livros
        private static void EmprestaLivros()
        {
            bool userOk = false;
            bool livroOk = false;
            IPessoa user_emp = null;
            ILivro livro_emp = null;

            while (!userOk)
            {
                string prompt3a = "CPF do usuário: ";
                Console.Write(prompt3a);
                var cpf_inp3 = Console.ReadLine();
                int cpf = ValidaInputInt(cpf_inp3, prompt3a, "CPF inválido. Tente Novamente.");

                if (pessoas != null)
                {
                    user_emp = Biblioteca.ProcurarPessoa(cpf, pessoas);

                    if (user_emp != null)
                    {
                        Console.WriteLine($"CPF: {user_emp.GetCpf()} Nome: {user_emp.GetNome()} Email: {user_emp.GetEmail()}");
                        userOk = true;
                    }
                    else
                        Console.WriteLine("Usuário não cadastrado!");
                }
                else
                    Console.WriteLine("Usuário não cadastrado!");
                    
            }

            while (!livroOk)
            {
                string prompt3b = "Tombo do Livro: ";
                Console.Write(prompt3b);
                var tombo_inp = Console.ReadLine();
                string tombo = ValidaInputStr(tombo_inp, prompt3b, "Tombo inválido. Tente Novamente.");


                

                if (livros != null)
                {
                    livro_emp = Biblioteca.ProcurarLivro(tombo, livros);

                    if (livro_emp != null)
                    {
                        Console.WriteLine($"Tombo: {livro_emp.GetTombo()} Titulo: {livro_emp.GetTitulo()} " +
                                            $"Autor: {livro_emp.GetAutor()}");
                        livroOk = true;
                    }
                    else
                        Console.WriteLine("Livro não cadastrado!");
                }
                else
                    Console.WriteLine("Livro não cadastrado!");
            }

            Guid id_emp = Guid.NewGuid();
            DateTime data_emp = DateTime.Now;
            var culture = new CultureInfo("pt-BR");
            IEmprestimo emprestimo = new Emprestimo(id_emp.ToString(), data_emp.ToString("G", culture), livro_emp, user_emp);
            Biblioteca.Emprestar(emprestimo, emprestimos);
            Console.WriteLine("Empréstimo Realizado com Sucesso!");
            Console.WriteLine($" ID emprestimo: {emprestimo.GetId()} Data: {emprestimo.GetData()} " +
                              $"Pessoa: { emprestimo.GetPessoa().GetNome()} Livro: {emprestimo.GetLivro().GetTitulo()}");

        }

        // Metodo para Devolver Livros

        private static void DevolveLivros()
        {
            string idemp;
            string prompt4a = "ID do Empréstimo: ";
            Console.Write(prompt4a);
            var idemp_inp = Console.ReadLine();
            idemp = ValidaInputStr(idemp_inp, prompt4a, "ID inválido. Tente Novamente.");

            if (emprestimos != null)
            {
                IEmprestimo emprestado = Biblioteca.ProcurarEmprestimo(idemp, emprestimos);

                if (emprestado != null)
                    Console.WriteLine($"Id: {emprestado.GetId()} Data: {emprestado.GetData()} " +
                                          $"Pessoa: {emprestado.GetPessoa().GetNome()} Livro: {emprestado.GetLivro().GetTitulo()} ");
                else
                {
                    Console.WriteLine("Empréstimo não cadastrado!");
                    return;
                }

            }

            else
            {
                Console.WriteLine("Empréstimo não cadastrado!");
                return;
            }
                
            bool res_devolve = Biblioteca.Devolver(idemp, emprestimos);
            if (res_devolve)
                Console.WriteLine("Devolução realizada com sucesso!");
            else
                Console.WriteLine("Devolução não foi realizada!");
        }

        
        // Metodo para Validar Input do tipo String

        private static string ValidaInputStr(dynamic inp, string prompt, string msg)
        {
            while (inp.GetType() != typeof(string) || string.IsNullOrEmpty(inp))
            {
                
                Console.WriteLine(msg);
                Console.Write(prompt);
                inp = Console.ReadLine();

            }
            return inp.ToString();

        }

        // Metodo para Validar Input do tipo Inteiro

        private static int ValidaInputInt(dynamic inp_var, string prompt, string msg)
        {
            bool converte = false;
            int inp_int = 0;
            
            while (!converte)
            {
                converte = int.TryParse(inp_var, out inp_int);

                if (!converte)
                {
                    Console.WriteLine(msg);
                    Console.Write(prompt);
                    inp_var = Console.ReadLine();

                }
 
            }
            return inp_int;
        }
    }
}

